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
    
    
    } 
  public void OnDrop(PointerEventData eventData){
     Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
     
      if (d!=null){
        d.parentToReturnTo = this.transform;
        if (x != -1 && y != -1){
         eventData.pointerDrag.transform.localScale = new Vector3(0.9f,0.9f,1);
        Card myCard = eventData.pointerDrag.GetComponent<CardDisplay>().card;
        cmang.board[x,y] = myCard;
      }
      }
  }

  public void OnPointerExit(PointerEventData eventData){

    }
     
}
