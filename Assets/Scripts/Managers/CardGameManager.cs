using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardGameManager : MonoBehaviour
{
   
    public List<Card> deck = new List<Card>();
    public int[] rowOne = new int[3];
    public int[] rowTwo = new int[3];
    public int[] rowThree = new int[3];
    Transform[] cardSlots = new Transform[10];
    bool[] avaliableCardSlots = new bool[10];
    public GameObject playerArea;
    public GameObject cardPrefab;

    public void OpeningCardSlots(){
        for(int i=0; i < avaliableCardSlots.Length; i++){
            avaliableCardSlots[i] = true;
        }
        
        for (int i = 0; i < deck.Count; i++){
            Instantiate(deck[i]);
        }

      //  DrawCard();
        
    }
    public void DrawCard(){
        
        if (deck.Count >= 1){
            Debug.Log("DRAW!");
            Card randomCard = deck[Random.Range(0, deck.Count)];
        
            for (int i = 0; i < avaliableCardSlots.Length; i++){
                
                if (avaliableCardSlots[i] == true){
                    
                    GameObject drawnCard = Instantiate(cardPrefab, new Vector3(0,0,0), Quaternion.identity);
                    drawnCard.transform.SetParent(playerArea.transform, false);
                    drawnCard.GetComponent<CardDisplay>().SetInfo(randomCard);
                    avaliableCardSlots[i] = false;
                    deck.Remove(randomCard);
                    return;
                }
            }
        }
    }


    
    public void EndCombat(){

    }

    
}
