using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Action : ScriptableObject
{
  public enum Direction{
       UP, DOWN, LEFT, RIGHT, SPLASH
   }
  public string descriptionText;
  public Direction direction;
  public abstract void CardAction(Card[,] board, int x, int y);
}
