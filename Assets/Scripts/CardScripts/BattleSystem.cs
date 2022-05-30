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
    public GameObject canvas;
    public BattleState state;
    CardGameManager cmang; 
    PlayerHUD playerHud;
    public GameObject enemyPrefab;
    public Enemy[] enemy;
    public Transform enemyArea;
    // Start is called before the first frame update
    void Start()
    {
        cmang = GetComponent<CardGameManager>();
        playerHud = GetComponent<PlayerHUD>();
    } 

    public void SetupBattle(Enemy[] enemies){
         int manaStart = cmang.manatotal;
        if (enemy == null){
            enemy = enemies;
        }
        for (int i = 0 ; i < enemies.Length; i++){
            GameObject enemyObject = Instantiate(enemyPrefab, new Vector3(0,0,0), Quaternion.identity);
            enemyObject.transform.SetParent(enemyArea.transform, false);
            enemyObject.GetComponent<EnemyDisplay>().SetEnemyInfo(enemy[i]);
        }
        //Temporary 
        cmang.board[0, 3] = enemy[0];
        cmang.board[1, 3] = enemy[0];
        cmang.board[2, 3] = enemy[0];

        cmang.mana = cmang.manaStart;
        cmang.manatotal = cmang.manaStart;
        StartCoroutine(PlayerTurn());
    }

    public IEnumerator PlayerTurn(){
        state = BattleState.START;
        cmang.manatotal += 1;
        cmang.mana = cmang.manatotal;

        //Draw Opening Hand
        cmang.DrawCard();
        cmang.DrawCard();
        cmang.DrawCard();
        cmang.DrawCard();
        cmang.DrawCard();
       

       //Player begins!
       state = BattleState.PLAYERTURN;
       PlayerHUDChanges("Your turn");

       yield return new WaitForSecondsRealtime(1f);

       playerHud.StopTextTurnText();
    }

    public void PlayerHUDChanges(string text){
        playerHud.SetPlayerMana(cmang.mana);
        playerHud.HUDTextUpdate(text);
        
    }


//Begins the next phase!
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
                        //Go through array of possible actions and use them
                        cmang.board[i,j].cActions[k].CardAction(cmang.board, i, j);
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



        yield return new WaitForSecondsRealtime(0f);
    }

    public IEnumerator EnemyTurn(){
        //Enemy attack code 
            Action chosenAction = enemy[0].cActions[Random.Range(0, enemy[0].cActions.Length)];
      Debug.Log(chosenAction);
        
        chosenAction.CardAction(cmang.board, 0, 3);
        chosenAction.CardAction(cmang.board, 1, 3);
    chosenAction.CardAction(cmang.board, 2, 3);

        Debug.Log("Enemy ATTACK!");
        yield return new WaitForSecondsRealtime(1f);




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
        canvas.SetActive(false);
    }

    public void BeginFight(Enemy[] enemyOverworld){
        this.enemy = enemyOverworld;
        canvas.SetActive(true);
        SetupBattle(enemy);
    }
}
