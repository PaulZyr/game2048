using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home0422_2048
{
    public class Coordinates
    {
        public Coordinates(int i, int j)
        {
            I = i;
            J = j;
        }
        public int I { get; set; }
        public int J { get; set; }
        public override string ToString()
        {
            return I.ToString() + ":" + J.ToString();
        }
    }
}
