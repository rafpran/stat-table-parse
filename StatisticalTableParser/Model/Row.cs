using System.Collections.Generic;

namespace StatisticalTableParser.Model
{
  public class Row
  {
    public List<Cell> Cells { get; } = new List<Cell>();
  }
}