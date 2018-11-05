using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KursWpf.Games;

namespace KursWpf
{
    public class Gamer : Account {

        public Status GamerStatus { get; set; }
        public List<GameServer> Games { get; set; }

        public Gamer(string login, string passwordHash) : base(login, passwordHash) {
            GamerStatus = Status.Offline;
        }




    }

    public enum Status : byte {
        Offline,
        Online,
        Search,
        Playing
    }
}
