using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityBerserkersGizmos;

[ExecuteInEditMode]
public class AngleTest : MonoBehaviour
{	
	[Header ("Quaternions in form of euler angle")]
	[SerializeField]Vector3 eulerAnglesA = Vector3.right;
	[SerializeField]Vector3 eulerAnglesB = Vector3.up;

    [Space(11)]
    [Header("Results:")]
    [SerializeField] float angle;

    [Space(22)]
    [Header("Results from extebtion methods:")]
    [SerializeField] float signedAngle;
    [SerializeField] float angleOfB;

    [Space(55)]
    [Header("Visualization parameters")]
    [Header("Origin of vectors")]
    [SerializeField] Vector3 origin = Vector3.zero;
   [Header ("Which version of method")]
	[SerializeField] bool useBuiltinDirection;
	[Space (5)][SerializeField]BaseVectorDirection builtinDirection;
	[SerializeField]Vector3 customDirectionn = Vector3.right;

	void Update ()
	{
		Quaternion a = Quaternion.Euler (eulerAnglesA);
		Quaternion b = Quaternion.Euler (eulerAnglesB);
		angle =	Quaternion.Angle (a: a, b: b);

        // extentions methods
        signedAngle = b.SignedAngle();
    }

	void OnDrawGizmos ()
	{ 
		Quaternion startQ = Quaternion.Euler (eulerAnglesA);
		Quaternion endQ = Quaternion.Euler (eulerAnglesB);
		if (useBuiltinDirection) {
			GizmosForQuaternion.Angle (origin: origin, startRotation: startQ, endRotation: endQ, builtinDirection: builtinDirection, lenght: 6);	
		} else {
			GizmosForQuaternion.Angle (origin: origin, startRotation: startQ, endRotation: endQ, customDirection: customDirectionn, lenght: 6);		
		}
	}
}
