using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityBerserkersGizmos;

[ExecuteInEditMode]
public class PhysXSphereCast : MonoBehaviour
{
	[SerializeField]Vector3 origin;
	[SerializeField]Vector3 direction;
	[SerializeField]float radius;
	[SerializeField]Ray ray;
	
	[SerializeField]float maxDistance;
	RaycastHit hitBySphere;

	[Space (55)][Header ("Results:")]
	[SerializeField]	 bool isHitSomething;
	//	bool isHitSomethingR;

	void Update ()
	{		
		isHitSomething =	Physics.SphereCast (origin: origin, radius: radius, direction: direction, hitInfo: out hitBySphere, maxDistance: maxDistance);

//		Ray ray =new Ray(origin,direction);
//		isHitSomethingR =	Physics.SphereCast (ray: ray, radius: radius, hitInfo: out hittedBySphere, maxDistance: maxDistance);			
	}

	void OnDrawGizmos ()
	{
		GizmosForPhysics3D.DrawSphereCast (origin: origin, radius: radius, direction: direction, maxDistance: maxDistance);
//		GizmosForPhysics3D.DrawSphereCast (hitBySphere: hittedBySphere, origin: origin, radius: radius, direction: direction, maxDistance: maxDistance);
//		GizmosForPhysics3D.DrawSphereCast (hitBySphere: hittedBySphere, ray: ray, radius: radius, maxDistance: maxDistance);


		
	}
}
