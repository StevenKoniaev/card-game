using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Enemy : Card
{

public EnemyDisplay enemyDisplay;

public string description;

public override void TakeDamage(int dmg){
    health -= dmg;
    Debug.Log(this.health);
    enemyDisplay.CardUpdate(this);
    if (health > 0){
        
    } else {
        //Destroy(myDisplay.transform.parent.gameObject);
    }
}


}
