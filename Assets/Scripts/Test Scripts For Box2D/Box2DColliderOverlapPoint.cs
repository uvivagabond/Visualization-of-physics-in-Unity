using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityBerserkersGizmos;

[ExecuteInEditMode]
public class Box2DColliderOverlapPoint : MonoBehaviour
{
	[SerializeField]Collider2D myCollider2D;
	[SerializeField]Vector3 point;
	RaycastHit2D hitByRayCast;

	[Space (55)][Header ("Results:")]
	[SerializeField] bool isColliderOverlapingPoint;

	void Update ()
	{		
		isColliderOverlapingPoint = myCollider2D.OverlapPoint (point);
	}

	void OnDrawGizmos ()
	{
		GizmosForPhysics2D.DrawCollider2D_OverlapPoint (point: point);
	}
}
