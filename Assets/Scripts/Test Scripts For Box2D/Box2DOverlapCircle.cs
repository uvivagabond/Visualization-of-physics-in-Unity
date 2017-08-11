using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityBerserkersGizmos;

public class Box2DOverlapCircle : MonoBehaviour
{
	[SerializeField]Vector3 point;
	[SerializeField]float radius;
	RaycastHit2D hitByRayCast;

	[Space (55)][Header ("Results:")]
	[SerializeField]bool isSomethingHit;

	void Update ()
	{		
		isSomethingHit = Physics2D.OverlapCircle (point: point, radius: radius);
	}

	void OnDrawGizmos ()
	{
		GizmosForPhysics2D.DrawOverlapCircle (point: point, radius: radius);
	}
}
