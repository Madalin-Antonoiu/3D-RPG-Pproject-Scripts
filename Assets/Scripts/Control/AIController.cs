using UnityEngine;
using RPG.Combat;
using RPG.Core;
using RPG.Movement;

namespace RPG.Control {

  public class AIController : MonoBehaviour {
    [SerializeField] float chaseDistance = 5f;
    Fighter fighter;
    Health health;
    Mover mover;
    GameObject player;

    Vector3 guardPosition;



    private void Start() {
      mover = GetComponent<Mover>();
      fighter = GetComponent<Fighter>();
      player = GameObject.FindWithTag("Player");
      health = GetComponent<Health>();

      guardPosition = transform.position;
    }

    private void Update() {
     if(health.IsDead()) return;

     if(InAttackRangeOfPlayer() && fighter.CanAttack(player)){
        fighter.Attack(player);
     } else {
       mover.StartMoveAction(guardPosition);
     }

    }

    private bool InAttackRangeOfPlayer() {
      float distanceToPlayer = Vector3.Distance(player.transform.position, transform.position);
      return distanceToPlayer < chaseDistance;
    }

    // Called by Unity
    private void OnDrawGizmosSelected() {
      Gizmos.color = Color.blue; 
      Gizmos.DrawWireSphere(transform.position, chaseDistance);
    }


  }

}