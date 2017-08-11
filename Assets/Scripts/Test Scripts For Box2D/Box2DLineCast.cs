using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityBerserkersGizmos;

public class Box2DLineCast : MonoBehaviour
{

	[SerializeField]Vector3 start;
	[SerializeField]Vector3 end;

	[SerializeField]float distance = 1;

	RaycastHit2D hitByRayCast;

	[Space (55)][Header ("Results:")]
	[SerializeField]bool isSomethingHit;

	void Update ()
	{
		isSomethingHit = Physics2D.Linecast (start: start, end: end);
	}

	void OnDrawGizmos ()
	{
		GizmosForPhysics2D.DrawLinecast (start: start, end: end);
	}
}
