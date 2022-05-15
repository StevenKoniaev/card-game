using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    Transform myHandreference = null;

    CanvasGroup canvasgroupref=null;

    public void Start(){
        canvasgroupref = GetComponent<CanvasGroup>();
    }
    public void OnBeginDrag(PointerEventData eventData){
        myHandreference = this.transform.parent;
         this.transform.SetParent(this.transform.root);

         canvasgroupref.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData){
        this.transform.position = eventData.position;
    }

       public void OnEndDrag(PointerEventData eventData){
           this.transform.SetParent(myHandreference);
           canvasgroupref.blocksRaycasts = true;
    }
}
