using System;
using cards;

namespace Freecell
{
  internal class FinalCells
  {
    private int[] myCells;

    public FinalCells()
    {
      myCells = new int[4];
      for (int j = 0; j < 4; j++)
        myCells[j] = -1;
    }

    public FinalCells(String fc)
    {
      // FREECELLS:1,2,3,4
      myCells = new int[4];
      String rel;
      String[] nums;
      char[] sep = { ',' };
      if (fc.IndexOf("FINALCELLS:") == 0)
      {
        rel = fc.Substring(11);
        nums = rel.Split(sep);
        for (int j = 0; j < 4 && j < nums.Length; j++)
        {
          myCells[j] = Int32.Parse(nums[j]);
        }
      }
    }

    public int[] getOccupants()
    {
      return myCells;
    }

    public int removeCard(int col)
    {
      return -1;
    }

    public void insertCard(int col, int card)
    {
      myCells[col] = card;
    }

    public bool makePossibleMove(int col, int card, bool limited)
    {
      bool succ = false;
      if (!limited || Cards.getCardFaceValue(card) <= getMinCardValue())
      {
        if (((myCells[col] == -1) && (card < 4)) ||
          ((myCells[col] != -1) && cards.Cards.followsInSuit(card, myCells[col])))
        {
          myCells[col] = card;
          succ = true;
        }
      }
      return succ;
    }

    public bool makePossibleMove(int col, int card)
    {
      return makePossibleMove(col, card, false);
    }

    private int getMinCardValue()
    {
      int min = -1;
      for (int j = 0; j < 4; j++)
      {
        if (myCells[j] == -1)
        {
          min = 0;
          break;
        }
        else
        {
          int k = Cards.getCardFaceValue(myCells[j]);
          if ((min == -1) || (k < min))
          {
            min = k;
          }
        }
      }
      return min + 2;
    }

    public override String ToString()
    {
      return "FINALCELLS:" + myCells[0] + "," + myCells[1] + "," + myCells[2] + "," + myCells[3];
    }
  }
}
