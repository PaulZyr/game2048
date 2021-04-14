using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home0422_2048.Model
{
    public class NumbersModel
    {
        public NumbersModel()
        {
            FreeCells = new List<Coordinates>();
        }
        public int[,] Numbers { get; set; } = new int[,]
        {
             { 0, 0, 0, 0 },
             { 0, 0, 0, 0 },
             { 0, 0, 0, 0 },
             { 0, 0, 0, 0 }
        };
        
        public int[] NewNumber { get; set; } = new int[] { 2, 2, 2, 2, 2, 4, 2, 2, 2, 2 };

        private List<Coordinates> _freeCells;
        public List<Coordinates> FreeCells 
        { 
            get
            {
                GetFreeCells();
                return _freeCells;
            }
            set
            {
                _freeCells = value;
            }
        }

        private void GetFreeCells()
        {
            _freeCells.Clear();
            for (int i = 0; i < 4; ++i)
            {
                for (int j = 0; j < 4; ++j)
                {
                    if (Numbers[i, j] == 0) _freeCells.Add(new Coordinates(i, j));
                }
            }
        }
    }
}
