using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "New Card", menuName = "Cards/Monster")]
public class MonsterCard : Card
{
    public MonsterCard(){
         base.cType = CardType.MONSTER;
    }
 
}
