using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityBerserkersGizmos;

public class Box2DOverlapArea : MonoBehaviour
{

	[SerializeField]Vector3 pointA;
	[SerializeField]Vector3 pointB;

	RaycastHit2D hitByRayCast;

	[Space (55)][Header ("Results:")]
	[SerializeField]bool isSomethingHit;

	void Update ()
	{		
		isSomethingHit = Physics2D.OverlapArea (pointA: pointA, pointB: pointB);
	}

	void OnDrawGizmos ()
	{
		GizmosForPhysics2D.DrawOverlapArea (pointA: pointA, pointB: pointB);
	}
}
