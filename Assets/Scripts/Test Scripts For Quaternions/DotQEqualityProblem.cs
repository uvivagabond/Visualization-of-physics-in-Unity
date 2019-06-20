using System.Collections;
using System.Collections.Generic;
using UnityBerserkersGizmos;
using UnityEngine;

[ExecuteInEditMode]
public class DotQEqualityProblem : MonoBehaviour
{
    [Header("Are rotations equal")]
    [SerializeField] bool AIsEqualB;
    [SerializeField] bool AIsEqualC;

   [Space(33)] [Header("Rotations created with AngleAxis()")]
    [Header("Angle - 30°")]
    [SerializeField] Quaternion a;
    [Header("Angle - 30°+360° around axis")]
    [SerializeField] Quaternion b;
    [Header("Angle - 30°+720° around axis")]
    [SerializeField] Quaternion c;

 

    void Update()
    {

      a = Quaternion.AngleAxis(90f, Vector3.forward);
      b = Quaternion.AngleAxis(90f + 360f, Vector3.forward);
      c = Quaternion.AngleAxis(90f + 720f, Vector3.forward);

        AIsEqualB = a == b; // return false
        AIsEqualC = a == c; // return true
    }

 
}
