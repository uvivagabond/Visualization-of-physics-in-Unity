using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class ExampleClassForPhysics2D : MonoBehaviour
{
	[SerializeField]	Rigidbody2D rig;

	[SerializeField]bool czyMogaWSrodku;
	[SerializeField] Collider2D col;

	#region Variables

	#region RayCastVariables

	//	[SerializeField]Vector3 origin;
	//	[SerializeField]Vector3 direction = new Vector3 (1f, 0f, 0f);
	//	[SerializeField]Ray ray;
	//	[SerializeField]float distance = 1;
	//
	//	//	//	// hitinfo
	//	RaycastHit2D hitByRayCast;
	//	RaycastHit2D[] hitByRayCastTab;
	//	RaycastHit2D[] hitByRayCastTab2 = new RaycastHit2D[11];
	//
	//	[SerializeField]int iloscTrafionychColliderow;

	#endregion

	#region LineCastVariables

	//
	//	[SerializeField]Vector3 start;
	//	[SerializeField]Vector3 end;
	//	RaycastHit2D hittedByLineCast;
	//	RaycastHit2D[] hittedByLineCastTab = new RaycastHit2D[3];
	//	[SerializeField]	int iloscTrafionychColliderow;
	//
	//

	#endregion

	#region BoxCastVariables

	
	[SerializeField]Vector3 origin;
	[SerializeField]Vector3 size;
	[SerializeField]float angle;
	[SerializeField]Vector3 direction;
	[SerializeField]float distance = 1;
	
	RaycastHit2D hittedByBox;
	RaycastHit2D[] hitByBoxCastTab = new RaycastHit2D[111];
	RaycastHit2D[] hitByBoxCastTab222;

	[SerializeField]int iloscTrafionychColliderow;
	[SerializeField]int iloscTrafionychColliderow222;


	#endregion

	#region CapsuleCastVariables

	//
	//	[SerializeField]Vector3 origin;
	//	[SerializeField]Vector3 size;
	//	[SerializeField]float angle;
	//	[SerializeField]Vector3 direction;
	//	[SerializeField]float distance = 1;
	//	[SerializeField] CapsuleDirection2D capsuleDirection;
	//	RaycastHit2D hittedByCapsule;
	//	RaycastHit2D[] hittedByCapsuleCastTab;
	//


	#endregion

	#region CircleCastVariables

	//	[SerializeField]Vector3 origin;
	//	[SerializeField]float radius;
	//	[SerializeField]Vector3 direction;
	//	[SerializeField]float distance = 1;
	//	RaycastHit2D hittedByCircle;
	//	RaycastHit2D[] hittedByCircleCastTab;


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

	//	[SerializeField]Vector3 position;
	//	[SerializeField]Vector3 direction;
	//	[SerializeField]float radius;
	//
	//	[Space (55)][Header ("Wyniki:")]
	//	[SerializeField]	bool czySferaNachodziNaJakiesCollidery;
	//	[SerializeField]	Collider[] overlapedColliders;
	//

	#endregion


	#endregion

	#region zzz



	//	[SerializeField]Vector3 point1;
	//	[SerializeField]Vector3 point2;
	//
	//	Quaternion quat = Quaternion.identity;
	//	[SerializeField]Vector3 angles;

	//	[Space (50)]
	//	[SerializeField]Vector3 mojRozmiarDlaGizm;
	//	[Space (50)]
	//	[Space (50)]
	//	[SerializeField]bool same = true;
	//	Bounds b	= new Bounds (new Vector3 (0, 3), new Vector3 (2, 2));
	//	//	[SerializeField]	BoundingSphere bs = new BoundingSphere (new Vector3 (0, 0), 1);
	//	// tylko pierwsza składowa ma znaczenie, rysuje i tak kwadrat
	//	[Space (50)]
	//	[SerializeField]float distance = 10;
	//	RaycastHit2D hitByBox;
	//	RaycastHit2D hitByLine;
	//	RaycastHit2D hitByRay;
	//	RaycastHit2D hitByCapsules;
	//	RaycastHit2D[] hitByRays;
	//
	//	[Space (50)]
	//	[SerializeField]Vector3 center;
	//	[SerializeField]Vector3 size;
	//
	//	[SerializeField]CapsuleDirection2D capsuleDirectionDlaGizm = CapsuleDirection2D.Vertical;
	//	[SerializeField]float angle;
	//
	//	[Space (50)]
	//
	//
	//
	//
	//	Ray ray;
	//	RaycastHit2D[] hitCircle;
	//	RaycastHit hit3D;
	//	Collider[] overlaped3DTab;
	//
	//	RaycastHit2D[ ] hitByLines;
	//	[Space (50)][Space (50)]
	//	[SerializeField]	Collider2D coll;
	//	[SerializeField]	Collider2D coll2;
	//	Collider2D[] collTab;
	//	[SerializeField]CapsuleDirection2D capsuleDirectionDlaRaycasta = CapsuleDirection2D.Vertical;
	//	float alfhaOffset;
	//	float znak;

	#endregion

	void Update ()
	{
//		Debug.Log ();
		Physics2D.queriesStartInColliders = false;
//		ray = new Ray (origin, direction);
		ContactFilter2D contactFilter = new ContactFilter2D ();
		contactFilter.NoFilter ();
	
		#region Overlap
//		coll = Physics2D.OverlapArea (center, mojRozmiarDlaRaycasta);
//		collTab = Physics2D.OverlapAreaAll (center, mojRozmiarDlaRaycasta);

//		coll = Physics2D.OverlapBox (center, mojRozmiarDlaRaycasta, angle);
//		collTab = Physics2D.OverlapBoxAll (center, mojRozmiarDlaRaycasta, angle);
//
//		coll = Physics2D.OverlapCapsule (center, mojRozmiarDlaRaycasta, capsuleDirectionDlaGizm, angle);
//		collTab = Physics2D.OverlapCapsuleAll (center, mojRozmiarDlaRaycasta, capsuleDirectionDlaGizm, angle);
//
//		coll = Physics2D.OverlapCircle (center, radius);
//		collTab = Physics2D.OverlapCircleAll (center, radius);
		#endregion
		#region Raycasting
//		hitByRayCast = Physics2D.Raycast (origin: origin, direction: direction, distance: distance);
//		//int 
//		iloscTrafionychColliderow =	Physics2D.Raycast (origin: origin, direction: direction, distance: distance, 
//			contactFilter: contactFilter, results: hitByRayCastTab);
//		hitByRayCastTab = Physics2D.RaycastAll (origin: origin, direction: direction, distance: distance);
//		iloscTrafionychColliderow =	Physics2D.RaycastNonAlloc (origin: origin, direction: direction, results: hitByRayCastTab, distance: distance);


//		hittedByRayCast =	Physics2D.GetRayIntersection (ray: ray, distance: distance);
//		hittedByRayCastTab2 =	Physics2D.GetRayIntersectionAll (ray: ray, distance: distance);
//		iloscTrafionychColliderow =	Physics2D.GetRayIntersectionNonAlloc (ray: ray, results: hittedByRayCastTab2, distance: distance);

		#endregion
#region LineCasting
//		hittedByLineCast = Physics2D.Linecast (start: start, end: end);
//		Physics2D.LinecastNonAlloc (start: start, end: end, results: hittedByLineCastTab);
//		iloscTrafionychColliderow = Physics2D.Linecast (start: start, end: end, contactFilter: contactFilter, results: hittedByLineCastTab);
//		hittedByLineCastTab = Physics2D.LinecastAll (start: start, end: end);
#endregion
#region BoxCasting
//		hittedByBox = Physics2D.BoxCast (origin: origin, size: size, angle: angle, direction: direction, distance: distance);
//		int iloscTrafionychColliderow = Physics2D.BoxCast (origin: origin, size: size, angle: angle, direction: direction, contactFilter: contactFilter, results: hittedByBoxCastTab, distance: distance);
//		hitByBoxCastTab = Physics2D.BoxCastAll (origin: origin, size: size, angle: angle, direction: direction, distance: distance);
////		iloscTrafionychColliderow = Physics2D.BoxCastNonAlloc (origin: origin, size: size, angle: angle, direction: direction, results: hittedByBoxCastTab, distance: distance);
		iloscTrafionychColliderow = col.Cast (direction, hitByBoxCastTab, distance, true);
		iloscTrafionychColliderow222 = rig.Cast (direction, hitByBoxCastTab222, distance);

//		Debug.Log ("zz " + iloscTrafionychColliderow);
//		Debug.Log ("zz222 " + iloscTrafionychColliderow222);


//		foreach (var item in hitByBoxCastTab) {
//			if (item.collider != null)
//				Debug.Log ("zz " + item.collider.name);
//
//		}
//		Debug.Log ("zz ");

//		Debug.Log ("ile trafia " + iloscTrafionychColliderow);
#endregion
#region CapsuleCasting
//		hittedByCapsule = Physics2D.CapsuleCast (origin: origin, size: size, capsuleDirection: capsuleDirection, angle: angle, direction: direction);
//		int iloscTrafionychColliderow = Physics2D.CapsuleCast (origin: origin, size: size, capsuleDirection: capsuleDirection, angle: angle, contactFilter: contactFilter, results: hittedByCapsuleCastTab, direction: direction);
//		iloscTrafionychColliderow = Physics2D.CapsuleCastNonAlloc (origin: origin, size: size, capsuleDirection: capsuleDirection, angle: angle, results: hittedByCapsuleCastTab, direction: direction);
//		hittedByCapsuleCastTab = Physics2D.CapsuleCastAll (origin: origin, size: size, capsuleDirection: capsuleDirection, angle: angle, direction: direction);

#endregion
#region CircleCast
//		hittedByCircle = Physics2D.CircleCast (origin: origin, radius: radius, direction: direction);
//		int iloscTrafionychColliderow = Physics2D.CircleCast (origin: origin, radius: radius, contactFilter: contactFilter, results: hittedByCircleCastTab, direction: direction);
//		iloscTrafionychColliderow = Physics2D.CircleCastNonAlloc (origin: origin, radius: radius, results: hittedByCircleCastTab, direction: direction);
//		hittedByCircleCastTab = Physics2D.CircleCastAll (origin: origin, radius: radius, direction: direction);
//
#endregion

	}

	void OnDrawGizmos ()
	{
//		GizmosForPhysics2D.DrawCollider2D_Raycast (this.GetComponent<Collider2D> (), direction);
		#region Raycasting2D
		//		GizmosForPhysics2D.DrawRayCast (hitInfo: hittedByRayCast, origin: origin, direction: direction, distance: distance);
//		GizmosForPhysics2D.DrawRayCast (hitColliderCount: iloscTrafionychColliderow, origin: origin, direction: direction, distance: distance);

//		GizmosForPhysics2D.DrawRayCastAll (hitInfos: hitByRayCastTab, origin: origin, direction: direction, distance: distance);

		//		GizmosForPhysics2D.DrawGetRayIntersection (hitInfo: hittedByRayCast, ray: ray, distance: distance);

		//		GizmosForPhysics2D.DrawGetRayIntersectionAll (hitInfos: hittedByRayCastTab2, ray: ray, distance: distance);
		//		GizmosForPhysics2D.DrawGetRayIntersectionAll (hitInfos: hittedByRayCastTab2, ray: ray, distance: distance);
//		GizmosForPhysics2D.DrawGetRayIntersectionNonAlloc (hitColliderCount: iloscTrafionychColliderow, ray: ray, distance: distance);

		#endregion

		#region LineCasting2D
		//		GizmosForPhysics2D.DrawLineCast (hitInfo: hittedByLineCast, start: start, end: end);
//		GizmosForPhysics2D.DrawLineCast (hitColliderCount: iloscTrafionychColliderow, start: start, end: end);

		#endregion

		#region BoxCasting2D
//		GizmosForPhysics2D.DrawBoxCastAll (hitInfos: hitByBoxCastTab, origin: origin, size: size, angle: angle, direction: direction, distance: distance);
		#endregion

//		GizmosForPhysics2D.DrawCollider2D_Cast (col, direction, distance, true);

		#region Overlap2D
		//		GizmosForPhysics2D.DrawOverlapArea (coll, center, mojRozmiarDlaRaycasta);
		//		GizmosForPhysics2D.DrawOverlapArea (collTab, center, mojRozmiarDlaRaycasta);
		//		GizmosForPhysics2D.DrawOverlapAreaAll (collTab, center, mojRozmiarDlaRaycasta);

		//		GizmosForPhysics2D.DrawOverlapBox (coll, center, mojRozmiarDlaRaycasta, angle);
		//		Gizmos.DrawSphere (center, 0.1f);
		//		GizmosForPhysics2D.DrawOverlapBox (collTab, center, mojRozmiarDlaRaycasta, angle);
		//		GizmosForPhysics2D.DrawOverlapBoxAll (collTab, center, mojRozmiarDlaRaycasta, angle);
		//
		//		GizmosForPhysics2D.DrawOverlapCapsule (coll, center, mojRozmiarDlaRaycasta, capsuleDirectionDlaGizm, angle);
		//		GizmosForPhysics2D.DrawOverlapCapsule (collTab, center, mojRozmiarDlaRaycasta, capsuleDirectionDlaGizm, angle);
		//		GizmosForPhysics2D.DrawOverlapCapsuleAll (collTab, center, mojRozmiarDlaRaycasta, capsuleDirectionDlaGizm, angle);
		//
		//		GizmosForPhysics2D.DrawOverlapCircle (coll, center, radius);
		//		GizmosForPhysics2D.DrawOverlapCircle (collTab, center, radius);
		//		GizmosForPhysics2D.DrawOverlapCircleAll (collTab, center, radius);
		//
		//		GizmosForPhysics2D.DrawOverlapPoint (coll, center);
		//		GizmosForPhysics2D.DrawOverlapPoint (collTab, center);
		//		GizmosForPhysics2D.DrawOverlapPointAll (collTab, center);
		#endregion

	}




}