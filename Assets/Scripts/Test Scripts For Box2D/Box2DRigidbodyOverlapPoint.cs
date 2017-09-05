using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityBerserkersGizmos;

[ExecuteInEditMode]
public class Box2DRigidbodyOverlapPoint : MonoBehaviour
{
	[SerializeField]Rigidbody2D rigidbody2D;
	[SerializeField]Vector3 point;

	[Space (55)][Header ("Results:")]
	[SerializeField]bool isAnyOfRigidbodysCollidersOverlapingPoint;

	void Update ()
	{		
		isAnyOfRigidbodysCollidersOverlapingPoint = rigidbody2D.OverlapPoint (point);  //Physics2D.OverlapPoint (point: point);
	}

	void OnDrawGizmos ()
	{
		GizmosForPhysics2D.DrawRigidbody2D_OverlapPoint (rigidbody2D: rigidbody2D, point: point);
	}
}
