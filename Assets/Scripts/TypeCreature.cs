using System.Collections;
using System.Collections.Generic;
using UnityEngine;

  [CreateAssetMenu(menuName = "Cards/Creature")]
public class TypeCreature : CardType
{
    public override void OnSetType(CardDisplay dis)
    {
        dis.powerHolder.SetActive(true);
        dis.healthHolder.SetActive(true);
    }
}
