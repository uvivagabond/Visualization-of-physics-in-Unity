using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityBerserkersGizmos;

public class TRotate : MonoBehaviour {

   
    [Header ("Rotation in form of euler angle")]
    [SerializeField]Vector3 euler = Vector3.right;
   
   
    [Space(22)]
    [SerializeField]
    Vector3 axis= Vector3.right;
    [SerializeField]
    float angle;
    [SerializeField]  [Space(22)]
    Space space;  
    
    void Update()
    {    
        // transform.Rotate(euler.x * Time.deltaTime, euler.y * Time.deltaTime, euler.z * Time.deltaTime, space);
        //  transform.Rotate(euler * Time.deltaTime, space);
            transform.Rotate(axis,angle* Time.deltaTime, space);
          }
  
    void OnDrawGizmos()
    {
            GizmosForTransform.Rotate(transform, axis, angle*Time.deltaTime, space, 3);
         //   GizmosForTransform.Rotate(transform, euler, space, 3);
    }
}
