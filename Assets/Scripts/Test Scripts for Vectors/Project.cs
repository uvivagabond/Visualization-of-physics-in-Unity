using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityBerserkersGizmos;

[ExecuteInEditMode]
public class Project : MonoBehaviour
{
	[SerializeField]	Vector3 originOfVectors;
	[Space (50)]

	[SerializeField]	Vector3 vector = new Vector3 (0f, 0f, 0f);
	[SerializeField]	Vector3 onNormal = new Vector3 (0f, 0f, 0f);
	[SerializeField]	Vector3 result = new Vector3 (0f, 1f, 0f);

	[Space (50)]
	[SerializeField]bool useRealScale;
	[Space (20)]
	[SerializeField]	float angle;

	void Update ()
	{
		result = Vector3.Project (vector, onNormal);
	}

	void OnDrawGizmos ()
	{
		GizmosForVector.VisualizeProject (origin: originOfVectors, vector: vector, onNormal: onNormal, lenght: 5, realScale: useRealScale);
	}
}
