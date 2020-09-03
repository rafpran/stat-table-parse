using NUnit.Framework;
using StatisticalTableParser.Statistics;
using System.Collections.Generic;

namespace StatisticalTableParser.Test
{
    public class TableStatisticsTests
    {


        [Test]
        public void TestSimpleHeader()
        {
            var stats = new TableStatistics();
            Assert.AreEqual(0, stats.Stats.Count);
            const string Line = "H1 H2 H3";
            TableStatistics.AddLine(stats, Line);
            Assert.AreEqual(Line.Length, stats.Stats.Count);
            CollectionAssert.AreEqual(new[] { 1, 1, 0, 1, 1, 0, 1, 1 }, stats.Stats);
        }

        [Test]
        public void TestMulti()
        {
            var stats = new TableStatistics();
            Assert.AreEqual(0, stats.Stats.Count);
            const string Line1 = "Header 1   Header 2    Header 3";
            const string Line2 = "Row 11      Row 12      Row 13";
            const string Line3 = "Row 21      Row 22      Row 23";
            TableStatistics.AddLine(stats, Line1);
            TableStatistics.AddLine(stats, Line2);
            TableStatistics.AddLine(stats, Line3);
            Assert.AreEqual(Line1.Length, stats.Stats.Count);
            CollectionAssert.AreEqual(new[] { 3, 3, 3, 1, 3, 3, 0, 1, 0, 0, 0, 1, 3, 3, 3, 1, 3, 2, 1, 0, 0, 0, 0, 1, 3, 3, 3, 1, 3, 2, 1 }, stats.Stats);
        }

        [Test]
        public void TestEnsureRange()
        {
            var list = new List<int> { 1, 2, 3 };
            TableStatistics.EnsureLength(list, 6);
            CollectionAssert.AreEqual(new List<int> { 1, 2, 3, 0, 0, 0 }, list);
        }
    }
}