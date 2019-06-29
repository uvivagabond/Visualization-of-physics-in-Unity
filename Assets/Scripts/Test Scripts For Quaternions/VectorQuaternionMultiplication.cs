using System.Collections;
using System.Collections.Generic;
using UnityBerserkersGizmos;
using UnityEngine;


[ExecuteInEditMode]
public class VectorQuaternionMultiplication : MonoBehaviour
{
    [Header("Quaternions in angle-axis representation")]
    [SerializeField] Vector3 axis;
    [SerializeField] float angle;

    void Update()
    {
        // the vector that we want to rotate
        Vector3 vector = Vector3.right;

        // rotation about which we want to rotate the vector
        Quaternion q = Quaternion.AngleAxis(angle, axis);
        // inverse q, needed for further calculations
        Quaternion qInverse = Quaternion.Inverse(q);

        // create "pure quaternion / vector quaternion" from the vector so that we can multiply it with quaternions
        // "pure quaternion" is that which the real part is equal to 0, in this case the parameter w = 0
        Quaternion vectorAsPureQuaternion = new Quaternion(vector.x, vector.y, vector.z, 0);

        // we multiply in this order quaternion and get a new quaternion containing information about the inverted vector       
        Quaternion rotatedVectorAsQuaternion = q * vectorAsPureQuaternion * qInverse;

        // we extract the x, y, z of quaternion and create with them the inverted vector
        Vector3 rotatedVector = new Vector3(rotatedVectorAsQuaternion.x, rotatedVectorAsQuaternion.y, rotatedVectorAsQuaternion.z);

    }

    void OnDrawGizmos()
    {        
            GizmosForQuaternion.AngleAxis(Vector3.zero, angle, axis, Quaternion.identity,BaseVectorDirection.right );      
    }
}
