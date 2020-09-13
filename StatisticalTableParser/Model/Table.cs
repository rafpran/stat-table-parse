using System;
using System.Collections.Generic;
using System.Linq;

namespace StatisticalTableParser.Model
{
  public class Table
  {
    public List<Row> Rows { get; } = new List<Row>();

    public Row AddRow()
    {
      var row = new Row();
      Rows.Add(row);
      return row;
    }

    override public string ToString(){
      return string.Join(Environment.NewLine, Rows.Select(x => x.ToString()));
    }
  }
}