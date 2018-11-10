using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursWpf.Games
{
    public abstract class GameServer : IComparable<GameServer>{

        public string Name { get; set; }
        public string ImgGame { get; set; }
        //public string TypeGame { get; set; } // ENUM 
        public string ShortName { get; set; }
        public int CountGamers { get; set; }
        public string CountGamersF { get; set; }
        protected byte MaxGamersSession { get; set; }
        protected string Description { get; set; }

        public List<Account> _listGamers;
        private List<GameSession> GameSessions;

        public GameServer()
        {
            _listGamers = new List<Account>();
        }

        public int CompareTo(GameServer other)
        {
            if (CountGamers > other.CountGamers) return -1;
            else if (CountGamers < other.CountGamers) return 1;
            else return 0;
        }


        // ....
        protected void CreateSessions()
        {
            if (GameSessions == null)
            {
                GameSessions = new List<GameSession>();
            }

            foreach (var gamer in _listGamers)
            {
                if (GameSessions.Count == 0)
                {
                    //GameSession newSession = new GameSession();
                }
            }


        }

        public void GetCountPlayersFormat()
        {
            CountGamers = _listGamers.Count;
            int count = CountGamers;
            int lastdigit = Int32.Parse(count.ToString().Last().ToString());

            switch (lastdigit)
            {
                case 1:
                    CountGamersF = count + " игрок онлайн";
                    break;
                case 2:
                case 3:
                case 4:
                    CountGamersF = count + " игрока онлайн";
                    break;
                default:
                    CountGamersF = count + " игроков онлайн";
                    break;
            }
        }

        public void AddGamer(Account account)
        {
            _listGamers.Add(account);
        }

        public override string ToString()
        {
            return Name;
        }


        //public virtual string GetInfo()
        //{
            
        //}


    }
}
