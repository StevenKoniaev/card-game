using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CombatCollision : MonoBehaviour
{
    public List<Enemy> enemy = new List<Enemy>();

      private void OnCollisionEnter2D(Collision2D other) {
          this.enabled = false;
          Time.timeScale = 0;
          StaticEnemy.BeginFight(enemy);
     }




    
}
