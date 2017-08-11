using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityBerserkersGizmos;

public class Box2DOverlapBOx : MonoBehaviour
{
	
	[SerializeField]Vector3 point;
	[SerializeField]Vector3 size;
	[SerializeField]float angle;
	RaycastHit2D hitByRayCast;

	[Space (55)][Header ("Results:")]
	[SerializeField]bool isSomethingHit;

	void Update ()
	{		
		isSomethingHit = Physics2D.OverlapBox (point: point, size: size, angle: angle);
	}

	void OnDrawGizmos ()
	{
		GizmosForPhysics2D.DrawOverlapBox (point: point, size: size, angle: angle);
	}
}
