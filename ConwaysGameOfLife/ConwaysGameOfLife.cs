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

        private GameOfLife RemoveOffGridNeighbors()
        {
            foreach(Cell cell in this.cells)
            {
                cell.Neighbors.RemoveAll(IsOffGridNeighbor);
            }
            return this;
        }

        private bool IsOffGridNeighbor(int[] coordinates)
        {
            int rowCount = this.cells.GetLength(0);
            int columnCount = this.cells.GetLength(1);
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
