using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDeath : MonoBehaviour
{
    GameObject centerScreen;

    void CardDestruction(){
        Destroy(transform.parent.gameObject);
    }
}
