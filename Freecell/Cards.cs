using System;
using System.Collections.Generic;
using System.Text;
using Publicjoe.Windows.Cards;

namespace cards
{
  public enum Color
  {
    RED,
    BLACK
  }

  public class Cards
  {
    public static CardSuit getCardSuit(int card)
    {
      int suit = card % 4;
      return (CardSuit)suit;
    }

    public static Color getCardColor(int card)
    {
      CardSuit suit = getCardSuit(card);
      if ((suit == CardSuit.Diamond) || (suit == CardSuit.Heart))
        return Color.RED;
      else
        return Color.BLACK;
    }

    public static bool ofSameColor(int cardOne, int cardTwo)
    {
      return (getCardColor(cardOne) == getCardColor(cardTwo));
    }

    public static bool ofSameSuit(int cardOne, int cardTwo)
    {
      return (getCardSuit(cardOne) == getCardSuit(cardTwo));
    }

    public static bool followsInSuit(int cardOne, int cardTwo)
    {
      return ofSameSuit(cardOne, cardTwo) && (getCardFaceValue(cardOne) == getCardFaceValue(cardTwo) + 1);
    }

    public static bool followsAltCol(int cardOne, int cardTwo)
    {
      return !ofSameColor(cardOne, cardTwo) && (getCardFaceValue(cardOne) == getCardFaceValue(cardTwo) + 1);
    }

    public static bool follows(int cardOne, int cardTwo)
    {
      return (getCardFaceValue(cardOne) == getCardFaceValue(cardTwo) + 1);
    }

    public static int getCardFaceValue(int card)
    {
      return card / 4 + 1;
    }
  }
}
