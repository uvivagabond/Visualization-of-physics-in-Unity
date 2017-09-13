using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityBerserkersGizmos
{
	public static class GizmosForPhysics3D
	{
		#region Variables

		static Mesh sphereMesh;
		static Color nonHitColorB = Color.blue;
		static Color nonHitColorB2 = new Color (r: 0.129f, g: 0.108f, b: 0.922f, a: 0.25f);
		static Color nonHitColorB3 = new Color (r: 0.129f, g: 0.108f, b: 0.922f, a: 0.10f);

		static Color nonHitColorBaseG = new Color (r: 0.18f, g: 0.88f, b: 0.49f, a: 1f);
		//Color.green;
		static Color hitColorR = Color.red;
		static Color hitColorO = new Color (r: 1f, g: 0.341f, b: 0.133f, a: 1f);
		static Color hitColorR2 = new Color (r: 1f, g: 0.058f, b: 0.01f, a: 0.25f);
		static Color hitColorR3 = new Color (r: 1f, g: 0.058f, b: 0.01f, a: 0.10f);

		static Color overlappedColorR = Color.red;
		static Color nonOverlappedColorY = Color.yellow;
		static Color overlappedColorY2 = new Color (r: 1f, g: 0.341f, b: 0.133f, a: 1f);
		static Quaternion identity = Quaternion.identity;
		const int AdditionalDots = 0;
		const int DefaultSign = 1;
		const bool isDotted = false;

		#endregion

		#region RAYCASTING QUERIES

		#region Raycast3D

		public static void DrawRaycast (Vector3 origin, Vector3 direction, float maxDistance = Mathf.Infinity
		, int layerMask = Physics.DefaultRaycastLayers, QueryTriggerInteraction queryTriggerInteraction = QueryTriggerInteraction.UseGlobal)
		{
			RaycastHit hitInfo;
			bool isHit = Physics.Raycast (origin, direction, out hitInfo, maxDistance, layerMask, queryTriggerInteraction);
			DrawRaycast3DRaw (origin, direction, maxDistance, isHit);
		}

		public static void DrawRaycast (Ray ray, float maxDistance = Mathf.Infinity
		, int layerMask = Physics.DefaultRaycastLayers, QueryTriggerInteraction queryTriggerInteraction = QueryTriggerInteraction.UseGlobal)
		{
			DrawRaycast (ray.origin, ray.direction, maxDistance, layerMask, queryTriggerInteraction);
		}

		public static void DrawRaycastAll (Vector3 origin, Vector3 direction, float maxDistance = Mathf.Infinity
		, int layerMask = Physics.DefaultRaycastLayers, QueryTriggerInteraction queryTriggerInteraction = QueryTriggerInteraction.UseGlobal)
		{
			DrawRaycast (origin, direction, maxDistance, layerMask, queryTriggerInteraction);
		}

		public static void DrawRaycastAll (Ray ray, float maxDistance = Mathf.Infinity
		, int layerMask = Physics.DefaultRaycastLayers, QueryTriggerInteraction queryTriggerInteraction = QueryTriggerInteraction.UseGlobal)
		{
			DrawRaycast (ray.origin, ray.direction, maxDistance, layerMask, queryTriggerInteraction);
		}

		public static void DrawRaycastNonAlloc (Vector3 origin, Vector3 direction, float maxDistance = Mathf.Infinity
		, int layerMask = Physics.DefaultRaycastLayers, QueryTriggerInteraction queryTriggerInteraction = QueryTriggerInteraction.UseGlobal)
		{
			DrawRaycast (origin, direction, maxDistance, layerMask, queryTriggerInteraction);

		}

		public static void DrawRaycastNonAlloc (Ray ray, float maxDistance = Mathf.Infinity
		, int layerMask = Physics.DefaultRaycastLayers, QueryTriggerInteraction queryTriggerInteraction = QueryTriggerInteraction.UseGlobal)
		{
			DrawRaycast (ray.origin, ray.direction, maxDistance, layerMask, queryTriggerInteraction);
		}

		public static void DrawRaycastNonAlloc (int hitColliderCount, Vector3 origin, Vector3 direction, float maxDistance = Mathf.Infinity)
		{
			bool isHit = (hitColliderCount > 0);	
			DrawRaycast3DRaw (origin, direction, maxDistance, isHit);
		}

		public static void DrawRaycastNonAlloc (int hitColliderCount, Ray ray, float maxDistance = Mathf.Infinity)
		{
			bool isHit = (hitColliderCount > 0);	
			DrawRaycast3DRaw (ray.origin, ray.direction, maxDistance, isHit);
		}

		public static void DrawRaycast (bool isHit, Vector3 origin, Vector3 direction, float maxDistance = Mathf.Infinity)
		{
			DrawRaycast3DRaw (origin, direction, maxDistance, isHit);
		}

		public static void DrawRaycast (bool isHit, Ray ray, float maxDistance = Mathf.Infinity)
		{
			DrawRaycast3DRaw (ray.origin, ray.direction, maxDistance, isHit);
		}

		public static void DrawRaycast (RaycastHit hitByRay, Vector3 origin, Vector3 direction, float maxDistance = Mathf.Infinity)
		{
			bool isHit = hitByRay.collider != null;
			DrawRaycast3DRaw (origin, direction, maxDistance, isHit);
		}

		public static void DrawRaycast (RaycastHit hitByRay, Ray ray, float maxDistance = Mathf.Infinity)
		{
			bool isHit = hitByRay.collider != null;
			DrawRaycast3DRaw (ray.origin, ray.direction, maxDistance, isHit);
		}

		public static void DrawRaycastAll (RaycastHit[] hitByRay, Ray ray, float maxDistance = Mathf.Infinity)
		{
			bool isHit = (hitByRay != null && hitByRay.Length > 0);
			DrawRaycast3DRaw (ray.origin, ray.direction, maxDistance, isHit);
		}

		public static void DrawRaycastAll (RaycastHit[] hitByRay, Vector3 origin, Vector3 direction, float maxDistance = Mathf.Infinity)
		{
			bool isHit = (hitByRay != null && hitByRay.Length > 0);
			DrawRaycast3DRaw (origin, direction, maxDistance, isHit);
		}

		static void DrawRaycast3DRaw (Vector3 origin, Vector3 direction, float maxDistance, bool isHit)
		{		
			if (maxDistance > 0f) {
				Gizmos.color = (isHit) ? hitColorR : nonHitColorB;
				direction = direction.normalized;
				maxDistance = (maxDistance == Mathf.Infinity) ? 100000f : maxDistance;
				Gizmos.DrawRay (origin, direction * maxDistance);	
			}
			Gizmos.color = (isHit) ? hitColorR : nonHitColorBaseG;
			Gizmos.DrawSphere (origin, 0.1f);
			Gizmos.color = Color.white;	
		}

		#endregion

		#region Linecast3D

		public static void DrawLineCast (Vector3 start, Vector3 end
		, int layerMask = Physics.DefaultRaycastLayers, QueryTriggerInteraction queryTriggerInteraction = QueryTriggerInteraction.UseGlobal)
		{
			bool isHit = Physics.Linecast (start, end, layerMask, queryTriggerInteraction);
			DrawLineCast3DRaw (start, end, isHit);
		}

		public static void DrawLineCast (bool isHit, Vector3 start, Vector3 end
		, int layerMask = Physics.DefaultRaycastLayers, QueryTriggerInteraction queryTriggerInteraction = QueryTriggerInteraction.UseGlobal)
		{
			DrawLineCast3DRaw (start, end, isHit);
		}

		public static void DrawLineCast (RaycastHit hittedByLine, Vector3 start, Vector3 end
		)
		{
			bool isHit = hittedByLine.collider != null;
			DrawLineCast3DRaw (start, end, isHit);
		}

		static void DrawLineCast3DRaw (Vector3 start, Vector3 end, bool isHit)
		{
			Gizmos.color = (isHit) ? hitColorR : nonHitColorB;
			Gizmos.DrawLine (start, end);
			Gizmos.DrawSphere (end, 0.05f);
			Gizmos.color = nonHitColorBaseG;
			Gizmos.DrawSphere (start, 0.1f);
			Gizmos.color = Color.white;
		}

		#endregion

		#region Class Collider - Raycast

		public static void DrawCollider_Raycast (Collider collider, Ray ray, float maxDistance)
		{
			RaycastHit hitInfo;
			if (!collider) {
				return;
			}
			bool isHit = collider.Raycast (ray, out hitInfo, maxDistance);
			DrawRaycast3DRaw (ray.origin, ray.direction, maxDistance, isHit);
		}

		#endregion

		#endregion

		#region OVERLAPPING QUERIES

		#region Overlap Box 3D

		public 	static	void DrawOverlapBox (Vector3 center, Vector3 halfExtents, Quaternion orientation = default(Quaternion)
		, int layerMask = Physics.DefaultRaycastLayers, QueryTriggerInteraction queryTriggerInteraction = QueryTriggerInteraction.UseGlobal)
		{
			bool isOverlaped = Physics.CheckBox (center, halfExtents, orientation, layerMask, queryTriggerInteraction);
			DrawOverlapBoxRawFull3D (center, halfExtents, orientation, isOverlaped);
		}

		public 	static	void DrawOverlapBoxNonAlloc (Vector3 center, Vector3 halfExtents, Quaternion orientation = default(Quaternion)
			, int layerMask = Physics.DefaultRaycastLayers, QueryTriggerInteraction queryTriggerInteraction = QueryTriggerInteraction.UseGlobal)
		{
			DrawOverlapBox (center, halfExtents, orientation, layerMask, queryTriggerInteraction);
		}

		public 	static	void DrawCheckBox (Vector3 center, Vector3 halfExtents, Quaternion orientation = default(Quaternion)
		, int layerMask = Physics.DefaultRaycastLayers, QueryTriggerInteraction queryTriggerInteraction = QueryTriggerInteraction.UseGlobal)
		{
			DrawOverlapBox (center, halfExtents, orientation, layerMask, queryTriggerInteraction);
		}

		public 	static	void DrawOverlapBox (Collider[] overlapedColliders, Vector3 center, Vector3 halfExtents, Quaternion orientation = default(Quaternion))
		{
			bool isOverlaped = (overlapedColliders != null && overlapedColliders.Length > 0);
			DrawOverlapBoxRawFull3D (center, halfExtents, orientation, isOverlaped);
		}


		public 	static	void DrawCheckBox (bool isOverlaped, Vector3 center, Vector3 halfExtents, Quaternion orientation = default(Quaternion))
		{
			DrawOverlapBoxRawFull3D (center, halfExtents, orientation, isOverlaped);
		}

		static void DrawOverlapBoxRaw3D (Vector3 center, Vector3 halfExtents, Quaternion orientation, bool isOverlaped)
		{
			orientation = (orientation.Equals (default(Quaternion))) ? Quaternion.identity : orientation;

			Gizmos.matrix = Matrix4x4.TRS (center, orientation, Vector3.one);
			Gizmos.color = (isOverlaped) ? overlappedColorR : nonHitColorB;
			Gizmos.DrawWireCube (Vector3.zero, 2f * halfExtents * 0.95f);
			Gizmos.color = (isOverlaped) ? overlappedColorR : nonOverlappedColorY;
			Gizmos.DrawWireCube (Vector3.zero, 2f * halfExtents);
			Gizmos.matrix = Matrix4x4.identity;
		}

		static void DrawOverlapBoxRawFull3D (Vector3 center, Vector3 halfExtents, Quaternion orientation, bool isOverlaped)
		{
			Gizmos.color = (isOverlaped) ? overlappedColorR : nonHitColorB;
			DrawOverlapBoxRaw3D (center, halfExtents, orientation, isOverlaped);
			Gizmos.color = (isOverlaped) ? overlappedColorY2 : nonOverlappedColorY;
			DrawOverlapBoxRaw3D (center, halfExtents, orientation, isOverlaped);
			Gizmos.color = Color.white;
		}

		#endregion

		#region OverLap Capsule 3D

		public 	static	void DrawOverlapCapsule (Vector3 point0, Vector3 point1, float radius
		, int layerMask = Physics.DefaultRaycastLayers, QueryTriggerInteraction queryTriggerInteraction = QueryTriggerInteraction.UseGlobal)
		{
			DrawCheckCapsule (point0, point1, radius, layerMask, queryTriggerInteraction);
		}

		public 	static	void DrawOverlapCapsuleNonAlloc (Vector3 point0, Vector3 point1, float radius
			, int layerMask = Physics.DefaultRaycastLayers, QueryTriggerInteraction queryTriggerInteraction = QueryTriggerInteraction.UseGlobal)
		{
			DrawCheckCapsule (point0, point1, radius, layerMask, queryTriggerInteraction);
		}

		public 	static	void DrawCheckCapsule (Vector3 start, Vector3 end, float radius
		, int layerMask = Physics.DefaultRaycastLayers, QueryTriggerInteraction queryTriggerInteraction = QueryTriggerInteraction.UseGlobal)
		{
			bool isOverlaped = Physics.CheckCapsule (start, end, radius, layerMask, queryTriggerInteraction);
			Gizmos.color = (isOverlaped) ? overlappedColorR : nonOverlappedColorY;
			DrawCapsule3D (start, end, radius);
		}

		public 	static	void DrawOverlapCapsule (Collider[] overlapedColliders, Vector3 point0, Vector3 point1, float radius)
		{
			bool isOverlaped = (overlapedColliders != null && overlapedColliders.Length > 0);
			Gizmos.color = (isOverlaped) ? overlappedColorR : nonOverlappedColorY;
			DrawCapsule3D (point0, point1, radius);
		}

		public 	static	void DrawCheckCapsule (bool isOverlaped, Vector3 start, Vector3 end, float radius)
		{
			Gizmos.color = (isOverlaped) ? overlappedColorR : nonOverlappedColorY;
			DrawCapsule3D (start, end, radius);
		}

		static void DrawCapsule3D (Vector3 point1, Vector3 point2, float radius)
		{
			Vector3 origin = (point1 - point2) / 2 + point1;
			if (radius == 0) {
				Gizmos.DrawSphere (origin, 0.01f);
				return;
			} else if (radius < 0) {
				DisplayWarningAboutSize ("CheckCapsule/OverlapCapsule", "radius", "should be greater more then 0. ", null);
			}
			Gizmos.matrix = Matrix4x4.TRS (origin, Quaternion.identity, new Vector3 (radius, radius, radius));
			DrawHemispheresOfCapsule (point1, point2, radius);
			Gizmos.matrix = Matrix4x4.identity;
			DrawLineConnectingHS (point1, point2, radius);
		}

		#endregion

		#region Overlap Sphere 3D

		public 	static	void DrawOverlapSphere (Vector3 position, float radius
		, int layerMask = Physics.DefaultRaycastLayers, QueryTriggerInteraction queryTriggerInteraction = QueryTriggerInteraction.UseGlobal)
		{
			bool isOverlaped = Physics.CheckSphere (position, radius, layerMask, queryTriggerInteraction);
			DrawOverlapSphere3DRaw (position, radius, isOverlaped);	
		}

		public 	static	void DrawOverlapSphereNonAlloc (Vector3 position, float radius
			, int layerMask = Physics.DefaultRaycastLayers, QueryTriggerInteraction queryTriggerInteraction = QueryTriggerInteraction.UseGlobal)
		{
			DrawOverlapSphere (position, radius, layerMask, queryTriggerInteraction);
		}

		public 	static	void DrawCheckSphere (Vector3 position, float radius
		, int layerMask = Physics.DefaultRaycastLayers, QueryTriggerInteraction queryTriggerInteraction = QueryTriggerInteraction.UseGlobal)
		{
			DrawOverlapSphere (position, radius, layerMask, queryTriggerInteraction);
		}

		public 	static	void DrawOverlapSphere (Collider[] overlapedColliders, Vector3 position, float radius)
		{
			bool isOverlaped = (overlapedColliders != null && overlapedColliders.Length > 0);
			DrawOverlapSphere3DRaw (position, radius, isOverlaped);	
		}

		public 	static	void DrawCheckSphere (bool isOverlaped, Vector3 position, float radius)
		{
			DrawOverlapSphere3DRaw (position, radius, isOverlaped);	
		}

		static void DrawOverlapSphere3DRaw (Vector3 position, float radius, bool isOverlaped)
		{
			if (radius == 0) {
				Gizmos.color = (isOverlaped) ? overlappedColorR : nonOverlappedColorY;
				Gizmos.DrawSphere (position, 0.01f);
				return;
			} else if (radius < 0) {
				DisplayWarningAboutSize ("CheckSphere/OverlapSphere", "radius", "should be greater more then 0. ", null);
			}
			Gizmos.color = (isOverlaped) ? overlappedColorR : nonOverlappedColorY;
			Gizmos.matrix = Matrix4x4.TRS (position, Quaternion.identity, new Vector3 (1, 1, 1));
			DrawHemiSphere (Vector3.zero, radius, Vector3.up);
			DrawHemiSphere (Vector3.zero, radius, Vector3.down);
			Gizmos.matrix = Matrix4x4.identity;
		}

		#endregion

		#endregion

		#region SWEEPING QUERIES

		#region BoxCast3D

		public static void DrawBoxCast (Vector3 center, Vector3 halfExtents, Vector3 direction, Quaternion orientation = default(Quaternion), float maxDistance = Mathf.Infinity
		, int layerMask = Physics.DefaultRaycastLayers, QueryTriggerInteraction queryTriggerInteraction = QueryTriggerInteraction.UseGlobal)
		{
			bool isHit = Physics.BoxCast (center, halfExtents, direction, orientation, maxDistance, layerMask, queryTriggerInteraction);
			DrawBoxCast3DRaw (center, halfExtents, direction, orientation, maxDistance, isHit);
		}

		public static void DrawBoxCastAll (Vector3 center, Vector3 halfExtents, Vector3 direction, Quaternion orientation = default(Quaternion), float maxDistance = Mathf.Infinity
		, int layerMask = Physics.DefaultRaycastLayers, QueryTriggerInteraction queryTriggerInteraction = QueryTriggerInteraction.UseGlobal)
		{
			DrawBoxCast (center, halfExtents, direction, orientation, maxDistance, layerMask, queryTriggerInteraction);
		}

		public static void DrawBoxCastNonAlloc (Vector3 center, Vector3 halfExtents, Vector3 direction, Quaternion orientation = default(Quaternion), float maxDistance = Mathf.Infinity
		, int layerMask = Physics.DefaultRaycastLayers, QueryTriggerInteraction queryTriggerInteraction = QueryTriggerInteraction.UseGlobal)
		{
			DrawBoxCast (center, halfExtents, direction, orientation, maxDistance, layerMask, queryTriggerInteraction);
		}

		public static void DrawBoxCast (RaycastHit hitByBox, Vector3 center, Vector3 halfExtents, Vector3 direction, Quaternion orientation = default(Quaternion), float maxDistance = Mathf.Infinity)
		{
			bool isHit = hitByBox.collider != null;
			DrawBoxCast3DRaw (center, halfExtents, direction, orientation, maxDistance, isHit);
		}

		public static void DrawBoxCast (bool isHit, Vector3 center, Vector3 halfExtents, Vector3 direction, Quaternion orientation = default(Quaternion), float maxDistance = Mathf.Infinity)
		{
			DrawBoxCast3DRaw (center, halfExtents, direction, orientation, maxDistance, isHit);
		}

		public static void DrawBoxCastAll (RaycastHit[] hitByBox, Vector3 center, Vector3 halfExtents, Vector3 direction, Quaternion orientation = default(Quaternion), float maxDistance = Mathf.Infinity)
		{
			bool isHit = (hitByBox != null && hitByBox.Length > 0);
			DrawBoxCast3DRaw (center, halfExtents, direction, orientation, maxDistance, isHit);
		}

		public static void DrawBoxCastNonAlloc (int hitColliderCount, Vector3 center, Vector3 halfExtents, Vector3 direction, Quaternion orientation = default(Quaternion), float maxDistance = Mathf.Infinity)
		{
			bool isHit = (hitColliderCount > 0);	
			DrawBoxCast3DRaw (center, halfExtents, direction, orientation, maxDistance, isHit);
		}

		static void DrawBoxCast3DRaw (Vector3 center, Vector3 halfExtents, Vector3 direction, Quaternion orientation, float maxDistance, bool isHit)
		{		

			orientation = (orientation.Equals (default(Quaternion))) ? Quaternion.identity : orientation;
			if (maxDistance < 0) {
				Debug.LogWarning ("<b><size=13><color=#0392CF> In method </color><color=#CD1426FF> DrawBoxCast3D </color><color=#0392CF> - </color> <color=#CD1426FF>maxdistance</color>  <color=#0392CF>must be greater then 0! </color> </size></b>");
				return;
			}
			if ((halfExtents.x < 0 || halfExtents.y < 0 || halfExtents.z < 0)) {
				Debug.LogWarning ("<b><size=13> <color=#0392CF>In method</color> <color=#CD1426FF>DrawBoxCast3D</color> <color=#0392CF> components of</color><color=#CD1426FF> halfExtends</color><color=#0392CF> should't be negative! </color> </size></b>");
//			return;
			}
			direction = direction.normalized;
			Vector3 endPositionOfCube = direction.normalized * maxDistance + center;
			Vector3[] vertexes = new Vector3[8];
			Vector3 a1 = new Vector3 (1f * halfExtents.x, 1f * halfExtents.y, 1f * halfExtents.z);
			Vector3 b1 = new Vector3 (-1f * halfExtents.x, 1f * halfExtents.y, 1f * halfExtents.z);
			Vector3 c1 = new Vector3 (-1f * halfExtents.x, -1f * halfExtents.y, 1f * halfExtents.z);
			Vector3 d1 = new Vector3 (1f * halfExtents.x, -1f * halfExtents.y, 1f * halfExtents.z);
			Vector3 a = new Vector3 (1f * halfExtents.x, 1f * halfExtents.y, -1f * halfExtents.z);
			Vector3 b = new Vector3 (-1f * halfExtents.x, 1f * halfExtents.y, -1f * halfExtents.z);
			Vector3 c = new Vector3 (-1f * halfExtents.x, -1f * halfExtents.y, -1f * halfExtents.z);
			Vector3 d = new Vector3 (1f * halfExtents.x, -1f * halfExtents.y, -1f * halfExtents.z);
			vertexes [0] = a1;
			vertexes [1] = c;
			vertexes [2] = b1;
			vertexes [3] = d1;
			vertexes [4] = a;
			vertexes [5] = c1;
			vertexes [6] = d;
			vertexes [7] = b;
			#region Drawing BoxCast3D
			List<float> lenghtOProjectedVertexesOnDirection = new List<float> (8);

			for (int i = 0; i < 8; i++) {
				float lenght = Vector3.Project (orientation * vertexes [i], direction).magnitude;
				lenghtOProjectedVertexesOnDirection.Add (lenght);
			}
			float min = Mathf.Max (lenghtOProjectedVertexesOnDirection [0], lenghtOProjectedVertexesOnDirection [1], lenghtOProjectedVertexesOnDirection [2], lenghtOProjectedVertexesOnDirection [3], lenghtOProjectedVertexesOnDirection [4], lenghtOProjectedVertexesOnDirection [5], lenghtOProjectedVertexesOnDirection [6], lenghtOProjectedVertexesOnDirection [7]);
			Gizmos.color = new Color (r: 0.129f, g: 0.108f, b: 0.922f, a: 0.25f);
			Gizmos.color = (isHit) ? hitColorR2 : nonHitColorB2;
			for (int i = 0; i < 8; i++) {
				if (lenghtOProjectedVertexesOnDirection [i] != min) {
					Gizmos.DrawLine (center + orientation * vertexes [i], endPositionOfCube + orientation * vertexes [i]);
				} else if ((direction == Vector3.right || direction == Vector3.left || direction == Vector3.up || direction == Vector3.down || direction == Vector3.back || direction == Vector3.forward)) {
					Gizmos.DrawLine (center + orientation * vertexes [i], endPositionOfCube + orientation * vertexes [i]);//orientation == Quaternion.identity &&
				}
			}
			Gizmos.color = (isHit) ? hitColorO : nonHitColorB;
			Gizmos.matrix = Matrix4x4.TRS (endPositionOfCube, orientation, Vector3.one);
			Gizmos.DrawWireCube (Vector3.zero, halfExtents * 2);
			Gizmos.color = (isHit) ? hitColorR : nonHitColorBaseG;
			Gizmos.matrix = Matrix4x4.TRS (center, orientation, Vector3.one);
			Gizmos.DrawWireCube (Vector3.zero, halfExtents * 2);
			#endregion
			if (halfExtents == Vector3.zero) {
				Gizmos.DrawSphere (Vector3.zero, 0.05f);
			}
			Gizmos.matrix = Matrix4x4.identity;
		}

		#endregion

		#region CapsuleCast3D

		public static void DrawCapsuleCast (Vector3 point1, Vector3 point2, float radius, Vector3 direction, float maxDistance = Mathf.Infinity, 
		                                    int layerMask = Physics.DefaultRaycastLayers, QueryTriggerInteraction queryTriggerInteraction = QueryTriggerInteraction.UseGlobal)
		{
			RaycastHit hitInfo;
			bool isHit = Physics.CapsuleCast (point1, point2, radius, direction, out hitInfo, maxDistance, layerMask, queryTriggerInteraction);
			DrawCapsuleCast3DRaw (point1, point2, radius, direction, maxDistance, isHit);
		}

		public static void DrawCapsuleCastNonAlloc (Vector3 point1, Vector3 point2, float radius, Vector3 direction, float maxDistance = Mathf.Infinity, 
		                                            int layerMask = Physics.DefaultRaycastLayers, QueryTriggerInteraction queryTriggerInteraction = QueryTriggerInteraction.UseGlobal)
		{
			DrawCapsuleCast (point1, point2, radius, direction, maxDistance, layerMask, queryTriggerInteraction);
		}

		public static void DrawCapsuleCastAll (Vector3 point1, Vector3 point2, float radius, Vector3 direction, float maxDistance = Mathf.Infinity, 
		                                       int layerMask = Physics.DefaultRaycastLayers, QueryTriggerInteraction queryTriggerInteraction = QueryTriggerInteraction.UseGlobal)
		{
			DrawCapsuleCast (point1, point2, radius, direction, maxDistance, layerMask, queryTriggerInteraction);
		}

		public static void DrawCapsuleCast (RaycastHit hitByCapsule, Vector3 point1, Vector3 point2, float radius, Vector3 direction, float maxDistance = Mathf.Infinity)
		{
			bool isHit = hitByCapsule.collider != null;		
			DrawCapsuleCast3DRaw (point1, point2, radius, direction, maxDistance, isHit);
		}

		public static void DrawCapsuleCast (bool isHit, Vector3 point1, Vector3 point2, float radius, Vector3 direction, float maxDistance = Mathf.Infinity)
		{
			DrawCapsuleCast3DRaw (point1, point2, radius, direction, maxDistance, isHit);
		}

		public static void DrawCapsuleCastNonAlloc (int hitColliderCount, Vector3 point1, Vector3 point2, float radius, Vector3 direction, float maxDistance = Mathf.Infinity)
		{
			bool isHit = (hitColliderCount > 0);
			DrawCapsuleCast3DRaw (point1, point2, radius, direction, maxDistance, isHit);
		}


		public static void DrawCapsuleCastAll (RaycastHit[] hitByCapsule, Vector3 point1, Vector3 point2, float radius, Vector3 direction, float maxDistance = Mathf.Infinity)
		{
			bool isHit = (hitByCapsule != null && hitByCapsule.Length > 0);
			DrawCapsuleCast3DRaw (point1, point2, radius, direction, maxDistance, isHit);
		}


		static void DrawCapsuleCast3DRaw (Vector3 point1, Vector3 point2, float radius, Vector3 direction, float maxDistance, bool isHit)
		{
			if (radius == 0f) {
				radius = 0.0001f;
			}
			if (radius <= 0) {
				Debug.LogWarning ("<b><size=13><color=#0392CF>  </color><color=#CD1426FF>CapsuleCast's radius</color><color=#0392CF> - </color> <color=#CD1426FF>" + "</color> <color=#0392CF>should be greater then 0.</color> </size></b>");
			}
			Vector3 origin = (point1 - point2) / 2 + point1;
			direction = direction.normalized;
			Vector3 distanceBetweenHS = direction.normalized * (maxDistance - 0);
			Vector3 endPositionOfCapsule = distanceBetweenHS + origin;
			Vector3 capOff = direction * maxDistance;
			Vector3 directionFromPoints = point1 - point2;
			#region Drawing Hemispheres and line making from them capsule
			int sign = (radius < 0) ? -1 : 1;

			Gizmos.color = (isHit) ? hitColorO : nonHitColorB;
			Gizmos.matrix = Matrix4x4.TRS (endPositionOfCapsule, Quaternion.identity, new Vector3 (1, 1, 1));
			DrawHemispheresOfCapsule (point1 + capOff, point2 + capOff, radius * sign);
			Gizmos.matrix = Matrix4x4.identity;
			DrawLineConnectingHS (point1 + distanceBetweenHS, point2 + distanceBetweenHS, radius);
			Gizmos.color = (isHit) ? hitColorR : nonHitColorBaseG;
			Gizmos.matrix = Matrix4x4.TRS (origin, Quaternion.identity, new Vector3 (1, 1, 1));
			DrawHemispheresOfCapsule (point1, point2, radius * sign);
			Gizmos.matrix = Matrix4x4.identity;
			DrawLineConnectingHS (point1, point2, radius);
			#endregion
			#region Draw connecting Lines
			Gizmos.color = (isHit) ? hitColorR2 : nonHitColorB2;

			DrawLinesConnectingCapsulesHS (point1, radius, direction, origin, capOff, directionFromPoints);
			DrawLinesConnectingCapsulesHS (point2, radius, direction, origin, capOff, directionFromPoints, -1);
			DrawLinesConnectingSideOfCapsule (point1, point2, direction, radius, maxDistance);
			DrawLinesConnectingSideOfCapsule (point1, point2, direction, radius, maxDistance, -1);
			#endregion
			Gizmos.matrix = Matrix4x4.identity;
		}

		static void DrawLinesConnectingSideOfCapsule (Vector3 point1, Vector3 point2, Vector3 direction, float radius, float maxDistance = Mathf.Infinity, int sign = DefaultSign)
		{
			Vector3 directionOfHS = (point1 - point2);
			Vector3 distanceBetweenHS = direction.normalized * (maxDistance - 0);
			Vector3 tangentToDirectionOfHS = Vector3.zero;
			Vector3 binormalToDirectionOfHS = Vector3.zero;

			Vector3.OrthoNormalize (ref directionOfHS, ref tangentToDirectionOfHS, ref binormalToDirectionOfHS);
			directionOfHS = (point1 - point2);
			Vector3 tangendOffset = tangentToDirectionOfHS * (radius) * sign;
			binormalToDirectionOfHS = (Mathf.Abs (directionOfHS.z) > Mathf.Abs (directionOfHS.y)) ? tangendOffset * sign : binormalToDirectionOfHS;
			float numberOfLines = Mathf.Abs ((point1 - point2).magnitude) * 2;
			Vector3 beginOfSideOfCapsule = point1 + binormalToDirectionOfHS * sign * radius;
			Vector3 endOfSideOfCapsule = point1 + binormalToDirectionOfHS * sign * radius + distanceBetweenHS;

			for (float i = 0; i < numberOfLines; i = i + 1f) {	
				Vector3 offset = -i * directionOfHS / numberOfLines;
				Gizmos.DrawLine (beginOfSideOfCapsule + offset, endOfSideOfCapsule + offset);
			}
		}

		static void DrawLinesConnectingCapsulesHS (Vector3 point1, float radius, Vector3 direction, Vector3 origin, Vector3 capOff, Vector3 directionFromPoints, int sign = DefaultSign)
		{
			Vector3 tangentToDirection = Vector3.zero;
			Vector3.OrthoNormalize (ref direction, ref tangentToDirection);
			Vector3 tangendOffset = tangentToDirection * (radius) * sign;
			Vector3 basePositionOfLine = point1 + tangendOffset;
			Vector3 endPositionOfLine = point1 + capOff + tangendOffset;
			float delta = GetDeltaForLoop (radius, isDotted);
			float anglezRaw = Vector3.Angle (new Vector3 (0, directionFromPoints.y, directionFromPoints.z), Vector3.up);
			float anglez = (directionFromPoints.z < 0) ? 360 - anglezRaw : anglezRaw;
			for (int i = -5; i < 16; i++) {//6 /*/-*/ for diffrent angles not always work properly
				Quaternion connectingLinesAngularOffset = Quaternion.AngleAxis (i * 18 + anglez, direction);
				basePositionOfLine = connectingLinesAngularOffset * tangendOffset + point1;
				endPositionOfLine = point1 + capOff + connectingLinesAngularOffset * tangendOffset;
				Gizmos.DrawLine (basePositionOfLine, endPositionOfLine);
			}

		}

		static void DrawLineConnectingHS (Vector3 point1, Vector3 point2, float radius)
		{
			Vector3 origin = (point1 - point2) / 2 + point1;
			Vector3 direction = (point1 - point2).normalized;
			Vector3 tangentToDirection = Vector3.zero;
			Vector3.OrthoNormalize (ref direction, ref tangentToDirection);
			Vector3 tangendOffset = tangentToDirection * (radius);
			Vector3 basePositionOfLine = point1 + tangendOffset;
			Vector3 endPositionOfLine = point2 + tangendOffset;
			if (radius == 0) {
				Gizmos.DrawSphere (Vector3.zero, 0.05f);
			}
			float delta = GetDeltaForLoop (radius, isDotted);
			Vector3 beginPosition = basePositionOfLine;

			for (int i = 0; i < 20; i++) {
				Quaternion connectingLinesAngularOffset = Quaternion.AngleAxis (18 * i, direction);
				Gizmos.DrawLine (basePositionOfLine, endPositionOfLine);
				basePositionOfLine = connectingLinesAngularOffset * tangendOffset + point1; 
				endPositionOfLine = connectingLinesAngularOffset * tangendOffset + point2; 
			}
		}

		static void DrawHemispheresOfCapsule (Vector3 point1, Vector3 point2, float radius)
		{
			Vector3 directionFromPoints = point2 - point1;
			Quaternion rotationOfHS = Quaternion.FromToRotation (Vector3.down, directionFromPoints.normalized);
			Gizmos.matrix = Matrix4x4.TRS (point1, rotationOfHS, new Vector3 (1, 1, 1));
			DrawHemisphereUpOrDown (Vector3.zero, radius);
			Gizmos.matrix = Matrix4x4.TRS (point2, rotationOfHS, new Vector3 (1, 1, 1));
			DrawHemisphereUpOrDown (Vector3.zero, radius, -1);
		}

		#region Drawing Lines For HS

		/// <summary>
		/// Draw horizontal lines for HS
		/// </summary>
		static void DrawCircleForHS (Vector3 origin, float radius)
		{
			float delta = 0.1f;

			float x = radius * Mathf.Cos (0f);
			float z = radius * Mathf.Sin (0f);

			Vector3 beginPosition = (origin + new Vector3 (x, 0, z));
			Vector3 endPosition = beginPosition;
			Vector3 lastPosition = beginPosition;

			for (float deltaAngle = 0f; deltaAngle < Mathf.PI * 2; deltaAngle += delta) {
				x = radius * Mathf.Cos (deltaAngle);
				z = radius * Mathf.Sin (deltaAngle);
				endPosition = (origin + new Vector3 (x, 0, z));
				Gizmos.DrawLine (beginPosition, endPosition);
				beginPosition = endPosition;
			}
			Gizmos.DrawLine (beginPosition, lastPosition);	
		}

		/// <summary>
		/// Draws upper line of HS
		/// </summary>

		static void DrawArcForHS (Vector3 origin, float radius, float alfhaOffset)
		{
			float delta = 0.1f;
			float x = radius * Mathf.Cos (0f);
			float y = radius * Mathf.Sin (0f);
			Quaternion arcRotation = Quaternion.AngleAxis (alfhaOffset, Vector3.up);
			Vector3 beginPosition = arcRotation * origin + arcRotation * (new Vector3 (radius * Mathf.Cos (0), radius * Mathf.Sin (0)));
			Vector3 endPosition = beginPosition;
			Vector3 lastPosition = arcRotation * origin + arcRotation * (new Vector3 (radius * Mathf.Cos (Mathf.PI), radius * Mathf.Sin (Mathf.PI)));
			for (int i = 0; i < 1; i++) {			

				for (float deltaAngle = 0f; deltaAngle <= Mathf.PI; deltaAngle += delta) {

					x = radius * Mathf.Cos (deltaAngle);
					y = radius * Mathf.Sin (deltaAngle);
					endPosition = arcRotation * origin + arcRotation * (new Vector3 (x, y));
					Gizmos.DrawLine (beginPosition, endPosition);	
					beginPosition = endPosition;
				}
				Gizmos.DrawLine (beginPosition, lastPosition);	
			}
		}

		static void DrawHemiSphere (Vector3 origin, float radius, Vector3 offset)
		{
			float radius2 = 0;
			float delta = radius / 7;
			for (float deltaAngle = 0f; deltaAngle <= radius; deltaAngle += delta) {
				radius2 = Mathf.Sqrt (Mathf.Pow (radius, 2) - Mathf.Pow (deltaAngle, 2));
				DrawCircleForHS (origin + offset * deltaAngle, radius2);
			}
			float dir = Mathf.Sign (offset.y);
			DrawCircleForHS (origin + offset * radius, radius2 / 3);
			for (int i = 0; i < 181; i = i + 18) {
				DrawArcForHS (origin, radius * dir, i);
			}
		}

		#endregion

		static void DrawHemisphereUpOrDown (Vector3 origin, float radius, int sign = DefaultSign)
		{
			Vector3 offset = new Vector3 (0, 1, 0) * sign;
			DrawHemiSphere (origin, radius, offset);
		}

		#endregion

		#region SphereCast3D

		public static void DrawSphereCast (Vector3 origin, float radius, Vector3 direction, float maxDistance = Mathf.Infinity,
		                                   int layerMask = Physics.DefaultRaycastLayers, QueryTriggerInteraction queryTriggerInteraction = QueryTriggerInteraction.UseGlobal)
		{
			RaycastHit hitInfo;
			bool isHit = Physics.SphereCast (new Ray (origin, direction), radius, out hitInfo, maxDistance, layerMask, queryTriggerInteraction);
			DrawSphereCast3DRaw (origin, radius, direction, maxDistance, isHit);
		}

		public static void DrawSphereCast (Ray ray, float radius, float maxDistance = Mathf.Infinity,
		                                   int layerMask = Physics.DefaultRaycastLayers, QueryTriggerInteraction queryTriggerInteraction = QueryTriggerInteraction.UseGlobal)
		{
			RaycastHit hitInfo;
			bool isHit = Physics.SphereCast (ray, radius, out hitInfo, maxDistance, layerMask, queryTriggerInteraction);
			DrawSphereCast3DRaw (ray.origin, radius, ray.direction, maxDistance, isHit);
		}

		public static void DrawSphereCastAll (Vector3 origin, float radius, Vector3 direction, float maxDistance = Mathf.Infinity,
		                                      int layerMask = Physics.DefaultRaycastLayers, QueryTriggerInteraction queryTriggerInteraction = QueryTriggerInteraction.UseGlobal)
		{
			DrawSphereCast (origin, radius, direction, maxDistance, layerMask, queryTriggerInteraction);
		}

		public static void DrawSphereCastAll (Ray ray, float radius, float maxDistance = Mathf.Infinity,
		                                      int layerMask = Physics.DefaultRaycastLayers, QueryTriggerInteraction queryTriggerInteraction = QueryTriggerInteraction.UseGlobal)
		{
			DrawSphereCast (ray, radius, maxDistance, layerMask, queryTriggerInteraction);
		}

		public static void DrawSphereCastNonAlloc (Vector3 origin, float radius, Vector3 direction, float maxDistance = Mathf.Infinity,
		                                           int layerMask = Physics.DefaultRaycastLayers, QueryTriggerInteraction queryTriggerInteraction = QueryTriggerInteraction.UseGlobal)
		{
			DrawSphereCast (origin, radius, direction, maxDistance, layerMask, queryTriggerInteraction);
		}

		public static void DrawSphereCastNonAlloc (Ray ray, float radius, float maxDistance = Mathf.Infinity,
		                                           int layerMask = Physics.DefaultRaycastLayers, QueryTriggerInteraction queryTriggerInteraction = QueryTriggerInteraction.UseGlobal)
		{
			DrawSphereCast (ray, radius, maxDistance, layerMask, queryTriggerInteraction);
		}

		public static void DrawSphereCast (RaycastHit hittedBySphere, Vector3 origin, float radius, Vector3 direction, float maxDistance = Mathf.Infinity)
		{
			bool isHit = hittedBySphere.collider != null;
			DrawSphereCast3DRaw (origin, radius, direction, maxDistance, isHit);
		}

		public static void DrawSphereCast (RaycastHit hittedBySphere, Ray ray, float radius, float maxDistance = Mathf.Infinity)
		{
			bool isHit = hittedBySphere.collider != null;
			DrawSphereCast3DRaw (ray.origin, radius, ray.direction, maxDistance, isHit);
		}

		public static void DrawSphereCastNonAlloc (int hitColliderCount, Vector3 origin, float radius, Vector3 direction, float maxDistance = Mathf.Infinity)
		{
			bool isHit = (hitColliderCount > 0);
			DrawSphereCast3DRaw (origin, radius, direction, maxDistance, isHit);
		}

		public static void DrawSphereCastNonAlloc (int hitColliderCount, Ray ray, float radius, float maxDistance = Mathf.Infinity)
		{
			bool isHit = (hitColliderCount > 0);
			DrawSphereCast3DRaw (ray.origin, radius, ray.direction, maxDistance, isHit);
		}

		public static void DrawSphereCastAll (RaycastHit[] hittedBySphere, Vector3 origin, float radius, Vector3 direction, float maxDistance = Mathf.Infinity)
		{
			bool isHit = (hittedBySphere != null && hittedBySphere.Length > 0);
			DrawSphereCast3DRaw (origin, radius, direction, maxDistance, isHit);
		}

		public static void DrawSphereCastAll (RaycastHit[] hittedBySphere, Ray ray, float radius, float maxDistance = Mathf.Infinity)
		{
			bool isHit = (hittedBySphere != null && hittedBySphere.Length > 0);
			DrawSphereCast3DRaw (ray.origin, radius, ray.direction, maxDistance, isHit);
		}

		static float GetDeltaForLoop (float radius, bool isDotted)
		{
			float delta = 0.1f;
			if (isDotted && radius > 0.2f) {//
				delta = delta / radius;
			}
			return delta;
		}

		static void FindSphereAndCapsuleMesh ()
		{
			if (sphereMesh == null) {
				sphereMesh = Resources.GetBuiltinResource (typeof(Mesh), "Sphere.fbx") as Mesh; 
			}
		}

		static void DrawSphereCast3DRaw (Vector3 origin, float radius, Vector3 direction, float maxDistance, bool isHit)
		{
			direction = direction.normalized;
			FindSphereAndCapsuleMesh ();
			direction = direction.normalized;
			Vector3 endPositionOfSphere = direction.normalized * maxDistance + origin;
			Vector3 tangentToDirection = Vector3.zero;
			Vector3.OrthoNormalize (ref direction, ref tangentToDirection);
			Vector3 tangendOffset = tangentToDirection * radius;	

			#region Drawing SphereCast3D
			Gizmos.color = (isHit) ? hitColorO : nonHitColorB;
			Gizmos.matrix = Matrix4x4.identity;
			Gizmos.matrix = Matrix4x4.TRS (endPositionOfSphere, Quaternion.identity, new Vector3 (radius, radius, radius));
			Gizmos.DrawWireMesh (sphereMesh);
			Gizmos.color = (isHit) ? hitColorR : nonHitColorBaseG;
			Gizmos.matrix = Matrix4x4.TRS (origin, Quaternion.identity, new Vector3 (radius, radius, radius));
			Gizmos.DrawWireMesh (sphereMesh);
			Gizmos.matrix = Matrix4x4.identity;
			#endregion
			if (radius == 0) {
				Gizmos.DrawSphere (origin, 0.05f);
			}
			#region Draw sphere connecting lines
			Gizmos.matrix = Matrix4x4.TRS (origin, Quaternion.identity, Vector3.one);
			Vector3 basePositionOfLine = tangendOffset;
			Vector3 endPositionOfLine = direction.normalized * maxDistance + tangendOffset;
			Quaternion connectingLinesAngularOffset = Quaternion.AngleAxis (18, direction);
			Gizmos.color = (isHit) ? hitColorR : nonHitColorB;
			Vector3 beginPosition = basePositionOfLine;

			Vector3 endPosition = beginPosition;
			Vector3 beginPosition2 = endPositionOfLine;
			Vector3 endPosition2 = beginPosition2;
			Vector3 lastPosition = (new Vector3 (radius * Mathf.Cos (Mathf.PI), radius * Mathf.Sin (Mathf.PI), 0));
			Gizmos.color = (isHit) ? hitColorR2 : nonHitColorB2;
			for (int i = 0; i < 20; i++) {
				Gizmos.DrawLine (basePositionOfLine, endPositionOfLine);
				basePositionOfLine = connectingLinesAngularOffset * basePositionOfLine;
				endPositionOfLine = connectingLinesAngularOffset * endPositionOfLine;
			}
			#endregion
			Gizmos.matrix = Matrix4x4.identity;

		}

		#endregion

		#region Class Rigidbody - SweepTest

		/// <summary> /// Visualize Rigidbody.SweepTest() - only for colliders of type BoxCollider,SphereCollider,CapsuleCollider and MeshColliders (convex only) /// </summary>
		public static void Rigidbody_SweepTestAll (Rigidbody rigidbody, Vector3 direction, float maxDistance = Mathf.Infinity,
		                                           QueryTriggerInteraction queryTriggerInteraction = QueryTriggerInteraction.UseGlobal)
		{
			Rigidbody_SweepTest (rigidbody, direction, maxDistance, queryTriggerInteraction);
		}

		public static void Rigidbody_SweepTest (Rigidbody rigidbody, Vector3 direction, float maxDistance = Mathf.Infinity,
		                                        QueryTriggerInteraction queryTriggerInteraction = QueryTriggerInteraction.UseGlobal)
		{
			if (rigidbody == null) {
				return;
			}
			RaycastHit hitInfo;
			bool isHit = rigidbody.SweepTest (direction, out hitInfo, maxDistance, queryTriggerInteraction);
			Collider[] colliders = rigidbody.GetComponentsInChildren<Collider> ();
			if (colliders.Length == 0) {
				DisplayWarningAboutMisingComponent ("Rigidbody_SweepTest", rigidbody);
				return;
			}
			for (int i = 0; i < colliders.Length; i++) {
				DrawColliders3DShapes (rigidbody, direction, maxDistance, isHit, colliders [i]);
			}
			Gizmos.matrix = Matrix4x4.identity;
		}

		static void DrawColliders3DShapes (Rigidbody rigidbody, Vector3 direction, float maxDistance, bool isHit, Collider collider)
		{
			if (collider is BoxCollider) {
				BoxCollider bc = collider as BoxCollider;
				Vector3 origin, size;
				Quaternion rotation = Quaternion.identity;
				DataForCasting data = new DataForCasting (collider, direction, maxDistance);
				data.GetDataForCasting (out origin, out rotation, out direction, out size);
				if (size.x < 0 || size.y < 0 || size.z < 0 || bc.size.x < 0 || bc.size.y < 0 || bc.size.z < 0) {
					DisplayWarningAboutSize ("Rigidbody_SweepTest", "BoxCollider.size", "Transform's scale", "should't be negative! ", rigidbody);
				}
				size.Scale (bc.size / 2);
				size = new Vector3 (Mathf.Abs (size.x), Mathf.Abs (size.y), Mathf.Abs (size.z));
				DrawBoxCast3DRaw (origin, size, direction, rotation, maxDistance, isHit);
			} else if (collider is CapsuleCollider) {
				CapsuleCollider cc = collider as CapsuleCollider;
				Vector3 origin, scale;
				Quaternion rotation = Quaternion.identity;
				DataForCasting data = new DataForCasting (collider, direction, maxDistance);
				data.GetDataForCasting (out origin, out rotation, out direction, out scale);
				DisplayWarningAboutScale (rigidbody, scale);
				Vector3 capsuleDirection = (cc.direction == 0) ? Vector3.right : ((cc.direction == 1) ? Vector3.up : Vector3.forward);
				float height = cc.height;
				float radius = cc.radius;
				float heightScale = (cc.direction == 0) ? Mathf.Abs (scale.x) : ((cc.direction == 1) ? Mathf.Abs (scale.y) : Mathf.Abs (scale.z));
				float radiusScale = (cc.direction == 0) ? Mathf.Max (Mathf.Abs (scale.y), Mathf.Abs (scale.z)) : ((cc.direction == 1) ? Mathf.Max (Mathf.Abs (scale.x), Mathf.Abs (scale.z)) : Mathf.Max (Mathf.Abs (scale.x), Mathf.Abs (scale.y)));
				height *= heightScale;
				radius = Mathf.Clamp (radius, cc.radius * radiusScale, radius);
				capsuleDirection = rotation * capsuleDirection;
				Vector3 point1 = origin;
				Vector3 point2 = origin;
				if (height > 2 * radius) {
					point1 = (height * 0.5f - radius) * capsuleDirection;
					point2 = (-height * 0.5f + radius) * capsuleDirection;
				}
				DrawCapsuleCast3DRaw (point1, point2, radius, direction, maxDistance, isHit);
			} else if (collider is SphereCollider) {
				SphereCollider sc = collider as SphereCollider;
				float radius = sc.radius;
				Vector3 origin, scale;
				Quaternion rotation = Quaternion.identity;
				DataForCasting data = new DataForCasting (collider, direction, maxDistance);
				data.GetDataForCasting (out origin, out rotation, out direction, out scale);
				DisplayWarningAboutScale (rigidbody, scale);
				float maxFactorOfScale = Mathf.Max (Mathf.Abs (scale.x), Mathf.Abs (scale.y), Mathf.Abs (scale.z));
				radius *= maxFactorOfScale;
				DrawSphereCast3DRaw (origin, radius, direction, maxDistance, isHit);
			} else if (collider is MeshCollider) {
				MeshCollider mc = collider as MeshCollider;
				if (!mc.convex) {
					return;
				}
				Mesh mesh = mc.sharedMesh;
				Vector3[] vert = mesh.vertices;
				Vector3 origin, scale, endOfMC;
				Quaternion rotation = Quaternion.identity;
				DataForCasting data = new DataForCasting (collider, direction, maxDistance);
				data.GetDataForCasting (out origin, out endOfMC, out direction, out rotation, out scale);
				DisplayWarningAboutScale (rigidbody, scale);
				Gizmos.color = (isHit) ? hitColorR : nonHitColorBaseG;
				Gizmos.DrawWireMesh (mesh, origin, rotation, scale);
				Gizmos.color = (isHit) ? hitColorO : nonHitColorB;
				Gizmos.DrawWireMesh (mesh, endOfMC, rotation, scale);
				Gizmos.color = (isHit) ? hitColorR3 : nonHitColorB3;
				for (int i = 0; i < vert.Length; i++) {
					vert [i].Scale (scale);
					vert [i] = rotation * vert [i];
					Gizmos.DrawLine (origin + vert [i], endOfMC + vert [i]);
				}
			}
		}

		static void DisplayWarningAboutScale (Rigidbody rigidbody, Vector3 scale)
		{
			if (scale.x < 0 || scale.y < 0 || scale.z < 0) {
				DisplayWarningAboutSize ("Rigidbody_SweepTest", "Transform's scale", "should't be negative! ", rigidbody);
			}
		}

		static void DisplayWarningAboutSize (string nameOfMethod, string parameterRed, string info, Object obj)
		{		
			Debug.LogWarning ("<b><size=13><color=#0392CF> In method </color><color=#CD1426FF>" + nameOfMethod + "</color><color=#0392CF> - </color> <color=#CD1426FF>" + parameterRed + "</color> <color=#0392CF>" + info + "</color> </size></b>", obj);
		}

		static	void DisplayWarningAboutSize (string nameOfMethod, string parameterRed, string parameter2Red, string info, Object obj)
		{
			Debug.LogWarning ("<b><size=13><color=#0392CF> In method </color><color=#CD1426FF>" + nameOfMethod + "</color><color=#0392CF> - </color> <color=#CD1426FF>" + parameterRed + "</color><color=#0392CF> and/or </color> <color=#CD1426FF>" + parameter2Red + " </color><color=#0392CF>" + info + "</color> </size></b>", obj);
		}

		static	void DisplayWarningAboutMisingComponent (string nameOfMethod, Object obj)
		{
			Debug.LogWarning ("<b><size=13><color=#0392CF> In method </color><color=#CD1426FF>" + nameOfMethod + "</color><color=#FF3A08> - none colliders have been attached! </color></size></b>", obj);
		}

		#endregion

		#region PLANE RAYCAST

		public static void Plane_Raycast (Plane plane, Ray ray)
		{
			float end;
		
			bool isHit =	plane.Raycast (ray, out end);
			ray.direction = (!isHit) ? -ray.direction : ray.direction;
			DrawRaycast3DRaw (ray.origin, ray.direction, Mathf.Abs (end), isHit);
		}

		#endregion

		#endregion

		#region OTHER

		public static void VisualizeWorldCenterOfMass (Rigidbody rigidbody)
		{
			if (rigidbody) {
				Color temp = Gizmos.color;
				Vector3 centerOfMass = rigidbody.worldCenterOfMass;
				Gizmos.color = hitColorO;
				Gizmos.DrawWireSphere (centerOfMass, 0.2f);
				Gizmos.color = Color.red;
				Gizmos.DrawSphere (centerOfMass, 0.1f);
				Gizmos.color = temp;
				GizmosForVector.ShowVectorValue (centerOfMass + new Vector3 (0, 0.5f, 0), "", centerOfMass, Color.red);
			}
		}

		public static void VizualizeNormalVector (RaycastHit hitInfo, float lenght = 1f)
		{
			if (hitInfo.collider == null) {
				return;
			}
			ShowNormalVector (hitInfo.point, hitInfo.normal, lenght);
		}

		public static void VizualizeNormalVector (ContactPoint contactPoint, float lenght = 1f)
		{
			if (!contactPoint.otherCollider) {
				return;
			}
			ShowNormalVector (contactPoint.point, contactPoint.normal, lenght);
		}

		static void ShowNormalVector (Vector3 origin, Vector3 normal, float lenght = 1f)
		{

			Color color = new Color32 (102, 255, 0, 255);
			GUIStyle g = new GUIStyle ();	
			g.normal.textColor = color;

			GizmosForVector.DrawVector (origin, normal, lenght, color, "normal");	
			float signedAngle = Vector2.SignedAngle (Vector3.right, normal);
			float angle = Vector2.Angle (Vector3.right, normal);
			#if UNITY_EDITOR
			Color temp2 = UnityEditor.Handles.color;
			signedAngle = (signedAngle < 0) ? 360 - angle : signedAngle;
			UnityEditor.Handles.color = color;
			UnityEditor.Handles.Label (origin + normal * (lenght + 0.3f) - new Vector3 (-1.4f, 0.3f), System.Math.Round (signedAngle, 0) + "\xB0", g);
			UnityEditor.Handles.color = temp2;
			#endif
		}


		#endregion

		public static void VizualizeClosestPoint (Vector3 point, Collider collider, Vector3 position, Quaternion rotation, bool showPointAndClosestPoint = !default(bool), bool showDistance = !default(bool))
		{
			if (!IsAppropiateCollider (collider)) {
				return;
			}
			Color temp = Gizmos.color;
			Vector3 closestPoint = Physics.ClosestPoint (point, collider, position, rotation);
			//			Gizmos.DrawLine (point, closestPoint);
			//			float distance = (closestPoint - point).magnitude;
			ShowClosestDistance (point, showPointAndClosestPoint, showDistance, closestPoint);	  

			Gizmos.color = temp;
		}

		static void ShowClosestDistance (Vector3 point, bool showPointAndClosestPoint, bool showDistance, Vector3 closestPoint)
		{
			Gizmos.DrawLine (point, closestPoint);
			float distance = (closestPoint - point).magnitude;

			if (showDistance && distance > 0) {
				GizmosForVector.ShowLabel (point + (closestPoint - point) * 0.5f, "distance: " + System.Math.Round (distance, 2), (distance > 0) ? Color.green : Color.magenta);
			}
			if (distance > 0 && showPointAndClosestPoint) {
				GizmosForVector.ShowVectorValue (closestPoint, "closestPointOnCollider", closestPoint, Color.red);
			}
			GizmosForVector.ShowVectorValue (point, "point", point, (distance > 0) ? Color.blue : Color.magenta);
			Gizmos.color = (distance > 0) ? Color.blue : Color.magenta;
			Gizmos.DrawSphere (point, 0.05f);
		}

		public static void VizualizeClosestPoint (Vector3 point, Collider collider, bool showPointAndClosestPoint = !default(bool), bool showDistance = !default(bool))
		{			
			if (collider == null || !IsAppropiateCollider (collider)) {
				return;
			}
			Vector3 offset;
			offset = GetColliderOffset (collider);

			Vector3 position = collider.transform.position;// + offset;
			Quaternion rotation = collider.transform.rotation;

			VizualizeClosestPoint (point, collider, position, rotation, showPointAndClosestPoint, showDistance);
		}

		/// <summary>
		/// Check if collider is BoxCollider or SphereCollider or CapsuleCollider or MeshCollider (and is set as convex) otherwise return false
		/// </summary>

		static bool IsAppropiateCollider (Collider collider)
		{
			if (collider is MeshCollider) {
				MeshCollider mc = (MeshCollider)collider;
				return (!mc.convex) ? false : true;
			}
			return collider is BoxCollider || collider is SphereCollider || collider is CapsuleCollider;
		}

		/// <summary>
		/// Gets the collider offset (takes scale into account)(available for BoxCollider,SphereCollider,CapsuleCollider).
		/// </summary>
		/// <returns>The collider offset.</returns>
		/// <param name="collider">Collider.</param>
		static Vector3 GetColliderOffset (Collider collider)
		{
			Vector3 offset = Vector3.zero;
			if (collider is BoxCollider) {
				BoxCollider bc = (BoxCollider)collider;
				offset = bc.center;
			} else if (collider is SphereCollider) {
				SphereCollider sc = (SphereCollider)collider;
				offset = sc.center;
			} else if (collider is CapsuleCollider) {
				CapsuleCollider cc = (CapsuleCollider)collider;
				offset = cc.center;
			}
			offset.Scale (collider.transform.lossyScale);

			return offset;
		}

		public static void VizualizeClosestPointOnBounds (Vector3 position, Collider collider, bool showPointAndClosestPoint = !default(bool), bool showDistance = !default(bool))
		{		
			if (collider == null || !IsAppropiateCollider (collider)) {
				return;
			}
			Color temp = Gizmos.color;
			Bounds b = collider.bounds;

			Vector3 offset = GetColliderOffset (collider);
			Gizmos.DrawWireCube (collider.transform.position + collider.transform.rotation * offset, b.size);
			Vector3 closestPointOnBounds = collider.ClosestPointOnBounds (position);
			ShowClosestDistance (position, showPointAndClosestPoint, showDistance, closestPointOnBounds);
			Gizmos.color = temp;
		}
	}
}

