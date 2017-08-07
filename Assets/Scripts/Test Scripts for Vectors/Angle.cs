using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Angle : MonoBehaviour
{
	[SerializeField]	Vector3 originOfVectors;
	[Space (50)]

	[SerializeField]	Vector3 from = new Vector3 (0f, 0f, 0f);
	[SerializeField]	Vector3 to = new Vector3 (0f, 0f, 0f);

	[Space (20)]
	[SerializeField]	float angle;

	void Update ()
	{
		angle = Vector3.Angle (from: from, to: to);
	}

	void OnDrawGizmos ()
	{
		GizmosForVector.VisualizeAngle (origin: originOfVectors, from: from, to: to, lenght: 5);
	}
}
