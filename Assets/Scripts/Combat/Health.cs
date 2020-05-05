using UnityEngine;

namespace RPG.Combat {
  public class Health : MonoBehaviour {

    [SerializeField] float healthPoints = 100f;

    bool isDead = false;

    //Public getter method, returns true or false
    public bool IsDead(){
      return isDead;
    }

    public void TakeDamage(float damage){
      healthPoints = Mathf.Max(healthPoints - damage, 0);// if it goes < 0, 0 will be higher and will take the vaue of 0;
      if(healthPoints == 0) {
        Die();
      }
      print(healthPoints); 
    }

    private void Die() {
      if(isDead) return;

      isDead = true;
      GetComponent<Animator>().SetTrigger("die");
    }
  }
}