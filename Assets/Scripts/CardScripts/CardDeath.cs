using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CardDeath : MonoBehaviour
{
  //  GameObject centerScreen;
    public GameObject cardDestroyer;
    GameObject copy;


    void Start(){
    }
    public void CardDestruction(){
         
         copy = Instantiate(cardDestroyer, new Vector3(0,0,0), Quaternion.identity);
         copy.transform.localScale = new Vector3(0.9f, 0.9f, 1);
         copy.transform.SetParent(this.transform.parent);
         Destroy(transform.gameObject);
    }
}
