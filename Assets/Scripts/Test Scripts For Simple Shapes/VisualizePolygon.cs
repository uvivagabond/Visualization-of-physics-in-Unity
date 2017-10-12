using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityBerserkersGizmos;

public class VisualizePolygon : MonoBehaviour
{
	[SerializeField]Vector2 origin;
	[SerializeField]Vector2[] pointsInLocalSpace;

	void OnDrawGizmos ()
	{
		GizmosForPhysics2D.VisualizePolygonShape (origin: origin, points: pointsInLocalSpace);
	}
}
