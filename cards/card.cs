using System;
using System.Drawing;

namespace Publicjoe.Windows.Cards
{
  #region enums
  /// <summary>
  /// 
  /// </summary>
  public enum CardSuit : int
  {
    Club = 0,
    Diamond = 1,
    Heart = 2,
    Spade = 3
  }

  /// <summary>
  /// 
  /// </summary>
  public enum CardRank : int
  {
    Ace = 0,
    Two = 1,
    Three = 2,
    Four = 3,
    Five = 4,
    Six = 5,
    Seven = 6,
    Eight = 7,
    Nine = 8,
    Ten = 9,
    Jack = 10,
    Queen = 11,
    King = 12
  }

  /// <summary>
  /// Mode
  /// </summary>
  public enum CardMode : int
  {
    RankCollated = 0, // card number starts from 0
    SuitCollated = 1  // card number offset by 1 for blank card.
  }
  #endregion

  public class Card
  {
    /// <summary>
    /// .NET Graphics surface used for drawing.
    /// </summary>
    private Graphics graphicsSurface;

    /// <summary>
    /// Current Mode to draw Card
    /// </summary>
    private CardMode mode;
    public CardMode Mode
    {
      get { return mode; }
      set { mode = value; }
    }

    #region Constants
    public byte Width = 71;
    public byte Height = 96;
    #endregion

    public Card()
    {
      mode = CardMode.RankCollated;
    }

    /// <summary>
    /// Called just before using the card drawing functions.
    /// </summary>
    /// <param name="graphicsSurface">Graphics object on which the cards are to be drawn.</param>
    public void Begin(Graphics graphicsSurface)
    {
      this.graphicsSurface = graphicsSurface;
    }

    public void End()
    {
      this.graphicsSurface = null;
    }

    #region Drawing
    /// <summary>
    /// Draws a card in a given mode with specified suit and rank.
    /// </summary>
    /// <param name="topLeft">Top left location to start drawing the card.</param>
    /// <param name="cardIndex">Card index (dependant on mode), use the ToCardIndex</param>
    public void DrawCard(Point topLeft, int cardIndex)
    {
      graphicsSurface.DrawImage(GetImage(cardIndex), topLeft);
    }

    public void DrawCardBack(Point topLeft)
    {
      graphicsSurface.DrawImage(cards.Properties.Resources.backBlack, topLeft);
    }    

