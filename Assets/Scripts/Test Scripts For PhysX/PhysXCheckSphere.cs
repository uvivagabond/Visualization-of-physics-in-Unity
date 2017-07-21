using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysXCheckSphere : MonoBehaviour
{
	[SerializeField]Vector3 position;
	[SerializeField]float radius;

	[Space (55)][Header ("Results:")]
	[SerializeField]	bool isSphereOverlapColliders;

	void FixedUpdate ()
	{				
		isSphereOverlapColliders = Physics.CheckSphere (position: position, radius: radius);				
	}

	void OnDrawGizmos ()
	{
//		GizmosForPhysics3D.DrawCheckSphere (isOverlaped: isSphereOverlapColliders, position: position, radius: radius);
		GizmosForPhysics3D.DrawCheckSphere (position: position, radius: radius);
	}
}
