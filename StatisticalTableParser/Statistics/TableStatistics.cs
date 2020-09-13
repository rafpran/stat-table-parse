using System.Collections.Generic;
using System.IO;

namespace StatisticalTableParser.Statistics
{
  public class TableStatistics
  {
    internal List<int> Stats { get; } = new List<int>();

    public void Read(string path)
    {
      using (var sr = new StreamReader(path))
      {

        while (sr.Peek() >= 0)
        {
          var line = sr.ReadLine();
          AddLine(line);
        }
      }
    }

    internal void AddLine(string line)
    {
      var trimmed = line.Trim();
      Stats.EnsureLength(trimmed.Length);
      for (var i = 0; i < trimmed.Length; i++)
      {
        var ch = trimmed[i];
        if (!char.IsWhiteSpace(ch))
        {
          Stats[i]++;
        }
      }
    }


    public List<TableColumn> Columns(int dist)
    {
      var result = new List<TableColumn>();
      var whitespacesLength = 0;
      var previous = 0;
      for (int i = 0; i < Stats.Count; i++)
      {
        int val = Stats[i];
        if (val == 0)
        {
          whitespacesLength++;
        }
        else
        {
          whitespacesLength = 0;
        }
        if (whitespacesLength == dist)
        {

          var end = i - dist + 1;
          result.Add(new TableColumn(previous, end));
          previous = end;
        }
      }

      if (previous < Stats.Count){
        result.Add(new TableColumn(previous, Stats.Count - 1));
      }

      return result;
    }
  }
}