using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Card : ScriptableObject
{

    public enum CardType{
        SPELL, MONSTER, EQUIP
    }

public CardType cType;
public new string name;

public Sprite artwork;
public int cost;
public CardDisplay myDisplay = null;
public int health;
public int healthMax;

public Action[] cActions;

public bool TakeDamage(int dmg){
    health -= dmg;

    if (health <= 0){
        return true;
    } else {
        return false;
    }
}
    
}
