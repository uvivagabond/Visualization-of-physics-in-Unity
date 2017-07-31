using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box2DCapsuleCast : MonoBehaviour
{

	[SerializeField]Vector3 origin;
	[SerializeField]Vector3 size;
	[SerializeField]CapsuleDirection2D capsuleDirection;
	[SerializeField]Vector3 direction;
	[SerializeField]float angle = 0;
	[SerializeField]float distance = 1;

	RaycastHit2D hitByRayCast;

	[Space (55)][Header ("Results:")]
	[SerializeField]bool isSomethingHit;

	void Update ()
	{		
		isSomethingHit = Physics2D.CapsuleCast (origin: origin, size: size, capsuleDirection: capsuleDirection, angle: angle, direction: direction, distance: distance);
	}

	void OnDrawGizmos ()
	{
		GizmosForPhysics2D.DrawCapsuleCast (origin: origin, size: size, capsuleDirection: capsuleDirection, angle: angle, direction: direction, distance: distance);
	}
}
