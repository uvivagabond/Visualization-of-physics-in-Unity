using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityBerserkersGizmos;

public class PhysXLineCast : MonoBehaviour
{

	[SerializeField]Vector3 start;
	[SerializeField]Vector3 end;
	[Space (55)][Header ("Results:")]

	[SerializeField]	bool isHitSomething;
	RaycastHit hittedByLineCast;

	void FixedUpdate ()
	{
		isHitSomething = Physics.Linecast (start: start, end: end, hitInfo: out hittedByLineCast);
	}

	void OnDrawGizmos ()
	{
//		GizmosForPhysics3D.DrawLineCast (hittedByLine: hittedByLineCast, start: start, end: end);
		GizmosForPhysics3D.DrawLineCast (start: start, end: end);
	}
}
