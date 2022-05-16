using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CardDisplay : MonoBehaviour
{

    public Card card = null;
    public TextMeshProUGUI nameText = null;
    public TextMeshProUGUI descriptionText = null;
    public Image art = null;
    public TextMeshProUGUI manaText = null;
    public TextMeshProUGUI attackText = null;
    public TextMeshProUGUI healthText = null;
    // Start is called before the first frame update
    void Start()
    {
//        nameText.text =  card.cardName;
  //      descriptionText.text = card.cardDescription;
    //    art.sprite = card.artwork;
      //  manaText.text = card.cost.ToString();
       // attackText.text = card.power.ToString();
        //healthText.text = card.health.ToString();

    }

    public void SetInfo(Card myCard){
      
        
        this.card = myCard;
        nameText.text =  myCard.cardName;
        descriptionText.text = myCard.cardDescription;
        art.sprite = myCard.artwork;
        manaText.text = myCard.cost.ToString();
        attackText.text = myCard.power.ToString();
        healthText.text = myCard.health.ToString();
    }

    public void Die(){

    }
}
