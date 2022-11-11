using System;
using System.IO;

namespace Freecell
{	
  /// <summary>
  /// Summary description for Board.
  /// </summary>
  public class Board
	{
		public enum CellType 
		{
			FREE_CELL,
			FINAL_CELL,
			DEAL_AREA,
			UNKNOWN
		};
    
		FreeCells myFreeCells;
		FinalCells myFinalCells;
		DealArea myDealArea;

		public Board(StreamReader st)
		{
			String frc = st.ReadLine();
			myFreeCells = new FreeCells(frc);
			String fnc = st.ReadLine();
			myFinalCells = new FinalCells(fnc);
			String[] dealCols = new String[8];
			for (int j = 0; j < 8; j++)
				dealCols[j] = st.ReadLine();
			myDealArea = new DealArea(dealCols);
		}

		public Board(Deal deal)
		{
			myFreeCells = new FreeCells();
			myFinalCells = new FinalCells();
			myDealArea = new DealArea(deal);
		}

		public void saveToFile(StreamWriter st)
		{
			st.WriteLine(myFreeCells.ToString());
			st.WriteLine(myFinalCells.ToString());
			st.Write(myDealArea.ToString());
			st.Close();
		}

		public CellType getCellType(int colId)
		{
			if ((colId >= 0) && (colId < 4))
				return CellType.FREE_CELL;
			else if ((colId >= 4) && (colId < 8))
				return CellType.FINAL_CELL;
			else if ((colId >= 8) && (colId < 16))
				return CellType.DEAL_AREA;
			else
				return CellType.UNKNOWN;
		}

		public int removeCard(int colId)
		{
			CellType ct = getCellType(colId);
			int card = -1;
			if (ct == CellType.DEAL_AREA)
				card = myDealArea.removeCard(colId-8);
			else if (ct == CellType.FINAL_CELL)
				card = myFinalCells.removeCard(colId-4);
			else if (ct == CellType.FREE_CELL) 
				card = myFreeCells.removeCard(colId);
			return card;
		}

		public void insertCard(int colId, int card)
		{
			CellType ct = getCellType(colId);
			if (ct == CellType.DEAL_AREA)
				myDealArea.insertCard(colId-8, card);
			else if (ct == CellType.FINAL_CELL)
				myFinalCells.insertCard(colId-4, card);
			else if (ct == CellType.FREE_CELL) 
				myFreeCells.insertCard(colId, card);
		}

		public int[] getFreeCellOccupants()
		{
			return myFreeCells.getOccupants();
		}

		public int[] getFinalCellOccupants()
		{
			return myFinalCells.getOccupants();
		}

		public int[] getDealAreaCol(int index)
		{
			return myDealArea.getCol(index);
		}

		public bool makePossibleMove(int fromColId, int toColId)
		{
			CellType fromCell = getCellType(fromColId);
			CellType toCell = getCellType(toColId);
			bool success = false;

			if (fromCell == toCell) 
			{
				if	(fromCell != CellType.DEAL_AREA)
					success = false;
				else 
				{
					// Possible Move in the Free Cell Area
					success = myDealArea.makePossibleMove(fromColId-8, toColId - 8, myFreeCells.getFreeCount());
				}
			}
			else 
			{
				if (toCell == CellType.FREE_CELL) 
				{
					int card = removeCard(fromColId);
					if (card != -1) 
					{
						success = myFreeCells.makePossibleMove(toColId, card);
						if (!success) 
						{
							insertCard(fromColId, card);
						}
					}
				}
				else if (toCell == CellType.FINAL_CELL) 
				{
					int card = removeCard(fromColId);
					if (card != -1) 
					{
						success = myFinalCells.makePossibleMove(toColId-4, card);
						if (!success)
						{
							insertCard(fromColId, card);
						}
					}
				}
				else if (toCell == CellType.DEAL_AREA) 
				{
					int card = removeCard(fromColId);
					if (card != -1) 
					{
						success = myDealArea.makePossibleMoveCard(toColId-8, card);
						if (!success) 
						{
							insertCard(fromColId, card);
						}
					}
				}
			}

			return success;
		}

		public bool move(int fromCol, int toCol)
		{
			return makePossibleMove(fromCol, toCol);
		}

		/// <summary>
		/// Used when a doubleclick is detected; If the fromCol is from the deal area
		/// try to move to the final area if possible; If not try to move to a free cell;
		/// else if the from col is from the free area try to move to the final area
		/// </summary>
		/// <param name="fromCol"></param>
		/// <returns>true if there was a successful move</returns>
		public bool move(int fromCol, bool finalOnly)
		{
			bool success = false;
			CellType fromCell = getCellType(fromCol);
			if (fromCell == CellType.DEAL_AREA) 
			{
				int card = removeCard(fromCol);
				if (card != -1) 
				{
					for (int j= 0; j < 4; j++) 
					{
						success = myFinalCells.makePossibleMove(j, card, finalOnly);
						if (success)
							break;
					}
					if (!finalOnly && !success) 
					{
						for (int k= 0; k < 4; k++) 
						{
							success = myFreeCells.makePossibleMove(k, card);
							if (success)
								break;
						}
					}
					if (!success)
						insertCard(fromCol, card);
				}
			}
			else if (fromCell == CellType.FREE_CELL)
			{
				// Try to go to a final cell
				int card = removeCard(fromCol);
				if (card != -1) 
				{
					for (int j= 0; j < 4; j++) 
					{
						success = myFinalCells.makePossibleMove(j, card);
						if (success)
							break;
					}
					if (!success)
						insertCard(fromCol, card);
				}
			}
			return success;
		}

		// Check if any of the cards can automatically move to final positions
		public void moveAuto()
		{
			bool moved = true;
			while (moved) 
			{
				moved = false;
				for (int j = 8; j < 16; j++) 
				{
					moved = moved | move(j,true);
					while(move(j, true));
				}
			}
		}
	}
}
