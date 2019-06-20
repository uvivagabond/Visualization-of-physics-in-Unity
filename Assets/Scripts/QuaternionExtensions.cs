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

    public static void SignedToAngleAxis(this Quaternion q, out float  angle, out Vector3 axis)
    {
        float tempAngle=0;
        q.ToAngleAxis(out tempAngle, out axis);
        Vector3 right = Vector3.right;
        Vector3 quat = q * Vector3.right;
        Vector3.OrthoNormalize(ref axis, ref right);
        float dot = Vector3.Dot(Vector3.Cross(right, quat), axis);
        float sign = Mathf.Sign(dot);
        angle= Mathf.Sign(dot) > 0 ? tempAngle : tempAngle - 360;
    }


    public static float GetWFromAngle (float angle)
	{
		return Mathf.Cos (angle * 0.5f * Mathf.Deg2Rad);
	}

	public static Vector3 GetAxis (this Quaternion q)
	{
		return new Vector3 (q.x, q.y, q.z).normalized;
	}


}
