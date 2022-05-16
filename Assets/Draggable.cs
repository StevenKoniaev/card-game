using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Transform myHandreference = null;
    GameObject placeHolder = null;
    CanvasGroup canvasgroupref=null;

    public void Start(){
        canvasgroupref = GetComponent<CanvasGroup>();
       // myHandreference = this.transform.parent;
    }
    public void OnBeginDrag(PointerEventData eventData){
       
        placeHolder = new GameObject();
        placeHolder.transform.SetParent(this.transform.parent);
        LayoutElement le = placeHolder.AddComponent<LayoutElement>();
     //   le.preferredHeight = this.GetComponent<LayoutElement>().preferredHeight;
      //  le.preferredWidth = this.GetComponent<LayoutElement>().preferredWidth;
       // le.flexibleHeight = 0 ; 
        //le.flexibleWidth = 0  ; 

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

           Destroy(placeHolder);
    }
}
