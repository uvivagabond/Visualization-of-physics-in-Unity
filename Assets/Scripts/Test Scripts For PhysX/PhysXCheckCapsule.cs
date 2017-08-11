using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityBerserkersGizmos;

public class PhysXCheckCapsule : MonoBehaviour
{

	[SerializeField]Vector3 point0;
	[SerializeField]Vector3 point1;
	[SerializeField]float radius = 1;
	[SerializeField]float maxDistance;
	
	[Space (55)][Header ("Results:")]
	[SerializeField]	bool isCapsuleOverlapSomething;


	void Update ()
	{
		isCapsuleOverlapSomething =	Physics.CheckCapsule (start: point0, end: point1, radius: radius);
	}

	void OnDrawGizmos ()
	{
//		GizmosForPhysics3D.DrawCheckCapsule (isOverlaped: isCapsuleOverlapSomething, start: point0, end: point1, radius: radius);
		GizmosForPhysics3D.DrawCheckCapsule (start: point0, end: point1, radius: radius);

	}
}
