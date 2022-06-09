using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class HealthbarHandler : MonoBehaviour
{
    public Image healthBar;
    public TextMeshProUGUI playerhealth;
    float smoothing = 3f;

    public void StartReduceHealth(){
        StartCoroutine(ReduceHealth());
    }

    public IEnumerator ReduceHealth(){
        
        float elapsedTime = 0;
         playerhealth.text = HealthSystem.GetHealth().ToString();
        while (healthBar.fillAmount != HealthSystem.GetHealth()){

            healthBar.fillAmount = Mathf.Lerp(
                healthBar.fillAmount, HealthSystem.GetHealth() / HealthSystem.GetMaxHealth(), smoothing * Time.deltaTime);

            Color healthColor = Color.Lerp(Color.yellow, Color.red, HealthSystem.GetHealth() / HealthSystem.GetMaxHealth());
            healthBar.color = healthColor;

            elapsedTime += Time.deltaTime;
            yield return null;
        }
        StopCoroutine(ReduceHealth());
        yield return null;
    }
       
}
