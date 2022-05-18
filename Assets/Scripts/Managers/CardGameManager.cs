using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardGameManager : MonoBehaviour
{
   
    public List<Card> deck = new List<Card>();
    public Transform[] cardSlots;
    public bool[] avaliableCardSlots;
    public GameObject playerArea;
    public GameObject cardPrefab;

    public void Start(){
        for(int i=0; i < avaliableCardSlots.Length; i++){
            avaliableCardSlots[i] = true;
        }
        
        for (int i = 0; i < deck.Count; i++){
            Instantiate(deck[i]);
        }
        DrawCard();
        DrawCard();
        
    }
    public void DrawCard(){
        
        if (deck.Count >= 1){

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
