using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Mover : MonoBehaviour {
   
	[SerializeField] Transform target;

	// Update is called every frame
	void Update(){    
		if(Input.GetMouseButtonDown(0)){
			MoveToClick();
		}
		UpdateAnimator();
	}

	private void MoveToClick(){
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		bool hasHit = Physics.Raycast(ray, out hit);	// Physics.Raycast(Ray, RaycastHit) -  API
		if(hasHit){
			GetComponent<NavMeshAgent>().destination = hit.point; //RaycastHit.point - API
		}
	}

	private void UpdateAnimator(){
		Vector3 velocity = GetComponent<NavMeshAgent>().velocity;
		Vector3 localVelocity = transform.InverseTransformDirection(velocity); // InverseTransformDirection - "No matter where you are in the world, lets convert that into animator for e.g you're moving forward at 3units"
		float speed = localVelocity.z;
		GetComponent<Animator>().SetFloat("forwardSpeed", speed); // Animator - Parameters - forwardSpeed exactly!
	}

}
