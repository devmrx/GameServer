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
            MaxGamersSession = 30;
        }
    }
}
