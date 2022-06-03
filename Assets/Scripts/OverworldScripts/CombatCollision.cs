using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CombatCollision : MonoBehaviour
{
    public List<Enemy> enemy = new List<Enemy>();

      private void OnCollisionEnter2D(Collision2D other) {
          StaticEnemy.BeginFight(enemy);
     }




    
}
