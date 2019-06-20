using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityBerserkersGizmos;


public class LookAtTestForTransform : MonoBehaviour
{
	[Header ("Origin of vectors")]
	[SerializeField]
	Transform origin;
	[Header ("Quaternions in form of euler angle")]
	[SerializeField]
	Transform target;
	[SerializeField]
	Vector3 worldPosition = Vector3.up;
	[SerializeField]
	Vector3 worldUp = Vector3.up;

	void Update ()
	{		
		transform.LookAt (worldPosition: worldPosition, worldUp: worldUp);

		#region Other

//		transform.LookAt (target: target, worldUp: Vector3.up);


		#endregion
	}

	void OnDrawGizmos ()
	{
//		GizmosForTransform.LookAt (origin, target, worldUp);
		GizmosForTransform.LookAt (origin, worldPosition, worldUp);

	}
}
