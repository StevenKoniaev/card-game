using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class EnemyDisplay : MonoBehaviour
{ 
     public Enemy enemy = null;

      //Properties to display
      
      public TextMeshProUGUI descriptionText;
      public Image artwork;
      public TextMeshProUGUI attack;
      public TextMeshProUGUI health;

    public void SetEnemyInfo(Enemy myEnemy){

      if (myEnemy == null){
        return;
      }
        this.enemy = myEnemy;
        //nameText.text = myEnemy.name;
        descriptionText.text = myEnemy.description;
        artwork.sprite = myEnemy.artwork;
        myEnemy.enemyDisplay = this;
        this.GetComponentInChildren<Animator>().runtimeAnimatorController = myEnemy.animatorcontroller;
        myEnemy.health = myEnemy.healthMax;
        health.text = myEnemy.health.ToString();
    }

    public void CardUpdate(Card myCard){
     this.health.text = myCard.health.ToString();
    }

    
}
