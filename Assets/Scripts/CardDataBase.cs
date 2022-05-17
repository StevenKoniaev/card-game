using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDataBase : MonoBehaviour
{
    public List<Card> cardList = new List<Card>();

    void Awake(){
       // cardList.Add(new Card());
    }
}
