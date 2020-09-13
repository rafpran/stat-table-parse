using System.IO;
using StatisticalTableParser.Statistics;

namespace StatisticalTableParser.Parser
{
  public class TableParser
  {
    public ParseResult Read(TableStatistics stats, string path)
    {
      var results = new ParseResult();

      var table = results.AddTable();
      using (var sr = new StreamReader(path))
      {
        while (sr.Peek() >= 0)
        {
          var row = table.AddRow();
          var line = sr.ReadLine();
          row.Parse(stats, line);

        }
      }
      return results;
    }
  }
}