using System.Collections;
using System.Collections.Generic;
using UnityBerserkersGizmos;
using UnityEngine;

public class LerpUnclampedVsSlerpUnclamped : MonoBehaviour
{
    [Header("Quaternions in form of euler angle")]
    [SerializeField] Vector3 startRotation = Vector3.right;
    [SerializeField] Vector3 endRotation = Vector3.up;
    [Space(11)]
    [Header("Percentage")]
    [Range(0, 20 )] [SerializeField] float t;

    private void Start()
    {
        t = 0;
    }
    private void Update()
    {
        t += Time.deltaTime * 0.5f;

    }

    void OnDrawGizmos()
    {
        Quaternion startQ = Quaternion.Euler(startRotation);
        Quaternion endQ = Quaternion.Euler(endRotation);


        GizmosForQuaternion.LerpUnclamped(Vector3.zero, startQ, endQ, t, BaseVectorDirection.right, 6f);
        GizmosForQuaternion.SlerpUnclamped(Vector3.zero, startQ, endQ, t, BaseVectorDirection.right, 9f);

        //  GizmosForQuaternion.DrawQuaternion(origin, Quaternion.Lerp(startQ, endQ, t),Color.green);

    }
}
