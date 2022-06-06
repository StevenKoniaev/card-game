using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardGameManager : MonoBehaviour
{
   
    public List<Card> deck = new List<Card>();
    public List<Card> graveyard = new List<Card>();
    //For now I added a referenace back to cardisplay - not sure if this is the best way of handling it but i'm gonna keep it- 
    //TODO consider swapping appraoch on getting back to carddisplay reference - have deck store game objects instead of cards?
    public Card[,] board = new Card[3,4];
    public GameObject playerArea;
    public GameObject cardPrefab;

    public int manatotal;
    public int mana;
    public int manaStart;
    
    
  
    public void DrawCard(){
        
        if (deck.Count >= 1){
            //Picks a random card
            Card randomCard = deck[Random.Range(0, deck.Count)];
                    //Create a game object
                    GameObject drawnCard = Instantiate(cardPrefab, new Vector3(0,0,0), Quaternion.identity);
                    //Set the parent to be my hand
                    drawnCard.transform.SetParent(playerArea.transform, false);
                    //Set info with the card display
                    drawnCard.GetComponent<CardDisplay>().SetInfo(randomCard);
                    //Remove card from deck
                    deck.Remove(randomCard);
                    return;
                }
            }
        
    


    
    public void EndCombat(){

    }

    
}
