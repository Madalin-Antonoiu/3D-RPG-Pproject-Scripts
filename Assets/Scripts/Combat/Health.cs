using UnityEngine;

namespace RPG.Combat {
  public class Health : MonoBehaviour {
    [SerializeField] float health = 100f;

    public void TakeDamage(float damage){
      health = Mathf.Max(health-damage, 0);// if it goes < 0, 0 will be higher and will take the vaue of 0;
      print(health); 
    }
  }
}