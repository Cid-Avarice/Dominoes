using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominoes
{
    public class Tile
    {
        private int side1;
        private int side2;
        private string name;

        public Tile(int side1, int side2)
        {
            this.side1 = side1;
            this.side2 = side2;
        }

        public int GetTotalPoints()
        {
            return side1 + side2;
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
            return side1 == side2;
        }

        public void AssignToPlayer(string name)
        {
            this.name = name;
        }

        public override string ToString()
        {
            return $"{side1}-{side2}";
        }
    }
}
