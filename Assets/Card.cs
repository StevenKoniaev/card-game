using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Card : ScriptableObject
{
 public string cardName;
 public int cost;
 public int power;
 public int health;
 public string cardDescription;

 public bool isSpell;

 public Sprite artwork;

 public Card(){

 }

public void PutInHand(){

}



}
