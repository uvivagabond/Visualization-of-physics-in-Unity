using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityBerserkersGizmos;

public class Box2DOverlapCapsule : MonoBehaviour
{
	[SerializeField]Vector3 point;
	[SerializeField]Vector3 size;
	[SerializeField]CapsuleDirection2D capsuleDirection;
	[SerializeField]float angle;
	RaycastHit2D hitByRayCast;

	[Space (55)][Header ("Results:")]
	[SerializeField]bool isSomethingHit;

	void Update ()
	{		
		isSomethingHit = Physics2D.OverlapCapsule (point: point, size: size, direction: capsuleDirection, angle: angle);
	}

	void OnDrawGizmos ()
	{
		GizmosForPhysics2D.DrawOverlapCapsule (point: point, size: size, direction: capsuleDirection, angle: angle);
	}
}
