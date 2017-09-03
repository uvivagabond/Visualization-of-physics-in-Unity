using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityBerserkersGizmos;

public class PhysXTestQueryTriggerInteraction : MonoBehaviour
{
	[SerializeField]Vector3 origin;
	[SerializeField]Vector3 direction;

	[SerializeField]float maxDistance = 1;
	[SerializeField]QueryTriggerInteraction queryTriggerInteraction = QueryTriggerInteraction.UseGlobal;

	RaycastHit hitByRayCast;
	RaycastHit coTrafilismy;
	[Space (55)][Header ("Results:")]
	[SerializeField]bool isSomethingHit;
	[SerializeField] Collider[] aaa;

	void Update ()
	{
		RaycastHit hitInfo;

		isSomethingHit = Physics.Raycast (origin: origin, direction: direction, hitInfo: out hitInfo, maxDistance: maxDistance,

			layerMask: Physics.DefaultRaycastLayers, queryTriggerInteraction: QueryTriggerInteraction.UseGlobal);

		RaycastHit[] hitInfos = Physics.RaycastAll (origin: origin, direction: direction, maxDistance: maxDistance, layermask: Physics.DefaultRaycastLayers, queryTriggerInteraction: queryTriggerInteraction);
		   


		aaa = new Collider[hitInfos.Length];
		for (int i = 0; i < hitInfos.Length; i++) {
			aaa [i] = hitInfos [i].collider;
		}
		                        
	}

	void OnDrawGizmos ()
	{
		GizmosForPhysics3D.DrawRaycast (origin: origin, direction: direction, maxDistance: maxDistance,
			layerMask: Physics.DefaultRaycastLayers, queryTriggerInteraction: queryTriggerInteraction);
	}

}
