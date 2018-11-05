using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursWpf.Games
{
    class Chess : GameServer
    {
        public Chess() {
            Name = "Chess";
            MaxGamersSession = 2;
        }

        private void CreateSession() {

        }
    }
}
