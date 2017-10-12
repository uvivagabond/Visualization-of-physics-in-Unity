using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityBerserkersGizmos;

public class VisualizeCapsule : MonoBehaviour
{
	[SerializeField]Vector2 origin;
	[SerializeField]Vector2 size;
	[SerializeField]CapsuleDirection2D capsuleDirection;
	[SerializeField]float angle = 0;
	[SerializeField]bool isDotted = false;

	void OnDrawGizmos ()
	{
		GizmosForPhysics2D.VisualizeCapsule (origin: origin, size: size, capsuleDirection: capsuleDirection, angle: angle, isDotted: isDotted);
	}
}
