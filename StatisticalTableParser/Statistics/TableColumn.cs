namespace StatisticalTableParser.Statistics{
  public class TableColumn{
    public int Start {get;}
    public int End {get;}

    public TableColumn(int start, int end)
    {
      Start = start;
      End = end;
    }
  }
}