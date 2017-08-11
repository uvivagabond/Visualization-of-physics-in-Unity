using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityBerserkersGizmos;

public class Box2DRayIntersection : MonoBehaviour
{
	[Header ("Definition of Ray")]
	[SerializeField]Vector3 origin;
	[SerializeField]Vector3 direction;
	[Space (44)]
	[SerializeField]float distance = 1;

	RaycastHit2D hitByRayCast;

	[Space (55)][Header ("Results:")]
	[SerializeField]bool isSomethingHit;

	void Update ()
	{
		isSomethingHit = Physics2D.GetRayIntersection (ray: new Ray (origin: origin, direction: direction), distance: distance);
	}

	void OnDrawGizmos ()
	{

		GizmosForPhysics2D.DrawGetRayIntersection (ray: new Ray (origin: origin, direction: direction), distance: distance);
	}
}
