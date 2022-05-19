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
      public TextMeshProUGUI cost;
      public TextMeshProUGUI attack;
      public TextMeshProUGUI health;

    public void SetInfo(Card myCard){

      if (myCard == null){
        return;
      }
        this.card = myCard;
        nameText.text = myCard.name;
        descriptionText.text = myCard.description;
        artwork.sprite = myCard.artwork;
        cost.text = myCard.cost.ToString();
        health.text = myCard.health.ToString();
    }


 

    public void Die(){

    }
}
