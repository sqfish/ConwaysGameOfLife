using ConwaysGameOfLife;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameOfLifeUnitTesting
{
    [TestClass]
    public class RuleAndTickTests
    {
        [TestMethod]
        public void TickTestRuleOneZeroLiveNeighbors()
        {
            GameOfLife ATestGridToTick = new GameOfLife(4, 4);
            ATestGridToTick[1, 1] = true;
            ATestGridToTick.Tick();
            Assert.AreEqual(false, ATestGridToTick[1, 1]);
        }

        [TestMethod]
        public void TickTestRuleOneOneLiveNeighbor()
        {
            GameOfLife ATestGridToTick = new GameOfLife(4, 4);
            ATestGridToTick[1, 1] = true;
            ATestGridToTick[1, 2] = true;
            ATestGridToTick.Tick();
            Assert.AreEqual(false, ATestGridToTick[1, 1]);
            Assert.AreEqual(false, ATestGridToTick[1, 2]);
        }

        [TestMethod]
        public void TickTestRuleTwoTwoLiveNeighbors()
        {
            GameOfLife ATestGridToTick = new GameOfLife(5, 3);
            ATestGridToTick[2, 1] = true;
            ATestGridToTick[3, 1] = true;
            ATestGridToTick[4, 0] = true;
            ATestGridToTick.Tick();
            Assert.AreEqual(true, ATestGridToTick[3, 1]);
        }

        [TestMethod]
        public void TickTestRuleTwoThreeLiveNeighbors()
        {
            GameOfLife ATestGridToTick = new GameOfLife(5, 3);
            ATestGridToTick[2, 1] = true;
            ATestGridToTick[3, 1] = true;
            ATestGridToTick[4, 0] = true;
            ATestGridToTick[4, 1] = true;
            ATestGridToTick.Tick();
            Assert.AreEqual(true, ATestGridToTick[3, 1]);
        }

        [TestMethod]
        public void TickTestRuleThreeFourLiveNeighbors()
        {
            GameOfLife ATestGridToTick = new GameOfLife(5, 3);
            ATestGridToTick[2, 1] = true;
            ATestGridToTick[2, 2] = true;
            ATestGridToTick[3, 1] = true;
            ATestGridToTick[4, 0] = true;
            ATestGridToTick[4, 1] = true;
            Assert.AreEqual(true, ATestGridToTick[3, 1]);
            ATestGridToTick.Tick();
            Assert.AreEqual(false, ATestGridToTick[3, 1]);
        }

        [TestMethod]
        public void TickTestRuleFourDeadCellWithTwoLiveNeighbors()
        {
            GameOfLife ATestGridToTick = new GameOfLife(5, 3);
            ATestGridToTick[2, 1] = true;
            ATestGridToTick[3, 1] = false;
            ATestGridToTick[4, 1] = true;
            Assert.AreEqual(false, ATestGridToTick[3, 1]);
            ATestGridToTick.Tick();
            Assert.AreEqual(false, ATestGridToTick[3, 1]);
        }

        [TestMethod]
        public void TickTestRuleFourDeadCellWithThreeLiveNeighbors()
        {
            GameOfLife ATestGridToTick = new GameOfLife(5, 3);
            ATestGridToTick[2, 1] = true;
            ATestGridToTick[3, 1] = false;
            ATestGridToTick[4, 0] = true;
            ATestGridToTick[4, 1] = true;
            Assert.AreEqual(false, ATestGridToTick[3, 1]);
            ATestGridToTick.Tick();
            Assert.AreEqual(true, ATestGridToTick[3, 1]);
        }

        [TestMethod]
        public void TickTestRuleFourDeadCellWithFourLiveNeighbors()
        {
            GameOfLife ATestGridToTick = new GameOfLife(5, 3);
            ATestGridToTick[2, 1] = true;
            ATestGridToTick[2, 2] = true;
            ATestGridToTick[3, 1] = false;
            ATestGridToTick[4, 0] = true;
            ATestGridToTick[4, 1] = true;
            Assert.AreEqual(false, ATestGridToTick[3, 1]);
            ATestGridToTick.Tick();
            Assert.AreEqual(false, ATestGridToTick[3, 1]);
        }

        [TestMethod]
        public void TickTestBlockFormation()
        {
            GameOfLife ATestGrid = new GameOfLife(4, 4);
            ATestGrid[1, 1] = true;
            ATestGrid[1, 2] = true;
            ATestGrid[2, 1] = true;
            ATestGrid[2, 2] = true;
            GameOfLife ATestGridToTick = new GameOfLife(4, 4);
            ATestGridToTick[1, 1] = true;
            ATestGridToTick[1, 2] = true;
            ATestGridToTick[2, 1] = true;
            ATestGridToTick[2, 2] = true;
            ATestGridToTick.Tick();
            CollectionAssert.AreEqual(ATestGrid.ToList()[0], ATestGridToTick.ToList()[0]);
            CollectionAssert.AreEqual(ATestGrid.ToList()[1], ATestGridToTick.ToList()[1]);
            CollectionAssert.AreEqual(ATestGrid.ToList()[2], ATestGridToTick.ToList()[2]);
            CollectionAssert.AreEqual(ATestGrid.ToList()[3], ATestGridToTick.ToList()[3]);
        }

        [TestMethod]
        public void TickTestLoafFormation()
        {
            GameOfLife ATestGrid = new GameOfLife(6, 6);
            ATestGrid[1, 2] = true;
            ATestGrid[1, 3] = true;
            ATestGrid[2, 1] = true;
            ATestGrid[2, 4] = true;
            ATestGrid[3, 2] = true;
            ATestGrid[3, 4] = true;
            ATestGrid[4, 3] = true;
            GameOfLife ATestGridToTick = new GameOfLife(6, 6);
            ATestGridToTick[1, 2] = true;
            ATestGridToTick[1, 3] = true;
            ATestGridToTick[2, 1] = true;
            ATestGridToTick[2, 4] = true;
            ATestGridToTick[3, 2] = true;
            ATestGridToTick[3, 4] = true;
            ATestGridToTick[4, 3] = true;
            ATestGridToTick.Tick();
            CollectionAssert.AreEqual(ATestGrid.ToList()[0], ATestGridToTick.ToList()[0]);
            CollectionAssert.AreEqual(ATestGrid.ToList()[1], ATestGridToTick.ToList()[1]);
            CollectionAssert.AreEqual(ATestGrid.ToList()[2], ATestGridToTick.ToList()[2]);
            CollectionAssert.AreEqual(ATestGrid.ToList()[3], ATestGridToTick.ToList()[3]);
            CollectionAssert.AreEqual(ATestGrid.ToList()[4], ATestGridToTick.ToList()[4]);
            CollectionAssert.AreEqual(ATestGrid.ToList()[5], ATestGridToTick.ToList()[5]);
        }

        [TestMethod]
        public void TickTestBlinkerFormation()
        {
            GameOfLife ATestGrid = new GameOfLife(5, 5);
            ATestGrid[1, 2] = true;
            ATestGrid[2, 2] = true;
            ATestGrid[3, 2] = true;
            GameOfLife ATestGridToTick = new GameOfLife(5, 5);
            ATestGridToTick[2, 1] = true;
            ATestGridToTick[2, 2] = true;
            ATestGridToTick[2, 3] = true;
            ATestGridToTick.Tick();
            CollectionAssert.AreEqual(ATestGrid.ToList()[0], ATestGridToTick.ToList()[0]);
            CollectionAssert.AreEqual(ATestGrid.ToList()[1], ATestGridToTick.ToList()[1]);
            CollectionAssert.AreEqual(ATestGrid.ToList()[2], ATestGridToTick.ToList()[2]);
            CollectionAssert.AreEqual(ATestGrid.ToList()[3], ATestGridToTick.ToList()[3]);
            CollectionAssert.AreEqual(ATestGrid.ToList()[4], ATestGridToTick.ToList()[4]);
        }

        [TestMethod]
        public void TickTestToadFormation()
        {
            GameOfLife ATestGrid = new GameOfLife(6, 6);
            ATestGrid[2, 2] = true;
            ATestGrid[2, 3] = true;
            ATestGrid[2, 4] = true;
            ATestGrid[3, 1] = true;
            ATestGrid[3, 2] = true;
            ATestGrid[3, 3] = true;
            GameOfLife ATestGridToTick = new GameOfLife(6, 6);
            ATestGridToTick[1, 3] = true;
            ATestGridToTick[2, 1] = true;
            ATestGridToTick[2, 4] = true;
            ATestGridToTick[3, 1] = true;
            ATestGridToTick[3, 4] = true;
            ATestGridToTick[4, 2] = true;
            ATestGridToTick.Tick();
            CollectionAssert.AreEqual(ATestGrid.ToList()[0], ATestGridToTick.ToList()[0]);
            CollectionAssert.AreEqual(ATestGrid.ToList()[1], ATestGridToTick.ToList()[1]);
            CollectionAssert.AreEqual(ATestGrid.ToList()[2], ATestGridToTick.ToList()[2]);
            CollectionAssert.AreEqual(ATestGrid.ToList()[3], ATestGridToTick.ToList()[3]);
            CollectionAssert.AreEqual(ATestGrid.ToList()[4], ATestGridToTick.ToList()[4]);
            CollectionAssert.AreEqual(ATestGrid.ToList()[5], ATestGridToTick.ToList()[5]);
        }

        [TestMethod]
        public void TickTestThreeStepFormationPart1()
        {
            GameOfLife ATestGridOneTick = new GameOfLife(5, 4);
            ATestGridOneTick[2, 1] = true;
            ATestGridOneTick[2, 2] = true;
            GameOfLife ATestGridToTick = new GameOfLife(5, 4);
            ATestGridToTick[1, 2] = true;
            ATestGridToTick[2, 1] = true;
            ATestGridToTick[3, 1] = true;
            ATestGridToTick.Tick();
            CollectionAssert.AreEqual(ATestGridOneTick.ToList()[0], ATestGridToTick.ToList()[0]);
            CollectionAssert.AreEqual(ATestGridOneTick.ToList()[1], ATestGridToTick.ToList()[1]);
            CollectionAssert.AreEqual(ATestGridOneTick.ToList()[2], ATestGridToTick.ToList()[2]);
            CollectionAssert.AreEqual(ATestGridOneTick.ToList()[3], ATestGridToTick.ToList()[3]);
            CollectionAssert.AreEqual(ATestGridOneTick.ToList()[4], ATestGridToTick.ToList()[4]);
        }

        [TestMethod]
        public void TickTestThreeStepFormationPart2()
        {
            GameOfLife ATestGridTwoTick = new GameOfLife(5, 4);
            GameOfLife ATestGridToTick = new GameOfLife(5, 4);
            ATestGridToTick[1, 2] = true;
            ATestGridToTick[2, 1] = true;
            ATestGridToTick[3, 1] = true;
            ATestGridToTick.Tick();
            ATestGridToTick.Tick();
            CollectionAssert.AreEqual(ATestGridTwoTick.ToList()[0], ATestGridToTick.ToList()[0]);
            CollectionAssert.AreEqual(ATestGridTwoTick.ToList()[1], ATestGridToTick.ToList()[1]);
            CollectionAssert.AreEqual(ATestGridTwoTick.ToList()[2], ATestGridToTick.ToList()[2]);
            CollectionAssert.AreEqual(ATestGridTwoTick.ToList()[3], ATestGridToTick.ToList()[3]);
            CollectionAssert.AreEqual(ATestGridTwoTick.ToList()[4], ATestGridToTick.ToList()[4]);
        }
    }
}