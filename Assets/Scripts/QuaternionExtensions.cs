using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class QuaternionExtensions
{
	public static float SignedAngle (this Quaternion q)
	{
		float angle;
		Vector3 axis;
		q.ToAngleAxis (out angle, out axis);
		Vector3 right = Vector3.right;
		Vector3 quat = q * Vector3.right;
		Vector3.OrthoNormalize (ref axis, ref right);
		float dot =	Vector3.Dot (Vector3.Cross (right, quat), axis);
		float sign = Mathf.Sign (dot);
		return Mathf.Sign (dot) > 0 ? angle : angle - 360;
	}

	public static float GetWFromAngle (float angle)
	{
		float sign = Mathf.Sign (Mathf.Cos (angle * 0.5f * Mathf.Deg2Rad));
		return Mathf.Abs (Mathf.Cos (angle / 2 * Mathf.Deg2Rad)) * sign;
	}

	public static Quaternion Add (this Quaternion first, Quaternion second)
	{
		return first * second;
	}

	public static Quaternion Substract (this Quaternion first, Quaternion second)
	{
		return first * Quaternion.Inverse (second);
	}

	/// <summary>
	/// Return axis for difference rotation between start and end rotation
	/// </summary>
	/// <returns>The angle axis custom.</returns>
	/// <param name="endRotation">Second rotation.</param>
	/// <param name="angle">Angle between rotations.</param>
	/// <param name="axis">Rotatio axis.</param>
	//	public static void ToAngleAxisCustom (this Quaternion startRotation, Quaternion endRotation, out float angle, out Vector3 axis)
	//	{
	//		Quaternion sub = startRotation.Substraction (endRotation);
	//		sub.ToAngleAxis (out angle, out axis);
	//	}
}
