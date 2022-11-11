using System;

namespace Freecell
{
  public class Deal
  {
    public const int DECK_SIZE = 52;
    private int[] myDeal;
    private int[] offsets = { 0, 7, 14, 21, 28, 34, 40, 46, 52 };
    public Deal(int[] deal)
    {
      myDeal = new int[DECK_SIZE];
      for (int j = 0; j < deal.Length; j++)
      {
        myDeal[j] = deal[j];
      }
    }

    public int[] getColumn(int index)
    {
      int len = offsets[index + 1] - offsets[index];
      int[] colCards = new int[len];
      for (int j = 0; j < len; j++)
      {
        colCards[j] = myDeal[j + offsets[index]];
      }
      return colCards;
    }
  }
}
