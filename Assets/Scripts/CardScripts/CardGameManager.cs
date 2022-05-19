using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardGameManager : MonoBehaviour
{
   
    public List<Card> deck = new List<Card>();
    
    public Card[,] board = new Card[3,3];
    Transform[] cardSlots = new Transform[10];
    bool[] avaliableCardSlots = new bool[10];
    public GameObject playerArea;
    public GameObject cardPrefab;

    public void OpeningCardSlots(){
        //Opening up the hand
        for(int i=0; i < avaliableCardSlots.Length; i++){
            avaliableCardSlots[i] = true;
        }
        for (int i = 0; i < deck.Count; i++){
            Instantiate(deck[i]);
        }        
    }
    public void DrawCard(){
        
        if (deck.Count >= 1){
            //Picks a random card
            Card randomCard = deck[Random.Range(0, deck.Count)];
        //Is there space in hand?
            for (int i = 0; i < avaliableCardSlots.Length; i++){
                //Has this slot been taken?
                if (avaliableCardSlots[i] == true){
                    //Create a game object
                    GameObject drawnCard = Instantiate(cardPrefab, new Vector3(0,0,0), Quaternion.identity);
                    //Set the parent to be my hand
                    drawnCard.transform.SetParent(playerArea.transform, false);
                    //Set info with the card display
                    drawnCard.GetComponent<CardDisplay>().SetInfo(randomCard);
                    //Card slot in hand has been taken
                    avaliableCardSlots[i] = false;
                    //Remove card from deck
                    deck.Remove(randomCard);
                    return;
                }
            }
        }
    }


    
    public void EndCombat(){

    }

    
}
