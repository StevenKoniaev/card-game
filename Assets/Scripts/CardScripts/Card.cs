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
public string description;
public Sprite artwork;
public int cost;

public int attack;
public int health;

    
}