    private Image GetImage( int cardIndex )
    {
      Image img = cards.Properties.Resources.bigJoker;

      if (mode == CardMode.RankCollated)
      {
        switch (cardIndex)
        {
          case 0: img = cards.Properties.Resources.clubA; break;
          case 1: img = cards.Properties.Resources.diamondA; break;
          case 2: img = cards.Properties.Resources.heartA; break;
          case 3: img = cards.Properties.Resources.spadeA; break;
          case 4: img = cards.Properties.Resources.club2; break;
          case 5: img = cards.Properties.Resources.diamond2; break;
          case 6: img = cards.Properties.Resources.heart2; break;
          case 7: img = cards.Properties.Resources.spade2; break;
          case 8: img = cards.Properties.Resources.club3; break;
          case 9: img = cards.Properties.Resources.diamond3; break;
          case 10: img = cards.Properties.Resources.heart3; break;
          case 11: img = cards.Properties.Resources.spade3; break;
          case 12: img = cards.Properties.Resources.club4; break;
          case 13: img = cards.Properties.Resources.diamond4; break;
          case 14: img = cards.Properties.Resources.heart4; break;
          case 15: img = cards.Properties.Resources.spade4; break;
          case 16: img = cards.Properties.Resources.club5; break;
          case 17: img = cards.Properties.Resources.diamond5; break;
          case 18: img = cards.Properties.Resources.heart5; break;
          case 19: img = cards.Properties.Resources.spade5; break;
          case 20: img = cards.Properties.Resources.club6; break;
          case 21: img = cards.Properties.Resources.diamond6; break;
          case 22: img = cards.Properties.Resources.heart6; break;
          case 23: img = cards.Properties.Resources.spade6; break;
          case 24: img = cards.Properties.Resources.club7; break;
          case 25: img = cards.Properties.Resources.diamond7; break;
          case 26: img = cards.Properties.Resources.heart7; break;
          case 27: img = cards.Properties.Resources.spade7; break;
          case 28: img = cards.Properties.Resources.club8; break;
          case 29: img = cards.Properties.Resources.diamond8; break;
          case 30: img = cards.Properties.Resources.heart8; break;
          case 31: img = cards.Properties.Resources.spade8; break;
          case 32: img = cards.Properties.Resources.club9; break;
          case 33: img = cards.Properties.Resources.diamond9; break;
          case 34: img = cards.Properties.Resources.heart9; break;
          case 35: img = cards.Properties.Resources.spade9; break;
          case 36: img = cards.Properties.Resources.club10; break;
          case 37: img = cards.Properties.Resources.diamond10; break;
          case 38: img = cards.Properties.Resources.heart10; break;
          case 39: img = cards.Properties.Resources.spade10; break;
          case 40: img = cards.Properties.Resources.clubJ; break;
          case 41: img = cards.Properties.Resources.diamondJ; break;
          case 42: img = cards.Properties.Resources.heartJ; break;
          case 43: img = cards.Properties.Resources.spadeJ; break;
          case 44: img = cards.Properties.Resources.clubQ; break;
          case 45: img = cards.Properties.Resources.diamondQ; break;
          case 46: img = cards.Properties.Resources.heartQ; break;
          case 47: img = cards.Properties.Resources.spadeQ; break;
          case 48: img = cards.Properties.Resources.clubK; break;
          case 49: img = cards.Properties.Resources.diamondK; break;
          case 50: img = cards.Properties.Resources.heartK; break;
          case 51: img = cards.Properties.Resources.spadeK; break;
        }
      }
      else
      {
        switch (cardIndex)
        {
          case 0: img = cards.Properties.Resources.clubA; break;
          case 1: img = cards.Properties.Resources.club2; break;
          case 2: img = cards.Properties.Resources.club3; break;
          case 3: img = cards.Properties.Resources.club4; break;
          case 4: img = cards.Properties.Resources.club5; break;
          case 5: img = cards.Properties.Resources.club6; break;
          case 6: img = cards.Properties.Resources.club7; break;
          case 7: img = cards.Properties.Resources.club8; break;
          case 8: img = cards.Properties.Resources.club9; break;
          case 9: img = cards.Properties.Resources.club10; break;
          case 10: img = cards.Properties.Resources.clubJ; break;
          case 11: img = cards.Properties.Resources.clubQ; break;
          case 12: img = cards.Properties.Resources.clubK; break;
          case 13: img = cards.Properties.Resources.diamondA; break;
          case 14: img = cards.Properties.Resources.diamond2; break;
          case 15: img = cards.Properties.Resources.diamond3; break;
          case 16: img = cards.Properties.Resources.diamond4; break;
          case 17: img = cards.Properties.Resources.diamond5; break;
          case 18: img = cards.Properties.Resources.diamond6; break;
          case 19: img = cards.Properties.Resources.diamond7; break;
          case 20: img = cards.Properties.Resources.diamond8; break;
          case 21: img = cards.Properties.Resources.diamond9; break;
          case 22: img = cards.Properties.Resources.diamond10; break;
          case 23: img = cards.Properties.Resources.diamondJ; break;
          case 24: img = cards.Properties.Resources.diamondQ; break;
          case 25: img = cards.Properties.Resources.diamondK; break;
          case 26: img = cards.Properties.Resources.heartA; break;
          case 27: img = cards.Properties.Resources.heart2; break;
          case 28: img = cards.Properties.Resources.heart3; break;
          case 29: img = cards.Properties.Resources.heart4; break;
          case 30: img = cards.Properties.Resources.heart5; break;
          case 31: img = cards.Properties.Resources.heart6; break;
          case 32: img = cards.Properties.Resources.heart7; break;
          case 33: img = cards.Properties.Resources.heart8; break;
          case 34: img = cards.Properties.Resources.heart9; break;
          case 35: img = cards.Properties.Resources.heart10; break;
          case 36: img = cards.Properties.Resources.heartJ; break;
          case 37: img = cards.Properties.Resources.heartQ; break;
          case 38: img = cards.Properties.Resources.heartK; break;
          case 39: img = cards.Properties.Resources.spadeA; break;
          case 40: img = cards.Properties.Resources.spade2; break;
          case 41: img = cards.Properties.Resources.spade3; break;
          case 42: img = cards.Properties.Resources.spade4; break;
          case 43: img = cards.Properties.Resources.spade5; break;
          case 44: img = cards.Properties.Resources.spade6; break;
          case 45: img = cards.Properties.Resources.spade7; break;
          case 46: img = cards.Properties.Resources.spade8; break;
          case 47: img = cards.Properties.Resources.spade9; break;
          case 48: img = cards.Properties.Resources.spade10; break;
          case 49: img = cards.Properties.Resources.spadeJ; break;
          case 50: img = cards.Properties.Resources.spadeQ; break;
          case 51: img = cards.Properties.Resources.spadeK; break;
        }
      }

      return img;
    }
    #endregion

