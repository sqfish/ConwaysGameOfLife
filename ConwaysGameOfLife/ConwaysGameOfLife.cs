using System;
using System.Collections.Generic;
using System.Linq;

namespace ConwaysGameOfLife
{
    public class GameOfLife : Board
    {
        public Cell[,] cells;

        public GameOfLife(int i, int j)
        {
            cells = new Cell[i, j];
            for (int h = 0; h < i; h++)
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

        public void RandomizeStartPattern()
        {
            int rowCount = this.cells.GetLength(0);
            int columnCount = this.cells.GetLength(1);
            Random random = new Random();
            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < columnCount; j++)
                {
                    int newValue = random.Next(2);
                    if (newValue == 1)
                    {
                        cells[i, j].State = true;
                    }
                }
            }
        }

        private void RemoveOffGridNeighbors()
        {
            foreach (Cell cell in this.cells)
            {
                cell.Neighbors.RemoveAll(IsOffGridNeighbor);
            }
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
            if (coordinates[1] == columnCount)
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
                    column.Add(this.cells[h, k].State);
                }
                output.Add(column);
            }
            return output;
        }

        public void Tick()
        {
            foreach (Cell cell in this.cells)
            {
                int[] stateCount = CountNeighborStates(cell);
                if (cell.State == true)
                {
                    if (stateCount[0] < 2)
                    {
                        cell.NewState = false;
                    }
                    if (stateCount[0] == 2 || stateCount[0] == 3)
                    {
                        cell.NewState = true;
                    }
                    if (stateCount[0] > 3)
                    {
                        cell.NewState = false;
                    }
                }
                if (cell.State == false)
                {
                    if (stateCount[0] == 3)
                    {
                        cell.NewState = true;
                    }
                }
            }

            foreach (Cell cell in this.cells)
            {
                cell.State = cell.NewState;
            }
        }

        private int[] CountNeighborStates(Cell cell)
        {
            List<int[]> neighbors = cell.Neighbors;
            int count = neighbors.Count;
            int dead = 0;
            int alive = 0;
            foreach (int[] item in neighbors)
            {
                if (this.cells[item[0], item[1]].State == true)
                { alive++; }
                if (this.cells[item[0], item[1]].State == false)
                { dead++; }
            }
            return new int[] { alive, dead };
        }
    }
}