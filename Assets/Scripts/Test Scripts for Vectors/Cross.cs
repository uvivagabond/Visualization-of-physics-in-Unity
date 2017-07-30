using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cross : MonoBehaviour
{

	[SerializeField]	Vector3 originOfVectors;
	[Space (50)]

	[SerializeField]	Vector3 lhs = new Vector3 (0f, 0f, 0f);
	[SerializeField]	Vector3 rhs = new Vector3 (0f, 0f, 0f);


	[Space (50)]
	[SerializeField]bool useRealScale;
	[Space (20)]
	[SerializeField]	Vector3 result;

	void Update ()
	{
		result = Vector3.Cross (lhs: lhs, rhs: rhs);
	}

	void OnDrawGizmos ()
	{
		GizmosForVector.VisualizeCross (origin: originOfVectors, lhs: lhs, rhs: rhs, realScale: useRealScale);
	}
}
