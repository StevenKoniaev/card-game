  using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropCard : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{


public CardGameManager cmang;
public int x;
public int y;

    public void OnPointerEnter(PointerEventData eventData){
      if (eventData.pointerDrag != null){
  Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
      if (d!=null){
        d.placeHolderparent = this.transform;
        
      }
      }
    
    } 
  public void OnDrop(PointerEventData eventData){
     Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
     
      if (d!=null){
        d.myHandreference = this.transform;
        if (x != -1 && y != -1){
         eventData.pointerDrag.transform.localScale = new Vector3(1,1,1);
        Card myCard = eventData.pointerDrag.GetComponent<CardDisplay>().card;
        cmang.board[x,y] = myCard;
      }
      }
  }

  public void OnPointerExit(PointerEventData eventData){
    if (eventData.pointerDrag != null){
 Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
      if (d!=null && d.placeHolderparent==this.transform){
        d.placeHolderparent = d.myHandreference;
      }
  }
    }
     
}
