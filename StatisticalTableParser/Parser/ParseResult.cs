
using System.Collections.Generic;
using StatisticalTableParser.Model;

namespace StatisticalTableParser.Parser
{
  public class ParseResult
  {
    public List<Table> Tables { get; } = new List<Table>();
  }
}