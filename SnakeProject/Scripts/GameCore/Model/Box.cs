using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnakeProject.Scripts.GameCore.Model
{
    //logic definition of a cell in the map
    public class Box : object
    {
        public int I { get; set; }//public

        public int J { get; set; }

        public Box(int i, int j)
        {
            I = i;
            J = j;
        }

        public override bool Equals(object obj)
        {
            // Check for null values and compare run-time types.
            if (obj == null || GetType() != obj.GetType())
                return false;

            Box p = (Box)obj;
            return (I == p.I) && (J == p.J);
        }

        public override int GetHashCode()
        {
            return I ^ J;
        }

        public override string ToString()
        {
            return "i: " + I + " j:" + J;
        }
    }
}