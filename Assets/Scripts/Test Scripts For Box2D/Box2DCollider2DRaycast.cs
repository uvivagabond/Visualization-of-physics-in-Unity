using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityBerserkersGizmos;

[ExecuteInEditMode]
public class Box2DCollider2DRaycast : MonoBehaviour
{
	[SerializeField]Vector3 direction;
	[SerializeField]Collider2D col;
	[SerializeField]float distance = 1;

	RaycastHit2D[] results = new RaycastHit2D[11];

	[Space (55)][Header ("Results:")]
	[SerializeField]bool isSomethingHit;

	void Update ()
	{
		int colliderCount =	col.Raycast (direction: direction, results: results, distance: distance);
		isSomethingHit = colliderCount > 0;
	}

	void OnDrawGizmos ()
	{
		GizmosForPhysics2D.DrawCollider2D_Raycast (collider: col, direction: direction, distance: distance);
	}
}
