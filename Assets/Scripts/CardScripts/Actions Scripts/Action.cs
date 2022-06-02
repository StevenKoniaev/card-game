using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Action : ScriptableObject
{
  public enum Direction{
       UP, DOWN, LEFT, RIGHT, SPLASH, RANDOM5, ALL
   }
  public string descriptionText;
  public Direction direction;
  public abstract void CardAction(Card[,] board, int x, int y);

  public bool[,] TargetSpaces(Card[,] board){
    
    bool[,] arrTarget = new bool[board.GetLength(0), board.GetLength(1)];

    switch (direction){
      
      case Direction.ALL: {
        for (int i = 0; i < arrTarget.GetLength(0); i++){
          for (int j = 0 ; j < arrTarget.GetLength(1)-1; j++){
            arrTarget[i,j] = true;
          }
        }
        return arrTarget;
     }
      default:{}break;
    
    }
    return null;
  }
  
}
