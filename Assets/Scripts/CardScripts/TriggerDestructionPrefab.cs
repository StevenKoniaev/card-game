using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDestructionPrefab : MonoBehaviour
{
    [SerializeField]
    GameObject deathHolder;

   public void BeginDestruction(){
        GameObject holder = Instantiate(deathHolder, new Vector3(this.transform.position.x, this.transform.position.y, 1), Quaternion.identity);
        holder.transform.SetParent(this.transform.root);
        
    }
}
