using System;

namespace Freecell
{
  /// <summary>
  /// Summary description for DealProducer.
  /// </summary>
  public class DealProducer
  {
    private DealProducer()
    {
    }

    static public Deal getRandomDeal()
    {
      int[] deal = new int[Deal.DECK_SIZE];
      bool[] dealt = new bool[Deal.DECK_SIZE];
      for (int j = 0; j < Deal.DECK_SIZE; j++)
        dealt[j] = false;
      int totalDealt = 0;
      Random rnd = new System.Random((int)(System.DateTime.Now.Ticks % Int32.MaxValue));
      while (totalDealt < Deal.DECK_SIZE)
      {
        int next = rnd.Next(Deal.DECK_SIZE);
        while (dealt[next])
        {
          next = (next + 1) % Deal.DECK_SIZE;
        }
        dealt[next] = true;
        deal[totalDealt] = next;
        totalDealt++;
      }
      return new Deal(deal);
    }
  }
}
