using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysXOverlapCapsule : MonoBehaviour
{

	[SerializeField]Vector3 point0;
	[SerializeField]Vector3 point1;
	[SerializeField]float radius;
	
	[Space (55)][Header ("Wyniki:")]
	[SerializeField]	Collider[] overlapedColliders;


	void Update ()
	{		
		overlapedColliders =	Physics.OverlapCapsule (point0: point0, point1: point1, radius: radius);
	}

	void OnDrawGizmos ()
	{
//		GizmosForPhysics3D.DrawOverlapCapsule (overlapedColliders: overlapedColliders, point0: point0, point1: point1, radius: radius);
		GizmosForPhysics3D.DrawOverlapCapsule (point0: point0, point1: point1, radius: radius);
	}
}
