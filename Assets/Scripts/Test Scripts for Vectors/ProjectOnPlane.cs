using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityBerserkersGizmos;

[ExecuteInEditMode]
public class ProjectOnPlane : MonoBehaviour
{
	[SerializeField]	Vector3 originOfVectors;
	[Space (50)]

	[SerializeField]	Vector3 vector;
	[SerializeField]	Vector3 planeNormal;
	[Space (50)]
	[SerializeField]bool useRealScale;
	[Space (20)]

	[SerializeField]	Vector3 result;

	void Update ()
	{
		result = Vector3.ProjectOnPlane (vector, planeNormal);
	}

	void OnDrawGizmos ()
	{
		GizmosForVector.VisualizeProjectOnPlane (origin: originOfVectors, vector: vector, planeNormal: planeNormal, realScale: useRealScale);
	}
}
