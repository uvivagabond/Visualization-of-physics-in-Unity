using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//using Utilities;
using UnityEngine.Events;

public class ExampleClassForPhysics3D : MonoBehaviour
{
	
	#region Variables

	#region BoxCastVariables

	//	[SerializeField]Vector3 center;
	//	[SerializeField]Vector3 halfExtents;
	//	[SerializeField]Vector3 direction;
	//	[SerializeField]Vector3 eulerAngles;
	//	Quaternion orientation;
	//	[SerializeField]float maxDistance = 1;

	//	// hitinfo
	//	RaycastHit hittedByBox;
	//	RaycastHit[] hittedByBoxCastTab;

	#endregion

	#region RayCastVariables

	//	[SerializeField]Vector3 origin;
	//	[SerializeField]Vector3 direction;
	//	[SerializeField]Ray ray;
	//	// hitinfo
	//	RaycastHit hittedByRayCast;
	//	RaycastHit[] hittedByRayCastTab;
	//
	//
	//	[SerializeField]float maxDistance = 1;

	#endregion

	#region LineCastVariables

	//	[SerializeField]Vector3 start;
	//	[SerializeField]Vector3 end;
	//	RaycastHit hittedByLineCast;

	#endregion

	#region SphereCastVariables

	//		[SerializeField]Vector3 origin;
	//		[SerializeField]Vector3 direction;
	//		[SerializeField]float radius;
	//	[SerializeField]Ray ray;
	//
	//	[SerializeField]float maxDistance;
	//	RaycastHit hittedBySphere;
	//	RaycastHit[] hittedBySphereTab;

	#endregion

	#region CapsuleCastVariables

	//		[SerializeField]Vector3 point1;
	//		[SerializeField]	Vector3 point2;
	//		[SerializeField]float radius;
	//		[SerializeField]Vector3 direction;
	//		[SerializeField]float maxDistance;
	//
	//		RaycastHit hittedByCapsule;
	//		RaycastHit[] hittedByCapsuleTab;
	//

	#endregion

	#region Overlap Check Box Variables

	//	[SerializeField]Vector3 center;
	//	[SerializeField]Vector3 halfExtents;
	//	[SerializeField]Vector3 eulerAngles;
	//	Quaternion orientation;
	//	[Space (55)][Header ("Wyniki:")]

	//	[SerializeField]	bool czySzescianNachodziNaJakiesCollidery;
	//	[SerializeField]	Collider[] overlapedColliders;

	#endregion

	#region Overlap Check Capsule Variables

	//	[SerializeField]Vector3 point0;
	//	[SerializeField]Vector3 point1;
	//	[SerializeField]float radius;
	//
	//	[Space (55)][Header ("Wyniki:")]
	//	[SerializeField]	bool czyKapsulaNachodziNaJakiesCollidery;
	//	[SerializeField]	Collider[] overlapedColliders;
	//

	#endregion

	#region Overlap Check Variables

	[SerializeField]Vector3 position;
	[SerializeField]Vector3 direction;
	[SerializeField]float radius;

	[Space (55)][Header ("Wyniki:")]
	[SerializeField]	bool czySferaNachodziNaJakiesCollidery;
	[SerializeField]	Collider[] overlapedColliders;

	#endregion


	#endregion

