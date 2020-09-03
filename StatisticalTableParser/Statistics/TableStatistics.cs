using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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
                    AddLine(stats, line);

                }
            }
            return stats;
        }

        internal static void AddLine(TableStatistics stats, string line)
        {
            var trimmed = line.Trim();
            EnsureLength(stats.Stats, trimmed.Length);
            for (var i = 0; i < trimmed.Length; i++)
            {
                var ch = trimmed[i];
                if (!char.IsWhiteSpace(ch))
                {
                    stats.Stats[i]++;
                }
            }
        }

        internal static void EnsureLength(List<int> s, int length)
        {
            if (s.Count < length)
            {
                s.AddRange(Enumerable.Range(0, length - s.Count).Select( _ => 0));
            }
        }

        public static List<int> Columns(TableStatistics stats, int dist)
        {
            var result = new List<int> { 0 };
            var whitespacesLength = 0;
            for (int i = 0; i < stats.Stats.Count; i++)
            {
                int val = stats.Stats[i];
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
                    result.Add(i - dist + 1);
                }
            }

            return result;
        }
    }
}