using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityBerserkersGizmos;

public class PhysXBoxCast : MonoBehaviour
{

	[SerializeField]Vector3 center;
	[SerializeField]Vector3 halfExtents;
	[SerializeField]Vector3 direction;
	[SerializeField]Vector3 eulerAngles;
	Quaternion orientation;
	[SerializeField]float maxDistance = 1;

	[Space (55)][Header ("Results:")]
	[SerializeField]bool isSomethingHit;
	RaycastHit hitByBox;

	void FixedUpdate ()
	{
		orientation = Quaternion.Euler (eulerAngles);
		isSomethingHit = Physics.BoxCast (center: center, halfExtents: halfExtents, direction: direction, hitInfo: out hitByBox, orientation: orientation, maxDistance: maxDistance);
	}

	void OnDrawGizmos ()
	{
		GizmosForPhysics3D.DrawBoxCast (center: center, halfExtents: halfExtents, direction: direction, orientation: orientation, maxDistance: maxDistance);
	}
}
