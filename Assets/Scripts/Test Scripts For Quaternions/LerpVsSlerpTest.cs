using System.Collections;
using System.Collections.Generic;
using UnityBerserkersGizmos;
using UnityEngine;

[ExecuteInEditMode]
public class LerpVsSlerpTest : MonoBehaviour
{
    [Header("Quaternions in form of euler angle")]
    [SerializeField] Vector3 startRotation = Vector3.right;
    [SerializeField] Vector3 endRotation = Vector3.up;
    [Space(11)]
    [Header("Percentage")]
    [Range(0, 1)] [SerializeField] float t;

    private void Update()
    {
        t += Time.deltaTime * 0.05f;

    }

    void OnDrawGizmos()
    {
        Quaternion startQ = Quaternion.Euler(startRotation);
        Quaternion endQ = Quaternion.Euler(endRotation);


        GizmosForQuaternion.Lerp(Vector3.zero, startQ, endQ, t, BaseVectorDirection.right, 6f);
        GizmosForQuaternion.Slerp(Vector3.zero, startQ, endQ, t, BaseVectorDirection.right, 9f);


    }
}
