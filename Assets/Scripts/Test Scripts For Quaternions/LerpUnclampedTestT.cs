﻿using System.Collections;
using System.Collections.Generic;
using UnityBerserkersGizmos;
using UnityEngine;

[ExecuteInEditMode]
public class LerpUnclampedTestT : MonoBehaviour
{
    [Header("Quaternions in form of euler angle")]
    [SerializeField] Vector3 start = Vector3.right;
    [SerializeField] Vector3 end = Vector3.up;
    [Space(11)]
    [Header("Percentage")]
    [Range(-5, 5)] [SerializeField] float t;



    void Update()
    {
        Quaternion startRotation = Quaternion.Euler(start);
        Quaternion endRotation = Quaternion.Euler(end);

        transform.rotation = Quaternion.LerpUnclamped(a: startRotation, b: endRotation, t: t);
    }

    void OnDrawGizmos()
    {
        Quaternion startQ = Quaternion.Euler(start);
        Quaternion endQ = Quaternion.Euler(end);


        GizmosForQuaternion.LerpUnclamped(Vector3.zero, startQ, endQ, t, BaseVectorDirection.right, 6f);
    }
}
