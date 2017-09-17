using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityBerserkersGizmos;

[ExecuteInEditMode]
public class PhysXPlaneRaycast : MonoBehaviour
{
	[SerializeField]Vector3 origin;
	[SerializeField]Vector3 direction;
	[SerializeField]float end;
	[SerializeField]bool isHitForwardSideOfPlane;
	Plane my_Plane;

	void Update ()
	{
		my_Plane = new Plane (inNormal: Vector3.up, inPoint: Vector3.zero);
		
		isHitForwardSideOfPlane = my_Plane.Raycast (new Ray (origin, direction), out end);
	}

	void OnDrawGizmos ()
	{
		GizmosForPhysics3D.Plane_Raycast (my_Plane, new Ray (origin, direction));
	}
}
