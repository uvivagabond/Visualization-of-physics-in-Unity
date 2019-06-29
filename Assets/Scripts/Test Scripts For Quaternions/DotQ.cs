using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityBerserkersGizmos;

[ExecuteInEditMode]
public class DotQ : MonoBehaviour
{

	[Header ("Origin of vectors")]
	[SerializeField]Vector3 origin = Vector3.zero;
	[Space (11)][Header ("Quaternions in form of euler angle")]
	[SerializeField]Vector3 firstRotation = Vector3.right;
	[SerializeField]Vector3 secondRotation = Vector3.up;

	[Space (22)][Header ("Dot product and parameter w")]
	[SerializeField]float dotProduct;
    [SerializeField] float parameterW;

    [SerializeField] Quaternion B;
    [SerializeField] Quaternion A;


    void Update ()
	{
        Quaternion a = Quaternion.Euler (firstRotation);
		Quaternion b =	Quaternion.Euler (secondRotation);

		dotProduct = Quaternion.Dot (a: a, b: b);

        //The difference in rotation between two quaternions
        Quaternion rotationDifferenceBA = Quaternion.Inverse(a) * b;
        parameterW = rotationDifferenceBA.w;

        A = Quaternion.identity;
        B= Quaternion.Euler(secondRotation);
    }

	void OnDrawGizmos ()
	{
		Quaternion a = Quaternion.Euler (firstRotation);
		Quaternion b = Quaternion.Euler (secondRotation);
	
		GizmosForQuaternion.Dot (origin, a, b, 6f);	
	}
}
