using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysXOverlapCapsule : MonoBehaviour
{

	[SerializeField]Vector3 point0;
	[SerializeField]Vector3 point1;
	[SerializeField]float radius;
	
	[Space (55)][Header ("Wyniki:")]
	[SerializeField]	bool czyKapsulaNachodziNaJakiesCollidery;
	[SerializeField]	Collider[] overlapedColliders;


	void Update ()
	{
		Collider[] collideryNaKtoreNachodziKapsula;
		
		overlapedColliders =	Physics.OverlapCapsule (point0: point0, point1: point1, radius: radius);
		czyKapsulaNachodziNaJakiesCollidery = Physics.CheckCapsule (start: point0, end: point1, radius: radius);
		
	}

	void OnDrawGizmos ()
	{
		GizmosForPhysics3D.DrawOverlapCapsule (overlapedColliders: overlapedColliders, point0: point0, point1: point1, radius: radius);
		GizmosForPhysics3D.DrawCheckCapsule (isOverlaped: czyKapsulaNachodziNaJakiesCollidery, start: point0, end: point1, radius: radius);

	}
}
