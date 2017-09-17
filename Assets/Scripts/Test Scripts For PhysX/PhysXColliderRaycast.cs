using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityBerserkersGizmos;

[ExecuteInEditMode]
public class PhysXColliderRaycast : MonoBehaviour
{
	[SerializeField]Vector3 origin;
	[SerializeField]Vector3 direction;
	[SerializeField]float maxDistance = 1;
	[SerializeField]	Collider my_collider;
	Ray ray;
	RaycastHit hitByRayCast;

	[Space (55)][Header ("Results:")]
	[SerializeField]bool isSomethingHit;

	void Start ()
	{
		if (!my_collider) {
			my_collider = GetComponent<Collider> ();
		}		
	}

	void Update ()
	{
		if (my_collider) {
			ray = new Ray (origin, direction);

			isSomethingHit = my_collider.Raycast (ray: ray, hitInfo: out hitByRayCast, maxDistance: maxDistance);
		}
	}

	void OnDrawGizmos ()
	{
		
		GizmosForPhysics3D.DrawCollider_Raycast (collider: my_collider, ray: ray, maxDistance: maxDistance);
	}
}
