using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursWpf.Games
{
    class Overwatch : GameServer
    {
        public Overwatch() {
            Name = "Overwatch";
            ShortName = "Overwatch";
            ImgGame = "Image/Overwatch.jpg";
            MaxGamersSession = 30;
            CountGamers = ServerEmulator.GetRandomCountGemers();
            //CountGamersF = GetCountPlayersFormat(CountGamers);
        }
    }
}
