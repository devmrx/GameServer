﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursWpf.Games
{
    [Serializable]
    class GameSession {

        private int MaxCountGamers { get; set; }
        public List<Gamer> GamersPlay { get; set; }  // id
        public DateTime _sessionTime;

        public GameSession(int maxCountGamers, DateTime sessionTime) {
            MaxCountGamers = maxCountGamers;
            _sessionTime = sessionTime;
        }



    }
}