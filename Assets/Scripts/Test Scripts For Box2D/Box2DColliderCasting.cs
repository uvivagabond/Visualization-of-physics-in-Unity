using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityBerserkersGizmos;

[ExecuteInEditMode]
public class Box2DColliderCasting : MonoBehaviour
{

	[SerializeField]Collider2D myCollider2D;
	[SerializeField]Vector3 direction;
	[SerializeField]float distance = 1;
	[SerializeField]bool ignoreSiblingsColliders = false;
	// remember to always initialize this array!!!
	RaycastHit2D[] hitByCollider2DCast = new RaycastHit2D[11];
	[Space (55)][Header ("Results:")]
	[SerializeField]int hitColliderCount;

	void Update ()
	{		
		hitColliderCount = myCollider2D.Cast (direction: direction, results: hitByCollider2DCast, distance: distance, ignoreSiblingColliders: ignoreSiblingsColliders);
	}

	void OnDrawGizmos ()
	{
		GizmosForPhysics2D.DrawCollider2D_Cast (collider: myCollider2D, direction: direction, distance: distance, ignoreSiblingColliders: ignoreSiblingsColliders);
	}
}
