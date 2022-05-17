using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CardDisplay : MonoBehaviour
{

    public Card card = null;
   public CardDisplayProperties[] properties;

    public void SetInfo(Card myCard){

      if (myCard == null){
        return;
      }
        
        this.card = myCard;

        for (int i =0; i < myCard.properties.Count; i++){
          CardProperties cp = myCard.properties[i];
          CardDisplayProperties p = GetProperty(cp.e);

          if (p == null){
            continue;
          }
          if (cp.e is ElementInt){
            p.text.text = cp.intVal.ToString();
          }else if (cp.e is ElementText){
            p.text.text = cp.stringVal;
          }
          else if (cp.e is ElementImage){
            p.img.sprite = cp.sprite;
          }
        }
      
    }


  public CardDisplayProperties GetProperty(Element e){
    CardDisplayProperties result = null;

    for (int i = 0; i < properties.Length; i++){
      if (properties[i].e == e){
        result = properties[i];
        break;
      }
    }

    return result;
  }
    public void Die(){

    }
}
