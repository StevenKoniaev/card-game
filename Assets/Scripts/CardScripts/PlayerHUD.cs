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

    public void SetPlayerHealth(){
    }

    public void SetPlayerMana(int mana){
        
    }

    public void HUDTextPlayerTurn(){
        turnTextText.text = "Your turn";
        turnTextObject.SetActive(true);
    }

    public void HUDTextEnemyTurn(){
        turnTextText.text = "Enemy turn";
        turnTextObject.SetActive(true);
    }

    public void StopTextTurnText(){
        turnTextObject.SetActive(false);
    }
}
