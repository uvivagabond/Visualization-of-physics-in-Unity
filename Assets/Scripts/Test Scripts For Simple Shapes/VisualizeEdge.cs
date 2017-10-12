using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityBerserkersGizmos;

public class VisualizeEdge : MonoBehaviour
{
	[SerializeField]Vector2 origin;
	[SerializeField]Vector2[] pointsInLocalSpace;
	[Range (0, 2)][SerializeField]float edgeRadius = 0;

	void OnDrawGizmos ()
	{
		GizmosForPhysics2D.VisualizeEdge (origin: origin, points: pointsInLocalSpace, edgeRadius: edgeRadius);
	}
}
