﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursWpf.Games
{
    [Serializable]
    class PUBG : GameServer
    {
        public PUBG() {
            Name = "PlayerUnknown’s Battlegrounds";
            ShortName = "Playerunknown's...";
            ImgGame = "Image/PUBG.jpg";
            MaxGamersSession = 100;
            CountGamers = ServerEmulator.GetRandomCountGemers();
            //CountGamersF = GetCountPlayersFormat(CountGamers);
        }

    }
}
