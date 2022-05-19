using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Enemy : Card
{
    
public bool TakeDamage(int dmg){
    health -= dmg;

    if (health <= 0){
        return true;
    } else {
        return false;
    }
}

}
