using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityBerserkersGizmos;


public class LookAtTestForTransform : MonoBehaviour {
    [Header("Origin of vectors")]
    [SerializeField]
    Transform origin;
    [Header("Quaternions in form of euler angle")]
    [SerializeField]
    Transform target;
    [SerializeField]
    Vector3 worldUp = Vector3.up;

    void Update()
    {
        transform.LookAt(target, worldUp);
    }

    void OnDrawGizmos()
    {
      //  GizmosForTransform.LookAt(origin, target, worldUp);
        GizmosForTransform.LookAt(origin, target.position, worldUp);

    }
}
