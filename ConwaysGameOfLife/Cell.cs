using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConwaysGameOfLife
{
    public class Cell
    {
        public bool State { get; set; }
        public bool NewState { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }
        public List<int[]> Neighbors { get; set; }

        public Cell()
        {

        }

        public Cell(int h, int k)
        {
            Row = h;
            Column = k;
            GenerateNeighbors();
        }

        //public bool State
        //{
        //    get { return state; }
        //    set { this.state = value; }
        //}

        //public bool NewState
        //{
        //    get { return newState; }
        //    set { this.newState = value; }
        //}

        public int[] Position
        {
            get { return new int[] { Row, Column }; }
        }

        //public List<int[]> Neighbors
        //{
        //    get { return neighbors; }
        //    set { this.neighbors = value; }
        //}

        private void GenerateNeighbors()
        {    
            List<int[]> output = new List<int[]>();
            output.Add(new int[] { Row - 1, Column - 1 });
            output.Add(new int[] { Row - 1, Column });
            output.Add(new int[] { Row - 1, Column + 1 });
            output.Add(new int[] { Row, Column - 1 });
            output.Add(new int[] { Row, Column + 1 });
            output.Add(new int[] { Row + 1, Column - 1 });
            output.Add(new int[] { Row + 1, Column });
            output.Add(new int[] { Row + 1, Column + 1 });

            Neighbors = output;
        }
    }
}
