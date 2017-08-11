using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityBerserkersGizmos;

public class PhysXPlaneRaycast : MonoBehaviour
{
	[SerializeField]Vector3 origin;
	[SerializeField]Vector3 direction;
	[SerializeField]float end;

	Plane my_Plane;
	// Use this for initialization
	void Start ()
	{
		my_Plane = new Plane (inNormal: Vector3.up, inPoint: Vector3.zero);
	}
	
	// Update is called once per frame
	void Update ()
	{
		my_Plane.Raycast (new Ray (origin, direction), out end);
	}

	void OnDrawGizmos ()
	{
		GizmosForPhysics3D.Plane_Raycast (my_Plane, new Ray (origin, direction));
	}
}
