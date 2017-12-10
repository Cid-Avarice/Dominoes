using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominoes
{
    public class Board
    {
        public Player[] players;
        public List<Tile> TileCollection;
        public int team1points;
        public int team2points;
        public int round;

        public Board(Player[] people)
        {
            FillCollection();
            players = people;
            team1points = 0;
            team2points = 0;
            round = 1;
        }

        public void StartRound()
        {
            foreach (Player player in players)
            {
                List<Tile> tempHand = new List<Tile>();
                Random generator = new Random();

                for (int i = 0; i <= 6; i++)
                {
                   

                    if (TileCollection.Count != 0)
                    {
                        int a = generator.Next(0, TileCollection.Count - 1);
                        tempHand.Add(TileCollection.ElementAt(a));
                        TileCollection.RemoveAt(a);
                    }
                   
                }

                player.AssignHand(tempHand);
            }
        }

        private void FillCollection()
        {
            List<Tile> tempCollection = new List<Tile>();

            

            for (int i = 0; i <= 6; i++)
            {
                for (int j = 6; j >= i; j--)
                {
                    Tile TempTile = new Tile(i, j);
                    tempCollection.Add(TempTile);
                }
          
            }

            TileCollection = tempCollection;
        }
    }
}
