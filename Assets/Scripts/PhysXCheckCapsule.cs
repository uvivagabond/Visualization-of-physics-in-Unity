using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysXCheckCapsule : MonoBehaviour
{

	[SerializeField]Vector3 point0;
	[SerializeField]Vector3 point1;
	[SerializeField]float radius;
	
	[Space (55)][Header ("Wyniki:")]
	[SerializeField]	bool czyKapsulaNachodziNaJakiesCollidery;
	[SerializeField]	Collider[] overlapedColliders;


	void Update ()
	{
//				orientation = Quaternion.Euler (eulerAngles);
//		bool czyTrafiloWCos = Physics.CapsuleCast (point1: point1, point2: point2, radius: radius, direction: direction, hitInfo: out hittedByCapsule, maxDistance: maxDistance);
		
		RaycastHit[] infoOWszystkichTrafionychColliderach;
		
//				hittedByCapsuleTab =	Physics.CapsuleCastAll (point1: point1, point2: point2, radius: radius, direction: direction, maxDistance: maxDistance);
		
	}

	void OnDrawGizmos ()
	{
		GizmosForPhysics3D.DrawOverlapCapsule (overlapedColliders: overlapedColliders, point0: point0, point1: point1, radius: radius);
		GizmosForPhysics3D.DrawCheckCapsule (isOverlaped: czyKapsulaNachodziNaJakiesCollidery, start: point0, end: point1, radius: radius);

	}
}
