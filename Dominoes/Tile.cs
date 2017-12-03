using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominoes
{
    class Tile
    {
        private int side1;
        private int side2;
        private bool isDouble;
        private int totalpoints;
        private string name;

        public Tile(int side1, int side2)
        {
            this.side1 = side1;
            this.side2 = side2;
            totalpoints = side1 + side2;
            if (side1 == side2)
            {
                isDouble = true;
            }
            else
                isDouble = false;
        }

        public int GetTotalPoints()
        {
            return totalpoints;
        }

        public int GetSide1()
        {
            return side1;
        }

        public int GetSide2()
        {
            return side2;
        }

        public string GetName()
        {
            return name; 
        }

        public bool GetIsDouble()
        {
            return isDouble;
        }

        public void AssignToPlayer(string name)
        {
            this.name = name;
        }
    }
}
