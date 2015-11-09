using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConwaysGameOfLife
{
    public class GameOfLife : Board
    {
        public Cell[,] cells;
        public GameOfLife(int i, int j)
        {
            cells = new Cell[i, j];
            for (int h = 0; h < i; h++ )
            {
                for (int k = 0; k < j; k++)
                {
                    cells[h, k] = new Cell(h, k);
                }
            }
            this.RemoveOffGridNeighbors();
        }

        public bool this[int i, int j]
        {
            get { return cells[i, j].State; }
            set { cells[i, j].State = value; }
        }

        public GameOfLife CreateStartPattern()
        {
            int rowCount = this.cells.GetLength(0);
            int columnCount = this.cells.GetLength(1);

            for (int h = 0; h < rowCount; h++)
            {
                this[h, 0] = true;
            }
            return this;
        }

        public GameOfLife RemoveOffGridNeighbors()
        {
            foreach(Cell cell in this.cells)
            {
                Console.WriteLine("current cell: {0}, {1}", cell.row, cell.column);
                Console.WriteLine("starting neighbors: {0}", cell.neighbors.Count);
                cell.neighbors.RemoveAll(IsOffGridNeighbor);
                Console.WriteLine("final neighbors: {0}", cell.neighbors.Count);
            }
            return this;
        }

        private bool IsOffGridNeighbor(int[] coordinates)
        {
            Console.WriteLine("Testing Neighbor {0}", coordinates.ToString());
            int rowCount = this.cells.GetLength(0);
            Console.WriteLine("rowCount: {0}", rowCount);
            int columnCount = this.cells.GetLength(1);
            Console.WriteLine("columnCount: {0}", columnCount);
            bool isOffGrid = false;
            if (coordinates.Contains(-1))
            {
                isOffGrid = true;
            }
            if (coordinates[0] == rowCount)
            {
                isOffGrid = true;
            }
            if(coordinates[1] == columnCount)
            {
                isOffGrid = true;
            }
            Console.WriteLine("isOffGrid {0}", isOffGrid);
            return isOffGrid;
        }

        public List<List<bool>> ToList()
        {
            int rowCount = this.cells.GetLength(0);
            int columnCount = this.cells.GetLength(1);

            List<List<bool>> output = new List<List<bool>>();
            for (int h = 0; h < rowCount; h++)
            {
                List<bool> column = new List<bool>();
                for (int k = 0; k < columnCount; k++)
                {
                    column.Add(this.cells[h,k].State);
                }
                output.Add(column);
            }
            return output;
        }

        public void Tick()
        {
            throw new NotImplementedException();
        }
    }
}
