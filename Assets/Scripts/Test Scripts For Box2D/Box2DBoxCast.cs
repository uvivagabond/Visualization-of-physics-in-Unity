using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box2DBoxCast : MonoBehaviour
{
	[SerializeField]Vector3 origin;
	[SerializeField]Vector3 size;
	[SerializeField]Vector3 direction;
	[SerializeField]float angle = 0;
	[SerializeField]float distance = 1;

	RaycastHit2D hitByRayCast;

	[Space (55)][Header ("Results:")]
	[SerializeField]bool isSomethingHit;

	void Update ()
	{		
		isSomethingHit = Physics2D.BoxCast (origin: origin, size: size, angle: angle, direction: direction, distance: distance);
	}

	void OnDrawGizmos ()
	{
		GizmosForPhysics2D.DrawBoxCast (origin: origin, size: size, angle: angle, direction: direction, distance: distance);
	}
}
