using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "New Card", menuName = "Cards/Equip")]
public class EquipCard : FriendlyCard
{
    public EquipCard(){
         base.cType = CardType.EQUIP;
    }
}
