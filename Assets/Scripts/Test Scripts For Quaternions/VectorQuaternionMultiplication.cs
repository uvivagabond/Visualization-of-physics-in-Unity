using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[ExecuteInEditMode]
public class VectorQuaternionMultiplication : MonoBehaviour
{
  public  Vector3 eulerAngles;
  public  Vector3 end1;
  public  Vector3 end2;
  
    void Update()
    {
        Quaternion rotation = Quaternion.Euler(eulerAngles);
        end1 = rotation * Vector3.right;

        // Prep for calculations
        Quaternion positionQuaternion = new Quaternion(
            1, 0, 0, 0);
        Quaternion inverseRotation = Quaternion.Inverse(rotation);

        // Calculate new position
        Quaternion newPositionQuat = rotation * positionQuaternion * inverseRotation;

        // Store result
       end2 = new Vector3(
            newPositionQuat.x, newPositionQuat.y, newPositionQuat.z);
    }
}
