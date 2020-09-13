using System;
using System.Collections.Generic;
using System.Linq;
using StatisticalTableParser.Statistics;

namespace StatisticalTableParser.Model
{
  public class Row
  {
    public List<Cell> Cells { get; } = new List<Cell>();

    internal void Parse(TableStatistics stats, string line)
    {
      if (string.IsNullOrWhiteSpace(line))
        return;
      var columns = stats.Columns(2);
      foreach (var column in columns)
      {
        var end = Math.Min(line.Length, column.End + 1) - column.Start;
        if (end <= 0){
          Cells.Add(new Cell(""));
          break;
        }
        string v = line.Substring(column.Start, end).Trim();

        Cells.Add(new Cell(v));
      }
      // if (cur < line.Length)
      //   Cells.Add(new Cell(line.Substring(cur)));
    }

    override public string ToString()
    {
      return string.Join(" ", Cells.Select(x => x.Value));
    }
  }
}