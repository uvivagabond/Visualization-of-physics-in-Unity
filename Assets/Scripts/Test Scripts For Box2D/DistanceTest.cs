using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityBerserkersGizmos;

[ExecuteInEditMode]
public class DistanceTest : MonoBehaviour
{

	[SerializeField]Rigidbody2D myRigidbody2D;

	[SerializeField]Collider2D pierwszyKollider;
	[SerializeField]Collider2D drugiKollider;

	ColliderDistance2D distance;
	[SerializeField] Vector3 normal;
	[SerializeField]bool isOverlaped;
	[SerializeField]bool isValid;


	void Update ()
	{
//		Physics2D.Distance (colliderA: pierwszyKollider, colliderB: drugiKollider);

//		pierwszyKollider.Distance (collider: drugiKollider);

		distance = myRigidbody2D.Distance (collider: drugiKollider);
		normal = GizmosForVector.Round (distance.normal, 2);
		isValid = distance.isValid;
		isOverlaped = distance.isOverlapped;
	}

	void OnDrawGizmos ()
	{
		GizmosForPhysics2D.VizualizeDistance (distance);
	}
}
