using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class SignedAngle3D : MonoBehaviour
{

	[SerializeField]	Vector3 originOfVectors;
	[Space (50)]

	[SerializeField]	Vector3 from = new Vector3 (0f, 0f, 0f);
	[SerializeField]	Vector3 to = new Vector3 (0f, 0f, 0f);
	[SerializeField]	Vector3 axis = new Vector3 (0f, 1f, 0f);

	[Space (20)]
	[SerializeField]	float angle;

	void Update ()
	{
		angle = Vector3.SignedAngle (from: from, to: to, axis: axis);
	}

	void OnDrawGizmos ()
	{
		GizmosForVector.VisualizeSignedAngle3D (origin: originOfVectors, from: from, to: to, axis: axis, lenght: 5);
	}
}
