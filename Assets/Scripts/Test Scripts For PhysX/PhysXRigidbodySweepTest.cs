using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityBerserkersGizmos;

[RequireComponent (typeof(Rigidbody))]
public class PhysXRigidbodySweepTest : MonoBehaviour
{
	[SerializeField]Vector3 origin;
	[SerializeField]Vector3 direction;
	[SerializeField]Ray ray;
	[SerializeField]float maxDistance = 1;
	Rigidbody my_rigidbody;
	RaycastHit hitByRayCast;

	[Space (55)][Header ("Results:")]
	[SerializeField]bool isSomethingHit;

	void FixedUpdate ()
	{
		if (!my_rigidbody) {
			my_rigidbody = this.GetComponent<Rigidbody> ();
		}
		if (my_rigidbody) {
			my_rigidbody.SweepTest (direction: direction, hitInfo: out hitByRayCast, maxDistance: maxDistance);
		}
	}

	void OnDrawGizmos ()
	{

		GizmosForPhysics3D.Rigidbody_SweepTest (rigidbody: my_rigidbody, direction: direction, maxDistance: maxDistance);
//		GizmosForPhysics3D.DrawRaycast (origin: origin, direction: direction, maxDistance: maxDistance);
//		GizmosForPhysics3D.DrawRaycast (ray: ray, maxDistance: maxDistance);
	}
}
