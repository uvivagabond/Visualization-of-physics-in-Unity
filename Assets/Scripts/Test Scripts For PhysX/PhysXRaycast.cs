using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityBerserkersGizmos;

public class PhysXRaycast : MonoBehaviour
{
	[SerializeField]Vector3 origin;
	[SerializeField]Vector3 direction;

	[SerializeField]float maxDistance = 1;

	RaycastHit hitByRayCast;
	Ray ray;

	[Space (55)][Header ("Results:")]
	[SerializeField]bool isSomethingHit;

	void Update ()
	{
		isSomethingHit = Physics.Raycast (origin: origin, direction: direction, hitInfo: out hitByRayCast, maxDistance: maxDistance);
		ray = new Ray (origin, direction);
		isSomethingHit = Physics.Raycast (ray: ray, hitInfo: out hitByRayCast, maxDistance: maxDistance);

	}

	void OnDrawGizmos ()
	{
		GizmosForPhysics3D.DrawRaycast (origin: origin, direction: direction, maxDistance: maxDistance);
//		GizmosForPhysics3D.DrawRaycast (ray: ray, maxDistance: maxDistance);
	}
}
