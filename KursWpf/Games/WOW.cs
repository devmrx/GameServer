﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursWpf.Games
{
    [Serializable]
    class WOW : GameServer
    {
        public WOW() {
            Name = "World of Warships";
            ShortName = "World of Warships";
            ImgGame = "Image/World of Warships.jpg";
            MaxGamersSession = 30;
            CountGamers = ServerEmulator.GetRandomCountGemers();
            //CountGamersF = GetCountPlayersFormat(CountGamers);
        }
    }
}
