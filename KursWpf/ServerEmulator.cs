﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursWpf
{
    public static class ServerEmulator
    {
        private static Random _rand;

        static ServerEmulator() {
            _rand = new Random();
        }

        public static void GetRandomStatus(List<Account> accounts) {
            foreach (var account in accounts) {
                if (account is Gamer gamer) {
                    gamer.GamerStatus = (Status)_rand.Next(0, 4);
                }
            }
        }


        public static string GetRandomPassHash() {
            return _rand.Next(0, 40000).GetHashCode().ToString();
        }

        public static int GetRandomCountGemers()
        {
            return _rand.Next(20, 401);
        }
    }
}
