
using System;
using UnityEngine;
using RPG.Combat;
using RPG.Movement;
using RPG.Core;

namespace RPG.Control {

  public class PlayerController : MonoBehaviour {

		Health health;

		private void Start() {
			health = GetComponent<Health>();
		}

		private void Update() {
      if (health.IsDead()) return;
			if(InteractWithCombat()) return; // it true it won't interact with movement;
			if(InteractWithMovement()) return;
		}

    private bool InteractWithCombat() {
      RaycastHit[] hits = Physics.RaycastAll(GetMouseRay());
			foreach (RaycastHit hit in hits){

				CombatTarget target = hit.transform.GetComponent<CombatTarget>();

				if(target == null) continue;
				if(!GetComponent<Fighter>().CanAttack(target.gameObject)) continue; // means go to next hit in foreach
				if(Input.GetMouseButton(0)){
					GetComponent<Fighter>().Attack(target.gameObject);
				}
        return true;
			}
			return false; // we din't find any combat targets to interact with
    }

    private bool InteractWithMovement() {

      RaycastHit hit;
      bool hasHit = Physics.Raycast(GetMouseRay(), out hit);  

      if (hasHit) {
				if(Input.GetMouseButton(0)){
          GetComponent<Mover>().StartMoveAction(hit.point);
				}
				return true;
      }
			return false;

    }

    private static Ray GetMouseRay() {
      return Camera.main.ScreenPointToRay(Input.mousePosition);
    }
		

  }
}