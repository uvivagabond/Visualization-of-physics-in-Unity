using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityBerserkersGizmos;

[ExecuteInEditMode]
public class Box2DCollider2DOverlapCollider : MonoBehaviour
{

	[SerializeField]Collider2D collider2D;
	[SerializeField]ContactFilter2D cf = new ContactFilter2D ();

	[Space (22)][Header ("Results:")]
	[SerializeField]int overlappedCollidersCount;
	//	[SerializeField]Collider2D[] results = new Collider2D[3];

	void Update ()
	{		
		collider2D = GetComponent<Collider2D> ();
		Collider2D[] results = new Collider2D[2];
		overlappedCollidersCount = collider2D.OverlapCollider (contactFilter: cf, results: results);

	}

	void OnDrawGizmos ()
	{
		GizmosForPhysics2D.DrawCollider2D_OverlapCollider (collider: collider2D, contactFilter: cf);

	}
}
