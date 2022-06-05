using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class HealthbarHandler : MonoBehaviour
{
    public Image healthBar;
    public TextMeshProUGUI playerhealth;
    public float waitTime = 1000f;

    public void StartReduceHealth(){
        StartCoroutine(ReduceHealth());
    }

    public IEnumerator ReduceHealth(){
        
        float elapsedTime = 0;
         playerhealth.text = HealthSystem.GetHealth().ToString();
        while (elapsedTime < waitTime){

            healthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount, HealthSystem.GetHealth() / HealthSystem.GetMaxHealth(), elapsedTime/waitTime);

            Color healthColor = Color.Lerp(Color.yellow, Color.red, HealthSystem.GetHealth() / HealthSystem.GetMaxHealth());
            healthBar.color = healthColor;

            elapsedTime += Time.deltaTime;
            yield return null;
          //  yield return new WaitForSecondsRealtime(0.001f);
        }
       
        
        StopCoroutine(ReduceHealth());
        yield return null;
    }
       
}
