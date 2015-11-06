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
            throw new NotImplementedException();
        }

        public void Tick()
        {
            throw new NotImplementedException();
        }
    }
}
