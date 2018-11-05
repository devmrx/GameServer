using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursWpf.Games
{
    class WOW : GameServer
    {
        public WOW() {
            Name = "World of Warships";
            MaxGamersSession = 30;
        }
    }
}
