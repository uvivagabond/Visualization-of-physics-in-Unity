using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityBerserkersGizmos;

public class RotateTowardsTestVer2 : MonoBehaviour
{

	[Header ("SHOWING CHANGE OF ROTATION")][Space (11)]
	[Space (11)][Header ("Quaternions in form of euler angle")]
    [SerializeField] Vector3 from = Vector3.right;
    [SerializeField]Vector3 to = Vector3.right;
	[Tooltip ("Velocity in degrees/s")][SerializeField]float maxDegreesVelocity = 5;


   
	void Update ()
	{
		Quaternion fromQ = transform.rotation;
		Quaternion toQ = Quaternion.Euler (to);
		float maxAngleInDegrees = maxDegreesVelocity * Time.deltaTime;
		Quaternion actualRotation = Quaternion.RotateTowards (fromQ, toQ, maxAngleInDegrees);
		transform.rotation = actualRotation;
	}

	void OnDrawGizmos ()
	{
		Quaternion fromQ;
		fromQ = transform.rotation;
		Quaternion toQ = Quaternion.Euler (to);

		GizmosForQuaternion.RotateTowards (Vector3.zero, fromQ, toQ, BaseVectorDirection.right, 6);

	}
}
