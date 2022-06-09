using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "New Action", menuName = "Actions/Attack")]
public class AttackAction : Action
{
    [SerializeField]
   private int damage = 3;
   
   

   
    public override void CardAction(Card[,] board, int x, int y){
        //Deal damage to a unit based on the direction
        //TODO switch the directon be an enum or something ~ 
        //Doing now! Is there a better way to do this? Think about it.\
        //Switch statment + enum is so clean
        switch (direction){
            //Check direction of attack action!
            
            case Direction.UP:
            {
                if (x+1 < board.GetLength(0)){
                    if (board[x+1, y] != null){
                        Animation(board, x+1, y);
                        cmang.CardTakeDamage(board[x+1,y], damage, cmang, x+1, y);
                    }
                }
                break;
            }

            case Direction.DOWN:
            {
                if (x-1 >= 0){
                    if (board[x-1, y] != null){
                        Animation(board, x-1, y);
                        cmang.CardTakeDamage(board[x-1,y], damage, cmang, x+1, y);
                      
                    }
                }
                break;
            }
            case Direction.LEFT:{
                if (y-1 >= 0){
                    if (board[x, y-1] != null){
                        Animation(board, x, y-1);
                        cmang.CardTakeDamage(board[x,y-1], damage, cmang, x, y-1);
                       
                    }
                }
                break;
            }
            case Direction.RIGHT:
            {
                  if (y+1 < board.GetLength(1)){
                    if (board[x, y+1] != null){
                        Animation(board, x, y+1);
                        cmang.CardTakeDamage(board[x,y+1], damage, cmang, x, y+1);
                       
                    }
                }
                break;
            }
            default:{} break;
        }
    }

   
    
}
