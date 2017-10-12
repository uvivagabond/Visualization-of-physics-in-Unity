using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityBerserkersGizmos;

public class VisualizeCircle : MonoBehaviour
{
	[SerializeField]Vector2 origin;
	[SerializeField]float radius = 0;
	[SerializeField]bool isDotted = false;

	void OnDrawGizmos ()
	{
		GizmosForPhysics2D.VisualizeCircle (origin: origin, radius: radius, isDotted: isDotted);
	}
}
