using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursWpf.Games
{
    public abstract class GameServer : IComparable<GameServer>{

        public string Name { get; set; }
        public string ImgGame { get; set; }
        public string TypeGame { get; set; } // ENUM 
        public string ShortName { get; set; }
        public int CountGamers { get; set; }
        //protected int GamersOnline { get; set; }
        protected byte MaxGamersSession { get; set; }
        protected string Description { get; set; }

        public int CompareTo(GameServer other)
        {
            if (CountGamers > other.CountGamers) return -1;
            else if (CountGamers < other.CountGamers) return 1;
            else return 0;
        }



        // link to collection gamers

        //public abstract void GetInfo();


    }
}
