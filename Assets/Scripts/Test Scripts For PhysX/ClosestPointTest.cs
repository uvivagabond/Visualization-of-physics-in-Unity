using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityBerserkersGizmos;

public class ClosestPointTest : MonoBehaviour
{
	[SerializeField] Rigidbody rig;
	[SerializeField] Transform tr;
	[SerializeField] Collider col;
	[SerializeField] Vector3 closestPoint;

	
	void Update ()
	{
		closestPoint =	Physics.ClosestPoint (point: new Vector3 (0, 0), collider: col, position: tr.position, rotation: tr.rotation);
//		closestPoint =	col.ClosestPoint (position: new Vector3 (0, 0));
		closestPoint = GizmosForVector.Round (closestPoint, 2);
	}

	void OnDrawGizmos ()
	{
		GizmosForPhysics3D.VizualizeClosestPoint (new Vector3 (0, 0), col, tr.position, tr.rotation);
//		GizmosForPhysics3D.VizualizeClosestPoint (new Vector3 (0, 0), col);
	}
}
