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
        private int row;
        private int column;
        private List<int[]> neighbors;

        public Cell()
        {

        }

        public Cell(int h, int k)
        {
            row = h;
            column = k;
            GenerateNeighbors();
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

        public List<int[]> Neighbors
        {
            get { return neighbors; }
            set { this.neighbors = value; }
        }

        private void GenerateNeighbors()
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
