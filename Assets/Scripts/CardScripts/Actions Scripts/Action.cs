using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Action : ScriptableObject
{
  public enum Direction{
       UP, DOWN, LEFT, RIGHT
   }

  

  public enum Activation{
    ONPLAY, ONDEATH, ONHIT, ONENDTURN
  }
  public Activation activation;

  [SerializeField]
  public string descriptionText;

  [SerializeField]
  public GameObject attackPrefab;
  [SerializeField]
  public Direction direction;


   public void Animation(Card[,] board, int x, int y){
        if (attackPrefab != null ){
            GameObject holder = Instantiate(attackPrefab, new Vector3(board[x, y].myDisplay.transform.position.x, board[x, y].myDisplay.transform.position.y, 0), Quaternion.identity); 
}
    }



  public abstract void CardAction(Card[,] board, int x, int y);
  


  
}
