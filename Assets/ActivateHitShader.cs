using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActivateHitShader : MonoBehaviour
{
    [SerializeField]
     Image image;
     
   void HitShader(){
    
       IEnumerator TakeDamage_Cor(){
           
           image.material.SetInt("_hit", 1);
           yield return new WaitForSeconds(0.25f);
           image.material.SetInt("_hit", 0);
       }
       StartCoroutine(TakeDamage_Cor());
       
   }
}