    public bool IsFace(CardRank value)
    {
      return value == CardRank.Jack || value == CardRank.Queen || value == CardRank.King;
    }

    public bool IsBlack(CardSuit type)
    {
      return type == CardSuit.Club || type == CardSuit.Spade;
    }

    #region Helpers
    /// <summary>
    /// Helper that converts a given Card's rank, suit, mode into the card index.
    /// </summary>
    /// <param name="suit">Suit to draw.</param>
    /// <param name="rank">Rank of card.</param>
    /// <returns></returns>
    public int ToCardIndex(CardSuit suit, CardRank rank)
    {
      int cardNo = -1;

      switch (mode)
      {
        case CardMode.RankCollated:
          cardNo = ((int)rank) * 4 + ((int)suit);
          break;

        case CardMode.SuitCollated:
          cardNo = 1 + ((int)rank) + 13 * ((int)suit);
          break;

        default:
          cardNo = 0;
          break;
      }
      return cardNo;
    }

    /// <summary>
    /// Helper that converts card index to Suit of Card.
    /// </summary>
    /// <param name="cardIndex">Card's index.</param>
    /// <returns></returns>
    public CardSuit SuitFromCardIndex(int cardIndex)
    {
      if (mode == CardMode.SuitCollated && (cardIndex >= 1 && cardIndex <= 52))
      {
        return (CardSuit)((cardIndex - 1) / 13);
      }
      else if (mode == CardMode.RankCollated && (cardIndex >= 0 && cardIndex <= 51))
      {
        return (CardSuit)(cardIndex % 4);
      }
      else
      {
        throw new ApplicationException("Suite only valid to SuitCollated, RankCollated modes.");
      }
    }

    /// <summary>
    /// Helper that converts card index to Rank of Card.
    /// </summary>
    /// <param name="cardIndex"></param>
    /// <returns></returns>
    public CardRank RankFromCardIndex(int cardIndex)
    {
      if (mode == CardMode.SuitCollated && (cardIndex >= 1 && cardIndex <= 52))
      {
        return (CardRank)((cardIndex - 1) % 13);
      }
      else if (mode == CardMode.RankCollated && (cardIndex >= 0 && cardIndex <= 51))
      {
        return (CardRank)(cardIndex / 4);
      }
      else
      {
        throw new ApplicationException("Rank only valid to SuitCollated, RankCollated modes.");
      }
    }
    #endregion
  }
}
