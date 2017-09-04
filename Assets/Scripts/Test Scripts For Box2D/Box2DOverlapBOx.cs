using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityBerserkersGizmos;

public class Box2DOverlapBOx : MonoBehaviour
{
	
	[SerializeField]Vector3 point;
	[SerializeField]Vector3 size;
	[SerializeField]float angle;
	RaycastHit2D hitByRayCast;
	[SerializeField]ContactFilter2D cf = new ContactFilter2D ();

	[Space (55)][Header ("Results:")]
	[SerializeField]bool isSomethingHit;
	[SerializeField]int overlappedCollidersCount;
	[SerializeField]Collider2D[] results = new Collider2D[10];

	void Update ()
	{		
		isSomethingHit = Physics2D.OverlapBox (point: point, size: size, angle: angle);
		overlappedCollidersCount = Physics2D.OverlapBox (point, size, angle, cf, results);
	}

	void OnDrawGizmos ()
	{
//		GizmosForPhysics2D.DrawOverlapBox (point: point, size: size, angle: angle);
		GizmosForPhysics2D.DrawOverlapBox (point: point, size: size, angle: angle, contactFilter: cf);
	}
}
