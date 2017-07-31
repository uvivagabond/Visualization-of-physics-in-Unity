using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box2DOverlapPoint : MonoBehaviour
{
	[SerializeField]Vector3 point;
	RaycastHit2D hitByRayCast;

	[Space (55)][Header ("Results:")]
	[SerializeField]bool isSomethingHit;

	void Update ()
	{		
		isSomethingHit = Physics2D.OverlapPoint (point: point);
	}

	void OnDrawGizmos ()
	{
		GizmosForPhysics2D.DrawOverlapPoint (point: point);
	}
}
