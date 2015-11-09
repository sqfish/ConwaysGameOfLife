using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConwaysGameOfLife
{
    public class Cell
    {
        private bool state = false;
        public int row;
        public int column;
        public List<int[]> neighbors;

        public Cell()
        {

        }

        public Cell(int h, int k)
        {
            row = h;
            column = k;
            Neighbors();
        }

        public bool State
        {
            get { return state; }
            set { this.state = value; }
        }

        public int[] Position
        {
            get { return new int[] { row, column }; }
        }

        private void Neighbors()
        {    
            List<int[]> output = new List<int[]>();
            output.Add(new int[] { row - 1, column - 1 });
            output.Add(new int[] { row - 1, column });
            output.Add(new int[] { row - 1, column + 1 });
            output.Add(new int[] { row, column - 1 });
            output.Add(new int[] { row, column + 1 });
            output.Add(new int[] { row + 1, column - 1 });
            output.Add(new int[] { row + 1, column });
            output.Add(new int[] { row + 1, column + 1 });

            neighbors = output;
        }
    }
}
