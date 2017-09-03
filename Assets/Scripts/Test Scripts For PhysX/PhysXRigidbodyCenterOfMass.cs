using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityBerserkersGizmos;

[ExecuteInEditMode]
public class PhysXRigidbodyCenterOfMass : MonoBehaviour
{
	Rigidbody myRigidbody;

	void Start ()
	{
		myRigidbody = GetComponent<Rigidbody> ();
	}


	void OnDrawGizmos ()
	{
		GizmosForPhysics3D.VisualizeWorldCenterOfMass (myRigidbody);
	}
}
