using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysXRaycast : MonoBehaviour
{

	[SerializeField]Vector3 origin;
	[SerializeField]Vector3 direction;
	[SerializeField]Ray ray;
	[SerializeField]float maxDistance = 1;

	RaycastHit hittedByRayCast;

	[Space (55)][Header ("Results:")]
	[SerializeField]bool isSomethingHit;

	void FixedUpdate ()
	{
		isSomethingHit = Physics.Raycast (origin: origin, direction: direction, hitInfo: out hittedByRayCast, maxDistance: maxDistance);
		isSomethingHit = Physics.Raycast (ray: ray, hitInfo: out hittedByRayCast, maxDistance: maxDistance);

	}

	void OnDrawGizmos ()
	{
		GizmosForPhysics3D.DrawRaycast (origin: origin, direction: direction, maxDistance: maxDistance);
		GizmosForPhysics3D.DrawRaycast (ray: ray, maxDistance: maxDistance);

	}
}
