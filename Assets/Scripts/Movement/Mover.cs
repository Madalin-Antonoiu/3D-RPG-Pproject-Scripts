using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Mover : MonoBehaviour {
   
	[SerializeField] Transform target;

	// Update is called every frame
	void Update(){    
		UpdateAnimator();
	}

	public void MoveTo(Vector3 destination){
		GetComponent<NavMeshAgent>().destination = destination;
	}
  

	private void UpdateAnimator(){
		Vector3 velocity = GetComponent<NavMeshAgent>().velocity;
		Vector3 localVelocity = transform.InverseTransformDirection(velocity); // InverseTransformDirection - "No matter where you are in the world, lets convert that into animator for e.g you're moving forward at 3units"
		float speed = localVelocity.z;
		GetComponent<Animator>().SetFloat("forwardSpeed", speed); // Animator - Parameters - forwardSpeed exactly!
	}

}
