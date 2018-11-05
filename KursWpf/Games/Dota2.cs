using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursWpf.Games
{
    class Dota2 : GameServer {

        public Dota2() {
            Name = "Dota 2";
            ShortName = "Dota 2";
            ImgGame = "Image/Dota2.jpg";
            MaxGamersSession = 10;
            CountGamers = ServerEmulator.GetRandomCountGemers();
        }
    }
}
