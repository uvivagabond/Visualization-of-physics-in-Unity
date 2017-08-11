using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityBerserkersGizmos;

[ExecuteInEditMode]

public class Dot : MonoBehaviour
{
	[SerializeField]	Vector3 originOfVectors;
	[Space (50)]

	[SerializeField]	Vector3 lhs = new Vector3 (0f, 0f, 0f);
	[SerializeField]	Vector3 rhs = new Vector3 (0f, 0f, 0f);


	[Space (50)]
	[SerializeField]bool useRealScale;
	[Space (20)]
	[SerializeField]	float dotProduct;

	void Update ()
	{
		dotProduct = Vector3.Dot (lhs: lhs, rhs: rhs);
	}

	void OnDrawGizmos ()
	{
		GizmosForVector.VisualizeDot (origin: originOfVectors, lhs: lhs, rhs: rhs, realScale: useRealScale);
	}
}
