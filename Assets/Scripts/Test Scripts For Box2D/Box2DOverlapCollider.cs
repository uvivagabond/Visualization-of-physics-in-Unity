using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityBerserkersGizmos;

[ExecuteInEditMode]
public class Box2DOverlapCollider : MonoBehaviour
{

	[SerializeField]Collider2D collider2D;
	[SerializeField]Rigidbody2D rigidbody2D;
	[SerializeField]ContactFilter2D cf = new ContactFilter2D ();

	[Space (22)][Header ("Results:")]
	[SerializeField]int overlappedCollidersCount;
	//	[SerializeField]Collider2D[] results = new Collider2D[3];
	[SerializeField]	 int hitCollidersCount2;
	RaycastHit2D[] results2 = new RaycastHit2D[3];

	void Update ()
	{		
		collider2D = GetComponent<Collider2D> ();
		Collider2D[] results = new Collider2D[2];
		overlappedCollidersCount = Physics2D.OverlapCollider (collider: collider2D, contactFilter: cf, results: results);
//		overlappedCollidersCount = rigidbody2D.OverlapCollider (contactFilter: cf, results: results);

		hitCollidersCount2 = Physics2D.Raycast (new Vector3 (0, 0, 0), Vector3.up, cf, results2, 5);
	}

	void OnDrawGizmos ()
	{
		GizmosForPhysics2D.DrawOverlapCollider (collider: collider2D, contactFilter: cf);
//		GizmosForPhysics2D.DrawOverlapCollider (rigidbody2D: rigidbody2D, contactFilter: cf);

		GizmosForPhysics2D.DrawRayCast (new Vector3 (0, 0, 0), Vector3.up, cf, 5);
	}
}
