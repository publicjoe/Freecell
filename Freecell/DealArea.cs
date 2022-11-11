using System;
using cards;
using System.Text;

namespace Freecell
{
  internal class DealArea
  {
    private int[][] columns;
    private int[] colSizes;
    const int MAX_COL = 26;
    public DealArea(Deal deal)
    {
      columns = new int[8][];
      colSizes = new int[8];
      for (int j = 0; j < 8; j++)
      {
        columns[j] = new int[MAX_COL];
        int[] col = deal.getColumn(j);
        for (int k = 0; k < col.Length; k++)
        {
          columns[j][k] = col[k];
        }
        colSizes[j] = col.Length;
      }
    }

    public DealArea(String[] dealCols)
    {
      columns = new int[8][];
      colSizes = new int[8];
      String[] parts;
      char[] sep = { ':', ',' };
      for (int j = 0; j < 8; j++)
      {
        columns[j] = new int[MAX_COL];
        colSizes[j] = 0;

        // Parse the col stirng and init the col
        parts = dealCols[j].Split(sep);
        colSizes[j] = Int32.Parse(parts[2]);
        if (parts[0].Equals("DEALAREA") && (parts.Length == colSizes[j] + 3))
        {
          // Things are Ok
          for (int k = 0; k < colSizes[j]; k++)
            columns[j][k] = Int32.Parse(parts[k + 3]);
        }
      }
    }

    public bool makePossibleMove(int fromCol, int toCol, int freeCells)
    {
      bool succ = false;
      if (colSizes[fromCol] != 0)
      {
        int fromCard = removeCard(fromCol);
        int toCard = -1;
        if (colSizes[toCol] != 0)
          toCard = columns[toCol][colSizes[toCol] - 1];
        if ((colSizes[toCol] == 0) || isValidMove(fromCard, toCard))
        {
          if (colSizes[toCol] != 0)
          {
            insertCard(toCol, fromCard);
          }
          else
          {
            // Try to see if a multi-column move is possible
            int max = freeCells + 1;
            int k = colSizes[fromCol] - 1;
            int num = 1;
            int last = fromCard;
            while ((k >= 0) && (num < max))
            {
              int curr = columns[fromCol][k];
              if (Cards.followsAltCol(curr, last))
              {
                k--;
                last = curr;
                num++;
              }
              else
                break;
            }
            bool multi = false;
            if (num > 1)
            {
              // Ask for a choice
              if (System.Windows.Forms.MessageBox.Show("Move Column", "Move Column", System.Windows.Forms.MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
              {
                multi = true;
              }
            }
            if (!multi)
              insertCard(toCol, fromCard);
            else
            {
              // Move the column
              for (int j = k + 1; j < colSizes[fromCol]; j++)
              {
                insertCard(toCol, columns[fromCol][j]);
              }
              insertCard(toCol, fromCard);
              // Reduce the from column size
              colSizes[fromCol] -= (num - 1);
            }

          }
          succ = true;
        }
        else
        {
          insertCard(fromCol, fromCard);
          // Try for a multi-column move
          if (freeCells > 0)
          {
            int max = freeCells + 1;
            int cardVal = Cards.getCardFaceValue(toCard) - 1;
            if (cardVal > 0)
            {
              // Look for card with face value = CardVal
              int k = colSizes[fromCol] - 2;
              int num = 1;
              int last = fromCard;
              while (k >= 0 && num < max)
              {
                num++;
                int curr = columns[fromCol][k];
                if (Cards.followsAltCol(curr, last))
                {
                  last = curr;
                }
                else break;
                if (Cards.getCardFaceValue(curr) == cardVal)
                {
                  // Found a successful sequence
                  // Do the move
                  // Ensure that they are different colours
                  if (!Cards.ofSameColor(curr, toCard))
                  {
                    for (int j = k; j < colSizes[fromCol]; j++)
                    {
                      insertCard(toCol, columns[fromCol][j]);
                    }
                    // Reduce the from column size
                    colSizes[fromCol] -= num;
                    succ = true;
                  }
                  break;
                }
                k--;
              }
            }
          }
        }
      }
      return succ;
    }

    public bool makePossibleMoveCard(int toCol, int card)
    {
      bool succ = false;
      int fromCard = card;
      int toCard = -1;
      if (colSizes[toCol] != 0)
        toCard = columns[toCol][colSizes[toCol] - 1];
      if ((colSizes[toCol] == 0) || (toCard == -1) || isValidMove(fromCard, toCard))
      {
        insertCard(toCol, fromCard);
        succ = true;
      }
      return succ;
    }

    public bool isValidMove(int fromCard, int toCard)
    {
      bool valid = false;
      cards.Color fromColor = Cards.getCardColor(fromCard);
      cards.Color toColor = Cards.getCardColor(toCard);

      if (fromColor != toColor)
      {
        valid = Cards.follows(toCard, fromCard);
      }
      return valid;
    }

    public void insertCard(int col, int card)
    {
      columns[col][colSizes[col]] = card;
      colSizes[col]++;
    }

    public int removeCard(int col)
    {
      int len = colSizes[col];
      int card = -1;
      if (len > 0)
      {
        colSizes[col] = colSizes[col] - 1;
        card = columns[col][colSizes[col]];
      }
      return card;
    }

    public int[] getCol(int index)
    {
      int[] col = new int[colSizes[index]];
      for (int j = 0; j < col.Length; j++)
        col[j] = columns[index][j];
      return col;
    }

    public override String ToString()
    {
      StringBuilder sb = new StringBuilder();
      for (int j = 0; j < 8; j++)
      {
        if (j != 0)
          sb.Append("\n");
        sb.Append("DEALAREA:");
        sb.Append(j);
        sb.Append(":");
        sb.Append(colSizes[j]);
        sb.Append(":");
        for (int k = 0; k < colSizes[j]; k++)
        {
          if (k != 0)
            sb.Append(",");
          sb.Append(columns[j][k]);
        }
      }
      return sb.ToString();
    }
  }
}
