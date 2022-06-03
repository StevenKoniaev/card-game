using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class HealthSystem {
    private static int health;
    private static int healthMax;

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
    public static int GetHealth(){
        return health;
    }
}

