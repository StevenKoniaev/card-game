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

      public Animator animator;


    public void SetInfo(Card myCard){

      if (myCard == null){
        return;
      }
        this.card = myCard;

        if (nameText != null){
          nameText.text = myCard.name;
        }
          
        if (costText != null){
          costText.text = myCard.cost.ToString();
        }
          
        if (animator != null && myCard.animatorcontroller != null){
          animator.runtimeAnimatorController = myCard.animatorcontroller;
        }
        
        artwork.sprite = myCard.artwork;

        myCard.health = myCard.healthMax;
        healthText.text = myCard.health.ToString();

        myCard.myDisplay = this;

        if (effectText != null){
          for (int i =0; i < myCard.cActions.Length; i++){
          effectText.text += myCard.cActions[i].descriptionText + "\n";
        }
        }
        
    }

    public void CardUpdate(Card myCard){
     this.healthText.text = myCard.health.ToString();
    }
 

    public void Die(){

    }
}
