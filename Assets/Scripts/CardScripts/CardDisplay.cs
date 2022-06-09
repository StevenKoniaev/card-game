using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CardDisplay : MonoBehaviour
{

    [HideInInspector]
    public Card card = null;

      public GameObject healthHolder;
      //Properties to display
      public TextMeshProUGUI nameText;
      public TextMeshProUGUI effectText;
      public Image artwork;
      public TextMeshProUGUI costText;
      public TextMeshProUGUI healthText;
      public Image directionImg;
      public Animator animator;
      


    public void SetInfo(Card myCard){

      if (myCard == null){
        return;
      }
        this.card = (myCard);

        

        if (nameText != null){
          nameText.text = myCard.name;
        }
          
        if (costText != null){
          costText.text = ((FriendlyCard)myCard).cost.ToString();
        }
          
        if (card.GetType() == typeof(Enemy)){
          animator.runtimeAnimatorController = ((Enemy)myCard).animatorcontroller;
        }
        
        artwork.sprite = myCard.artwork;

        this.card.health = myCard.healthMax;
        healthText.text = myCard.health.ToString();

        this.card.myDisplay = this;

        if (effectText != null){
          for (int i =0; i < ((FriendlyCard)myCard).cActions.Length; i++){
            
          effectText.text += ((FriendlyCard)myCard).cActions[i].descriptionText + "\n";
        }

        if (((FriendlyCard)myCard).cActions.Length > 0){

          switch (((FriendlyCard)myCard).cActions[0].direction) {
            case Action.Direction.RIGHT: {
              directionImg.transform.Rotate(new Vector3(0,0,0));
              break;
            }
            case Action.Direction.UP:{
              directionImg.transform.Rotate(new Vector3(0,0,90));
              break;
            }
            case Action.Direction.LEFT:{
              directionImg.transform.Rotate(new Vector3(0,0,180));
              break;
            }
            case Action.Direction.DOWN:{
              directionImg.transform.Rotate(new Vector3(0,0,-90));
              break;
            }

            default:{
             
            }break;
          } 
        }
      }  
    }

    public void CardUpdate(Card myCard){
     this.healthText.text = myCard.health.ToString();
    }
 

    public void Die(){

    }
}
