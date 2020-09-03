using NUnit.Framework;
using StatisticalTableParser.Statistics;

namespace StatisticalTableParser.Test
{
    public class TableParseTests
    {
        private const string doublePureTable = "double-pure-table.txt";
        private const string jitteredMultiTable = "jittered-multiline-table.txt";
        private const string jitteredTable = "jittered-table.txt";
        private const string pureMultiTable = "pure-multiline-table.txt";
        private const string pureTable = "pure-table.txt";

        [Test]
        [TestCase(doublePureTable, new[] { 0, 8, 20 })]
        [TestCase(jitteredMultiTable, new[] { 0, 7, 18 })]
        [TestCase(jitteredTable, new[] { 0, 8, 20 })]
        [TestCase(pureMultiTable, new[] { 0, 7, 18 })]
        [TestCase(pureTable, new[] { 0, 8, 20 })]
        public void TestColumns(string tableName, int[] expectedColumns)
        {
            var path = TestContext.CurrentContext.TestDirectory + "../../../../resources/" + tableName;
            var stats = TableStatistics.Read(path);
            var columns = TableStatistics.Columns(stats, 2);
            CollectionAssert.AreEqual(expectedColumns, columns);
        }
    }
}