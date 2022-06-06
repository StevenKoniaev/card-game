using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "New Action", menuName = "Actions/EnemyAttack")]
public class EnemyAttackAction : Action
{
    //[SerializeField]
    //private int damage = 3;
    
    public void ActionDisplay(){

    }
    public override void CardAction(Card[,] board, int x, int y){}

    public override void CardAction(Card[,] board, bool[,] arrTargets, ReferenceGridObjects refGrid){
    for (int i =0; i < arrTargets.GetLength(0); i++){
        for (int j = 0; j < arrTargets.GetLength(1); j++){
            if (arrTargets[i,j] == true){
                if (board[i,j] != null){
                            Animation(board, i, j);
                            board[i,j].TakeDamage(valueForEffect, board, i, j);
                        }
                        if(board[i,j] == null){
                            Animation(board,i,j,refGrid);
                            HealthSystem.Damage(valueForEffect);
                        }
            }
        }
    }
    }
}
