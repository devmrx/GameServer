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
        public string CountGamersF { get; set; }
        //protected int GamersOnline { get; set; }
        protected byte MaxGamersSession { get; set; }
        protected string Description { get; set; }

        public int CompareTo(GameServer other)
        {
            if (CountGamers > other.CountGamers) return -1;
            else if (CountGamers < other.CountGamers) return 1;
            else return 0;
        }

        //156 игроков онлайн

        //0 игроков
        //1 игрок
        //2 игрока
        //3 игрока
        //4 игрока
        //5 игроков
        //6 игроков
        //7 игроков
        //8 игроков
        //9 игроков

        public string GetCountPlayersFormat(int count)
        {
            int lastdigit = Int32.Parse(count.ToString().Last().ToString());

            switch (lastdigit)
            {
                case 1:
                    return count + " игрок онлайн";
                case 2:
                case 3:
                case 4:
                    return count + " игрока онлайн";
                default:
                    return count + " игроков онлайн";
            }
        }



        // link to collection gamers

        //public abstract void GetInfo();


    }
}
