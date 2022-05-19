using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum BattleState{
START, PLAYERTURN, ENEMYTURN, WON, LOST, ENEEMYBATTLE
}
//This boi is the main script who manages everything in a fight - Be WARNED ~! 
public class BattleSystem : MonoBehaviour
{
    public int manatotal;
    public int mana;
    private int health; 
    public BattleState state;
    CardGameManager cmang; 
    PlayerHUD playerHud;

    public Enemy[] enemy;
    // Start is called before the first frame update
    void Start()
    {
        
        cmang = GetComponent<CardGameManager>();
        playerHud = GetComponent<PlayerHUD>();
        SetupBattle(null);
        
    } 

    public void SetupBattle(Enemy[] enemies){
        if (enemy == null){
            enemy = enemies;
        }
        mana = 0;
        manatotal = 0;
        StartCoroutine(PlayerTurn());
    }

    public IEnumerator PlayerTurn(){
        state = BattleState.START;
        manatotal += 1;
        mana = manatotal;

        //Draw Opening Hand
        cmang.OpeningCardSlots();
        cmang.DrawCard();
        cmang.DrawCard();
        cmang.DrawCard();
        cmang.DrawCard();
        cmang.DrawCard();
       

       //Player begins!
       state = BattleState.PLAYERTURN;
       PlayerHUDChanges("Your turn");

       yield return new WaitForSeconds(1f);

       playerHud.StopTextTurnText();
    }

    public void PlayerHUDChanges(string text){
        playerHud.SetPlayerMana(mana);
        playerHud.HUDTextUpdate(text);
        
    }



    public void EndTurnButton(){
        if (state != BattleState.PLAYERTURN){
            return;
        }
        StartCoroutine(AttackPhase());
    }

    IEnumerator AttackPhase(){
   //Minion attaccks! and effects!~
        for (int i = 0; i < 3; i++){
            for (int j = 0 ; j < 3; j++){
                if (cmang.board[i,j] != null){
                    for (int k = 0; k < cmang.board[i,j].cActions.Length; k++ ){
                        cmang.board[i,j].cActions[k].CardAction();
                    }
                }
            }
        }
        
        //Checking to see how many enemies are alive or dead
        bool isDead = false;
        for (int i = 0; i < enemy.Length; i++){
            if (enemy[i].health > 0){
                isDead = false;
                break;
            }
            isDead = true;
        }
   
        if (isDead){
            //END COMBAT
            state = BattleState.WON;
            EndBattle();
        } else{
            //Enemy Turn
            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }



        yield return new WaitForSeconds(0f);
    }

    public IEnumerator EnemyTurn(){
        Debug.Log("Enemy ATTACK!");
        yield return new WaitForSeconds(1f);

        bool isDead = false;
        //Take damage

        if (isDead){
            state = BattleState.LOST;
            EndBattle();
        } else {
            state = BattleState.PLAYERTURN;
            PlayerTurn();
        }
    }
    public void EndBattle(){
        if (state== BattleState.WON){
          playerHud.HUDTextUpdate("You won!");
        } else if  (state == BattleState.LOST){
            playerHud.HUDTextUpdate("You lost...");
        }
    }
}
