using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityBerserkersGizmos;

[ExecuteInEditMode]
public class PhysXCapsuleCast : MonoBehaviour
{

	[SerializeField]Vector3 point1;
	[SerializeField]Vector3 point2;
	[SerializeField]float radius;
	[SerializeField]Vector3 direction;
	[SerializeField]float maxDistance;

	[Space (55)][Header ("Results:")]
	[SerializeField]bool isHitSomething;
	RaycastHit hitByCapsule;

	void Update ()
	{
		isHitSomething = Physics.CapsuleCast (point1: point1, point2: point2, radius: radius, direction: direction, hitInfo: out hitByCapsule, maxDistance: maxDistance);
	}

	void OnDrawGizmos ()
	{
		GizmosForPhysics3D.DrawCapsuleCast (point1: point1, point2: point2, radius: radius, direction: direction, maxDistance: maxDistance);
	}
}
