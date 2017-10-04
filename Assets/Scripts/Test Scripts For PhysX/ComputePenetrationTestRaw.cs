using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityBerserkersGizmos;

[ExecuteInEditMode]
public class ComputePenetrationTestRaw : MonoBehaviour
{

	[SerializeField] Collider colliderA;
	[SerializeField] Collider colliderB;
	[SerializeField] Vector3 direction;
	[Space (22)][Header ("Results")]
	[SerializeField] float distance;
	[SerializeField] bool isPenetrating;

	void Update ()
	{
		isPenetrating =	Physics.ComputePenetration (colliderA: colliderA, positionA: colliderA.transform.position, rotationA: colliderA.transform.rotation,
			colliderB: colliderB, positionB: colliderB.transform.position, rotationB: colliderB.transform.rotation, direction: out direction, distance: out distance);
	}

	void OnDrawGizmos ()
	{

		GizmosForPhysics3D.VizualizeComputePenetration (colliderA: colliderA, positionA: colliderA.transform.position, rotationA: colliderA.transform.rotation,
			colliderB: colliderB, positionB: colliderB.transform.position, rotationB: colliderB.transform.rotation);
//		//drawing colliders
//		Gizmos.color = Color.red;
//		Gizmos.DrawSphere (colliderB.transform.position + Vector3.Scale (colliderB.center, colliderB.transform.lossyScale), 0.05f);
//
//		if (isPenetrating) {
//			Gizmos.DrawRay (colliderB.transform.position + Vector3.Scale (colliderB.center, colliderB.transform.lossyScale), direction * distance);
//		} 
//		Gizmos.color = Color.yellow;
//		Gizmos.matrix = Matrix4x4.Rotate (colliderB.transform.rotation);
//		Gizmos.DrawWireCube (colliderB.transform.position + Vector3.Scale (colliderB.center, colliderB.transform.lossyScale), Vector3.Scale (colliderB.size, colliderB.transform.lossyScale));
//		Gizmos.matrix = Matrix4x4.Rotate (colliderA.transform.rotation);
//		Gizmos.color = Color.green;
//		Gizmos.DrawWireCube (colliderA.transform.position + Vector3.Scale (colliderA.center, colliderA.transform.lossyScale), Vector3.Scale (colliderA.size, colliderA.transform.lossyScale));
//		Gizmos.matrix = Matrix4x4.identity;
	}
}
