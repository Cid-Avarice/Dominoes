using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominoes
{
    public class Board
    {
        private Player[] members;
        private Tile[] TileCollection;
        public int team1points;
        public int team2points;
        public int rounds;


        public Board(Player[] people)
        {
            this.FillCollection();
            members = people;
            team1points = 0;
            team2points = 0;
            rounds = 1;
        }


        private void FillCollection()
        {
            Tile[] tempCollection = new Tile[28];
            int counter = 0; 

            for (int i = 0; i <= 6; i++)
            {
                

                for (int j = 6; j >= i; j--)
                {

                    Tile TempTile = new Tile(i, j);
                    tempCollection[counter++] = TempTile;
                    
                }
          
            }

            TileCollection = tempCollection;
        }
    }
}
