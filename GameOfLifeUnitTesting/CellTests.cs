using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConwaysGameOfLife;
using System.Collections.Generic;

namespace GameOfLifeUnitTesting
{
    [TestClass]
    public class CellTests
    {
        [TestMethod]
        public void CreateNewCellWithConstructor()
        {
            Cell ATestCell = new Cell();
            Assert.AreEqual(false, ATestCell.State);
        }

        [TestMethod]
        public void CreateNewCellWithSecondConstructorAndGetPosition()
        {
            Cell ATestCell = new Cell(5, 8);
            Assert.AreEqual(5, ATestCell.Position[0]);
            Assert.AreEqual(8, ATestCell.Position[1]);
        }

        [TestMethod]
        public void InitializeCellState()
        {
            Cell ATestCell = new Cell();
            ATestCell.State = true;
            Assert.AreEqual(true, ATestCell.State);
        }

        [TestMethod]
        public void CalculateAppropriateNeighborCoordinatesForCellAt0x0()
        {
            Cell ATestCell = new Cell(0, 0);
            List<int[]> TestNeighbors = new List<int[]>();
            TestNeighbors.Add(new int[] { -1, -1 });
            TestNeighbors.Add(new int[] { -1, 0 });
            TestNeighbors.Add(new int[] { -1, 1 });
            TestNeighbors.Add(new int[] { 0, -1 });
            TestNeighbors.Add(new int[] { 0, 1 });
            TestNeighbors.Add(new int[] { 1, -1 });
            TestNeighbors.Add(new int[] { 1, 0 });
            TestNeighbors.Add(new int[] { 1, 1 });
            List<int[]> ActualNeighbors = ATestCell.Neighbors;
            CollectionAssert.AreEquivalent(TestNeighbors[0], ActualNeighbors[0]);
            CollectionAssert.AreEquivalent(TestNeighbors[1], ActualNeighbors[1]);
            CollectionAssert.AreEquivalent(TestNeighbors[2], ActualNeighbors[2]);
            CollectionAssert.AreEquivalent(TestNeighbors[3], ActualNeighbors[3]);
            CollectionAssert.AreEquivalent(TestNeighbors[4], ActualNeighbors[4]);
            CollectionAssert.AreEquivalent(TestNeighbors[5], ActualNeighbors[5]);
            CollectionAssert.AreEquivalent(TestNeighbors[6], ActualNeighbors[6]);
            CollectionAssert.AreEquivalent(TestNeighbors[7], ActualNeighbors[7]);
        }

        [TestMethod]
        public void CalculateAppropriateNeighborCoordinatesForCellAt2x2()
        {
            Cell ATestCell = new Cell(2,2);
            PrivateObject ATestCellObj = new PrivateObject(ATestCell);
            List<int[]> TestNeighbors = new List<int[]>();
            TestNeighbors.Add(new int[] { 1, 1 });
            TestNeighbors.Add(new int[] { 1, 2 });
            TestNeighbors.Add(new int[] { 1, 3 });
            TestNeighbors.Add(new int[] { 2, 1 });
            TestNeighbors.Add(new int[] { 2, 3 });
            TestNeighbors.Add(new int[] { 3, 1 });
            TestNeighbors.Add(new int[] { 3, 2 });
            TestNeighbors.Add(new int[] { 3, 3 });
            List<int[]> ActualNeighbors = ATestCell.Neighbors;
            CollectionAssert.AreEquivalent(TestNeighbors[0], ActualNeighbors[0]);
            CollectionAssert.AreEquivalent(TestNeighbors[1], ActualNeighbors[1]);
            CollectionAssert.AreEquivalent(TestNeighbors[2], ActualNeighbors[2]);
            CollectionAssert.AreEquivalent(TestNeighbors[3], ActualNeighbors[3]);
            CollectionAssert.AreEquivalent(TestNeighbors[4], ActualNeighbors[4]);
            CollectionAssert.AreEquivalent(TestNeighbors[5], ActualNeighbors[5]);
            CollectionAssert.AreEquivalent(TestNeighbors[6], ActualNeighbors[6]);
            CollectionAssert.AreEquivalent(TestNeighbors[7], ActualNeighbors[7]);
        }
    }
}
