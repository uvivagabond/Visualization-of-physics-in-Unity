using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysXRaycast : MonoBehaviour
{

	[SerializeField]Vector3 origin;
	[SerializeField]Vector3 direction;
	[SerializeField]Ray ray;
	// hitinfo
	RaycastHit hittedByRayCast;
	RaycastHit[] hittedByRayCastTab;
	
	
	[SerializeField]float maxDistance = 1;


	void Update ()
	{
		bool czyTrafiloWCos = Physics.Raycast (origin: origin, direction: direction, hitInfo: out hittedByRayCast, maxDistance: maxDistance);
		bool czyTrafiloWCos2 = Physics.Raycast (ray: ray, hitInfo: out hittedByRayCast, maxDistance: maxDistance);

		RaycastHit[] infoOWszystkichTrafionychColliderach;

		hittedByRayCastTab = Physics.RaycastAll (origin: origin, direction: direction, maxDistance: maxDistance);
		hittedByRayCastTab = Physics.RaycastAll (ray: ray, maxDistance: maxDistance);
	}

	void OnDrawGizmos ()
	{
		GizmosForPhysics3D.DrawRaycast (hitByRay: hittedByRayCast, origin: origin, direction: direction, maxDistance: maxDistance);
		GizmosForPhysics3D.DrawRaycast (hitByRay: hittedByRayCast, ray: ray, maxDistance: maxDistance);
		GizmosForPhysics3D.DrawRaycastAll (hitByRay: hittedByRayCastTab, origin: origin, direction: direction, maxDistance: maxDistance);
		GizmosForPhysics3D.DrawRaycastAll (hitByRay: hittedByRayCastTab, ray: ray, maxDistance: maxDistance);
		
	}
}
