using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityBerserkersGizmos;

public class ClosestPointOnBounds : MonoBehaviour
{

	[SerializeField] Rigidbody rig;
	[SerializeField] Transform tr;
	[SerializeField] Collider col;
	[SerializeField] Vector3 closestPoint;


	void Update ()
	{
		closestPoint =	col.ClosestPointOnBounds (tr.position);
		//		closestPoint =	col.ClosestPoint (position: new Vector3 (0, 0));
		//		myRigidbody2D.
		closestPoint = GizmosForVector.Round (closestPoint, 2);
	}

	void OnDrawGizmos ()
	{
//		GizmosForPhysics3D.VizualizeClosestPointOnBounds (new Vector3 (0, 0), col);
		GizmosForPhysics3D.VizualizeClosestPointOnBounds (new Vector3 (0, 0), rig);

	}
}

