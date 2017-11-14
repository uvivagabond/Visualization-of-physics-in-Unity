using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityBerserkersGizmos;

public class LerpUnclampedTestQ : MonoBehaviour {


	[Header ("SHOWING TRAJECTORY OF ROTATION")][Space (5)]
	[Header ("Press L to start move")][Space (11)]
	[Header ("Origin of vectors")]
	[SerializeField]Vector3 origin = Vector3.zero;
	[Header ("Quaternions in form of euler angle")]
	[SerializeField]Vector3 start = Vector3.right;
	[SerializeField]Vector3 end = Vector3.up;
	[SerializeField]float howFuther = 3;
	[Space (22)][Header ("Which version of method")]
	[SerializeField] bool useBuiltinDirection;
	[Space (5)][SerializeField]BaseVectorDirection builtinDirection;
	[Space (22)][SerializeField]Vector3 customDirection = Vector3.right;

	void Update ()
	{
		// when we press L we start slerping cube
		if (Input.GetKeyDown (KeyCode.L)) {
			Quaternion startQ = Quaternion.Euler (start);
			Quaternion endQ = Quaternion.Euler (end);
			IEnumerator slerp = QuaternionCoroutines.LerpUnclamped (transform, startQ, endQ, 1, 10);
			StartCoroutine (slerp);
		}
		// when we press P when you want to set cube to start rotation
		if (Input.GetKeyDown (KeyCode.P)) {
			transform.rotation = Quaternion.Euler (start);	
		}
	}

	void OnDrawGizmos ()
	{
		Quaternion startQ = Quaternion.Euler (start);
		Quaternion endQ = Quaternion.Euler (end);
		if (useBuiltinDirection) {
			GizmosForQuaternion.LerpUnclamped (origin, startQ, endQ, howFuther, builtinDirection, 6f);
		} else {
			GizmosForQuaternion.LerpUnclamped (origin, startQ, endQ, howFuther, customDirection, 6f);
		}
	}
}