	void Update ()
	{
//		orientation = Quaternion.Euler (eulerAngles);

		#region BoxCast
		//		bool czyTrafiloWCos = Physics.BoxCast (center: center, halfExtents: halfExtents, direction: direction, hitInfo: out hittedByBox, orientation: orientation, maxDistance: maxDistance);
		//	
		//		RaycastHit[] infoOWszystkichTrafionychColliderach;
		//
		//		hittedByBoxCastTab = Physics.BoxCastAll (center: center, halfExtents: halfExtents, direction: direction, orientation: orientation, maxDistance: maxDistance);
		//		int iloscTrafionychColliderow =	Physics.BoxCastNonAlloc (center: center, halfExtents: halfExtents, direction: direction, results: hittedByBoxCastTab, orientation: orientation, maxDistance: maxDistance);
		#endregion

		#region Raycast
		//		bool czyTrafiloWCos = Physics.Raycast (origin: origin, direction: direction, hitInfo: out hittedByRayCast, maxDistance: maxDistance);
		//		bool czyTrafiloWCos2 = Physics.Raycast (ray: ray, hitInfo: out hittedByRayCast, maxDistance: maxDistance);

		//		RaycastHit[] infoOWszystkichTrafionychColliderach;

		//		hittedByRayCastTab = Physics.RaycastAll (origin: origin, direction: direction, maxDistance: maxDistance);
		//		hittedByRayCastTab = Physics.RaycastAll (ray: ray, maxDistance: maxDistance);
		#endregion

		#region LineCast

		//		Physics.Linecast (start: start, end: end, hitInfo: out hittedByLineCast);

		#endregion

		#region SphereCast
		//		bool czyTrafiloWCos =	Physics.SphereCast (origin: origin, radius: radius, direction: direction, hitInfo: out hittedBySphere, maxDistance: maxDistance);
		//		bool czyTrafiloWCos2 =	Physics.SphereCast (ray: ray, radius: radius, hitInfo: out hittedBySphere, maxDistance: maxDistance);
		//
		//		RaycastHit[] infoOWszystkichTrafionychColliderach;
		//		hittedBySphereTab =	Physics.SphereCastAll (origin: origin, radius: radius, direction: direction, maxDistance: maxDistance);
		//		hittedBySphereTab =	Physics.SphereCastAll (ray: ray, radius: radius, maxDistance: maxDistance);
		//
		#endregion

		#region CapsuleCast

//		bool czyTrafiloWCos = Physics.CapsuleCast (point1: point1, point2: point2, radius: radius, direction: direction, hitInfo: out hittedByCapsule, maxDistance: maxDistance);
//
//		RaycastHit[] infoOWszystkichTrafionychColliderach;
//
//		hittedByCapsuleTab =	Physics.CapsuleCastAll (point1: point1, point2: point2, radius: radius, direction: direction, maxDistance: maxDistance);
//
		#endregion

		#region Overlap Check Box
//		Collider[] collideryNaKtoreNachodziSzescian;
//
//		overlapedColliders = Physics.OverlapBox (center: center, halfExtents: halfExtents, orientation: orientation);
//		czySzescianNachodziNaJakiesCollidery = Physics.CheckBox (center: center, halfExtents: halfExtents, orientation: orientation);
		#endregion

		#region Overlap Check Capsule
//		Collider[] collideryNaKtoreNachodziKapsula;
//
//		overlapedColliders =	Physics.OverlapCapsule (point0: point0, point1: point1, radius: radius);
//		czyKapsulaNachodziNaJakiesCollidery = Physics.CheckCapsule (start: point0, end: point1, radius: radius);
//
		#endregion

		#region Overlap Check Sphere
//		Collider[] collideryNaKtoreNachodziSfera;
//		
//		overlapedColliders =	Physics.OverlapSphere (position: position, radius: radius);
//		czySferaNachodziNaJakiesCollidery = Physics.CheckSphere (position: position, radius: radius);
//		
		#endregion
	}

	void OnDrawGizmos ()
	{
#region Raycasting3D
		#region BoxCast
//		GizmosForPhysics3D.DrawBoxCast (hittedByBox: hittedByBox, 
//			center: center, halfExtents: halfExtents, direction: direction, orientation: orientation, maxDistance: distance);
//		GizmosForPhysics3D.DrawBoxCastAll (hittedByBox: hittedByBoxCastResults, 
//			center: center, halfExtents: halfExtents, direction: direction, orientation: orientation, maxDistance: distance);
		#endregion
		#region Raycast
//		GizmosForPhysics3D.DrawRaycast (hittedByRay: hittedByRayCast, origin: origin, direction: direction, maxDistance: maxDistance);
//		GizmosForPhysics3D.DrawRaycast (hittedByRay: hittedByRayCast, ray: ray, maxDistance: maxDistance);
//		GizmosForPhysics3D.DrawRaycastAll (hittedByRay: hittedByRayCastTab, origin: origin, direction: direction, maxDistance: maxDistance);
//		GizmosForPhysics3D.DrawRaycastAll (hittedByRay: hittedByRayCastTab, ray: ray, maxDistance: maxDistance);
//
		#endregion
#region LineCast
//		GizmosForPhysics3D.DrawLineCast (hittedByLine: hittedByLineCast, start: start, end: end);

#endregion
#region SphereCast
//		GizmosForPhysics3D.DrawSphereCast (hittedBySphere: hittedBySphere, origin: origin, radius: radius, direction: direction, maxDistance: maxDistance);
//		GizmosForPhysics3D.DrawSphereCast (hittedBySphere: hittedBySphere, ray: ray, radius: radius, maxDistance: maxDistance);
//		GizmosForPhysics3D.DrawSphereCastAll (hittedBySphere: hittedBySphereTab, origin: origin, radius: radius, direction: direction, maxDistance: maxDistance);
//		GizmosForPhysics3D.DrawSphereCastAll (hittedBySphere: hittedBySphereTab, ray: ray, radius: radius, maxDistance: maxDistance);


#endregion
#endregion



#region Overlap3D

		#region OverLap Check Box
//		GizmosForPhysics3D.DrawOverlapBox (overlapedColliders: overlapedColliders, center: center, halfExtents: halfExtents, orientation: orientation);
//		GizmosForPhysics3D.DrawCheckBox (isOverlaped: czySzescianNachodziNaJakiesCollidery, center: center, halfExtents: halfExtents, orientation: orientation);
		#endregion
		#region OverLap Check Capsule
//		GizmosForPhysics3D.DrawOverlapCapsule (overlapedColliders: overlapedColliders, point0: point0, point1: point1, radius: radius);
//		GizmosForPhysics3D.DrawCheckCapsule (isOverlaped: czyKapsulaNachodziNaJakiesCollidery, start: point0, end: point1, radius: radius);
		#endregion

		#region OverLap Check Sphere
//		GizmosForPhysics3D.DrawOverlapSphere (overlapedColliders: overlapedColliders, position: position, radius: radius);
//		GizmosForPhysics3D.DrawCheckSphere (isOverlaped: czySferaNachodziNaJakiesCollidery, position: position, radius: radius);
		#endregion
#endregion
	}
}