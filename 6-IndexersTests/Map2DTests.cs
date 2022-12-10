namespace Indexers
{
    using System;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class Map2DTests
    {
        private readonly int[] seven = new int[] { 7, 14, 21, 28, 35, 42, 49, 56, 63, 70 };
        private IMap2D<int, int, int> pitagoricTable;

        // Called once before each test after the constructor
        [TestInitialize]
        public void TestInitialize()
        {
            this.pitagoricTable = new Map2D<int, int, int>();
            this.pitagoricTable.Fill(
                Enumerable.Range(1, 10),
                Enumerable.Range(1, 10),
                (i, j) => i * j);
            Console.WriteLine(pitagoricTable.ToString());
        }

        [TestMethod]
        public void FillAndIndexerTest()
        {
            for (int i = 1; i <= 10; i++)
            {
                for (int j = 1; j <= 10; j++)
                {
                    Assert.AreEqual(i * j, this.pitagoricTable[i, j]);
                }
            }
            //Console.WriteLine(pitagoricTable.ToString());
        }

        [TestMethod]
        public void GetRowTest()
        {
            if (!this.pitagoricTable.GetRow(7).Select(t => t.Item2).SequenceEqual(this.seven))
            {
                Assert.Fail("Wrong implementation");
            }
            //Console.WriteLine(pitagoricTable.ToString());
        }

        [TestMethod]
        public void GetColumnTest()
        {
            if (!this.pitagoricTable.GetColumn(7).Select(t => t.Item2).SequenceEqual(this.seven))
            {
                Assert.Fail("Wrong implementation");
            }
            //Console.WriteLine(pitagoricTable.ToString());
        }
    }
}
