﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursWpf.Games
{
    [Serializable]
    class Chess : GameServer
    {
        public Chess() {
            Name = "Chess";
            ShortName = "Chess";
            ImgGame = "Image/Chess.jpg";
            MaxGamersSession = 2;
            CountGamers = ServerEmulator.GetRandomCountGemers();
            //CountGamersF = GetCountPlayersFormat(CountGamers);
        }

        private void CreateSession() {

        }
    }
}
