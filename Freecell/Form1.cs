using System;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using Publicjoe.Windows.Cards;

namespace Freecell
{
  public partial class Form1 : Form
  {
    private Card cardDrawing;
    private Board myBoard;
    private Move myCurrentMove;

    private int lastX = -1;
    private int lastY = -1;

    private long lastTime = 0;

    public Form1()
    {
      InitializeComponent();

      cardDrawing = new Card();
      myCurrentMove = new Move();

      this.Invalidate(true);
    }

    private void FreePanel_Paint(object sender, PaintEventArgs e)
    {
      if (myBoard != null)
      {
        cardDrawing.Begin(e.Graphics);

        try
        {
          int[] cell = myBoard.getFreeCellOccupants();
          int wdOffset = 74;
          int startX = 1;
          int startY = 1;
          for (int j = 0; j < cell.Length; j++)
          {
            Graphics g = FreePanel.CreateGraphics();

            g.DrawRectangle(new Pen(Color.LimeGreen), new Rectangle(startX + wdOffset * j, startY, 71, 96));

            if (cell[j] != -1)
            {
              cardDrawing.DrawCard( new Point( startX + wdOffset * j, startY ), cell[j]);
            }
          }
        }
        catch (Exception f)
        {
          Console.WriteLine(f.StackTrace);
        }
        finally
        {
          //gr.ReleaseHdc(dc);
        }
      }
      else
      {
        int wdOffset = 74;
        int startX = 1;
        int startY = 1;
        for (int j = 0; j < 4; j++)
        {
          Graphics g = FreePanel.CreateGraphics();

          g.DrawRectangle(new Pen(Color.LimeGreen), new Rectangle(startX + wdOffset * j, startY, 71, 96));
        }
      }
    }

    private void FinalPanel_Paint(object sender, PaintEventArgs e)
    {
      if (myBoard != null)
      {
        cardDrawing.Begin(e.Graphics);

        try
        {
          int[] cell = myBoard.getFinalCellOccupants();
          int wdOffset = 74;
          int startX = 1;
          int startY = 1;
          for (int j = 0; j < cell.Length; j++)
          {
            Graphics g = FinalPanel.CreateGraphics();

            g.DrawRectangle(new Pen(Color.LimeGreen), new Rectangle(startX + wdOffset * j, startY, 71, 96));

            if (cell[j] != -1)
            {
              cardDrawing.DrawCard( new Point( startX + wdOffset * j, startY ), cell[j]);
            }
          }
        }
        catch (Exception f)
        {
          Console.WriteLine(f.StackTrace);
        }
        finally
        {
          //gr.ReleaseHdc(dc);
        }
      }
      else
      {
        int wdOffset = 74;
        int startX = 1;
        int startY = 1;
        for (int j = 0; j < 4; j++)
        {
          Graphics g = FinalPanel.CreateGraphics();

          g.DrawRectangle(new Pen(Color.LimeGreen), new Rectangle(startX + wdOffset * j, startY, 71, 96));
        }
      }
    }

    private void DealAreaPanel_Paint(object sender, PaintEventArgs e)
    {
      cardDrawing.Begin(e.Graphics);
      repaintCards();
    }

    private void FreePanel_MouseDown(object sender, MouseEventArgs e)
    {
      bool done = false;
      int col = getColumnFromCoordinate(e.X);
      if ((col >= 0) && (col < 4))
      {
        if ((e.X == lastX) && ((System.DateTime.Now.Ticks - lastTime) < 3000000))
        {
          myCurrentMove.clear();
          done = myBoard.move(col, false);
        }
        else
        {
          lastX = e.X;
          lastTime = System.DateTime.Now.Ticks;
          myCurrentMove.setColumn(col);
          if (myCurrentMove.isDone)
          {
            done = myBoard.move(myCurrentMove.fromCol, myCurrentMove.toCol);
            myCurrentMove.clear();
          }
        }
        if (done)
          doOnMove(sender, done);
        else if (!myCurrentMove.isFirst())
        {
          setUpArrowCursor();
        }
        else
          this.Cursor = Cursors.Arrow;
      }
    }

    private void FinalPanel_MouseDown(object sender, MouseEventArgs e)
    {
      int col = getColumnFromCoordinate(e.X);
      if ((col >= 0) && (col < 4))
      {
        if (!myCurrentMove.isFirst())
        {
          myCurrentMove.setColumn(col + 4);
          bool done = myBoard.move(myCurrentMove.fromCol, myCurrentMove.toCol);
          myCurrentMove.clear();
          doOnMove(sender, done);
        }
      }
    }

