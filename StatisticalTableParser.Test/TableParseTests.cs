using NUnit.Framework;
using System.IO;
using System.Text.Json;
using StatisticalTableParser.Statistics;
using StatisticalTableParser.Parser;

namespace StatisticalTableParser.Test
{
  public class TableParseTests
  {
    private string[] AllTables = new[]{
      "double-pure-table.txt",
      "jittered-multiline-table.txt",
      "jittered-table.txt",
      "pure-multiline-table.txt",
      "pure-table.txt"
    };

    [Test]
    public void Test1()
    {

      foreach (var tableName in AllTables)
      {
        var path = TestContext.CurrentContext.TestDirectory + "../../../../resources/" + tableName;

        var stats = TableStatistics.Read(path);
        TestContext.Progress.WriteLine(JsonSerializer.Serialize(stats.Stats));
        using (var sr = new StreamReader(path))
        {
          var state = new ParserState();
          while (sr.Peek() >= 0)
          {
            var line = sr.ReadLine();

            TestContext.Progress.WriteLine(line);
          }
          
        }
      }
    }
  }
}