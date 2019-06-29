using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityBerserkersGizmos;

public class RotateTowardsTest : MonoBehaviour
{
	[Space (11)][Header ("Quaternions in form of euler angle")]
	[SerializeField]Vector3 fromAsEulerAngles = Vector3.zero;
	[SerializeField]Vector3 toAsEulerAngles= new Vector3(0,0,90);
    [Space(11)] [Tooltip ("Velocity in degrees/s")][SerializeField]float maxDegreesVelocity = 5;

    [Space(22)]
    [Header("Results:")]
    [SerializeField] Quaternion q;
    [SerializeField] Vector3 qAsEulerAngles = Vector3.right;

    void Update ()
	{
		Quaternion from = transform.rotation;
		Quaternion to = Quaternion.Euler (toAsEulerAngles);

		float maxDegreesDelta = maxDegreesVelocity * Time.deltaTime;
		Quaternion actualRotation = Quaternion.RotateTowards (from:from, to:to, maxDegreesDelta: maxDegreesDelta);
		transform.rotation = actualRotation;

        q = actualRotation;
        qAsEulerAngles = q.eulerAngles;
    }

	void OnDrawGizmos ()
	{
		Quaternion fromQ = Quaternion.Euler (fromAsEulerAngles);	
		Quaternion toQ = Quaternion.Euler (toAsEulerAngles);
       	GizmosForQuaternion.RotateTowards (Vector3.zero, fromQ, toQ, BaseVectorDirection.right, 6);
	
	}
}
