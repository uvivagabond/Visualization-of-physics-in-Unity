using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityBerserkersGizmos;

public class Box2DRigidbodyCasting : MonoBehaviour
{
	[SerializeField]Rigidbody2D myRigidbody2D;
	[SerializeField]Vector3 direction;
	[SerializeField]float distance = 1;
	// always must be declared table size!
	RaycastHit2D[] hitByRigidbody2DCast = new RaycastHit2D[5];
	[Space (55)][Header ("Results:")]
	[SerializeField]int hitColliderCount;

	void Update ()
	{		
		hitColliderCount = myRigidbody2D.Cast (direction: direction, results: hitByRigidbody2DCast, distance: distance);
	}

	void OnDrawGizmos ()
	{
		GizmosForPhysics2D.DrawRigidbody2D_Cast (rigidbody2D: myRigidbody2D, direction: direction, distance: distance);
	}
}
