using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaiterClass : MonoBehaviour
{

    public void StartUp(GameObject obj){
        StartCoroutine(WaitForAnimation(obj));
    }
    public IEnumerator WaitForAnimation(GameObject obj){
        Debug.Log("IM WATCHING YOU");
        yield return new WaitForSecondsRealtime(1000);
    }
}
