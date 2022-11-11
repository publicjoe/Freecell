using System;

namespace Freecell
{
  internal class FreeCells
  {
    private int[] myCells;
    private int myFreeCount;

    public FreeCells()
    {
      myCells = new int[4];
      for (int j = 0; j < 4; j++)
        myCells[j] = -1;
      myFreeCount = 4;
    }

    public FreeCells(String fc)
    {
      // FREECELLS:1,2,3,4
      myCells = new int[4];
      String rel;
      String[] nums;
      char[] sep = { ',' };
      myFreeCount = 4;
      if (fc.IndexOf("FREECELLS:") == 0)
      {
        rel = fc.Substring(10);
        nums = rel.Split(sep);
        for (int j = 0; j < 4 && j < nums.Length; j++)
        {
          myCells[j] = Int32.Parse(nums[j]);
          if (myCells[j] != -1)
            myFreeCount--;
        }
      }
    }

    public int removeCard(int col)
    {
      int card = myCells[col];
      myCells[col] = -1;
      if (card != -1)
        myFreeCount++;
      return card;
    }

    public void insertCard(int col, int card)
    {
      myCells[col] = card;
      myFreeCount--;
    }

    public bool makePossibleMove(int col, int card)
    {
      bool succ = false;
      if (myFreeCount != 0)
      {
        if (myCells[col] == -1)
        {
          insertCard(col, card);
          succ = true;
        }
      }
      return succ;
    }

    public int[] getOccupants()
    {
      return myCells;
    }

    public int getFreeCount()
    {
      return myFreeCount;
    }

    public override String ToString()
    {
      return "FREECELLS:" + myCells[0] + "," + myCells[1] + "," + myCells[2] + "," + myCells[3];
    }
  }
}
