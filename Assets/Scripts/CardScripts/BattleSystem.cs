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
        //Begin the combat
       SetupBattle();
    } 

    private bool EnemyPredictable(Enemy e){
        return true;
    }

    public void SetupBattle(){
        //Check to see if this a test or trying to import an enemy from overworld
        if (StaticEnemy.enemyToFight.Count != 0){
            pHolderenemy.RemoveAll(EnemyPredictable);
            for (int i = 0; i < StaticEnemy.enemyToFight.Count; i ++){
                pHolderenemy.Add(StaticEnemy.enemyToFight[i]);
            }
        }
        //Create the enemy graphics      
        for (int i = 0 ; i < pHolderenemy.Count; i++){
            GameObject enemyObject = Instantiate(enemyPrefab, new Vector3(0,0,0), Quaternion.identity);
            enemyObject.transform.SetParent(enemyArea.transform, false);
            enemyObject.GetComponent<CardDisplay>().SetInfo(pHolderenemy[i]);
        }
        //Temporary 
        //TODO Add for dynamic combat sizes
        cmang.board[0, 3] = pHolderenemy[0];
        cmang.board[1, 3] = pHolderenemy[0];
        cmang.board[2, 3] = pHolderenemy[0];
        //Manages mana
        cmang.mana = cmang.manaStart;
        cmang.manatotal = cmang.manaStart;
        //Import health from overworld
        hpbar.StartReduceHealth();
        //Begin players turn
        StartCoroutine(PlayerTurn());
    }

    public IEnumerator PlayerTurn(){
        //Player's turn 
        state = BattleState.START;
        cmang.manatotal += 1;
        cmang.mana = cmang.manatotal;
        playerHud.SetPlayerMana(cmang.mana);
        //Draw Opening Hand
        cmang.DrawCard();
        cmang.DrawCard();
        cmang.DrawCard();

       
       
       //GUI "Your turn"
       playerHud.HUDTextUpdate("Your Turn");
       yield return new WaitForSecondsRealtime(1f);
       playerHud.StopTextTurnText();

       //Which cells is the enemy targetting? What attack will it be with?
       chosenEnemyAction = pHolderenemy[0].cActions[Random.Range(0, pHolderenemy[0].cActions.Length)];
       pHolderenemy[0].myDisplay.transform.gameObject.GetComponent<EffectDisplay>().SetEffectInfo(chosenEnemyAction);
       //2D arr of bool
        arrTarget  = chosenEnemyAction.TargetSpaces(cmang.board);
        //GUI Markers for where the enemy effect will go
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
       //Player begins!
       state = BattleState.PLAYERTURN;
       StopCoroutine(PlayerTurn());
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
        for (int i = 0; i < pHolderenemy.Count; i++){
            if (pHolderenemy[i].health > 0){
                //At least one enemy is still alive - continue combat
                state = BattleState.ENEMYTURN;
                break;
            } else {
                state = BattleState.WON;
            }
        }
        if (state == BattleState.WON){
            EndBattle();
        } else if (state == BattleState.ENEMYTURN){
            StartCoroutine(EnemyTurn());
        }
        
            
        yield return new WaitForSecondsRealtime(0f);
         StopCoroutine(AttackPhase());
    }

    public IEnumerator EnemyTurn(){
        //Display message
         playerHud.HUDTextUpdate("Enemy Turn");
       yield return new WaitForSecondsRealtime(1f);
       playerHud.StopTextTurnText();
       //Do the enemies chosen action
       //TODO dynamic enemy sizes
        chosenEnemyAction.CardAction(cmang.board, arrTarget, refGrid);
        //See if health has changed since attack
        hpbar.StartReduceHealth();
         //  chosenAction.CardAction(cmang.board, 1, 3);
        // chosenAction.CardAction(cmang.board, 2, 3);
        yield return new WaitForSecondsRealtime(0f);
        //Destroy indicators
        for (int i = 0; i < gridTargets.Count; i++){
            Destroy(gridTargets[i]);
        }
        //Check player's health to see if they can still fight
        if (HealthSystem.GetHealth() <= 0){
            state = BattleState.LOST;
            EndBattle();
            StopCoroutine(EnemyTurn());
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
