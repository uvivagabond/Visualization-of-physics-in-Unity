using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class QuaternionExtensions
{

	public static float SignedAngle (this Quaternion q)
	{
		float angle = Mathf.Acos (q.w) * 2f * Mathf.Rad2Deg;
		float signx = q.x != 0 ? Mathf.Sign (q.x) : (q.y != 0 ? Mathf.Sign (q.y) : (q.z != 0 ? Mathf.Sign (q.z) : 1));

		if (signx > 0) {
			angle = (Mathf.Sign (q.w) >= 0) ? angle : angle - 360;
		} else {
			angle = (Mathf.Sign (q.w) < 0) ? 360 - angle : -angle;
		}
		return angle;
	}

	public static float GetWFromAngle (float angle)
	{
		
		float w = Mathf.Sign (angle) > 0 ? Mathf.Cos (angle / 2 * Mathf.Deg2Rad) : Mathf.Cos (angle / 2 * Mathf.Deg2Rad);

		return w;
	}

	//	public static Quaternion Add (this Quaternion first, Quaternion second)
	//	{
	//		return first * second;
	//	}
	//
	//		public static Quaternion Substraction (this Quaternion first, Quaternion second)
	//		{
	//			return first * Quaternion.Inverse (second);
	//		}

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
