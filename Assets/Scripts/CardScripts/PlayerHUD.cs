using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class PlayerHUD : MonoBehaviour
{
    
    public TextMeshProUGUI manaText;
    public TextMeshProUGUI healthText;
    public GameObject turnTextObject;
    public TextMeshProUGUI turnTextText;

    public void Start(){
        
    }

    public void SetPlayerHealth(int hp){
        healthText.text = hp.ToString();
    }

    public void SetPlayerMana(int mana){
        manaText.text = mana.ToString();
    }

    public void HUDTextUpdate(string text){
        turnTextText.text = text;
        turnTextObject.SetActive(true);
    }

  

    public void StopTextTurnText(){
        turnTextObject.SetActive(false);
    }
}
