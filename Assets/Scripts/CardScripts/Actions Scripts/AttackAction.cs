using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "New Action", menuName = "Actions/Attack")]
public class AttackAction : Action
{
   public int damage = 3;
    public void CardAction(Card[,] board, int x, int y){
        //Deal damage to a unit based on the direction
        //TODO switch the directon be an enum or something ~ 
        if (board[x,y+1] != null){
            board[x,y+1].health -= damage;
            Debug.Log(board[x,y+1].health);
        }
        

    }
}
