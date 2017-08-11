using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityBerserkersGizmos;

public class SmoothDamp : MonoBehaviour
{
	[SerializeField] Vector3 targetPosition;
	[SerializeField] float smoothTime = 0.3F;
	[SerializeField] Vector3 velocity = Vector3.zero;
	[SerializeField] float maxSpeed;
	[SerializeField] float deltaTime;

	void Update ()
	{
		transform.position = Vector3.SmoothDamp (current: transform.position, target: targetPosition, currentVelocity: ref velocity, 
			smoothTime: smoothTime, maxSpeed: maxSpeed, deltaTime: deltaTime);
	}

	void OnDrawGizmos ()
	{
		GizmosForVector.VisualizeSmoothDampPath (current: transform.position, target: targetPosition, currentVelocity: velocity,
			smoothTime: smoothTime, maxSpeed: maxSpeed);
	}
}
