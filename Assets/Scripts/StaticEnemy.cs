using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class StaticEnemy 
{
   public static List<Enemy> enemyToFight = new List<Enemy>();

   public static void BeginFight(List<Enemy> enemyImport){
       for (int i = 0; i < enemyImport.Count; i++){
           enemyToFight.Add(enemyImport[i]);
       }
        SceneManager.LoadScene("CardFight");
   }
}
