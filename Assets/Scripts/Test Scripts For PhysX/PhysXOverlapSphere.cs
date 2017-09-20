using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityBerserkersGizmos;

[ExecuteInEditMode]
public class PhysXOverlapSphere : MonoBehaviour
{

	[SerializeField]Vector3 position;
	[SerializeField]float radius = 1;

	[Space (55)][Header ("Results:")]
	[SerializeField]	Collider[] overlapedColliders;

	void Update ()
	{
		overlapedColliders = Physics.OverlapSphere (position: position, radius: radius);			
	}

	void OnDrawGizmos ()
	{
//		GizmosForPhysics3D.DrawOverlapSphere (overlapedColliders: overlapedColliders, position: position, radius: radius);
		GizmosForPhysics3D.DrawOverlapSphere (position: position, radius: radius);
	}
}
