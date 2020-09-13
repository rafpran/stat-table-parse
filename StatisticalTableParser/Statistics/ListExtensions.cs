using System.Collections.Generic;
using System.Linq;

namespace StatisticalTableParser
{
  public static class ListExtensions
  {
    public static void EnsureLength(this List<int> list, int length)
    {
      if (list.Count < length)
      {
        list.AddRange(Enumerable.Range(0, length - list.Count).Select(_ => 0));
      }
    }
  }
}