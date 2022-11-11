using System;

namespace Freecell
{
  internal class Move
  {
    private bool isBegin = true;
    public int fromCol;
    public int toCol;
    public bool isDone = false;

    public void setColumn(int col)
    {
      if (col >= 0)
      {
        if (isBegin)
        {
          isBegin = false;
          fromCol = col;
        }
        else
        {
          isDone = true;
          toCol = col;
        }
      }
    }

    public void clear()
    {
      isDone = false;
      isBegin = true;
    }

    public bool isFirst()
    {
      return isBegin;
    }
  }
}
