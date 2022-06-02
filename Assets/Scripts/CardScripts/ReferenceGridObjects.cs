using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReferenceGridObjects : MonoBehaviour
{
    public GameObject[] refHolderRowOne = new GameObject[3];
    public GameObject[] refHolderRowTwo = new GameObject[3];
    public GameObject[] refHolderRowThree = new GameObject[3];

    public List<GameObject[]> arrRef = new List<GameObject[]>();

    void Start(){
        arrRef.Add(refHolderRowOne);
        arrRef.Add(refHolderRowTwo);
        arrRef.Add(refHolderRowThree);
    }

}
