using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GizmosForPhysics2D
{
	#region Variables

	static Color nonHitColorB = Color.blue;
	static Color nonHitColorB2 = new Color (r: 0.129f, g: 0.108f, b: 0.922f, a: 0.25f);
	static Color nonHitColorG = Color.green;
	static Color hitColorR = Color.red;
	static Color hitColorO = new Color (r: 1f, g: 0.341f, b: 0.133f, a: 1f);
	static Color hitColorR2 = new Color (r: 1f, g: 0.058f, b: 0.11f, a: 0.15f);
	static Color overlappedColorR = Color.red;
	static Color nonOverlappedColorY = Color.yellow;
	const int AdditionalDots = 0;
	const bool isDotted = false;
	const float SmallInfinity = 100000f;

	#endregion

	#region OVERLAPING QUERIES


	#region Overlap Circle done

	static void DrawOverlapCircleRaw (Vector2 point, float radius, bool isOverlaped)
	{
		float offset = 0.08f;
		bool isExisting = (radius > 0) ? true : false;
		if (isExisting) {
			Gizmos.color = (isOverlaped) ? overlappedColorR : nonOverlappedColorY;
			DrawCircleRaw (point, radius, true);
		}
		isExisting = (radius - offset > 0) ? true : false;
		if (isExisting) {
			Gizmos.color = (isOverlaped) ? overlappedColorR : nonHitColorB;
			DrawCircleRaw (point, radius - offset, true);
		}
	}

	static void DrawOverlapCircleFull (Vector2 point, float radius, bool isOverlaped)
	{
		if (radius < 0) {
			Gizmos.color = (isOverlaped) ? overlappedColorR : nonOverlappedColorY;
			Gizmos.DrawSphere (point, 0.06f);
		} else {
			DrawOverlapCircleRaw (point, radius, isOverlaped);
		}
	}

	public static void  DrawOverlapCircle (Collider2D overlapedCollider2D, Vector2 point, float radius)
	{
		bool isOverlaped = (overlapedCollider2D != null);
		DrawOverlapCircleFull (point, radius, isOverlaped);

	}

	public static void  DrawOverlapCircle (Collider2D[] overlapedColliders2D, Vector2 point, float radius)
	{
		bool isOverlaped = (overlapedColliders2D != null && overlapedColliders2D.Length > 0);
		DrawOverlapCircleFull (point, radius, isOverlaped);
	}

	public static void  DrawOverlapCircleAll (Collider2D[] overlapedColliders2D, Vector2 point, float radius)
	{
		bool isOverlaped = (overlapedColliders2D != null && overlapedColliders2D.Length > 0);
		DrawOverlapCircleFull (point, radius, isOverlaped);
	}

	#endregion

	#region Overlap Capsule

	static void DrawOverlapCapsuleRaw (Vector2 point, Vector2 size, CapsuleDirection2D direction, float angle, bool isOverlaped)
	{
		Gizmos.color = (isOverlaped) ? overlappedColorR : nonOverlappedColorY;
		Vector3 sizeChanged = (direction == CapsuleDirection2D.Horizontal) ? new Vector3 (size.y, size.x) : (Vector3)size;
		if (size.x > 0.1f && size.y > 0.01f) {
			DrawCapsule (point, sizeChanged, direction, angle, true);
		}
		Gizmos.color = (isOverlaped) ? overlappedColorR : nonHitColorB;
		Vector3 offset = new Vector3 (0.1f, 0.1f);
		if (size.x > 0.1f && size.y > 0.1f)
			DrawCapsule (point, sizeChanged - offset, direction, angle, true);
	}

	public static void  DrawOverlapCapsule (Collider2D overlapedCollider2D, Vector2 point, Vector2 size, CapsuleDirection2D direction, float angle)
	{
		bool isOverlaped = (overlapedCollider2D != null);
		DrawOverlapCapsuleRaw (point, size, direction, angle, isOverlaped);		
	}

	public static void  DrawOverlapCapsule (Collider2D[] overlapedColliders2D, Vector2 point, Vector2 size, CapsuleDirection2D direction, float angle)
	{
		bool isOverlaped = (overlapedColliders2D != null && overlapedColliders2D.Length > 0);
		DrawOverlapCapsuleRaw (point, size, direction, angle, isOverlaped);		
	}

	public static void  DrawOverlapCapsuleAll (Collider2D[] overlapedColliders2D, Vector2 point, Vector2 size, CapsuleDirection2D direction, float angle)
	{
		bool isOverlaped = (overlapedColliders2D != null && overlapedColliders2D.Length > 0);
		DrawOverlapCapsuleRaw (point, size, direction, angle, isOverlaped);		
	}

	#endregion

	#region Overlap Point done

	static void DrawOverlapPointRaw (Vector2 point, bool isOverlaped)
	{
		Gizmos.color = (isOverlaped) ? overlappedColorR : nonOverlappedColorY;
		Gizmos.DrawSphere (point, 0.08f);
	}

	public static void  DrawOverlapPoint (Collider2D overlapedCollider2D, Vector2 point)
	{
		bool isOverlaped = (overlapedCollider2D != null);
		DrawOverlapPointRaw (point, isOverlaped);
	}

	public static void  DrawOverlapPoint (Collider2D[] overlapedColliders2D, Vector2 point)
	{
		bool isOverlaped = (overlapedColliders2D != null && overlapedColliders2D.Length > 0);
		DrawOverlapPointRaw (point, isOverlaped);
	}

	public static void  DrawOverlapPointAll (Collider2D[] overlapedColliders2D, Vector2 point)
	{
		bool isOverlaped = (overlapedColliders2D != null && overlapedColliders2D.Length > 0);
		DrawOverlapPointRaw (point, isOverlaped);
	}

	#endregion

	#region Overlap Box

	static void DrawOverlapBoxFull (Vector3 point, Vector3 size, float angle, bool isOverlaped)
	{
		if (size.x < 0 || size.y < 0) {
			Gizmos.color = (isOverlaped) ? overlappedColorR : nonOverlappedColorY;
			Gizmos.DrawSphere (point, 0.06f);
		} else {
			DrawOverlapBoxRaw (point, size, angle, isOverlaped, true);
		}
	}


	public static void DrawOverlapBox (Collider2D overlapedCollider2D, Vector3 point, Vector3 size, float angle)
	{
		bool isOverlaped = (overlapedCollider2D != null);
		DrawOverlapBoxFull (point, size, angle, isOverlaped);
	}

	public static void DrawOverlapBox (Collider2D[] overlapedColliders2D, Vector3 point, Vector3 size, float angle)
	{
		bool isOverlaped = (overlapedColliders2D != null && overlapedColliders2D.Length > 0);
		DrawOverlapBoxFull (point, size, angle, isOverlaped);
	}

	public static void DrawOverlapBoxAll (Collider2D[] overlapedColliders2D, Vector3 point, Vector3 size, float angle)
	{
		DrawOverlapBox (overlapedColliders2D, point, size, angle);
	}

	static void DrawDottedLine (Vector3 startPosition, Vector3 endPosition, int densityOfDots = AdditionalDots, bool isDotted = isDotted)
	{
		if (isDotted) {
			int allDotsAndBreaks;
			Vector3 zzz = endPosition - startPosition;
			float distansBetweenPoints = zzz.magnitude;
			int additionalDots = densityOfDots > 0 ? (int)densityOfDots / 5 : 0;

			if (distansBetweenPoints > 2) {			
				allDotsAndBreaks = (int)distansBetweenPoints * 10 - additionalDots;
			} else {
				allDotsAndBreaks = 10 + additionalDots;
			}
			List<Vector3> dots = new List<Vector3> ();
			for (int i = 0; i < allDotsAndBreaks; i++) {
				float t = i / (float)allDotsAndBreaks;
				dots.Add (Vector3.Lerp (startPosition, endPosition, t));
			}
			for (int i = 0; i < allDotsAndBreaks - 1; i++) {	
				if (i % 2 == 0)
					Gizmos.DrawLine (dots [i], dots [i + 1]);
			}
			dots.Clear ();
		} else {
			Gizmos.DrawLine (startPosition, endPosition);
		}

	}



	static void DrawRectangle (Vector3 centerOfRectangle, 
	                           Vector3 cornerPositionInLS1, Vector3 cornerPositionInLS2, Vector3 cornerPositionInLS3, Vector3 cornerPositionInLS4, bool isDotted = isDotted,
	                           int densityOfDots = AdditionalDots)
	{
		DrawDottedLine (cornerPositionInLS1 + centerOfRectangle, cornerPositionInLS2 + centerOfRectangle, densityOfDots, isDotted);
		DrawDottedLine (cornerPositionInLS2 + centerOfRectangle, cornerPositionInLS3 + centerOfRectangle, densityOfDots, isDotted);
		DrawDottedLine (cornerPositionInLS3 + centerOfRectangle, cornerPositionInLS4 + centerOfRectangle, densityOfDots, isDotted);
		DrawDottedLine (cornerPositionInLS4 + centerOfRectangle, cornerPositionInLS1 + centerOfRectangle, densityOfDots, isDotted);
	}



	static	void DrawOverlapBoxRaw (Vector3 point, Vector3 size, float angle, bool isOverlaped, bool isDotted = isDotted)
	{
		Gizmos.color = (isOverlaped) ? overlappedColorR : nonOverlappedColorY;

		float angleOfDiagonal, halfOfDiagonalLenght;
		Vector3 cornerPosition1, cornerPosition2, cornerPosition3, cornerPosition4;
		//		Vector3 cornerPosition1i, cornerPosition2i, cornerPosition3i, cornerPosition4i;
		Vector3 cornerPosition1o, cornerPosition2o, cornerPosition3o, cornerPosition4o;
		GetInfoAboutDiagonalsOfBox (size, out angleOfDiagonal, out halfOfDiagonalLenght);
		GetCornersPositionInLSOfBox (angle, angleOfDiagonal, halfOfDiagonalLenght, out cornerPosition1, out cornerPosition2, out cornerPosition3, out cornerPosition4);
		//		GetCornersPositionInLSOfBox (angle, angleOfDiagonal, halfOfDiagonalLenght - 0.08f, out cornerPosition1i, out cornerPosition2i, out cornerPosition3i, out cornerPosition4i);
		GetDirectionOfCorners (angle, halfOfDiagonalLenght, 
			out cornerPosition1o, out  cornerPosition2o, out  cornerPosition3o, out  cornerPosition4o);
		float secondRectOffset = -0.08f;
		float xx = (size.y > 0) ? 1f : -1f;
		float yy = (size.x > 0) ? 1f : -1f;
		float dd = (size.x < 0 && size.y < 0) ? -1f : 1f;
		float ee = (size.x < 0 && size.y > 0) ? -1f : 1f;

		DrawRectangle (point, cornerPosition1, cornerPosition2, cornerPosition3, cornerPosition4, isDotted);
		Gizmos.color = (isOverlaped) ? overlappedColorR : nonHitColorB;
		if (!(size.x > secondRectOffset && size.x < -secondRectOffset || size.y > secondRectOffset && size.y < -secondRectOffset)) {
			DrawRectangle (point, cornerPosition1 + dd * ee * new Vector3 (xx * cornerPosition1o.x, yy * cornerPosition1o.y) * secondRectOffset, 
				cornerPosition2 + dd * ee * new Vector3 (xx * cornerPosition2o.x, yy * cornerPosition2o.y) * secondRectOffset, 
				cornerPosition3 + dd * ee * new Vector3 (xx * cornerPosition3o.x, yy * cornerPosition3o.y) * secondRectOffset, 
				cornerPosition4 + dd * ee * new Vector3 (xx * cornerPosition4o.x, yy * cornerPosition4o.y) * secondRectOffset, isDotted, 30);
		}
	}

	#endregion

	#region Overlap Area done

	static void DrawOverlapAreaRaw (Vector2 pointA, Vector2 pointB, bool isOverlaped)
	{
		Vector3 size = -pointA + pointB;
		Vector3 center = (Vector3)pointA + size * 0.5f;
		DrawOverlapBoxRaw (center, size, 0, isOverlaped, true);
	}

	public static void DrawOverlapArea (Collider2D overlapedCollider2D, Vector2 pointA, Vector2 pointB)
	{
		bool isOverlaped = (overlapedCollider2D != null);
		DrawOverlapAreaRaw (pointA, pointB, isOverlaped);
	}

	public static void DrawOverlapArea (Collider2D[] overlapedColliders2D, Vector2 pointA, Vector2 pointB)
	{
		bool isOverlaped = (overlapedColliders2D != null && overlapedColliders2D.Length > 0);
		DrawOverlapAreaRaw (pointA, pointB, isOverlaped);
	}

	public static void DrawOverlapAreaAll (Collider2D[] overlapedColliders2D, Vector2 pointA, Vector2 pointB)
	{
		bool isOverlaped = (overlapedColliders2D != null && overlapedColliders2D.Length > 0);
		DrawOverlapAreaRaw (pointA, pointB, isOverlaped);
	}

	#endregion

	#endregion

	#region RAYCASTING  QUERIES

	#region RayIntersection

	public static void DrawGetRayIntersection (RaycastHit2D hitInfo, Ray ray, float distance = Mathf.Infinity)
	{
		bool isHit = hitInfo.collider != null;
		DrawRaycastRaw3D (ray.origin, ray.direction, distance, isHit);
	}

	public static void DrawGetRayIntersection (bool hitInfo, Ray ray, float distance = Mathf.Infinity)
	{
		DrawRaycastRaw3D (ray.origin, ray.direction, distance, hitInfo);
	}

	public static void DrawGetRayIntersection (int hitColliderCount, Ray ray, float distance = Mathf.Infinity)
	{
		bool isHit = (hitColliderCount > 0);		
		DrawRaycastRaw3D (ray.origin, ray.direction, distance, isHit);
	}

	public static void DrawGetRayIntersectionNonAlloc (int hitColliderCount, Ray ray, float distance = Mathf.Infinity)
	{
		bool isHit = (hitColliderCount > 0);		
		DrawRaycastRaw3D (ray.origin, ray.direction, distance, isHit);
	}

	public static void DrawGetRayIntersectionAll (RaycastHit2D[] hitInfos, Ray ray, float distance = Mathf.Infinity)
	{
		bool isHit = (hitInfos != null && hitInfos.Length > 0);
		DrawRaycastRaw3D (ray.origin, ray.direction, distance, isHit);
	}

	#endregion

	#region Ray casting



	public static void DrawRayCast (RaycastHit2D hitInfo, Vector2 origin, Vector2 direction, float distance = Mathf.Infinity)
	{
		bool isHit = hitInfo.collider != null;
		DrawRaycastRaw (origin, direction, distance, isHit);
	}

	public static void DrawRayCast (bool hitInfo, Vector2 origin, Vector2 direction, float distance = Mathf.Infinity)
	{
		DrawRaycastRaw (origin, direction, distance, hitInfo);
	}

	public static  void DrawRayCast (int hitColliderCount, Vector2 origin, Vector2 direction, float distance = Mathf.Infinity)
	{
		bool isHit = (hitColliderCount > 0);
		DrawRaycastRaw (origin, direction, distance, isHit);
	}

	public static  void DrawRayCastAll (RaycastHit2D[] hitInfos, Vector2 origin, Vector2 direction, float distance = Mathf.Infinity)
	{
		bool isHit = (hitInfos != null && hitInfos.Length > 0);
		DrawRaycastRaw (origin, direction, distance, isHit);
	}

	public static  void DrawRayCastNonAlloc (int hitColliderCount, Vector2 origin, Vector2 direction, float distance = Mathf.Infinity)
	{
		bool isHit = (hitColliderCount > 0);
		DrawRaycastRaw (origin, direction, distance, isHit);
	}

	static void DrawRaycastRaw3D (Vector3 origin, Vector3 direction, float distance, bool isHit)
	{
		Gizmos.color = (isHit) ? hitColorR : nonHitColorB;
		direction = direction.normalized;
		distance = (distance == Mathf.Infinity) ? 1000000f : distance;

		Gizmos.DrawRay (origin, direction * distance);
		Gizmos.DrawSphere (origin, 0.05f);
		Gizmos.color = Color.white;
	}

	static void DrawRaycastRaw (Vector2 origin, Vector2 direction, float distance, bool isHit)
	{
		Gizmos.color = (isHit) ? hitColorR : nonHitColorB;
		direction = direction.normalized;
		distance = (distance == Mathf.Infinity) ? 1000000f : distance;
		Gizmos.DrawRay (origin, direction * distance);
		Gizmos.DrawSphere (origin, 0.05f);
		Gizmos.color = Color.white;
	}

	#endregion

	#region Line casting


	public static  void DrawLineCast (RaycastHit2D hitInfo, Vector3 start, Vector3 end)
	{
		bool isHit = hitInfo.collider != null;
		DrawLineCastRaw (start, end, isHit);
	}

	public static  void DrawLineCast (bool hitInfo, Vector3 start, Vector3 end)
	{
		DrawLineCastRaw (start, end, hitInfo);
	}

	public  static void DrawLineCast (int hitColliderCount, Vector3 start, Vector3 end)
	{
		bool isHit = (hitColliderCount > 0);
		DrawLineCastRaw (start, end, isHit);
	}

	public static  void DrawLineCastAll (RaycastHit2D[] hitInfos, Vector3 start, Vector3 end)
	{
		bool isHit = (hitInfos != null && hitInfos.Length > 0);
		DrawLineCastRaw (start, end, isHit);
	}

	public static  void DrawLineCastNonAlloc (int hitColliderCount, Vector3 start, Vector3 end)
	{
		bool isHit = (hitColliderCount > 0);
		DrawLineCastRaw (start, end, isHit);
	}

	static void DrawLineCastRaw (Vector3 start, Vector3 end, bool isHit)
	{
		start = new Vector3 (start.x, start.y);
		end = new Vector3 (end.x, end.y);
		Gizmos.color = (isHit) ? hitColorR : nonHitColorB;
		Gizmos.DrawLine (start, end);
		Gizmos.DrawSphere (start, 0.05f);
		Gizmos.DrawSphere (end, 0.05f);
	}

	#endregion

	#endregion

	#region SWEEP  QUERIES

	#region Box casting

	public static void DrawBoxCastAll (RaycastHit2D[] hitInfos, Vector3 origin, Vector3 size, float angle, Vector3 direction, float distance = Mathf.Infinity)
	{
		bool isHit = (hitInfos != null && hitInfos.Length > 0 && hitInfos [0].collider != null);
		DrawBoxCastRaw (origin, size, angle, direction, distance, isHit);
	}

	public static void DrawBoxCast (RaycastHit2D hitInfo, Vector3 origin, Vector3 size, float angle, Vector3 direction, float distance = Mathf.Infinity)
	{
		bool isHit = hitInfo.collider != null;
		DrawBoxCastRaw (origin, size, angle, direction, distance, isHit);	
	}

	public static void DrawBoxCast (bool hitInfo, Vector3 origin, Vector3 size, float angle, Vector3 direction, float distance = Mathf.Infinity)
	{
		DrawBoxCastRaw (origin, size, angle, direction, distance, hitInfo);	
	}

	public static void DrawBoxCast (int hitColliderCount, Vector3 origin, Vector3 size, float angle, Vector3 direction, float distance = Mathf.Infinity)
	{
		bool isHit = (hitColliderCount > 0);		
		DrawBoxCastRaw (origin, size, angle, direction, distance, isHit);	
	}

	public static void DrawBoxCastNonAlloc (int hitColliderCount, Vector3 origin, Vector3 size, float angle, Vector3 direction, float distance = Mathf.Infinity)
	{
		bool isHit = (hitColliderCount > 0);		
		DrawBoxCastRaw (origin, size, angle, direction, distance, isHit);	
	}

	static void DrawBoxCastRaw (Vector3 origin, Vector3 size, float angle, Vector3 direction, float distance, bool isHit)
	{
		direction = new Vector3 (direction.x, direction.y);
		size = new Vector3 (size.x, size.y);
		distance = (distance == Mathf.Infinity) ? 1000000f : distance;

		Vector3 endPositionOfBox = origin + direction.normalized * distance;
		float angleOfDiagonal, halfOfDiagonalLenght;
		Vector3 cornerPosition1, cornerPosition2, cornerPosition3, cornerPosition4; 

		GetInfoAboutDiagonalsOfBox (size, out angleOfDiagonal, out halfOfDiagonalLenght);
		GetCornersPositionInLSOfBox (angle, angleOfDiagonal, halfOfDiagonalLenght, out cornerPosition1, out cornerPosition2, out cornerPosition3, out cornerPosition4);

		Gizmos.matrix = Matrix4x4.identity;
		//We getting lenght from start to point projected on direction to delete not important lines
		float dlA = Vector3.Project (cornerPosition1, direction).magnitude;
		float dlB = Vector3.Project (cornerPosition2, direction).magnitude;
		float dlC = Vector3.Project (cornerPosition3, direction).magnitude;
		float dlD = Vector3.Project (cornerPosition4, direction).magnitude;

		Gizmos.color = (isHit) ? hitColorR2 : nonHitColorB2;
		if (dlA + dlC < dlB + dlD) {
			Gizmos.DrawLine ((origin + cornerPosition1), endPositionOfBox + cornerPosition1);
			Gizmos.DrawLine ((origin + cornerPosition3), endPositionOfBox + cornerPosition3);		
		} else {			
			Gizmos.DrawLine ((origin + cornerPosition2), endPositionOfBox + cornerPosition2);
			Gizmos.DrawLine ((origin + cornerPosition4), endPositionOfBox + cornerPosition4);
		}
		#region Drawing Cubes and Lines
		Gizmos.matrix = Matrix4x4.TRS (origin, Quaternion.AngleAxis (angle, Vector3.forward), Vector3.one);
		Gizmos.color = (isHit) ? hitColorR : nonHitColorG;
		Gizmos.DrawWireCube (Vector3.zero, size);
		Gizmos.matrix = Matrix4x4.TRS (endPositionOfBox, Quaternion.AngleAxis (angle, Vector3.forward), Vector3.one);
		Gizmos.color = (isHit) ? hitColorR : nonHitColorB;
		Gizmos.DrawWireCube (Vector3.zero, size);
		Gizmos.matrix = Matrix4x4.identity;
		#endregion

		#region Lines from center to corners
		//		DrawDiagonalOfRectangle (Vector3.zero, cornerPosition1, cornerPosition2, cornerPosition3, cornerPosition4);
		#endregion
	}

	static void DrawDiagonalOfRectangle (Vector3 origin, Vector3 cornerPosition1, Vector3 cornerPosition2, Vector3 cornerPosition3, Vector3 cornerPosition4)
	{
		Gizmos.color = Color.green;
		Gizmos.DrawLine (origin, origin + cornerPosition1);
		Gizmos.color = Color.yellow;
		Gizmos.DrawLine (origin, origin + cornerPosition2);
		Gizmos.color = Color.magenta;
		Gizmos.DrawLine (origin, origin + cornerPosition3);
		Gizmos.color = Color.blue;
		Gizmos.DrawLine (origin, origin + cornerPosition4);
	}

	/// <summary> /// Gets angle between horizontal line and diagonals and half lenght of diagonal. /// </summary>
	static void GetInfoAboutDiagonalsOfBox (Vector2 size, out float angleOfDiagonal, out float halfOfDiagonalLenght)
	{
		angleOfDiagonal = Mathf.Atan (size.x / (size.y)) * Mathf.Rad2Deg;
		halfOfDiagonalLenght = (float)Mathf.Sqrt (Mathf.Pow (size.x, 2) + Mathf.Pow (size.y, 2)) * 0.5f;
	}


	static void GetCornersPositionInLSOfBox (float angle, float angleOfDiagonal, float halfOfDiagonalLenght,
	                                         out Vector3 cornerPosition1, out Vector3 cornerPosition2, out Vector3 cornerPosition3, out Vector3 cornerPosition4)
	{
		cornerPosition1 = new Vector3 (-Mathf.Sin (Mathf.Deg2Rad * (angle - angleOfDiagonal)), Mathf.Cos (Mathf.Deg2Rad * (angle - angleOfDiagonal))).normalized * halfOfDiagonalLenght;
		cornerPosition2 = new Vector3 (-Mathf.Sin (Mathf.Deg2Rad * (angle - 180 + angleOfDiagonal)), Mathf.Cos (Mathf.Deg2Rad * (angle - 180 + angleOfDiagonal))).normalized * halfOfDiagonalLenght;
		cornerPosition3 = new Vector3 (-Mathf.Sin (Mathf.Deg2Rad * (angle - 180 - angleOfDiagonal)), Mathf.Cos (Mathf.Deg2Rad * (angle - 180 - angleOfDiagonal))).normalized * halfOfDiagonalLenght;
		cornerPosition4 = new Vector3 (-Mathf.Sin (Mathf.Deg2Rad * (angle - 360 + angleOfDiagonal)), Mathf.Cos (Mathf.Deg2Rad * (angle - 360 + angleOfDiagonal))).normalized * halfOfDiagonalLenght;
	}

	static void GetDirectionOfCorners (float angle, float halfOfDiagonalLenght,
	                                   out Vector3 directionToCorner1, out Vector3 directionToCorner2, out Vector3 directionToCorner3, out Vector3 directionToCorner4)
	{
		directionToCorner1 = new Vector3 (-Mathf.Sin (Mathf.Deg2Rad * (angle - 45)) * halfOfDiagonalLenght,
			Mathf.Cos (Mathf.Deg2Rad * (angle - 45)) * halfOfDiagonalLenght).normalized;

		directionToCorner2 = new Vector3 (-Mathf.Sin (Mathf.Deg2Rad * (angle - 135)) * halfOfDiagonalLenght,
			Mathf.Cos (Mathf.Deg2Rad * (angle - 135)) * halfOfDiagonalLenght).normalized;

		directionToCorner3 = new Vector3 (-Mathf.Sin (Mathf.Deg2Rad * (angle - 225)) * halfOfDiagonalLenght,
			Mathf.Cos (Mathf.Deg2Rad * (angle - 225)) * halfOfDiagonalLenght).normalized;

		directionToCorner4 = new Vector3 (-Mathf.Sin (Mathf.Deg2Rad * (angle - 315)) * halfOfDiagonalLenght,
			Mathf.Cos (Mathf.Deg2Rad * (angle - 315)) * halfOfDiagonalLenght).normalized;
		Debug.Log (directionToCorner1);
	}


	#endregion

	#region Capsule Casting


	public static	void DrawCapsuleCast (RaycastHit2D hitInfo, Vector3 origin, Vector3 size, CapsuleDirection2D capsuleDirection, float angle, Vector3 direction, float distance = Mathf.Infinity)
	{
		bool isHit = hitInfo.collider != null;
		DrawCapsuleCastRaw (origin, size, capsuleDirection, angle, direction, distance, isHit);
	}

	public static	void DrawCapsuleCast (bool hitInfo, Vector3 origin, Vector3 size, CapsuleDirection2D capsuleDirection, float angle, Vector3 direction, float distance = Mathf.Infinity)
	{
		DrawCapsuleCastRaw (origin, size, capsuleDirection, angle, direction, distance, hitInfo);
	}

	public static	void DrawCapsuleCast (int hitColliderCount, Vector3 origin, Vector3 size, CapsuleDirection2D capsuleDirection, float angle, Vector3 direction, float distance = Mathf.Infinity)
	{
		bool isHit = (hitColliderCount > 0);
		DrawCapsuleCastRaw (origin, size, capsuleDirection, angle, direction, distance, isHit);
	}

	public static	void DrawCapsuleCastNonAlloc (int hitColliderCount, Vector3 origin, Vector3 size, CapsuleDirection2D capsuleDirection, float angle, Vector3 direction, float distance = Mathf.Infinity)
	{
		bool isHit = (hitColliderCount > 0);
		DrawCapsuleCastRaw (origin, size, capsuleDirection, angle, direction, distance, isHit);
	}

	public static	void DrawCapsuleCastAll (RaycastHit2D[] hitInfos, Vector3 origin, Vector3 size, CapsuleDirection2D capsuleDirection, float angle, Vector3 direction, float distance = Mathf.Infinity)
	{
		bool isHit = (hitInfos != null && hitInfos.Length > 0);
		DrawCapsuleCastRaw (origin, size, capsuleDirection, angle, direction, distance, isHit);
	}

	static	void DrawCapsuleCastRaw (Vector3 origin, Vector3 size, CapsuleDirection2D capsuleDirection, float angle, Vector3 direction, float distance, bool isHit)
	{
		direction = new Vector3 (direction.x, direction.y);
		distance = (distance == Mathf.Infinity) ? 1000000f : distance;

		size = capsuleDirection == CapsuleDirection2D.Vertical ? new Vector3 (size.x, size.y) : new Vector3 (size.y, size.x);
		Gizmos.matrix = Matrix4x4.identity;
		float radius = size.x * 0.5f;
		Vector3 endPositionOfCapsule = origin + direction.normalized * distance;
		Vector3 offsetFromOrigin = GetArcOffsetFromOrigin (size, radius);//, capsuleDirection
		float verticalDir = (direction.x > 0) ? -1 : 1;
		offsetFromOrigin = offsetFromOrigin * verticalDir;
		if (size.x > 0) {
			Gizmos.color = (isHit) ? hitColorR2 : nonHitColorB2;
			Vector3 directionFromAngle = new Vector3 (-Mathf.Sin (Mathf.Deg2Rad * (angle)) * radius, Mathf.Cos (Mathf.Deg2Rad * (angle)) * radius);
			#region Line connecting capsules
			float additionInfoAboutAngle = (direction.x < 0) ? 360 - Vector3.Angle (Vector3.up, direction) : Vector3.Angle (Vector3.up, direction);
			float modyficatorForLinePosition = Mathf.Sign (Mathf.Sin (Mathf.Deg2Rad * (angle + additionInfoAboutAngle)));
			Vector3 originOfArc1 = origin + offsetFromOrigin.magnitude * directionFromAngle.normalized;
			Vector3 originOfArc2 = origin - offsetFromOrigin.magnitude * directionFromAngle.normalized;
			Vector3 tangentToDirection = Vector3.zero;
			Vector3.OrthoNormalize (ref direction, ref tangentToDirection);
			Vector3 baseCapsuleLine1 = tangentToDirection * radius * modyficatorForLinePosition + originOfArc1;
			Vector3 baseCapsuleLine2 = -tangentToDirection * radius * modyficatorForLinePosition + originOfArc2;
			Vector3 endCapsuleLine1 = tangentToDirection * radius * modyficatorForLinePosition + originOfArc1 + direction.normalized * distance;
			Vector3 endCapsuleLine2 = -tangentToDirection * radius * modyficatorForLinePosition + originOfArc2 + direction.normalized * distance;
			Gizmos.DrawLine (baseCapsuleLine2, endCapsuleLine2);
			//connecting capsules
			Gizmos.DrawLine (baseCapsuleLine1, endCapsuleLine1);
			//connecting capsules
			#endregion
			#region Drawing Capsules
			Gizmos.color = (isHit) ? hitColorR : nonHitColorG;
			//draw first capsule
			DrawCapsule (origin, size, capsuleDirection, angle, false);
			Gizmos.color = (isHit) ? hitColorO : nonHitColorB;
			//draw second capsule
			DrawCapsule (endPositionOfCapsule, size, capsuleDirection, angle, false);
			#endregion
		}
	}

	static void DrawCapsule (Vector3 origin, Vector3 size, CapsuleDirection2D capsuleDirection, float angle, bool isDotted = isDotted)
	{		
		float alphaOffset = 0f; 	
		float radius = (size.x < 0) ? 0f : size.x * 0.5f;
		Vector3 offsetFromOrigin = GetArcOffsetFromOrigin (size, radius);//, capsuleDirection

		Vector3 directionFromAngle = new Vector3 (-Mathf.Sin (Mathf.Deg2Rad * (angle)) * radius, Mathf.Cos (Mathf.Deg2Rad * (angle)) * radius);

		Vector3 tangentToAngleDirection = Vector3.zero;
		Vector3.OrthoNormalize (ref directionFromAngle, ref tangentToAngleDirection);
		Vector3 arcOffsetFromOrigin = offsetFromOrigin.magnitude * directionFromAngle;
		Vector3 tangendOffset = tangentToAngleDirection * radius;

		Vector3 baseCapsuleArc1B = origin + arcOffsetFromOrigin + tangendOffset;
		Vector3 baseCapsuleArc1E = origin - arcOffsetFromOrigin + tangendOffset;
		Vector3 baseCapsuleArc2B = origin + arcOffsetFromOrigin - tangendOffset;
		Vector3 baseCapsuleArc2E = origin - arcOffsetFromOrigin - tangendOffset;
		DrawDottedLine (baseCapsuleArc1B, baseCapsuleArc1E, 50, isDotted);
		DrawDottedLine (baseCapsuleArc2B, baseCapsuleArc2E, 50, isDotted);

		//		Gizmos.DrawLine (baseCapsuleArc1B, baseCapsuleArc1E);
		//		Gizmos.DrawLine (baseCapsuleArc2B, baseCapsuleArc2E);
		Gizmos.matrix = Matrix4x4.TRS (origin, Quaternion.AngleAxis (angle, Vector3.forward), Vector3.one);//draw second capsule and rest lines

		DrawHalfCircle (offsetFromOrigin, radius, alphaOffset, isDotted);
		DrawHalfCircle (-offsetFromOrigin, radius, Mathf.PI + alphaOffset, isDotted);
		Gizmos.matrix = Matrix4x4.identity;
	}

	static Vector3 GetArcOffsetFromOrigin (Vector3 size, float radius)//, CapsuleDirection2D capsuleDirection
	{
		Vector3 offsetValueY = Vector3.zero;
		float sizeX = 0.5f * size.x - radius;
		float sizeY = 0.5f * size.y - radius;
		if (size.y > size.x) {
			offsetValueY = new Vector3 (0f, sizeY);
		} else if (size.x >= size.y && size.y > 0) {
			offsetValueY = new Vector3 (0f, sizeX);		
		} else if (size.y < 0 || size.x < 0) {
			offsetValueY = Vector3.zero;	
		}	
		return offsetValueY;
	}

	static void DrawHalfCircle (Vector3 origin, float radius, float alfhaOffsetInRadians, bool isDotted)
	{
		float delta = GetDeltaForLoop (radius, isDotted);
		float x = radius * Mathf.Cos (0f);
		float y = radius * Mathf.Sin (0f);

		Vector3 beginPosition = origin + (new Vector3 (radius * Mathf.Cos (alfhaOffsetInRadians), radius * Mathf.Sin (alfhaOffsetInRadians), 0));
		Vector3 endPosition = beginPosition;
		Vector3 lastPosition = origin + (new Vector3 (radius * Mathf.Cos (Mathf.PI + alfhaOffsetInRadians), radius * Mathf.Sin (Mathf.PI + alfhaOffsetInRadians), 0));
		int z = 1;

		for (float deltaAngle = 0f + alfhaOffsetInRadians; deltaAngle <= Mathf.PI + alfhaOffsetInRadians; deltaAngle += delta) {
			z++;
			x = radius * Mathf.Cos (deltaAngle);
			y = radius * Mathf.Sin (deltaAngle);
			endPosition = origin + (new Vector3 (x, y, 0));
			DrawDottedLiness (beginPosition, endPosition, isDotted, z);
			beginPosition = endPosition;
		}
		Gizmos.DrawLine (beginPosition, lastPosition);	
	}

	static float GetDeltaForLoop (float radius, bool isDotted)
	{
		float delta = 0.1f;
		if (isDotted && radius > 0.2f) {//
			delta = delta / radius;
		}
		return delta;
	}

	static void DrawDottedLiness (Vector3 beginPosition, Vector3 endPosition, bool isDotted, int z)
	{
		if (isDotted && z % 2 == 0) {			
			Gizmos.DrawLine (beginPosition, endPosition);
		} else if (isDotted == false) {
			Gizmos.DrawLine (beginPosition, endPosition);
		} 
	}



	#endregion

	#region Circle Casting

	public static  	void DrawCircleCastAll (RaycastHit2D[] hitInfos, Vector3 origin, float radius, Vector3 direction, float distance = Mathf.Infinity)
	{			
		bool isHit = (hitInfos != null && hitInfos.Length > 0);
		DrawCircleCastRaw (origin, radius, direction, distance, isHit);
	}

	public static  void DrawCircleCast (RaycastHit2D hitInfo, Vector3 origin, float radius, Vector3 direction, float distance = Mathf.Infinity)
	{			
		bool isHit = hitInfo.collider != null;
		DrawCircleCastRaw (origin, radius, direction, distance, isHit);
	}

	public static  void DrawCircleCast (bool hitInfo, Vector3 origin, float radius, Vector3 direction, float distance = Mathf.Infinity)
	{			
		DrawCircleCastRaw (origin, radius, direction, distance, hitInfo);
	}

	public static  void DrawCircleCast (int hitColliderCount, Vector3 origin, float radius, Vector3 direction, float distance = Mathf.Infinity)
	{
		bool isHit = (hitColliderCount > 0);		
		DrawCircleCastRaw (origin, radius, direction, distance, isHit);
	}

	public static  void DrawCircleCastNonAlloc (int hitColliderCount, Vector3 origin, float radius, Vector3 direction, float distance = Mathf.Infinity)
	{
		bool isHit = (hitColliderCount > 0);		
		DrawCircleCastRaw (origin, radius, direction, distance, isHit);
	}

	static void DrawCircleCastRaw (Vector3 origin, float radius, Vector3 direction, float distance, bool isHit)
	{
		direction = new Vector3 (direction.x, direction.y);
		distance = (distance == Mathf.Infinity) ? 1000000f : distance;
		Vector3 endPositionOfCircle = origin + direction.normalized * distance;
		Vector3 tangent = Vector3.zero;
		Vector3.OrthoNormalize (ref direction, ref tangent);
		Gizmos.color = (isHit) ? hitColorR2 : nonHitColorB2;
		Gizmos.DrawLine (origin + tangent * radius, endPositionOfCircle + tangent * radius);
		Gizmos.DrawLine (origin - tangent * radius, endPositionOfCircle - tangent * radius);
		Gizmos.color = (isHit) ? hitColorR : nonHitColorG;
		//draw first circle
		DrawCircleRaw (origin, radius);
		Gizmos.color = (isHit) ? hitColorO : nonHitColorB;
		//draw second circle
		DrawCircleRaw (endPositionOfCircle, radius);

		#region Visualization of tangents of direction
		//		Gizmos.DrawLine (endPositionOfCircle, endPositionOfCircle + tangent * radius);
		//		Gizmos.DrawLine (endPositionOfCircle, endPositionOfCircle - tangent * radius);
		//
		//		Gizmos.DrawLine (origin, origin + tangent * radius);
		//		Gizmos.DrawLine (origin, origin - tangent * radius);
		#endregion
		Gizmos.matrix = Matrix4x4.identity;

	}


	static void DrawCircleRaw (Vector3 origin, float radius, bool isDotted = isDotted)
	{	
		float delta = 0.1f;
		if (isDotted && radius > 0.2f) {
			delta = delta / radius;
		}
		float x = radius * Mathf.Cos (0f);
		float y = radius * Mathf.Sin (0f);
		Vector3 beginPosition = origin + new Vector3 (x, y, 0);
		Vector3 endPosition = beginPosition;
		Vector3 lastPosition = beginPosition;
		int z = 1;

		for (float deltaAngle = 0f; deltaAngle < Mathf.PI * 2; deltaAngle += delta) {
			z++;
			x = radius * Mathf.Cos (deltaAngle);
			y = radius * Mathf.Sin (deltaAngle);
			endPosition = origin + new Vector3 (x, y, 0);
			if (isDotted && z % 2 == 0) {
				Gizmos.DrawLine (beginPosition, endPosition);
			} else if (isDotted == false) {
				Gizmos.DrawLine (beginPosition, endPosition);
			}
			beginPosition = endPosition;
		}
		Gizmos.DrawLine (beginPosition, lastPosition);
	}

	#endregion


	#region Collider  Casting

	public static void DrawCollider2D_Raycast (Collider2D collider, Vector2 direction, float distance = Mathf.Infinity)
	{
		Vector3 origin = collider.GetComponent<Transform> ().position;
		bool isHit =	Physics2D.Raycast (origin, direction, distance);
		DrawRaycastRaw (origin, direction, distance, isHit);
	}

	public static void DrawCollider2D_Cast (Collider2D collider, Vector3 direction, float distance = Mathf.Infinity, bool ignoreSiblingColliders = !default(bool))
	{	
		if (!collider) {
			return;
		}
		RaycastHit2D[] hitInfos = new RaycastHit2D[1];
		bool isHit = collider.Cast (direction, hitInfos, distance, ignoreSiblingColliders) > 0;
		DrawCollider2DShape (collider, direction, distance, isHit);	
		Gizmos.matrix = Matrix4x4.identity;
	}

	static void DrawCollider2DShape (Collider2D collider, Vector3 direction, float distance, bool isHit)
	{
		if (collider is BoxCollider2D) {
			BoxCollider2D bc = collider as BoxCollider2D;
			DrawBoxColliderCastRaw (bc, direction, distance, isHit);
		} else if (collider is CircleCollider2D) {
			CircleCollider2D circleCollider = (CircleCollider2D)collider;
			Vector3 originOfCC, scale;
			DataForCasting data = new DataForCasting (collider, direction, distance);
			data.GetDataForCasting (out originOfCC, out direction, out scale);
			float scaleFactor = (scale.x > scale.y) ? scale.x : scale.y;
			DrawCircleCastRaw (originOfCC, circleCollider.radius * scaleFactor, direction, distance, isHit);
		} else if (collider is CapsuleCollider2D) {
			DrawCapsuleCastRaw (collider, direction, distance, isHit);
		} else if (collider is EdgeCollider2D) {
			DrawEdgeCastRaw (collider, direction, distance, isHit);
		} else if (collider is PolygonCollider2D) {
			DrawPolyfCastRaw (collider, direction, distance, isHit);
		} else if (collider is CompositeCollider2D) {
			DrawCompositeCastRaw (collider, direction, distance, isHit);
		}
	}

	static void DrawCompositeCastRaw (Collider2D collider, Vector3 direction, float distance, bool isHit)
	{
		CompositeCollider2D compositeCollider = (CompositeCollider2D)collider;
		float edgeRadius = compositeCollider.edgeRadius;

		Vector3 originOfCC, endOfCC, scale, tangentToDirection = Vector3.zero;
		Quaternion rotation, rotationI;
		DataForCasting data = new DataForCasting (collider, direction, distance);
		data.GetDataForCasting (out originOfCC, out  endOfCC, out  direction, out  rotation, out scale);
		//		originOfCC = rotation * originOfCC;
		rotationI = Quaternion.Inverse (rotation);
		originOfCC += rotation * Vector3.Scale ((Vector3)compositeCollider.offset, new Vector3 (scale.x, scale.y));
		endOfCC += rotation * Vector3.Scale ((Vector3)compositeCollider.offset, new Vector3 (scale.x, scale.y));
		int pathCount = compositeCollider.pathCount;
		for (int k = 0; k < pathCount; k++) {
			Vector2[] points = new Vector2[compositeCollider.GetPathPointCount (k)];
			compositeCollider.GetPath (k, points);
			for (int i = 0; i < points.Length; i++) {
				//				points [i] = Vector2.Scale (rotation * points [i], new Vector3 (scale.x, scale.y));
				points [i] = rotation * points [i];
				//				points [i] = (Vector3)Vector2.Scale (points [i], rotationI * scale);
			}
			Gizmos.color = (isHit) ? hitColorR : nonHitColorG;
			DrawPolygonOrCompositeCollider (points, originOfCC);
			Gizmos.color = (isHit) ? hitColorO : nonHitColorB;
			DrawPolygonOrCompositeCollider (points, endOfCC);
			DrawLinesConnectingEdgePolygonCompositeCast (direction, tangentToDirection, points, isHit, originOfCC, endOfCC, edgeRadius);
			Gizmos.color = (isHit) ? hitColorR : nonHitColorG;

			DrawCapsulesForEdgeOrCompositeCast (points, originOfCC, direction, edgeRadius, true);
			Gizmos.color = (isHit) ? hitColorO : nonHitColorB;

			DrawCapsulesForEdgeOrCompositeCast (points, endOfCC, direction, edgeRadius, true);
		}
	}

	static void DrawEdgeCastRaw (Collider2D collider, Vector3 direction, float distance, bool isHit)
	{
		EdgeCollider2D edgeColider = (EdgeCollider2D)collider;
		Vector3 originOfEC, endOfEC, scale;
		Quaternion rotation;
		DataForCasting data = new DataForCasting (collider, direction, distance);
		data.GetDataForCasting (out originOfEC, out  endOfEC, out  direction, out  rotation, out scale);
		originOfEC += rotation * Vector3.Scale ((Vector3)edgeColider.offset, new Vector3 (scale.x, scale.y));
		endOfEC += rotation * Vector3.Scale ((Vector3)edgeColider.offset, new Vector3 (scale.x, scale.y));
		float edgeRadius = edgeColider.edgeRadius;
		Vector3 tangentToDirection = Vector3.zero;
		Vector2[] points = edgeColider.points;

		if (points.Length < 2) {
			return;			
		}
		for (int i = 0; i < points.Length; i++) {
			points [i] = rotation * (Vector3)Vector2.Scale (points [i], scale);
		}

		#region Draw Lines connecting egdes
		DrawLinesConnectingEdgePolygonCompositeCast (direction, tangentToDirection, points, isHit, originOfEC, endOfEC, edgeRadius);
		Gizmos.color = (isHit) ? hitColorR : nonHitColorG;

		DrawCapsulesForEdgeOrCompositeCast (points, originOfEC, direction, edgeRadius);
		Gizmos.color = (isHit) ? hitColorO : nonHitColorB;

		DrawCapsulesForEdgeOrCompositeCast (points, endOfEC, direction, edgeRadius);
		#endregion

		#region Drawing Points of EdgeCollider
		Gizmos.color = (isHit) ? hitColorR : nonHitColorG;
		DrawEdgeCollider (points, originOfEC, rotation);
		Gizmos.color = (isHit) ? hitColorO : nonHitColorB;
		DrawEdgeCollider (points, endOfEC, rotation);
		#endregion
		Gizmos.matrix = Matrix4x4.identity;

	}

	static void DrawPolyfCastRaw (Collider2D collider, Vector3 direction, float distance, bool isHit)
	{
		PolygonCollider2D polygonCollider = (PolygonCollider2D)collider;
		Vector3 originOfPC, endOfPC, scale, tangentToDirection = Vector3.zero;
		Quaternion rotation;
		DataForCasting data = new DataForCasting (collider, direction, distance);
		data.GetDataForCasting (out originOfPC, out  endOfPC, out  direction, out  rotation, out scale);
		int pathCount = polygonCollider.pathCount;
		for (int k = 0; k < pathCount; k++) {
			Vector2[] points = polygonCollider.GetPath (k);		
			for (int i = 0; i < points.Length; i++) {
				points [i] = rotation * Vector2.Scale (points [i], new Vector3 (scale.x, scale.y));
			}
			Gizmos.color = (isHit) ? hitColorR : nonHitColorG;
			DrawPolygonOrCompositeCollider (points, originOfPC);
			Gizmos.color = (isHit) ? hitColorO : nonHitColorB;
			DrawPolygonOrCompositeCollider (points, endOfPC);
			DrawLinesConnectingEdgePolygonCompositeCast (direction, tangentToDirection, points, isHit, originOfPC, endOfPC);
		}
	}

	static void DrawBoxColliderCastRaw (Collider2D collider, Vector3 direction, float distance, bool isHit)
	{		
		direction.Normalize ();
		Vector3 originOfBC, endOfBC, scale;
		Quaternion rotation;
		DataForCasting data = new DataForCasting (collider, direction, distance);
		data.GetDataForCasting (out originOfBC, out  endOfBC, out  direction, out  rotation, out scale);

		BoxCollider2D boxCollider = (BoxCollider2D)collider;
		Quaternion rotationFromDirection = Quaternion.FromToRotation (Vector3.up, direction);
		float edgeRadius = boxCollider.edgeRadius;
		Vector3 size = Vector3.Scale (boxCollider.size, scale);

		Vector3 tangentToDirection = Vector3.zero;

		#region Line connecting BC
		Vector3.OrthoNormalize (ref direction, ref tangentToDirection);

		Vector3 firstQ = new Vector3 (-size.x / 2f, size.y / 2f);
		Vector3 thirdQ = new Vector3 (size.x / 2f, -size.y / 2f);
		Vector3 secondQ = new Vector3 (size.x / 2f, size.y / 2f);
		Vector3 fourthQ = new Vector3 (-size.x / 2f, -size.y / 2f);

		Vector3 baseFirstQuarterH, endFirstQuarterH, baseFirstQuarterV, endFirstQuarterV;
		Vector3 baseThirdQuarterH, endThirdQuarterH, baseThirdQuarterV, endThirdQuarterV;
		Vector3 baseSecondQuarterH, endSecondQuarterH, baseSecondQuarterV, endSecondQuarterV;
		Vector3 baseFourthQuarterH, endFourthQuarterH, baseFourthQuarterV, endFourthQuarterV;
		int sign = (direction.x <= 0) ? 0 : 360;
		GetPointsOnBoxCollider (originOfBC, endOfBC, firstQ, tangentToDirection, rotation, edgeRadius, out baseFirstQuarterH, out endFirstQuarterH, out baseFirstQuarterV, out endFirstQuarterV);
		GetPointsOnBoxCollider (originOfBC, endOfBC, thirdQ, -tangentToDirection, rotation, edgeRadius, out baseThirdQuarterH, out endThirdQuarterH, out baseThirdQuarterV, out endThirdQuarterV);
		GetPointsOnBoxCollider (originOfBC, endOfBC, secondQ, -tangentToDirection, rotation, edgeRadius, out baseSecondQuarterH, out endSecondQuarterH, out baseSecondQuarterV, out endSecondQuarterV);
		GetPointsOnBoxCollider (originOfBC, endOfBC, fourthQ, tangentToDirection, rotation, edgeRadius, out baseFourthQuarterH, out endFourthQuarterH, out baseFourthQuarterV, out endFourthQuarterV);
		float delta = sign - rotationFromDirection.eulerAngles.z;
		float angle = (rotation.eulerAngles.z + delta);
		//in case of gimbal lock connecting lines don't work correct
		Gizmos.color = (isHit) ? hitColorR2 : nonHitColorB2;
		if (IsAngleBetween (angle, 0, 90) || IsAngleBetween (angle, 360, 450)) {				
			Gizmos.DrawLine (baseFirstQuarterH, endFirstQuarterH);
			Gizmos.DrawLine (baseThirdQuarterH, endThirdQuarterH);
		} else if (IsAngleBetween (angle, 90, 180) || IsAngleBetween (angle, 450, 540)) {
			Gizmos.DrawLine (baseSecondQuarterV, endSecondQuarterV);
			Gizmos.DrawLine (baseFourthQuarterV, endFourthQuarterV);
		} else if (IsAngleBetween (angle, 180, 270) || IsAngleBetween (angle, -180, -90)) {
			Gizmos.DrawLine (baseFirstQuarterV, endFirstQuarterV);
			Gizmos.DrawLine (baseThirdQuarterV, endThirdQuarterV);
		} else if (IsAngleBetween (angle, 270, 360) || IsAngleBetween (angle, -90, 0)) {
			Gizmos.DrawLine (baseSecondQuarterH, endSecondQuarterH);
			Gizmos.DrawLine (baseFourthQuarterH, endFourthQuarterH);
		} 
		#endregion
		#region Drawing BoxColliders
		Gizmos.color = (isHit) ? hitColorR : nonHitColorG;
		DrawBoxCollider (originOfBC, size, edgeRadius, rotation);
		Gizmos.color = (isHit) ? hitColorO : nonHitColorB;
		DrawBoxCollider (endOfBC, size, edgeRadius, rotation);
		#endregion
		Gizmos.matrix = Matrix4x4.identity;
	}

	static void DrawCapsuleCastRaw (Collider2D collider, Vector3 direction, float distance, bool isHit)
	{
		CapsuleCollider2D capsuleCollider = (CapsuleCollider2D)collider;
		Vector3 originOfCC, endOfCC, scale;
		Quaternion rotation;
		DataForCasting data = new DataForCasting (collider, direction, distance);
		data.GetDataForCasting (out originOfCC, out endOfCC, out direction, out rotation, out scale);
		Vector3 size = Vector3.Scale (capsuleCollider.size, scale);
		float angle = (rotation.eulerAngles.z);
		size = (capsuleCollider.direction == CapsuleDirection2D.Vertical) ? size : new Vector3 (size.y, size.x);
		float deltaAngle = ((capsuleCollider.direction == CapsuleDirection2D.Vertical) ? 0 : 90);
		DrawCapsuleCastRaw (originOfCC, size, CapsuleDirection2D.Vertical, angle + deltaAngle, direction, distance, isHit);
	}

	static void DrawPolygonOrCompositeCollider (Vector2[] points, Vector3 origin = default(Vector3))
	{		
		for (int i = 0; i < points.Length - 1; i++) {
			Gizmos.DrawLine (origin + (Vector3)points [i], origin + (Vector3)points [i + 1]);
		}	
		Gizmos.DrawLine (origin + (Vector3)points [points.Length - 1], origin + (Vector3)points [0]);
	}

	static void DrawBoxCollider (Vector3 origin, Vector3 size, float edgeRadius, Quaternion rotation)
	{
		origin = new Vector3 (origin.x, origin.y);
		size = new Vector3 (size.x, size.y);

		#region Rectangle
		Gizmos.matrix = Matrix4x4.TRS (origin, rotation, Vector3.one);

		Gizmos.DrawWireCube (Vector3.zero, size);
		float ER = edgeRadius;
		Vector3 LU = new Vector3 (-size.x, size.y) * 0.5f;
		Vector3 RU = new Vector3 (size.x, size.y) * 0.5f;

		Vector3 LD = new Vector3 (-size.x, -size.y) * 0.5f;

		Vector3 RD = new Vector3 (size.x, -size.y) * 0.5f;
		//		Gizmos.color = Color.yellow;
		Gizmos.DrawLine (LU + new Vector3 (0, ER), RU + new Vector3 (0, ER));
		Gizmos.DrawLine (RU + new Vector3 (ER, 0), RD + new Vector3 (ER, 0));
		Gizmos.DrawLine (RD + new Vector3 (0, -ER), LD + new Vector3 (0, -ER));
		Gizmos.DrawLine (LD + new Vector3 (-ER, 0), LU + new Vector3 (-ER, 0));
		//		Gizmos.color = Color.blue;
		DrawArcForBCLimitedTo180 (LU, ER, new Vector3 (0, ER), new Vector3 (-ER, 0));
		//		Gizmos.color = Color.red;

		DrawArcForBCLimitedTo180 (RU, ER, new Vector3 (ER, 0), new Vector3 (0, ER));
		//		Gizmos.color = Color.magenta;

		Gizmos.matrix = Matrix4x4.TRS (origin, rotation * Quaternion.AngleAxis (180, Vector3.forward), Vector3.one);
		DrawArcForBCLimitedTo180 (LU, ER, new Vector3 (0, ER), new Vector3 (-ER, 0));
		//		Gizmos.color = Color.white;

		DrawArcForBCLimitedTo180 (RU, ER, new Vector3 (ER, 0), new Vector3 (0, ER));
		#endregion
		Gizmos.matrix = Matrix4x4.identity;

	}

	static void DrawEdgeCollider (Vector2[] points, Vector3 origin, Quaternion rotation)
	{		
		for (int i = 0; i < points.Length - 1; i++) {
			Gizmos.DrawLine (origin + (Vector3)points [i], origin + (Vector3)points [i + 1]);
		}	
	}

	static void DrawLinesConnectingEdgePolygonCompositeCast (Vector3 direction, Vector3 tangentToDirection, Vector2[] points, bool isHit, Vector3 originOfEC, Vector3 endOfEC, float edgeRadius = default(float))
	{
		Vector3.OrthoNormalize (ref direction, ref tangentToDirection);
		List<EdgeAndPolygonColliderCastData> allPointAndMagnitudes = new List<EdgeAndPolygonColliderCastData> ();
		int numberOfPoints = points.Length;
		for (int i = 0; i < numberOfPoints; i++) {
			Vector3 temp = Vector3.Project (points [i], tangentToDirection);
			float g = temp.magnitude * Mathf.Sign (SignedAngle (direction, temp, Vector3.forward));
			allPointAndMagnitudes.Add (new EdgeAndPolygonColliderCastData (points [i], g));
		}
		allPointAndMagnitudes.Sort ((a, b) => b.signedMagnitude.CompareTo (a.signedMagnitude));
		Gizmos.color = (isHit) ? hitColorR2 : nonHitColorB2;
		Vector3 edgeVector = tangentToDirection * edgeRadius;
		for (int i = 1; i < numberOfPoints - 1; i++) {
			Gizmos.DrawLine (originOfEC + allPointAndMagnitudes [i].point + edgeVector, endOfEC + allPointAndMagnitudes [i].point + edgeVector);
			Gizmos.DrawLine (originOfEC + allPointAndMagnitudes [i].point - edgeVector, endOfEC + allPointAndMagnitudes [i].point - edgeVector);

		}
		Gizmos.DrawLine (originOfEC + allPointAndMagnitudes [0].point + edgeVector, endOfEC + allPointAndMagnitudes [0].point + edgeVector);
		Gizmos.DrawLine (originOfEC + allPointAndMagnitudes [numberOfPoints - 1].point - edgeVector, endOfEC + allPointAndMagnitudes [numberOfPoints - 1].point - edgeVector);

	}

	static void DrawCapsulesForEdgeOrCompositeCast (Vector2[] points, Vector3 origin, Vector3 direction, float radius, bool isItCompositeCollider = default(bool))
	{
		Vector3 start = Vector3.zero;
		int iterations = isItCompositeCollider ? points.Length : points.Length - 1;
		Vector3 directionFromPoints = Vector3.zero;
		for (int i = 0; i < iterations; i++) {			
			int k = i;
			int m = i + 1;
			if (i == points.Length - 1) {
				m = 0;
			}
			directionFromPoints = points [k] - points [m];
			Vector3.OrthoNormalize (ref directionFromPoints, ref start);

			Gizmos.DrawLine ((Vector3)points [k] + start * radius + origin, (Vector3)points [m] + start * radius + origin);
			//			Gizmos.color = Color.yellow;

			Gizmos.DrawLine ((Vector3)points [k] - start * radius + origin, (Vector3)points [m] - start * radius + origin);
			float angle = SignedAngle (direction, directionFromPoints, Vector3.forward) * Mathf.Deg2Rad;
			//			Gizmos.color = Color.magenta;
			Quaternion rotationOfHS = Quaternion.FromToRotation (direction, directionFromPoints.normalized);
			Gizmos.matrix = Matrix4x4.TRS ((Vector3)points [k] + origin, rotationOfHS, new Vector3 (1, 1, 1));
			DrawHalfCircle (Vector3.zero, radius, 0, false);
			//			Gizmos.color = Color.magenta;
			Gizmos.matrix = Matrix4x4.TRS ((Vector3)points [m] + origin, rotationOfHS, new Vector3 (1, 1, radius));

			DrawHalfCircle (Vector3.zero, radius, Mathf.PI, false);
			//			Gizmos.color = Color.red;
			Gizmos.matrix = Matrix4x4.identity;
		}	
	}

	/// <summary> /// Method similar to Vectro3.SignedAngle() added in 2017.1 - I copy this for older versions of unity /// </summary>

	static float SignedAngle (Vector3 from, Vector3 to, Vector3 axis)
	{
		from.Normalize ();
		to.Normalize ();
		float value1 = Mathf.Acos (Mathf.Clamp (Vector3.Dot (from, to), -1, 1)) * Mathf.Rad2Deg;
		float value2 = Mathf.Sign (Vector3.Dot (axis, Vector3.Cross (from, to)));
		return value1 * value2;
	}

	static bool  IsAngleBetween (float 	angle, float a, float b)
	{
		return angle >= a && angle < b;
	}

	static void GetPointsOnBoxCollider (Vector3 origin, Vector3 endOfBC, Vector3 quarter, Vector3 tangentToDir, Quaternion rotation, float edge,
	                                    out Vector3 baseQuarterH, out Vector3 endQuarterH, out Vector3 baseQuarterV, out Vector3 endQuarterV)
	{
		baseQuarterH = origin + rotation * quarter + tangentToDir * edge;
		endQuarterH = endOfBC + rotation * quarter + tangentToDir * edge;
		baseQuarterV = origin - rotation * quarter + tangentToDir * edge;
		endQuarterV = endOfBC - rotation * quarter + tangentToDir * edge;
	}

	static void DrawArcForBCLimitedTo180 (Vector3 origin, float radius, Vector3 from, Vector3 to)
	{
		float delta = 0.1f;
		float x = radius * Mathf.Cos (0f);
		float y = radius * Mathf.Sin (0f);
		float angleFrom = (from.y < 0) ? 360 - Vector3.Angle (Vector3.right, from) : Vector3.Angle (Vector3.right, from) * Mathf.Deg2Rad;
		float angleTo = (to.y < 0) ? 360 - Vector3.Angle (Vector3.right, to) : Vector3.Angle (Vector3.right, to) * Mathf.Deg2Rad;
		Vector3 beginPosition = origin + (new Vector3 (radius * Mathf.Cos (angleFrom), radius * Mathf.Sin (angleFrom)));
		Vector3 endPosition = beginPosition;
		Vector3 lastPosition = origin + (new Vector3 (radius * Mathf.Cos (angleTo), radius * Mathf.Sin (angleTo)));

		for (float deltaAngle = angleFrom; deltaAngle <= angleTo; deltaAngle += delta) {
			x = radius * Mathf.Cos (deltaAngle);
			y = radius * Mathf.Sin (deltaAngle);
			endPosition = origin + (new Vector3 (x, y));
			Gizmos.DrawLine (beginPosition, endPosition);	
			beginPosition = endPosition;
		}
		Gizmos.DrawLine (beginPosition, lastPosition);

	}

	struct EdgeAndPolygonColliderCastData
	{
		public EdgeAndPolygonColliderCastData (Vector3 point, float signedMagnitude)
		{
			this.point = point;
			this.signedMagnitude = signedMagnitude;
		}

		public Vector3 point;
		public float signedMagnitude;
	}


	#endregion

	#region Rigidbody Casting

	public static void DrawRigidbody2D_Cast (Rigidbody2D rigidbody2D, Vector3 direction, float distance = Mathf.Infinity)
	{
		if (!rigidbody2D) {
			return;
		}
		RaycastHit2D[] hitInfos = new RaycastHit2D[1];
		bool isHit = rigidbody2D.Cast (direction, hitInfos, distance) > 0;
		Collider2D[] allAttachedColliders = new Collider2D[rigidbody2D.attachedColliderCount];
		rigidbody2D.GetAttachedColliders (allAttachedColliders);
		for (int i = 0; i < rigidbody2D.attachedColliderCount; i++) {
			DrawCollider2DShape (allAttachedColliders [i], direction, distance, isHit);	
		}
		Gizmos.matrix = Matrix4x4.identity;
	}

	#endregion

	#endregion

}

