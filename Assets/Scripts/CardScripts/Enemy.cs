using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Enemy : ScriptableObject
{
    
public Sprite artwork;
public new string name;
public int health;

public string description;

public bool TakeDamage(int dmg){
    health -= dmg;

    if (health <= 0){
        return true;
    } else {
        return false;
    }
}

}
