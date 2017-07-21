using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysXOverlapBox : MonoBehaviour
{
	[SerializeField]Vector3 center;
	[SerializeField]Vector3 halfExtents;
	[SerializeField]Vector3 eulerAngles;
	Quaternion orientation;
	[Space (55)][Header ("Results:")]
	[SerializeField]	Collider[] overlapedColliders;

	void FixedUpdate ()
	{
		orientation = Quaternion.Euler (eulerAngles);
		overlapedColliders = Physics.OverlapBox (center: center, halfExtents: halfExtents, orientation: orientation);			
	}

	void OnDrawGizmos ()
	{
//		GizmosForPhysics3D.DrawOverlapBox (overlapedColliders: overlapedColliders, center: center, halfExtents: halfExtents, orientation: orientation);
		GizmosForPhysics3D.DrawOverlapBox (center: center, halfExtents: halfExtents, orientation: orientation);

	}
}
