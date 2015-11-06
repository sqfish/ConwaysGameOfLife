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
                    cells[h, k] = new Cell();
                }
            }
        }

        public bool this[int i, int j]
        {
            get { return cells[i, j].State; }
            set { cells[i, j].State = value; }
        }

        public List<List<bool>> ToList()
        {
            int rowLength = this.cells.GetLength(0);
            Console.WriteLine("rowLength: {0}", rowLength);
            int colLength = this.cells.GetLength(1);
            Console.WriteLine("colLength: {0}", colLength);

            List<List<bool>> output = new List<List<bool>>();
            for (int h = 0; h < rowLength; h++)
            {
                List<bool> column = new List<bool>();
                for (int k = 0; k < colLength; k++)
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
