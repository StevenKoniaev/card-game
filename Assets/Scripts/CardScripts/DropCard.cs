  using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropCard : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{


public CardGameManager cmang;
public PlayerHUD playerHud;
public int x;
public int y;

public void Start(){
  playerHud = GameObject.FindGameObjectWithTag("Manager").GetComponent<PlayerHUD>();
}

    public void OnPointerEnter(PointerEventData eventData){
    
    
    } 
  public void OnDrop(PointerEventData eventData){
     Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
   
      if (d!=null && this.x != -1 && d.canDrag == true){
        int cardCost = ((FriendlyCard)d.GetComponent<CardDisplay>().card).cost;
          if (cmang.mana >=  cardCost){
              cmang.mana -= cardCost;
              playerHud.SetPlayerMana(cmang.mana);
              
                d.parentToReturnTo = this.transform;
                
                eventData.pointerDrag.transform.localScale = new Vector3(0.9f,0.9f,1);
                cmang.board[x,y] = eventData.pointerDrag.GetComponent<CardDisplay>().card;
                //On plan effect
                Action[] arrAc = ((FriendlyCard)d.GetComponent<CardDisplay>().card).cActions;
                for (var i = 0; i < arrAc.Length; i++)
                {
                    if (arrAc[i].activation == Action.Activation.ONPLAY){
                        arrAc[i].CardAction(cmang, x, y);
                    }
                }
                //Disable stacking
                this.enabled = false;
        
      }
        }
  }

  public void OnPointerExit(PointerEventData eventData){

    }
     
}
