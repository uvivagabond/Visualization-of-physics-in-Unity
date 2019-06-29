using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityBerserkersGizmos;

[ExecuteInEditMode]
public class ToAngleAxisTest : MonoBehaviour
{
 
    [Header ("Quaternions in form of euler angle")]
	[SerializeField]Vector3 eulerAngles = Vector3.right;

	[Space (22)][Space (22)][Header ("Results:")]
	[SerializeField]Vector3 axis;
	[SerializeField] float angle;

    [Space(11)]
    [Header("Results:")]
    [SerializeField] Quaternion q;


    [Space(55)]
    [Header("Visualization parameters")]
    [Header("Origin of vectors")]
    [SerializeField] Vector3 origin = Vector3.zero;
    [Header("Which version of method")]
    [SerializeField] bool useBuiltinDirection;
    [SerializeField] BaseVectorDirection builtinDirection;
    [SerializeField] Vector3 customDirectionn = Vector3.right;

    void Update ()
	{
        q = Quaternion.Euler (eulerAngles);
        q.ToAngleAxis (angle:out angle,axis: out axis);
	}

	void OnDrawGizmos ()
	{
		Quaternion startQ = Quaternion.Euler (eulerAngles);
		if (useBuiltinDirection) {
			GizmosForQuaternion.ToAngleAxis (origin, startQ, builtinDirection);
		} else {
			GizmosForQuaternion.ToAngleAxis (origin, startQ, customDirectionn);
		}
	}
}
