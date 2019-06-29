using System.Collections;
using System.Collections.Generic;
using UnityBerserkersGizmos;
using UnityEngine;

[ExecuteInEditMode]
public class EulerTest : MonoBehaviour
{
  public  Vector3 eulerAngles;

    [Space(33)]
    [Header("Created quaternion ")]
    public  Quaternion quaternionCreatedFromEulerAngles=Quaternion.identity;

    void Update()
    {
        quaternionCreatedFromEulerAngles = Quaternion.Euler(euler: eulerAngles);
    }

    void OnDrawGizmos()
    {
        GizmosForQuaternion.ToAngleAxis(transform.position, quaternionCreatedFromEulerAngles, BaseVectorDirection.right);     
    }
}
