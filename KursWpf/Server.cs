using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using KursWpf.Games;

namespace KursWpf
{
    public class Server
    {
        public string Ip { get; private set; }
        public string HostName { get; private set; }
        public bool _serverWork = false;

        public List<GameServer> Games { get; set; }
        public List<Account> Accounts { get; set; }

        private Queue<Account> QueueActiveAccount;

        public delegate void PrintWorkProcess(string operation);
        private PrintWorkProcess WriteLog;
        public Func<string, bool> QuestionOutput;


        public void SetWorkerM(PrintWorkProcess worker) 
        {
            WriteLog += worker;
        }


        public Server() 
        {
            Ip = ServerConfig.Ip;
            QueueActiveAccount = new Queue<Account>();
        }

        public void SaveLog(string action)
        {
            if (WriteLog != null && ServerConfig.LogActivate)
            {
                WriteLog(action);
            }

        }

        private void SelectActiveAccounts()
        {
            SaveLog("Добавление игроков со статусом онлайн в очередь");

            foreach (Gamer account in Accounts)
            {
                if(account.GamerStatus == KursWpf.Status.Online)
                    QueueActiveAccount.Enqueue(account);
            }
        }


        private void SelectGame()
        {
            SaveLog("Распределение игроков в очереди по играм");

            if (QueueActiveAccount.Count != 0)
            {
                while (QueueActiveAccount.Count != 0 && Games.Count != 0) {
                    Account gamer = QueueActiveAccount.Dequeue();
                    Games[ServerEmulator.GetRandomIndxGame(Games.Count)].AddGamer(gamer);
                }

                foreach (var game in Games) {
                    game.GetCountPlayersFormat();
                }
                Games.Sort();
            }         
        }



        private void LoadGames() {

            SaveLog("Загрузка игр");

            Games = new List<GameServer>
            {
                new Chess(),
                new WOW(),
                new CSGO(),
                new PUBG(),
                new Dota2(),
                new Overwatch()
            };
            //Games.Sort();

          
        }

        private void LoadAccounts() {
            // DB
            SaveLog("Загрузка пользователей");

            Accounts = new List<Account>
            {
                new Gamer(0, "Milena", ServerEmulator.GetRandomPassHash()),
                new Gamer(1, "Dima", ServerEmulator.GetRandomPassHash()),
                new Gamer(2, "darkness", ServerEmulator.GetRandomPassHash()),
                new Gamer(3, "Viktor", ServerEmulator.GetRandomPassHash()),
                new Gamer(4, "IronMan", ServerEmulator.GetRandomPassHash()),
                new Gamer(5, "Rabbit", ServerEmulator.GetRandomPassHash()),
                new Gamer(6, "Samurai", ServerEmulator.GetRandomPassHash()),
                new Gamer(7, "Fox", ServerEmulator.GetRandomPassHash()),
                new Gamer(8, "Dog12", ServerEmulator.GetRandomPassHash()),
                new Gamer(9, "Stark", ServerEmulator.GetRandomPassHash()),
                new Gamer(10, "Antoni", ServerEmulator.GetRandomPassHash()),
                new Gamer(11, "Halk", ServerEmulator.GetRandomPassHash()),
                new Gamer(12, "Marshmallow", ServerEmulator.GetRandomPassHash()),
                new Gamer(13, "Nagibator228", ServerEmulator.GetRandomPassHash()),
                new Gamer(14, "volk", ServerEmulator.GetRandomPassHash()),
                new Gamer(15, "zoro", ServerEmulator.GetRandomPassHash()),
                new Gamer(16, "stalker", ServerEmulator.GetRandomPassHash()),
                new Gamer(17, "Rock123", ServerEmulator.GetRandomPassHash()),
                new Gamer(18, "Linda", ServerEmulator.GetRandomPassHash()),
                new Gamer(19, "Sniper", ServerEmulator.GetRandomPassHash()),
                new Gamer(20, "Viper", ServerEmulator.GetRandomPassHash()),
                new Gamer(21, "mistic", ServerEmulator.GetRandomPassHash()),
            };

            
        }

        

        public void Start()
        {
            SaveLog("Запуск игрового сервера");

            if (!_serverWork) {
                _serverWork = true;

                if (File.Exists("sessions.dat") 
                    && QuestionOutput != null 
                    && QuestionOutput("Найдена сохраненная сессия!\r\n Хотите её восстановить?"))
                {
                    DeserializeSessionsGames();

                    return;
                }


                // Load games and players
                // Start
                LoadGames();
                LoadAccounts();

                ServerEmulator.GetRandomStatus(Accounts);

                SelectActiveAccounts();
                SelectGame();

                StartGame();
            }
        }

        public void StartGame()
        {
            foreach (var game in Games)
            {
                game.CreateSessions();
            }
        }

        //public void Restart();

        public void Stop(bool saveSessions = false) {

            SaveLog("Выключение игрового сервера");

            if (saveSessions)
            {
                SerializeSessionsGames();
            }


            _serverWork = false;
        }

        //public void GetListGames() {
        //    Console.WriteLine();
        //    Console.WriteLine("Игры установленные на сервере:");
        //    foreach (var game in Games) {
        //        Console.WriteLine(game.Name);
        //    }

        //    Console.WriteLine();
        //}


        // TODO: Доработать метоы сериализации

        public void SerializeSessionsGames()
        {
            

            BinaryFormatter formatter = new BinaryFormatter();
            

            using (FileStream fs = new FileStream("sessions.dat", FileMode.OpenOrCreate)) {
                formatter.Serialize(fs, Games);

                //Console.WriteLine("Объект сериализован");
            }

        }

        public void DeserializeSessionsGames()
        {
            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream fs = new FileStream("sessions.dat", FileMode.OpenOrCreate)) {
                Games = (List<GameServer>)formatter.Deserialize(fs);

                //QueueActiveAccount = Games.Select(game => game._listGamers.Select(gamer => gamer)).AsQueryable<Account>();

                foreach (var game in Games)
                {
                    foreach (var gamer in game._listGamers)
                    {
                        QueueActiveAccount.Enqueue(gamer);
                    }
                }

                LoadAccounts();

                foreach (var account in Accounts)
                {
                    foreach (var accountActive in QueueActiveAccount)
                    {
                        if (account.Id == accountActive.Id)
                        {
                            ((Gamer)account).GamerStatus = KursWpf.Status.Online;
                            break;
                        }
                    }
                }

                //Console.WriteLine("Объект десериализован");

            }
        }


        public string Status() {
            //var gc = GC.GetTotalMemory(false);
            return (GC.GetTotalMemory(false) / (int)Math.Pow(1024, 2) + " MB");
            //_serverWork ? "Сервер запущен" : "Сервер выключен";

        }

    }
}
