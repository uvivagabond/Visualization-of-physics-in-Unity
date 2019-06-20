using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityBerserkersGizmos;

[ExecuteInEditMode]
public class TestWParamater : MonoBehaviour
{
	[SerializeField] BaseVectorDirection builtinDirection;
	[Space (22)]	
	[SerializeField]Vector3 axis;
    [SerializeField] float angle;
	[Header ("Values of individual components")]
	[SerializeField] [Range (-1, 1)] float x;
	[SerializeField] [Range (-1, 1)] float y;
	[SerializeField] [Range (-1, 1)] float z;
	[SerializeField] [Range (-1, 1)] float w;

	[Header ("Quaternion, which was based on the above parameters")]
	[Space (22)]


	[SerializeField] Quaternion exampleQuaternion;

    void Start ()
	{
	
	}

	void Update ()
	{
        exampleQuaternion = Quaternion.AngleAxis(angle, axis);
        exampleQuaternion = RoundQuaternion(exampleQuaternion);
        x = exampleQuaternion.x;
        y = exampleQuaternion.y;
        z = exampleQuaternion.z;
        w = exampleQuaternion.w;     
        // transform.Rotate(axis, 30 * Time.deltaTime);
    }

	void OnDrawGizmos ()
	{
        // GizmosForQuaternion.FromToRotation(transform.position, Vector3.right, transform.right);
        GizmosForQuaternion.ToAngleAxis(transform.position, exampleQuaternion, BaseVectorDirection.right);
        float halfAxisLenght = 2;
        UnityEditor.Handles.color  = new Color32(162, 0, 255, 255);
        Gizmos.color   = new Color32(162, 0, 255, 255);
      //  GizmosForVector.DrawVector(transform.position - axis.normalized * halfAxisLenght,
      //              axis.normalized, halfAxisLenght * 2, Gizmos.color);

    }



	Quaternion RoundQuaternion (Quaternion q)
	{
		q.x = (float)System.Math.Round (q.x, 2);
		q.y = (float)System.Math.Round (q.y, 2);
		q.z = (float)System.Math.Round (q.z, 2);
		q.w = (float)System.Math.Round (q.w, 2);
		return q;
	}
}



