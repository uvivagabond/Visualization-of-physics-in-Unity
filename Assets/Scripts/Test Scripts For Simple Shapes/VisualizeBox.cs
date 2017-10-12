using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityBerserkersGizmos;

public class VisualizeBox : MonoBehaviour
{
	[SerializeField]Vector2 center;
	[SerializeField]Vector2 size;
	[SerializeField]float edgeRadius = 0;

	void OnDrawGizmos ()
	{
		GizmosForPhysics2D.VisualizeBox (center: center, size: size, edgeRadius: edgeRadius);
	}
}
