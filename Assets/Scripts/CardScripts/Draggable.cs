using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    //The parent to return to ref for where the card should jump back to
    public Transform myHandreference = null;
    public Transform placeHolderparent = null;
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
        
        le.preferredHeight = this.GetComponent<LayoutElement>().preferredHeight;
        le.preferredWidth = this.GetComponent<LayoutElement>().preferredWidth;
        le.minHeight = this.GetComponent<LayoutElement>().minHeight;
         le.minWidth = this.GetComponent<LayoutElement>().minWidth;
        le.flexibleHeight = 0 ; 
        le.flexibleWidth = 0  ; 

        placeHolder.transform.SetSiblingIndex(this.transform.GetSiblingIndex());
         myHandreference = this.transform.parent;
         placeHolderparent = myHandreference;
         this.transform.SetParent(this.transform.root);
         canvasgroupref.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData){
        this.transform.position = eventData.position;

        if(placeHolder.transform.parent != placeHolderparent){
            placeHolder.transform.SetParent(placeHolderparent);
        }

        int newSiblingIndex = placeHolderparent.childCount;

        for (int i = 0; i < placeHolderparent.childCount; i++){
            if(this.transform.position.x < placeHolderparent.GetChild(i).position.x){
                newSiblingIndex = i;
                if (placeHolder.transform.GetSiblingIndex() < newSiblingIndex){
                    newSiblingIndex --;
                }
                break;
            }
        }
        placeHolder.transform.SetSiblingIndex(newSiblingIndex);

    }

       public void OnEndDrag(PointerEventData eventData){
           this.transform.SetParent(myHandreference);
            this.transform.SetSiblingIndex(placeHolder.transform.GetSiblingIndex());

           canvasgroupref.blocksRaycasts = true;

           Destroy(placeHolder);
    }
}
