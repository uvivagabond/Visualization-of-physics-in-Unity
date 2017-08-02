using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignedAngle2D : MonoBehaviour
{
	[SerializeField]	Vector3 originOfVectors;
	[Space (50)]

	[SerializeField]	Vector3 from = new Vector3 (0f, 0f, 0f);
	[SerializeField]	Vector3 to = new Vector3 (0f, 0f, 0f);

	[Space (50)]
	[SerializeField]bool useRealScale;
	[Space (20)]
	[SerializeField]	float angle;

	void Update ()
	{
		angle = Vector2.SignedAngle (from: from, to: to);
	}

	void OnDrawGizmos ()
	{
		GizmosForVector.VisualizeSignedAngle2D (origin: originOfVectors, from: from, to: to, realScale: useRealScale);
	}
}
