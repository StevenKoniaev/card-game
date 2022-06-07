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
   public List<Enemy> pHolderenemy = new List<Enemy>();
    public Transform enemyArea;
    public GameObject isTarget; 
    List<GameObject> gridTargets = new List<GameObject>();
    Action chosenEnemyAction;
     ReferenceGridObjects refGrid;
     public HealthbarHandler hpbar;

     bool[,] arrTarget;

    // Start is called before the first frame update
    void Start()
    {
        cmang = GetComponent<CardGameManager>();
        playerHud = GetComponent<PlayerHUD>();
        refGrid = GetComponent<ReferenceGridObjects>();
        
       SetupBattle();
    } 

    private bool EnemyPredictable(Enemy e){
        return true;
    }

    public void SetupBattle(){
        if (StaticEnemy.enemyToFight.Count != 0){
            pHolderenemy.RemoveAll(EnemyPredictable);

            for (int i = 0; i < StaticEnemy.enemyToFight.Count; i ++){
                pHolderenemy.Add(StaticEnemy.enemyToFight[i]);
            }
        }

         int manaStart = cmang.manatotal;
        
        for (int i = 0 ; i < pHolderenemy.Count; i++){
            GameObject enemyObject = Instantiate(enemyPrefab, new Vector3(0,0,0), Quaternion.identity);
            enemyObject.transform.SetParent(enemyArea.transform, false);
            enemyObject.GetComponent<CardDisplay>().SetInfo(pHolderenemy[i]);
        }

     
        //Temporary 
        cmang.board[0, 3] = pHolderenemy[0];
        cmang.board[1, 3] = pHolderenemy[0];
        cmang.board[2, 3] = pHolderenemy[0];
   
        
        

        cmang.mana = cmang.manaStart;
        cmang.manatotal = cmang.manaStart;
        hpbar.StartReduceHealth();
        
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

       
       //Player begins!
       state = BattleState.PLAYERTURN;
       PlayerHUDChanges("Your turn");

       yield return new WaitForSecondsRealtime(1f);

       playerHud.StopTextTurnText();


       //Which cells is the enemy targetting? What attack will it be with?
       chosenEnemyAction = pHolderenemy[0].cActions[Random.Range(0, pHolderenemy[0].cActions.Length)];
       pHolderenemy[0].myDisplay.transform.gameObject.GetComponent<EffectDisplay>().SetEffectInfo(chosenEnemyAction);

        arrTarget  = chosenEnemyAction.TargetSpaces(cmang.board);
        
       for (int i = 0; i < arrTarget.GetLength(0); i++){
           for (int j = 0; j < arrTarget.GetLength(0); j++){
               if (arrTarget[i,j] == true){
                  
                   GameObject myTarget = Instantiate(isTarget, new Vector3(0,0,0), Quaternion.identity);
                    myTarget.transform.SetParent(canvas.transform,false);
                    //Add to array to delete later
                    gridTargets.Add(myTarget);
                    myTarget.transform.position = refGrid.arrRef[i][j].transform.position;
               }
           }
       }


       StopCoroutine(PlayerTurn());
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
                        if (cmang.board[i,j].cActions[k].activation == Action.Activation.ONENDTURN){
                            cmang.board[i,j].cActions[k].CardAction(cmang.board, i, j);
                        }
                        
                    }
                }
            }
        }
        //Checking to see how many enemies are alive or dead
        bool isDead = false;
        for (int i = 0; i < pHolderenemy.Count; i++){
            if (pHolderenemy[i].health > 0){
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
        StopCoroutine(AttackPhase());
        
        //Display message
        PlayerHUDChanges("Enemy Turn");

       yield return new WaitForSecondsRealtime(1f);

       playerHud.StopTextTurnText();


        
        chosenEnemyAction.CardAction(cmang.board, arrTarget, refGrid);
        
        hpbar.StartReduceHealth();
         //  chosenAction.CardAction(cmang.board, 1, 3);
        // chosenAction.CardAction(cmang.board, 2, 3);

        yield return new WaitForSecondsRealtime(1f);

        for (int i = 0; i < gridTargets.Count; i++){
            Destroy(gridTargets[i]);
        }

         
        //Take damage
        if (HealthSystem.GetHealth() <= 0){
            state = BattleState.LOST;
            EndBattle();
        } else {
            state = BattleState.PLAYERTURN;
      
            StartCoroutine(PlayerTurn());
            StopCoroutine(EnemyTurn());
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
