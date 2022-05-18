using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Card : ScriptableObject
{
public CardType cType;



public List<CardProperties> properties = new List<CardProperties>();
    
}
