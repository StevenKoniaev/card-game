using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Action : ScriptableObject
{
  public string descriptionText;
  public abstract void CardAction(Card[,] board, int x, int y);
}