    private void DealAreaPanel_MouseDown(object sender, MouseEventArgs e)
    {
      bool done = false;
      int col = getColumnFromCoordinate(e.X);
      if (col >= 0)
      {
        if ((e.X == lastX) && ((System.DateTime.Now.Ticks - lastTime) < 3000000))
        {
          myCurrentMove.clear();
          done = myBoard.move(col + 8, false);
        }
        else
        {
          lastX = e.X;
          lastTime = System.DateTime.Now.Ticks;
          myCurrentMove.setColumn(col + 8);
          if (myCurrentMove.isDone)
          {
            done = myBoard.move(myCurrentMove.fromCol, myCurrentMove.toCol);
            myCurrentMove.clear();
          }
        }
        if (done)
          doOnMove(sender, done);
        else if (!myCurrentMove.isFirst())
        {
          setUpArrowCursor();
        }
        else
          this.Cursor = Cursors.Arrow;
      }
    }

    private void repaintCards()
    {
      if (myBoard != null)
      {
        int htOffset = 25;
        int wdOffset = 79;
        for (int i = 0; i < 8; i++)
        {
          int[] col = myBoard.getDealAreaCol(i);
          for (int j = 0; j < col.Length; j++)
          {
            cardDrawing.DrawCard( new Point(5 + i * wdOffset, 5 + j * htOffset), col[j]);
          }
        }
      }
    }

    private void doOnMove(object sender, bool done)
    {
      if (done)
      {
        this.Cursor = Cursors.Arrow;
        myBoard.moveAuto();
        Control sc = (Control)sender;
        sc.Parent.Invalidate(true);
      }
      else
      {
        this.Cursor = Cursors.Arrow;
      }
    }

    private void setUpArrowCursor()
    {
      this.Cursor = Cursors.UpArrow;
    }

    private int getColumnFromCoordinate(int x)
    {
      if ((x >= 5) && (x < 78))
        return 0;
      else if ((x >= 84) && (x < 157))
        return 1;
      else if ((x >= 163) && (x < 236))
        return 2;
      else if ((x >= 242) && (x < 315))
        return 3;
      else if ((x >= 321) && (x < 396))
        return 4;
      else if ((x >= 400) && (x < 473))
        return 5;
      else if ((x > 479) && (x < 552))
        return 6;
      else if ((x > 558) && (x < 631))
        return 7;
      else
        return -1;
    }

    private void newDealToolStripMenuItem_Click(object sender, EventArgs e)
    {
      try
      {
        Deal deal = DealProducer.getRandomDeal();
        myBoard = new Board(deal);
        this.Invalidate(true);
      }
      catch
      {
      }
    }

    private void loadDealToolStripMenuItem_Click(object sender, EventArgs e)
    {
      OpenFileDialog dlg = new OpenFileDialog();
      dlg.InitialDirectory = "C:\temp";
      dlg.RestoreDirectory = true;
      dlg.Filter = "Deals|*.deal";
      StreamReader str;

      if (dlg.ShowDialog() == DialogResult.OK)
      {
        try
        {
          myBoard = null;
          str = new StreamReader(dlg.FileName);
          myBoard = new Board(str);
          str.Close();
          this.DealAreaPanel.Invalidate();
          this.FinalPanel.Invalidate();
          this.FreePanel.Invalidate();
        }
        catch (Exception f)
        {
          System.Windows.Forms.MessageBox.Show("Error opening file or parsing contents");
        }
      }
    }

    private void saveDealToolStripMenuItem_Click(object sender, EventArgs e)
    {
      SaveFileDialog dlg = new SaveFileDialog();
      dlg.InitialDirectory = "C:\temp";
      dlg.RestoreDirectory = true;
      dlg.Filter = "Deals|*.deal";
      StreamWriter str;
      if (dlg.ShowDialog() == DialogResult.OK)
      {
        str = new StreamWriter(dlg.OpenFile());
        myBoard.saveToFile(str);
        str.Close();
      }
    }

    private void quitToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Application.Exit();
    }

    private void Form1_Resize(object sender, EventArgs e)
    {
      this.DealAreaPanel.Location = new Point(0, 130);
      this.DealAreaPanel.Size = new Size(this.Width, this.Height - 130);
    }
  }
}