using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Orthonormalize : MonoBehaviour
{

	[SerializeField]	Vector3 originOfVectors;
	[Space (50)]

	[SerializeField]	Vector3 normal = new Vector3 (0f, 0f, 0f);
	[Space (50)]
	[SerializeField]	Vector3 tangent = new Vector3 (0f, 0f, 0f);
	[SerializeField]	Vector3 binormal = new Vector3 (0f, 0f, 0f);


	[Space (50)]
	[SerializeField]float lenght;

	void Update ()
	{
		Vector3.OrthoNormalize (normal: ref normal, tangent: ref tangent, binormal: ref binormal);
	}

	void OnDrawGizmos ()
	{
		GizmosForVector.VisualizeOrthonormalize (origin: originOfVectors, normal: normal, lenght: lenght);
	}
}
