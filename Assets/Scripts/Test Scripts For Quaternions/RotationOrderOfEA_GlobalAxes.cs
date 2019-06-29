using UnityBerserkersGizmos;
using UnityEngine;

[ExecuteInEditMode]
public class RotationOrderOfEA_GlobalAxes: MonoBehaviour
{
    [Header("Rotation angles around individual global axes")]
   public float aroundXAxis;
   public float aroundYAxis;
   public float aroundZAxis;

 //   public Vector3 eulerAngles;
 
  
    [Space(33)] public RotationOrder order;

    [Space(33)]
    [Header("What rotations Unity sees")]
    public Vector3 ReadEulerAngles;

    [Space(33)]
    public Quaternion fullRotation;
    void Update()
    {
        // rotations around global axes
        Quaternion aroundX = Quaternion.AngleAxis(aroundXAxis,Vector3.right);
        Quaternion aroundY = Quaternion.AngleAxis(aroundYAxis, Vector3.up);
        Quaternion aroundZ = Quaternion.AngleAxis(aroundZAxis, Vector3.forward);

        switch (order)
        {   
            //order for global axes
            case RotationOrder.zxy_OrderForGlobalAxes:
                fullRotation = aroundY * aroundX * aroundZ;
                break;
            case RotationOrder.zyx:
                fullRotation = aroundX * aroundY * aroundZ;
                break;
            case RotationOrder.xyz:
                fullRotation = aroundZ * aroundY * aroundX;
                break;
            case RotationOrder.xzy:
                fullRotation = aroundY * aroundZ* aroundX;
                break;
            case RotationOrder.yxz:
                fullRotation = aroundZ * aroundX * aroundY;
                break;
            case RotationOrder.yzx:
                fullRotation = aroundX * aroundZ* aroundY;
                break;
            default:
                break;
        }
      
        ReadEulerAngles = fullRotation.eulerAngles;
    }


    void OnDrawGizmos()
    {
        Quaternion aroundX = Quaternion.AngleAxis(aroundXAxis, Vector3.right);
        Quaternion aroundY = Quaternion.AngleAxis(aroundYAxis, Vector3.up);
        Quaternion aroundZ = Quaternion.AngleAxis(aroundZAxis, Vector3.forward);
        GizmosForVector.DrawCoordinateSystem(transform.position, aroundY * aroundX * aroundZ);//
        GizmosForVector.DrawCoordinateSystem(transform.position + Vector3.right * 6, fullRotation);
    }
}

public enum RotationOrder
{
    zxy_OrderForGlobalAxes, //order for global axes
    zyx,
    xyz,
    xzy,
    yxz, 
    yzx
}
