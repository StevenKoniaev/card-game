using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class FriendlyCard : Card
{
    public enum CardType{
        SPELL, MONSTER, EQUIP
    }

    public int cost;
    public Action[] cActions;
    public CardType cType;
}
