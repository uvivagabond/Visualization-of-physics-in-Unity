using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityBerserkersGizmos;

[ExecuteInEditMode]
public class TestXYZParamaters : MonoBehaviour
{
	[Space (22)]	
	[Header ("Values of individual components")]
	[SerializeField] [Range (-1, 1)] float x;
	[SerializeField] [Range (-1, 1)] float y;
	[SerializeField] [Range (-1, 1)] float z;
	[SerializeField] [Range (-1, 1)] float w;

    [Space(22)]
    [Header("RESULTS:")]
    [Header ("Quaternion, which was based on the above parameters")]
	[Space (22)]
	[SerializeField] Quaternion exampleQuaternion;
	[Space (22)]
	[Header ("Vector consisting of parameters, x, y, z and then normalized")]
	[SerializeField] Vector3 xyzNormalized;

	void Update ()
	{
		exampleQuaternion = new Quaternion (x: x,
			y: y,
			z: z,
			w: w);

     //   exampleQuaternion = exampleQuaternion.normalized;
        exampleQuaternion.Normalize();

        x = exampleQuaternion.x;
		y = exampleQuaternion.y;
		z = exampleQuaternion.z;
		w = exampleQuaternion.w;

        xyzNormalized = new Vector3(exampleQuaternion.x, exampleQuaternion.y, exampleQuaternion.z).normalized.Round(2);


    }

    void OnDrawGizmos ()
	{
		GizmosForQuaternion.ToAngleAxis (transform.position, exampleQuaternion, BaseVectorDirection.right);
	}

}
