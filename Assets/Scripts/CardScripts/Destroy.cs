using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    void DestroyThis(){
        Destroy(this.transform.gameObject);
    }
}
