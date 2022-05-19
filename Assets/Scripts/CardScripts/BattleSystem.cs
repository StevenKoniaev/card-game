using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum BattleState{
START, PLAYERTURN, ENEMYTURN, WON, LOST, PLAYERBATTLE, ENEEMYBATTLE
}
//This boi is the main script who manages everything - Be WARNED ~! 
public class BattleSystem : MonoBehaviour
{
    public int manatotal;
    public int mana;
    private int health; 
    public BattleState state;
    CardGameManager cmang; 
    PlayerHUD playerHud;
    // Start is called before the first frame update
    void Start()
    {
        
        cmang = GetComponent<CardGameManager>();
        playerHud = GetComponent<PlayerHUD>();
        StartCoroutine(SetupBattle());
    } 

    public IEnumerator SetupBattle(){
        state = BattleState.START;
        manatotal = 1;
        mana = 1;

        //Draw Opening Hand
        cmang.OpeningCardSlots();
        cmang.DrawCard();
       cmang.DrawCard();
        cmang.DrawCard();
        cmang.DrawCard();
        cmang.DrawCard();
       
       yield return new WaitForSeconds(1f);
       //Player begins!
       state = BattleState.PLAYERTURN;
       PlayerTurn();

       yield return new WaitForSeconds(1f);

       playerHud.StopTextTurnText();
    }

    public void PlayerTurn(){
        playerHud.HUDTextPlayerTurn();
    }

    public void NextTurn(){
        manatotal += 1;
        mana = manatotal;
    }

    public void EndTurnButton(){
        if (state != BattleState.PLAYERTURN){
            return;
        }
        StartCoroutine(PlayerAttack());
    }

    IEnumerator PlayerAttack(){
        yield return new WaitForSeconds(0f);
    }
}
