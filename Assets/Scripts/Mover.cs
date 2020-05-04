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
	}

	private void MoveToClick(){
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		bool hasHit = Physics.Raycast(ray, out hit);	// Physics.Raycast(Ray, RaycastHit) -  API
		if(hasHit){
			GetComponent<NavMeshAgent>().destination = hit.point; //RaycastHit.point - API
		}
	}

}
