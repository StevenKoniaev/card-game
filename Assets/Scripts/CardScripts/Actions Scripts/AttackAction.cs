using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "New Action", menuName = "Actions/Attack")]
public class AttackAction : Action
{
   public int damage = 3;
   
   

   
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
                        AttackAnimation(board, x+1, y);
                        board[x+1, y].TakeDamage(damage, board, x+1, y);
                    }
                }
                break;
            }

            case Direction.DOWN:
            {
                if (x-1 >= 0){
                    if (board[x-1, y] != null){
                        AttackAnimation(board, x-1, y);
                        board[x-1, y].TakeDamage(damage, board, x-1, y);
                      
                    }
                }
                break;
            }
            case Direction.LEFT:{
                if (y-1 >= 0){
                    if (board[x, y-1] != null){
                        AttackAnimation(board, x, y-1);
                        board[x, y-1].TakeDamage(damage, board, x, y-1);
                       
                    }
                }
                break;
            }
            case Direction.RIGHT:
            {
                  if (y+1 < board.GetLength(1)){
                    if (board[x, y+1] != null){
                        AttackAnimation(board, x, y+1);
                        board[x, y+1].TakeDamage(damage, board, x, y+1);
                       
                    }
                }
                break;
            }

            case Direction.ALL:
            {
                for (int i=0; i < board.GetLength(0); i++){
                    for (int j=0; j < board.GetLength(1)-1; j++){
                        if (board[i,j] != null){
                            board[i,j].TakeDamage(damage, board, i, j);
                        }

                        if(board[i,j] == null){
                            HealthSystem.Damage(damage);
                        }
                       
                    }
                }
                break;
            }
            default:{} break;
        }
    }

    void AttackAnimation(Card[,] board, int x, int y){
        if (attackPrefab != null){
            GameObject holder = Instantiate(attackPrefab, new Vector3(board[x, y].myDisplay.transform.position.x, board[x, y].myDisplay.transform.position.y, 0), Quaternion.identity); 
           //  holder.AddComponent<WaiterClass>().StartUp(holder); Delay
                 }
    }
    
}
