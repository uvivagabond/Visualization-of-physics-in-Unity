using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityBerserkersGizmos;

[ExecuteInEditMode]
public class ComputePenetrationTestRaw : MonoBehaviour
{

	[SerializeField] Collider colliderA;
	[SerializeField] Collider colliderB;

	[Space (22)][Header ("Results")]
	[SerializeField] float distance;
	[SerializeField] Vector3 direction;
	[SerializeField] bool isPenetrating;

	void Update ()
	{
		isPenetrating =	Physics.ComputePenetration (colliderA: colliderA, positionA: Vector3.zero, rotationA: colliderA.transform.rotation,// colliderA.transform.position+
            colliderB: colliderB, positionB: colliderB.transform.position, rotationB: colliderB.transform.rotation, 
            direction: out direction, distance: out distance);
	}

	void OnDrawGizmos ()
	{
		GizmosForPhysics3D.VizualizeComputePenetration (colliderA: colliderA, 
			positionA: colliderA.transform.position, 
			rotationA: colliderA.transform.rotation,
			colliderB: colliderB, 
			positionB: colliderB.transform.position, 
			rotationB: colliderB.transform.rotation);	
	}
}
