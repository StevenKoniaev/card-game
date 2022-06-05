using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class HealthSystem {
    private static float health = 20;
    private static float healthMax = 20;


   public static void SetHealth( int healthSet){
       health = healthSet;
       healthMax = healthSet;

       
   }

   public static void Damage(int damage){
       health -= damage;
       if (health < 0 ){
           health = 0;
       }
       
   }

   public static void Heal(int heal){
       health += heal;
       if (health > healthMax){
           health = healthMax;
       }
      
   }
    public static float GetHealth(){
        return health;
    }

    public static float GetMaxHealth(){
        return healthMax;
    }
}

