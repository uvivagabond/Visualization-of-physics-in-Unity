using System.Collections;
using System.Collections.Generic;
using UnityBerserkersGizmos;
using UnityEngine;

[ExecuteInEditMode]
public class Inverse2 : MonoBehaviour
{
    [Header("Origin of vectors")]
    [SerializeField] Vector3 origin = Vector3.zero;
    [Space(11)]
    [Header("Quaternion in form of euler angle")]
    [SerializeField] Vector3 euler = Vector3.right;



    [Space(22)]
    [Header("Quaternion and it's inverse ")]
    [SerializeField] Quaternion q;
    [SerializeField] Quaternion qInverse;


    void Update()
    {
        q = Quaternion.Euler(euler);
        qInverse = Quaternion.Inverse(rotation: q);
    }

    void OnDrawGizmos()
    {
        Quaternion startQ = Quaternion.Euler(euler);
        GizmosForQuaternion.Inverse(origin, startQ, 6f);
    }
}
