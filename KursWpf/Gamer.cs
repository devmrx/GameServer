using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KursWpf.Games;

namespace KursWpf
{
    [Serializable]
    public class Gamer : Account {

        public Status GamerStatus { get; set; }
        //public List<GameServer> Games { get; set; }

        public Gamer(int id, string login, string passwordHash) : base(id, login, passwordHash) {
            GamerStatus = Status.Offline;
        }

        public override void Play()
        {

            GamerStatus = Status.Playing;
            //
        }
    }

    public enum Status : byte {
        Offline,
        Online,
        Search,
        Playing
    }

   

}
