using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CardDisplay : MonoBehaviour
{

    public Card card = null;
      public GameObject healthHolder;

      //Properties to display
      public TextMeshProUGUI nameText;
      public TextMeshProUGUI descriptionText;
      public Image artwork;
      public TextMeshProUGUI costText;
      public TextMeshProUGUI healthText;


    public void SetInfo(Card myCard){

      if (myCard == null){
        return;
      }
        this.card = myCard;
        nameText.text = myCard.name;
        artwork.sprite = myCard.artwork;
        costText.text = myCard.cost.ToString();
        myCard.health = myCard.healthMax;
        healthText.text = myCard.health.ToString();
        myCard.myDisplay = this;
        for (int i =0; i < myCard.cActions.Length; i++){
          descriptionText.text += myCard.cActions[i].descriptionText + "\n";
        }
    }

    public void CardUpdate(Card myCard){
     this.healthText.text = myCard.health.ToString();
    }
 

    public void Die(){

    }
}
