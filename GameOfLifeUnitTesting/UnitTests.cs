using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConwaysGameOfLife;

namespace GameOfLifeUnitTesting
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void CreateNewCell()
        {
            Cell ATestCell = new Cell();
            Assert.AreEqual(false, ATestCell.State);
        }

        [TestMethod]
        public void InitializeCellState()
        {
            Cell ATestCell = new Cell();
            ATestCell.State = true;
            Assert.AreEqual(true, ATestCell.State);
        }

        [TestMethod]
        public void CreateNewGrid()
        {
            GameOfLife ATestGrid = new GameOfLife(5, 5);
            Assert.AreEqual(25, ATestGrid.cells.Length);
        }

        [TestMethod]
        public void CreateNewGridGetCellValue()
        {
            GameOfLife ATestGrid = new GameOfLife(5, 5);
            
            Assert.AreEqual(false, ATestGrid[0,0]);
        }

        [TestMethod]
        public void CreateNewGridSetCellValue()
        {
            GameOfLife ATestGrid = new GameOfLife(5, 5);
            ATestGrid[2, 2] = true;
            Assert.AreEqual(true, ATestGrid[2, 2]);
        }

        [TestMethod]
        public void ToListWithEmptyGrid()
        {
 
        }

        [TestMethod]
        public void ToListWith1x1Grid()
        {

        }

        [TestMethod]
        public void ToListWith3x3Grid()
        {

        }
    }
}
