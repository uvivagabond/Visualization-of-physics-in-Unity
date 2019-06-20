using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityBerserkersGizmos;

public class TRotate : MonoBehaviour
{
	[Header ("Rotation in form of euler angle")]
	[SerializeField]Vector3 euler = Vector3.right;
   
	[Space (22)][SerializeField] Vector3 axis = Vector3.right;

	[SerializeField]  float angle;
	[SerializeField]  [Space (22)] Space space;


	void Update ()
	{    
		transform.Rotate (eulers: euler * Time.deltaTime, 
			relativeTo: Space.Self);		

		#region Other
//		transform.Rotate (
		//			xAngle: euler.x * Time.deltaTime, 
		//			yAngle: euler.y * Time.deltaTime, 
		//			zAngle: euler.z * Time.deltaTime, 
		//			relativeTo: space);
		//		transform.Rotate (
		//			axis: axis, 
		//			angle: angle * Time.deltaTime, 
		//			relativeTo: space);
		#endregion
	}

	void OnDrawGizmos ()
	{		
		GizmosForTransform.Rotate (transform, euler, space, 3);

		#region Other
		//		GizmosForTransform.Rotate (transform, euler.x * Time.deltaTime, euler.y * Time.deltaTime, euler.z * Time.deltaTime, space, 3);
//				GizmosForTransform.Rotate (transform, axis, angle * Time.deltaTime, space, 3);

		#endregion


	}
}
