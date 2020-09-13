using NUnit.Framework;
using System.Linq;

namespace StatisticalTableParser.Test
{
  public class ListExtensionsTests
  {

    [Test]
    [TestCase(new[] { 1, 2, 3 }, 6, new[] { 1, 2, 3, 0, 0, 0 })]
    [TestCase(new[] { 1, 2, 3 }, 4, new[] { 1, 2, 3, 0 })]
    [TestCase(new[] { 1, 2, 3 }, 3, new[] { 1, 2, 3 })]
    [TestCase(new[] { 1, 2, 3 }, 2, new[] { 1, 2, 3 })]
    [TestCase(new[] { 1, 2, 3 }, 1, new[] { 1, 2, 3 })]
    public void TestEnsureRange(int[] given, int length, int[] expected)
    {
      var list = given.ToList();
      list.EnsureLength(length);
      CollectionAssert.AreEqual(expected, list.ToArray());
    }
  }
}