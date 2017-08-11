using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityBerserkersGizmos;

public class Box2DCircleCast : MonoBehaviour
{
	[SerializeField]Vector3 origin;
	[SerializeField]Vector3 direction;
	[SerializeField]float radius = 1;
	[SerializeField]float distance = 1;

	RaycastHit2D hitByRayCast;

	[Space (55)][Header ("Results:")]
	[SerializeField]bool isSomethingHit;

	void Update ()
	{		
		isSomethingHit = Physics2D.CircleCast (origin: origin, radius: radius, direction: direction, distance: distance);
	}

	void OnDrawGizmos ()
	{
		GizmosForPhysics2D.DrawCircleCast (origin: origin, radius: radius, direction: direction, distance: distance);
	}
}
