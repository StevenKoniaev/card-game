using System.Collections;
using System.Collections.Generic;
using UnityEngine;


  [CreateAssetMenu(menuName = "Cards/Equip")]
public class TypeEquip : CardType
{  
    public override void OnSetType(CardDisplay dis)
    {
     
       base.OnSetType(dis);

           dis.healthHolder.SetActive(false);
        dis.powerHolder.SetActive(false);

    }
}
