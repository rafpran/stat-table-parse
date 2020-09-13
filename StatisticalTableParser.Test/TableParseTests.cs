using System.Linq;
using NUnit.Framework;
using StatisticalTableParser.Parser;
using StatisticalTableParser.Statistics;

namespace StatisticalTableParser.Test
{
  public class TableParseTests
  {
    // private const string doublePureTable = "double-pure-table.txt";
    private const string jitteredMultiTable = "jittered-multiline-table.txt";
    private const string jitteredTable = "jittered-table.txt";
    private const string pureMultiTable = "pure-multiline-table.txt";
    private const string pureTable = "pure-table.txt";

    [Test]
    // [TestCase(doublePureTable, new[] { 8, 20, 31 })]
    [TestCase(jitteredMultiTable, new[] { 7, 18, 28 })]
    [TestCase(jitteredTable, new[] { 8, 20, 31 })]
    [TestCase(pureMultiTable, new[] { 7, 18, 28 })]
    [TestCase(pureTable, new[] { 8, 20, 31 })]
    public void TestColumns(string tableName, int[] expectedColumns)
    {
      var path = TestContext.CurrentContext.TestDirectory + "../../../../resources/" + tableName;
      var ts = new TableStatistics();
      ts.Read(path);
      var columns = ts.Columns(2).Select(c => c.End);
      CollectionAssert.AreEqual(expectedColumns, columns);
    }


    [Test]
    // [TestCase(doublePureTable, new[] { "Header1", "Header2", "Header3" })]
    [TestCase(jitteredMultiTable, new[] { "Header1", "Header2", "Header3" })]
    [TestCase(jitteredTable, new[] { "Header 1", "Header 2", "Header 3" })]
    [TestCase(pureMultiTable, new[] { "Header1", "Header2", "Header3" })]
    [TestCase(pureTable, new[] { "Header 1", "Header 2", "Header 3" })]
    public void TestHeader(string tableName, string[] expectedColumns)
    {
      var path = TestContext.CurrentContext.TestDirectory + "../../../../resources/" + tableName;
      var ts = new TableStatistics();
      ts.Read(path);
      var columns = ts.Columns(2);
      var p = new TableParser();
      var res = p.Read(ts, path);

      CollectionAssert.AreEqual(expectedColumns, res.Tables[0].Rows[0].Cells.Select(x => x.Value.Trim()).ToArray());
    }

        [Test]
    // [TestCase(doublePureTable, new[] { "Header1", "Header2", "Header3" })]
    [TestCase(jitteredMultiTable, new[] { "Header1", "Header2", "Header3" })]
    [TestCase(jitteredTable, new[] { "Header 1", "Header 2", "Header 3" })]
    [TestCase(pureMultiTable, new[] { "Header1", "Header2", "Header3" })]
    [TestCase(pureTable, new[] { "Header 1", "Header 2", "Header 3" })]
    public void TestContent(string tableName, string[] expectedColumns)
    {
      var path = TestContext.CurrentContext.TestDirectory + "../../../../resources/" + tableName;
      var ts = new TableStatistics();
      ts.Read(path);
      var p = new TableParser();
      var res = p.Read(ts, path);

      CollectionAssert.AreEqual(expectedColumns, res.Tables[0].Rows[0].Cells.Select(x => x.Value.Trim()).ToArray());
    }
  }
}