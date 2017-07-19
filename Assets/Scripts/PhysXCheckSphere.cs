using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysXCheckSphere : MonoBehaviour
{
	[SerializeField]Vector3 position;
	[SerializeField]Vector3 direction;
	[SerializeField]float radius;

	[Space (55)][Header ("Wyniki:")]
	[SerializeField]	bool czySferaNachodziNaJakiesCollidery;
	[SerializeField]	Collider[] overlapedColliders;

	void Update ()
	{
		Collider[] collideryNaKtoreNachodziSfera;
				
		overlapedColliders =	Physics.OverlapSphere (position: position, radius: radius);
		czySferaNachodziNaJakiesCollidery = Physics.CheckSphere (position: position, radius: radius);
				
	}

	void OnDrawGizmos ()
	{
		GizmosForPhysics3D.DrawOverlapSphere (overlapedColliders: overlapedColliders, position: position, radius: radius);
		GizmosForPhysics3D.DrawCheckSphere (isOverlaped: czySferaNachodziNaJakiesCollidery, position: position, radius: radius);
	}
}
