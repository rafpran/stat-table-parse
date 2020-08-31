using System.Collections.Generic;
using System;
using System.IO;

namespace StatisticalTableParser.Statistics
{
  public class TableStatistics
  {
    public List<int> Stats { get; } = new List<int>();

    public static TableStatistics Read(string path)
    {
      var stats = new TableStatistics();
      using (var sr = new StreamReader(path))
      {

        while (sr.Peek() >= 0)
        {
          var line = sr.ReadLine();
          stats.AddLine(line);

        }
      }
      return stats;
    }

    internal void AddLine(string line)
    {
      EnsureLength(line);
      for (var i = 0; i < line.Length; i++)
      {
        var ch = line[i];
        if (!Char.IsWhiteSpace(ch))
        {
          Stats[i]++;
        }
      }
    }

    protected void EnsureLength(string line)
    {
      if (Stats.Count < line.Length)
      {
        for (long i = Stats.Count; i < line.Length; i++)
        {
          Stats.Add(0);
        }
      }
    }
  }
}