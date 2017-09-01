using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityBerserkersGizmos;

public class Box2DRayCast : MonoBehaviour
{

	[SerializeField]Vector3 origin;
	[SerializeField]Vector3 direction;

	[SerializeField]float distance = 1;

	RaycastHit2D hitByRayCast;

	[Space (55)][Header ("Results:")]
	[SerializeField]bool isSomethingHit;

	void Update ()
	{		
		isSomethingHit = Physics2D.Raycast (origin: origin, direction: direction, distance: distance,			
			layerMask: Physics2D.DefaultRaycastLayers, minDepth: -Mathf.Infinity, maxDepth: Mathf.Infinity);
	}

	void OnDrawGizmos ()
	{
		GizmosForPhysics2D.DrawRayCast (origin: origin, direction: direction, distance: distance);
	}
}
