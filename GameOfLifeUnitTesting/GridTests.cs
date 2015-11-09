﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConwaysGameOfLife;
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
            Assert.AreEqual(0, TheOnlyCell.neighbors.Count);
        }


        [TestMethod]
        public void RemoveOffGridNeighborsInnerCell()
        {
            GameOfLife ATestGrid = new GameOfLife(5, 5);
            Cell AnInnerCell = ATestGrid.cells[2, 2];
            Assert.AreEqual(8, AnInnerCell.neighbors.Count);
        }

        [TestMethod]
        public void RemoveOffGridNeighborsWithNegativeCoordinates()
        {
            GameOfLife ATestGrid = new GameOfLife(5, 5);
            Cell ACornerCell = ATestGrid.cells[0, 0];
            Assert.AreEqual(3, ACornerCell.neighbors.Count);
        }

        [TestMethod]
        public void RemoveOffGridNeighborsWithPositiveCoordinates()
        {
            GameOfLife ATestGrid = new GameOfLife(5, 5);
            Cell ACornerCell = ATestGrid.cells[4, 4];
            Assert.AreEqual(3, ACornerCell.neighbors.Count);
        }

        [TestMethod]
        public void RemoveOffGridNeighborsRectangularGridInnerCell()
        {
            GameOfLife ATestGrid = new GameOfLife(8, 5);
            Cell AnInnerCell = ATestGrid.cells[2, 3];
            Assert.AreEqual(8, AnInnerCell.neighbors.Count);
        }

        [TestMethod]
        public void RemoveOffGridNeighborsWithNegativeCoordinatesInRectangularGrid()
        {
            GameOfLife ATestGrid = new GameOfLife(8, 5);
            Cell ACornerCell = ATestGrid.cells[0, 0];
            Assert.AreEqual(3, ACornerCell.neighbors.Count);
        }

        [TestMethod]
        public void RemoveOffGridNeighborsWithPositiveCoordinatesInRectangularGrid()
        {
            GameOfLife ATestGrid = new GameOfLife(8, 5);
            Cell ACornerCell = ATestGrid.cells[7, 4];
            Assert.AreEqual(3, ACornerCell.neighbors.Count);
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
    }
}