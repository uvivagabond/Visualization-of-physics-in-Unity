using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysXLineCast : MonoBehaviour
{

	[SerializeField]Vector3 start;
	[SerializeField]Vector3 end;
	RaycastHit hittedByLineCast;

	void Update ()
	{
		bool isHitSomething =	Physics.Linecast (start: start, end: end, hitInfo: out hittedByLineCast);

	}

	void OnDrawGizmos ()
	{
		GizmosForPhysics3D.DrawLineCast (hittedByLine: hittedByLineCast, start: start, end: end); 

	}
}
