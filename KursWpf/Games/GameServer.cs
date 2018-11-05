using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursWpf.Games
{
    public abstract class GameServer {

        public string Name { get; set; }
        //public string Img { get; set; }
        public string TypeGame { get; set; } // ENUM 
        //protected int CountGamers { get; set; }
        //protected int GamersOnline { get; set; }
        protected byte MaxGamersSession { get; set; }
        protected string Description { get; set; }

        // link to collection gamers

        //public abstract void GetInfo();


    }
}
