using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "New Enemy Action", menuName = "EnemyActions/EnemyAttack")]
public class EnemyAttackAction : EnemyActions
{
    //[SerializeField]
    //private int damage = 3;
    
    public void ActionDisplay(){

    }
    

    public override void CardAction(CardGameManager cmang, bool[,] arrTargets, ReferenceGridObjects refGrid){
    for (int i =0; i < arrTargets.GetLength(0); i++){
        for (int j = 0; j < arrTargets.GetLength(1); j++){
            if (arrTargets[i,j] == true){
                if (cmang.board[i,j] != null){
                            Animation(cmang.board, i, j);
                            cmang.CardTakeDamage(cmang.board[i,j], valueForEffect, cmang, i, j);
                        }
                        if(cmang.board[i,j] == null){
                            Animation(cmang.board,i,j,refGrid);
                            HealthSystem.Damage(valueForEffect);
                        }
            }
        }
    }
    }
}
