using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityBerserkersGizmos;
[ExecuteInEditMode]
public class ClosestPointTest : MonoBehaviour
{
	[SerializeField] Rigidbody rig;
	[SerializeField] Transform tr;
	[SerializeField] Collider col;

	[Space (22)][SerializeField] Vector3 closestPointOnCollider;

	
	void Update ()
	{
        //closestPointOnCollider =	Physics.ClosestPoint (point: new Vector3 (1,1), collider: col, position: tr.position, rotation: tr.rotation);

        closestPointOnCollider = col.ClosestPoint(position: new Vector3(0, 0));

        closestPointOnCollider = GizmosForVector.Round (closestPointOnCollider, 2);
	}

	void OnDrawGizmos ()
	{
		GizmosForPhysics3D.VizualizeClosestPoint (point: new Vector3 (1, 1), 
			collider: col, 
			position: tr.position, 
			rotation: tr.rotation);
	
//		GizmosForPhysics3D.VizualizeClosestPoint (new Vector3 (0, 0), col);
	}
}
