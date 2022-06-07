using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Action : ScriptableObject
{
  public enum Direction{
       UP, DOWN, LEFT, RIGHT, SPLASH, RANDOM5, ALL, COLUMNRIGHT, RANDOM4
   }

  public enum Type{
    ATTACK, EFFECT
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
  public Type myType;
  
  public int valueForEffect;
  

   public void Animation(Card[,] board, int x, int y){
        if (attackPrefab != null ){
            GameObject holder = Instantiate(attackPrefab, new Vector3(board[x, y].myDisplay.transform.position.x, board[x, y].myDisplay.transform.position.y, 0), Quaternion.identity); 
             //holder.AddComponent<WaiterClass>().StartUp(holder); 
}
    }

    public void Animation(Card[,] board, int x, int y, ReferenceGridObjects refGrid){
        if (attackPrefab != null ){
          
            GameObject holder = Instantiate(attackPrefab, new Vector3(refGrid.arrRef[x][y].transform.position.x, refGrid.arrRef[x][y].transform.position.y, 0), Quaternion.identity); 
          
            // holder.AddComponent<WaiterClass>().StartUp(holder); 
           
                 }
    }

  public abstract void CardAction(Card[,] board, int x, int y);
  public virtual void CardAction(Card[,] board, bool[,] arrTargets, ReferenceGridObjects refGrid){

  }

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
