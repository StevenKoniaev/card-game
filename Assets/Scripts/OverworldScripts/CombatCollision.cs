using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatCollision : MonoBehaviour
{
    public Enemy[] enemy;
    public BattleSystem bs;
      private void OnCollisionEnter2D(Collision2D other) {
          BeginFight();
          this.enabled = false;
          Time.timeScale = 0;
     }

     void BeginFight(){
         bs.BeginFight(enemy);
     }



    
}
