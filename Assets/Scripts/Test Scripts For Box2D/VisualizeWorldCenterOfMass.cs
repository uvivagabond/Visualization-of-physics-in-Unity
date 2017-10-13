using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityBerserkersGizmos;

[ExecuteInEditMode]
public class VisualizeWorldCenterOfMass : MonoBehaviour
{

	[SerializeField]Rigidbody2D myRigidbody2D;

	void OnDrawGizmos ()
	{
		GizmosForPhysics2D.VisualizeWorldCenterOfMass (myRigidbody2D);
	}

	void Start ()
	{
		myRigidbody2D = GetComponent<Rigidbody2D> ();
	}
}
