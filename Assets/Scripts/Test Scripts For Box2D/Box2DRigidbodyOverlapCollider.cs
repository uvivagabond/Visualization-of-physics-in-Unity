using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityBerserkersGizmos;

[ExecuteInEditMode]
public class Box2DRigidbodyOverlapCollider : MonoBehaviour
{

	[SerializeField]Rigidbody2D rigidbody2D;
	[SerializeField]ContactFilter2D cf = new ContactFilter2D ();

	[Space (22)][Header ("Results:")]
	[SerializeField]int overlappedCollidersCount;
	//	[SerializeField]Collider2D[] results = new Collider2D[3];

	void Update ()
	{		
		rigidbody2D = GetComponent<Rigidbody2D> ();
		Collider2D[] results = new Collider2D[2];
		overlappedCollidersCount = rigidbody2D.OverlapCollider (contactFilter: cf.NoFilter (), results: results);

	}

	void OnDrawGizmos ()
	{
		GizmosForPhysics2D.DrawRigidbody2D_OverlapCollider (rigidbody2D: rigidbody2D, contactFilter: cf);

	}
}
