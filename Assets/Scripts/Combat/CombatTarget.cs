using UnityEngine;

namespace RPG.Combat{

  // Whenever we place CombatTarget script, it is going to automatically place a Health component too
  // "You can't have a CombatTarget without Health!"
  [RequireComponent(typeof(Health))]

  public class CombatTarget : MonoBehaviour {
    
  }

}