using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityBerserkersGizmos;


[ExecuteInEditMode]
public class ClosestPointOnBounds : MonoBehaviour
{

	[SerializeField] Rigidbody rig;
	[SerializeField] Transform tr;
	[SerializeField] Collider col;
	[SerializeField] Vector3 point;

	[Space (22)][SerializeField] Vector3 closestPointOnBounds;


	void Update ()
	{
        //closestPointOnBounds =	col.ClosestPointOnBounds (position:point);

        closestPointOnBounds = rig.ClosestPointOnBounds(position: point);

        closestPointOnBounds = GizmosForVector.Round (closestPointOnBounds, 2);
	}

	void OnDrawGizmos ()
	{
        //GizmosForPhysics3D.VizualizeClosestPointOnBounds(position: point, collider: col);
        GizmosForPhysics3D.VizualizeClosestPointOnBounds (position: point, rigidbody: rig);
	}
}

