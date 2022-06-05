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
[HideInInspector]
public CardDisplay myDisplay = null;
public int health;
public int healthMax;

public RuntimeAnimatorController animatorcontroller;


public Action[] cActions;

public virtual void TakeDamage(int dmg, Card[,] board, int x, int y){
    health -= dmg;
    myDisplay.CardUpdate(this);
    if (health > 0){
        //Play the damage animation
        myDisplay.animator.SetTrigger("takeDamage");
    } else {
      myDisplay.GetComponent<TriggerDestructionPrefab>().BeginDestruction();
      board[x,y] = null;
        Destroy(myDisplay.transform.gameObject);
    }
}
    
}
