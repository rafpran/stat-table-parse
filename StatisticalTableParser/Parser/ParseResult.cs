using System.Collections.Generic;
using StatisticalTableParser.Model;

namespace StatisticalTableParser.Parser
{
  public class ParseResult
  {
    public List<Table> Tables { get; } = new List<Table>();

    internal Table AddTable()
    {
      var table = new Table();
      Tables.Add(table);
      return table;
    }
  }
}