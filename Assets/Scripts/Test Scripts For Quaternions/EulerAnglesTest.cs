using System.Collections;
using System.Collections.Generic;
using UnityBerserkersGizmos;
using UnityEngine;

[ExecuteInEditMode]
public class EulerAnglesTest : MonoBehaviour
{
    public Vector3 eulerAngles;
    [Space(33)][Header("Created quaternion ")]
    public Quaternion quaternionCreatedFromEulerAngles;
    [Space(33)]
    [Header("Read orientation ")]
    public Vector3 readOrientation;


    void Update()
    {
        // we modify the orientation of this quaternion
        quaternionCreatedFromEulerAngles.eulerAngles = eulerAngles;

        readOrientation = quaternionCreatedFromEulerAngles.eulerAngles;

    
    }

    void OnDrawGizmos()
    {
        GizmosForQuaternion.ToAngleAxis(transform.position, quaternionCreatedFromEulerAngles, BaseVectorDirection.right);
    }
}
