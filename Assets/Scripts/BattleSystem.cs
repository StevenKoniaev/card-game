using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum BattleState{
START, PLAYERTURN, ENEMYTURN, WON, LOST, PLAYERBATTLE, ENEEMYBATTLE
}

public class BattleSystem : MonoBehaviour
{
    public int manatotal;
    public int mana;
    private int health; 
    public BattleState state;
    
    CardGameManager cmang; 
    // Start is called before the first frame update
    void Start()
    {
        state = BattleState.START;
        cmang = GetComponent<CardGameManager>();;   
        SetupBattle();
    } 

    public void SetupBattle(){
        manatotal = 1;
        mana = 1;

        //Draw Opening Hand
        cmang.OpeningCardSlots();
        cmang.DrawCard();
        cmang.DrawCard();
        cmang.DrawCard();
        cmang.DrawCard();
        cmang.DrawCard();
        
     
       
      
    }

    public void NextTurn(){
        manatotal += 1;
        mana = manatotal;
    }
}
