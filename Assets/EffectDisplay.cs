using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class EffectDisplay : MonoBehaviour
{
    public TextMeshProUGUI numberEffect;
    public Image imageEffectCHOICE;
    public Sprite imageEffectAttackOption;
    public Sprite imageEffectSpellOption;

    public void SetEffectInfo(EnemyActions action){
       
             numberEffect.text = action.valueForEffect.ToString();
        
       

        if (action.myType == EnemyActions.Type.ATTACK){
            imageEffectCHOICE.sprite = imageEffectAttackOption;
        } else if (action.myType == EnemyActions.Type.EFFECT){
            imageEffectCHOICE.sprite = imageEffectSpellOption;
            }else{
            imageEffectCHOICE.sprite = null;
        }
    }
}
