using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityBerserkersGizmos;

[ExecuteInEditMode]
public class Inverse : MonoBehaviour
{
	[Header ("Origin of vectors")]
	[SerializeField]Vector3 origin = Vector3.zero;
	[Space (11)][Header ("Quaternion in angle-axis representation")]

   
    [SerializeField] Vector3 axis;
    [SerializeField] float angle;


    [Space(22)]
    [Header("Quaternion and it's inverse ")]
    [SerializeField] Quaternion q;
    [SerializeField] Quaternion qInverse;

       
    void Update ()
	{
        q = Quaternion.AngleAxis(angle,axis);
        qInverse = Quaternion.Inverse (rotation:q);	
	}

	
    void OnDrawGizmos()
    {
        GizmosForQuaternion.ToAngleAxis(origin, q);
        GizmosForQuaternion.ToAngleAxis(origin + Vector3.right * 9, qInverse);
    }
}
