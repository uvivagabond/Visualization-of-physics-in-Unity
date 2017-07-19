using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysXSphereCast : MonoBehaviour
{
	[SerializeField]Vector3 origin;
	[SerializeField]Vector3 direction;
	[SerializeField]float radius;
	[SerializeField]Ray ray;
	
	[SerializeField]float maxDistance;
	RaycastHit hittedBySphere;
	RaycastHit[] hittedBySphereTab;

	void Update ()
	{
		bool czyTrafiloWCos =	Physics.SphereCast (origin: origin, radius: radius, direction: direction, hitInfo: out hittedBySphere, maxDistance: maxDistance);
		bool czyTrafiloWCos2 =	Physics.SphereCast (ray: ray, radius: radius, hitInfo: out hittedBySphere, maxDistance: maxDistance);
		
		RaycastHit[] infoOWszystkichTrafionychColliderach;
		hittedBySphereTab =	Physics.SphereCastAll (origin: origin, radius: radius, direction: direction, maxDistance: maxDistance);
		hittedBySphereTab =	Physics.SphereCastAll (ray: ray, radius: radius, maxDistance: maxDistance);
		
	}

	void OnDrawGizmos ()
	{
		GizmosForPhysics3D.DrawSphereCast (hittedBySphere: hittedBySphere, origin: origin, radius: radius, direction: direction, maxDistance: maxDistance);
		GizmosForPhysics3D.DrawSphereCast (hittedBySphere: hittedBySphere, ray: ray, radius: radius, maxDistance: maxDistance);
		GizmosForPhysics3D.DrawSphereCastAll (hittedBySphere: hittedBySphereTab, origin: origin, radius: radius, direction: direction, maxDistance: maxDistance);
		GizmosForPhysics3D.DrawSphereCastAll (hittedBySphere: hittedBySphereTab, ray: ray, radius: radius, maxDistance: maxDistance);

		
	}
}
