using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Card : ScriptableObject
{


public new string name;
public Sprite artwork;

[HideInInspector]
public CardDisplay myDisplay = null;
public int health;
public int healthMax;
public RuntimeAnimatorController animatorcontroller;



    
}
