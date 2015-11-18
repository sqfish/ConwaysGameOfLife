using ConwaysGameOfLife;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace GameOfLifeUnitTesting
{
    [TestClass]
    public class GridTests
    {
        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void CreateNewEmptyGrid()
        {
            GameOfLife ATestGrid = new GameOfLife(0, 0);
            var ThisWillFail = ATestGrid[0, 0];
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

            Assert.AreEqual(false, ATestGrid[0, 0]);
        }

        [TestMethod]
        public void CreateNewGridSetCellValue()
        {
            GameOfLife ATestGrid = new GameOfLife(5, 5);
            ATestGrid[2, 2] = true;
            Assert.AreEqual(true, ATestGrid[2, 2]);
        }

        [TestMethod]
        public void CreateNewGridSetCellValueOtherCellsRetainValue()
        {
            GameOfLife ATestGrid = new GameOfLife(5, 5);
            ATestGrid[2, 2] = true;
            Assert.AreEqual(false, ATestGrid[2, 3]);
        }

        [TestMethod]
        public void RemoveOffGridNeighborsWithOneCellGrid()
        {
            GameOfLife ATestGrid = new GameOfLife(1, 1);
            Cell TheOnlyCell = ATestGrid.cells[0, 0];
            Assert.AreEqual(0, TheOnlyCell.Neighbors.Count);
        }

        [TestMethod]
        public void RemoveOffGridNeighborsInnerCell()
        {
            GameOfLife ATestGrid = new GameOfLife(5, 5);
            Cell AnInnerCell = ATestGrid.cells[2, 2];
            Assert.AreEqual(8, AnInnerCell.Neighbors.Count);
        }

        [TestMethod]
        public void RemoveOffGridNeighborsWithNegativeCoordinates()
        {
            GameOfLife ATestGrid = new GameOfLife(5, 5);
            Cell ACornerCell = ATestGrid.cells[0, 0];
            Assert.AreEqual(3, ACornerCell.Neighbors.Count);
        }

        [TestMethod]
        public void RemoveOffGridNeighborsWithPositiveCoordinates()
        {
            GameOfLife ATestGrid = new GameOfLife(5, 5);
            Cell ACornerCell = ATestGrid.cells[4, 4];
            Assert.AreEqual(3, ACornerCell.Neighbors.Count);
        }

        [TestMethod]
        public void RemoveOffGridNeighborsRectangularGridInnerCell()
        {
            GameOfLife ATestGrid = new GameOfLife(8, 5);
            Cell AnInnerCell = ATestGrid.cells[2, 3];
            Assert.AreEqual(8, AnInnerCell.Neighbors.Count);
        }

        [TestMethod]
        public void RemoveOffGridNeighborsWithNegativeCoordinatesInRectangularGrid()
        {
            GameOfLife ATestGrid = new GameOfLife(8, 5);
            Cell ACornerCell = ATestGrid.cells[0, 0];
            Assert.AreEqual(3, ACornerCell.Neighbors.Count);
        }

        [TestMethod]
        public void RemoveOffGridNeighborsWithPositiveCoordinatesInRectangularGrid()
        {
            GameOfLife ATestGrid = new GameOfLife(8, 5);
            Cell ACornerCell = ATestGrid.cells[7, 4];
            Assert.AreEqual(3, ACornerCell.Neighbors.Count);
        }

        [TestMethod]
        public void ToListWithEmptyGrid()
        {
            GameOfLife ATestGrid = new GameOfLife(0, 0);
            List<List<bool>> ATestListOfLists = new List<List<bool>>();
            CollectionAssert.AreEqual(ATestListOfLists, ATestGrid.ToList());
        }

        [TestMethod]
        public void ToListWith1x1Grid()
        {
            GameOfLife ATestGrid = new GameOfLife(1, 1);
            List<bool> ATestList = new List<bool> { false };
            List<List<bool>> ATestListOfLists = new List<List<bool>>();
            ATestListOfLists.Add(ATestList);
            CollectionAssert.AreEquivalent(ATestListOfLists[0], ATestGrid.ToList()[0]);
        }

        [TestMethod]
        public void ToListWith3x3Grid()
        {
            GameOfLife ATestGrid = new GameOfLife(3, 3);
            List<bool> ATestList = new List<bool>(new bool[] { false, false, false });
            List<List<bool>> ATestListOfLists = new List<List<bool>>();
            ATestListOfLists.Add(ATestList);
            ATestListOfLists.Add(ATestList);
            ATestListOfLists.Add(ATestList);
            CollectionAssert.AreEquivalent(ATestListOfLists[0], ATestGrid.ToList()[0]);
            CollectionAssert.AreEquivalent(ATestListOfLists[1], ATestGrid.ToList()[1]);
            CollectionAssert.AreEquivalent(ATestListOfLists[2], ATestGrid.ToList()[2]);
        }

        [TestMethod]
        public void CountNeighborStates1x1Grid()
        {
            PrivateObject ATestGrid = new PrivateObject(new GameOfLife(1, 1));
            Cell[,] ATestCellGrid = (Cell[,])ATestGrid.GetField("cells");
            int[] TestNeighborStates = (int[])ATestGrid.Invoke("CountNeighborStates", new object[] { ATestCellGrid[0, 0] });
            CollectionAssert.AreEqual(new int[] { 0, 0 }, TestNeighborStates);
        }

        [TestMethod]
        public void CountNeighborStates3x3Grid()
        {
            PrivateObject ATestGrid = new PrivateObject(new GameOfLife(3, 3));
            Cell[,] ATestCellGrid = (Cell[,])ATestGrid.GetField("cells");
            int[] TestNeighborStates0x0 = (int[])ATestGrid.Invoke("CountNeighborStates", new object[] { ATestCellGrid[0, 0] });
            int[] TestNeighborStates0x2 = (int[])ATestGrid.Invoke("CountNeighborStates", new object[] { ATestCellGrid[0, 2] });
            int[] TestNeighborStates2x0 = (int[])ATestGrid.Invoke("CountNeighborStates", new object[] { ATestCellGrid[2, 0] });
            int[] TestNeighborStates2x2 = (int[])ATestGrid.Invoke("CountNeighborStates", new object[] { ATestCellGrid[2, 2] });
            int[] TestNeighborStates1x0 = (int[])ATestGrid.Invoke("CountNeighborStates", new object[] { ATestCellGrid[1, 0] });
            int[] TestNeighborStates1x2 = (int[])ATestGrid.Invoke("CountNeighborStates", new object[] { ATestCellGrid[1, 2] });
            int[] TestNeighborStates0x1 = (int[])ATestGrid.Invoke("CountNeighborStates", new object[] { ATestCellGrid[0, 1] });
            int[] TestNeighborStates2x1 = (int[])ATestGrid.Invoke("CountNeighborStates", new object[] { ATestCellGrid[2, 1] });
            int[] TestNeighborStates1x1 = (int[])ATestGrid.Invoke("CountNeighborStates", new object[] { ATestCellGrid[1, 1] });
            CollectionAssert.AreEqual(new int[] { 0, 3 }, TestNeighborStates0x0);
            CollectionAssert.AreEqual(new int[] { 0, 3 }, TestNeighborStates0x2);
            CollectionAssert.AreEqual(new int[] { 0, 3 }, TestNeighborStates2x0);
            CollectionAssert.AreEqual(new int[] { 0, 3 }, TestNeighborStates2x2);
            CollectionAssert.AreEqual(new int[] { 0, 5 }, TestNeighborStates1x0);
            CollectionAssert.AreEqual(new int[] { 0, 5 }, TestNeighborStates1x2);
            CollectionAssert.AreEqual(new int[] { 0, 5 }, TestNeighborStates0x1);
            CollectionAssert.AreEqual(new int[] { 0, 5 }, TestNeighborStates2x1);
            CollectionAssert.AreEqual(new int[] { 0, 8 }, TestNeighborStates1x1);
        }

        [TestMethod]
        public void CountNeighborStates3x3GridMixOfLiveAndDead()
        {
            PrivateObject ATestGrid = new PrivateObject(new GameOfLife(3, 3));
            Cell[,] ATestCellGrid = (Cell[,])ATestGrid.GetField("cells");
            ATestCellGrid[0, 0].State = true;
            ATestCellGrid[1, 1].State = true;
            ATestCellGrid[2, 2].State = true;
            int[] TestNeighborStates0x0 = (int[])ATestGrid.Invoke("CountNeighborStates", new object[] { ATestCellGrid[0, 0] });
            int[] TestNeighborStates0x2 = (int[])ATestGrid.Invoke("CountNeighborStates", new object[] { ATestCellGrid[0, 2] });
            int[] TestNeighborStates2x0 = (int[])ATestGrid.Invoke("CountNeighborStates", new object[] { ATestCellGrid[2, 0] });
            int[] TestNeighborStates2x2 = (int[])ATestGrid.Invoke("CountNeighborStates", new object[] { ATestCellGrid[2, 2] });
            int[] TestNeighborStates1x0 = (int[])ATestGrid.Invoke("CountNeighborStates", new object[] { ATestCellGrid[1, 0] });
            int[] TestNeighborStates1x2 = (int[])ATestGrid.Invoke("CountNeighborStates", new object[] { ATestCellGrid[1, 2] });
            int[] TestNeighborStates0x1 = (int[])ATestGrid.Invoke("CountNeighborStates", new object[] { ATestCellGrid[0, 1] });
            int[] TestNeighborStates2x1 = (int[])ATestGrid.Invoke("CountNeighborStates", new object[] { ATestCellGrid[2, 1] });
            int[] TestNeighborStates1x1 = (int[])ATestGrid.Invoke("CountNeighborStates", new object[] { ATestCellGrid[1, 1] });
            CollectionAssert.AreEqual(new int[] { 1, 2 }, TestNeighborStates0x0);
            CollectionAssert.AreEqual(new int[] { 1, 2 }, TestNeighborStates0x2);
            CollectionAssert.AreEqual(new int[] { 1, 2 }, TestNeighborStates2x0);
            CollectionAssert.AreEqual(new int[] { 1, 2 }, TestNeighborStates2x2);
            CollectionAssert.AreEqual(new int[] { 2, 3 }, TestNeighborStates1x0);
            CollectionAssert.AreEqual(new int[] { 2, 3 }, TestNeighborStates1x2);
            CollectionAssert.AreEqual(new int[] { 2, 3 }, TestNeighborStates0x1);
            CollectionAssert.AreEqual(new int[] { 2, 3 }, TestNeighborStates2x1);
            CollectionAssert.AreEqual(new int[] { 2, 6 }, TestNeighborStates1x1);
        }
    }
}