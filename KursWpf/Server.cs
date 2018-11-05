﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KursWpf.Games;

namespace KursWpf
{
    public class Server
    {
        public string Ip { get; private set; }
        public string HostName { get; private set; }
        private bool _serverWork = false;

        public List<GameServer> Games { get; set; }
        public List<Account> Accounts { get; set; }

        public delegate void PrintWorkProcess(string operation);
        private PrintWorkProcess WriteLog;

        public Server() {
            Ip = ServerConfig.Ip;

            LoadGames();
            LoadAccounts();
        }

        public void SetWorkerM(PrintWorkProcess worker) {
            WriteLog += worker;
        }

        private void LoadGames() {
            Games = new List<GameServer>
            {
                new Chess(),
                //new SeaBattle(),
                new CSGO(),
                new PUBG(),
                new Dota2()
            };
        }

        private void LoadAccounts() {
            // DB
            Accounts = new List<Account>
            {
                new Gamer("Milena", ServerEmulator.GetRandomPassHash()),
                new Gamer("Dima", ServerEmulator.GetRandomPassHash()),
                new Gamer("darkness", ServerEmulator.GetRandomPassHash()),
                new Gamer("Viktor", ServerEmulator.GetRandomPassHash()),
                new Gamer("IronMan", ServerEmulator.GetRandomPassHash()),
                new Gamer("Rabbit", ServerEmulator.GetRandomPassHash()),
                new Gamer("Samurai", ServerEmulator.GetRandomPassHash()),
                new Gamer("Fox", ServerEmulator.GetRandomPassHash()),
                new Gamer("Dog12", ServerEmulator.GetRandomPassHash()),
                new Gamer("Stark", ServerEmulator.GetRandomPassHash()),
                new Gamer("Antoni", ServerEmulator.GetRandomPassHash()),
                new Gamer("Halk", ServerEmulator.GetRandomPassHash()),
                new Gamer("Marshmallow", ServerEmulator.GetRandomPassHash()),
                new Gamer("Nagibator228", ServerEmulator.GetRandomPassHash()),
                new Gamer("volk", ServerEmulator.GetRandomPassHash()),
                new Gamer("zoro", ServerEmulator.GetRandomPassHash()),
                new Gamer("stalker", ServerEmulator.GetRandomPassHash()),
                new Gamer("Rock123", ServerEmulator.GetRandomPassHash()),
                new Gamer("Linda", ServerEmulator.GetRandomPassHash()),
                new Gamer("Sniper", ServerEmulator.GetRandomPassHash()),
                new Gamer("Viper", ServerEmulator.GetRandomPassHash()),
                new Gamer("mistic", ServerEmulator.GetRandomPassHash()),
            };

            ServerEmulator.GetRandomStatus(Accounts);
        }

        public void Start() {
            _serverWork = true;
        }

        //public void Restart();

        public void Stop() {
            _serverWork = false;
        }

        public void GetListGames() {
            Console.WriteLine();
            Console.WriteLine("Игры установленные на сервере:");
            foreach (var game in Games) {
                Console.WriteLine(game.Name);
            }

            Console.WriteLine();
        }


        public virtual string Status() {
            //var gc = GC.GetTotalMemory(false);
            return (GC.GetTotalMemory(false) / (int)Math.Pow(1024, 2) + " MB");
            //Console.WriteLine(_serverWork ? "Сервер запущен" : "Сервер выключен");

        }

    }
}