using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropCard : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{

  public void Start(){
  
  }
    public void OnPointerEnter(PointerEventData eventData){

    }
  public void OnDrop(PointerEventData eventData){
     Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
      if (d!=null){
        d.myHandreference = this.transform;
      }
  }

  public void OnPointerExit(PointerEventData eventData){
      
  }
}
