using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CardType : ScriptableObject
{
    public string typeName;
    public virtual void OnSetType(CardDisplay dis){
         //Element t = ExtraScriptManager.GetResourcesManager().typeElement;
         //if (t != null){
           //   CardDisplayProperties type = dis.GetProperty(t);
        //type.textref.text = typeName;
         //}
      
    }
}
