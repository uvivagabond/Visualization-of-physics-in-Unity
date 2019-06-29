using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityBerserkersGizmos;

[ExecuteInEditMode]
public class LookRotationTest : MonoBehaviour
{
	[Header ("Directions")]
	[SerializeField]Vector3 forward = Vector3.right;
	[SerializeField]Vector3 upwards = Vector3.up;

    [Space(11)]
    [Header("Results:")]
    [SerializeField] Quaternion q;
    [SerializeField] Vector3 qAsEulerAngles = Vector3.right;


    [Space(55)]
    [Header("Visualization parameters")]
    [Header("Origin of vectors")]
    [SerializeField] Vector3 origin = Vector3.zero;

    void Update ()
	{
        q = Quaternion.LookRotation(forward: forward, upwards: upwards);//, upwards: upwards
        transform.rotation = q;


        #region More readable vector values       
        qAsEulerAngles = q.eulerAngles;
        forward.Normalize();
        forward= forward.Round(2);
        upwards.Normalize();
        upwards = upwards.Round(2);
        #endregion
    }

    void OnDrawGizmos ()
	{
		GizmosForQuaternion.LookRotation (origin, forward, upwards);
      //  GizmosForQuaternion.Angle(origin, Quaternion.identity, q, BaseVectorDirection.forward);
    }
}
