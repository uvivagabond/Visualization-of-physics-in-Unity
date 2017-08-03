using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Reflect : MonoBehaviour
{

	[SerializeField]	Vector3 originOfInDirection;
	[Space (50)]

	[SerializeField]	Vector3 inDirection;
	[Tooltip ("inNormal Must Be normalized to get correct results!!!")]
	[SerializeField]	Vector3 inNormal;
	[Space (50)]
	[SerializeField]bool useRealScale;
	[Space (20)]

	[SerializeField]	Vector3 result;

	void Update ()
	{
		inNormal.Normalize ();// !!!
		result = Vector3.Reflect (inDirection, inNormal);
	}

	void OnDrawGizmos ()
	{
		GizmosForVector.VisualizeReflect (originOfInDirection: originOfInDirection, inDirection: inDirection, inNormal: inNormal, realScale: useRealScale);
	}
}
