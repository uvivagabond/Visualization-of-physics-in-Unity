using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityBerserkersGizmos;

[ExecuteInEditMode]
public class AngleAxisTest : MonoBehaviour
{
 
    [Header ("Quaternions in form of euler angle")]
	[SerializeField]Vector3 startRotation = Vector3.right;
	
	[Space (22)]
	[SerializeField]Vector3 axis;
	[SerializeField] float angle;

    [Space(11)]
    [Header("Results:")]
    [SerializeField] Quaternion q;

    [Space(55)]
    [Header("Visualization parameters")]
    [Header("Origin of vectors")]
    [SerializeField] Vector3 origin1 = Vector3.zero;
    [Header("Which version of method")]
    [SerializeField] bool useBuiltinDirection;
    [Space(5)] [SerializeField] BaseVectorDirection builtinDirection;
    [SerializeField] Vector3 customDirectionn = Vector3.right;



    void Update ()	{
        q = Quaternion.AngleAxis (angle:angle,axis: axis);		
	}

	void OnDrawGizmos ()
	{
		Quaternion startQ = Quaternion.Euler (startRotation);
		if (useBuiltinDirection) {
			GizmosForQuaternion.AngleAxis (origin1, angle, axis, startQ, builtinDirection);
		} else {
			GizmosForQuaternion.AngleAxis (origin1, angle, axis, startQ, customDirectionn);
		}
	}


}
