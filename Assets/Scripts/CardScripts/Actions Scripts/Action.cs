using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Action : ScriptableObject
{
  public enum Direction{
       UP, DOWN, LEFT, RIGHT, SPLASH, RANDOM5, ALL, COLUMNRIGHT, RANDOM4
   }
  public string descriptionText;

  public GameObject attackPrefab;
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

     case Direction.RANDOM5: {
       for (int k = 0; k < 5; k++){
         int i = Random.Range(0, board.GetLength(0));
         int j = Random.Range(0, board.GetLength(1)-1);
         arrTarget[i, j] = true;
       }
       return arrTarget;
     }

     case Direction.COLUMNRIGHT:{
       for (int i =0; i < arrTarget.GetLength(0); i++){
         arrTarget[i,2] = true;
       }
       return arrTarget;
     }
      default:{}break;
    
    }
    return null;
  }
  
}
