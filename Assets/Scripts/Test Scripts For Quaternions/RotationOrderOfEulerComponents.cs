using UnityBerserkersGizmos;
using UnityEngine;

[ExecuteInEditMode]
public class RotationOrderOfEulerComponents : MonoBehaviour
{
    [Header("Rotation angles around individual axes")]
   public float aroundXAxis;
   public float aroundYAxis;
   public float aroundZAxis;

 //   public Vector3 eulerAngles;
 
  
    [Space(33)] public RotationOrder order;

    [Space(33)]
    [Header("What rotations Unity sees")]
    public Vector3 ReadEulerAngles;
    public Vector3 calculus;
    public Vector3 calculus2;

    [Space(33)]
    public Quaternion fullRotation;
    void Update()
    {
        Quaternion aroundX = Quaternion.AngleAxis(aroundXAxis,Vector3.right);
        Quaternion aroundY = Quaternion.AngleAxis(aroundYAxis, Vector3.up);
        Quaternion aroundZ = Quaternion.AngleAxis(aroundZAxis, Vector3.forward);
        Quaternion aroundX1 = Quaternion.AngleAxis(aroundXAxis, transform.right);
        Quaternion aroundY1 = Quaternion.AngleAxis(aroundYAxis, transform.up);
        Quaternion aroundZ1 = Quaternion.AngleAxis(aroundZAxis, transform.forward);
        switch (order)
        {
            case RotationOrder.zxy_Normal:
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
        // transform.rotation = Quaternion.Euler(aroundXAxis, aroundYAxis, aroundZAxis);
        transform.rotation = Quaternion.identity;
        transform.rotation = aroundX;
        //Debug.Log(aroundY * aroundX * aroundZ +" "+ aroundZ1 * aroundX1 * aroundY1);
        //transform.rotation *= aroundY1;
        //transform.rotation *= aroundX1;
        //transform.rotation *= aroundZ1;
        if (Input.GetMouseButtonDown(0))
        {
          //  transform.rotation = transform.rotation* fullRotation;
            transform.rotation = Quaternion.Inverse(transform.rotation) * fullRotation * transform.rotation;

            Debug.Log(transform.rotation.eulerAngles);

        }
        //transform.rotation = Quaternion.Inverse(transform.rotation) * fullRotation * transform.rotation;

        //Quaternion.Inverse(aroundX) * 

        //  transform.rotation *= Quaternion.Inverse(transform.rotation) * aroundY * transform.rotation;
        // transform.rotation *= aroundY * Quaternion.Inverse(transform.rotation) * transform.rotation;
        transform.rotation = (Quaternion.Inverse(transform.rotation) * transform.rotation) * Quaternion.Inverse(aroundY);// * aroundY * transform.rotation;


        calculus = (transform.rotation).eulerAngles;
        Debug.Log(transform.rotation.eulerAngles);
        //   transform.rotation = fullRotation * transform.rotation;
        // transform.rotation *= fullRotation;
        //transform.rotation *= aroundY;
        //transform.rotation *= aroundX;
        //transform.rotation *= aroundZ;
        ReadEulerAngles = fullRotation.eulerAngles;
        
    }


    void OnDrawGizmos()
    {
        Quaternion aroundX = Quaternion.AngleAxis(aroundXAxis, Vector3.right);
        Quaternion aroundY = Quaternion.AngleAxis(aroundYAxis, Vector3.up);
        Quaternion aroundZ = Quaternion.AngleAxis(aroundZAxis, Vector3.forward);
        GizmosForVector.DrawCoordinateSystem(transform.position, transform.rotation);//
        GizmosForVector.DrawCoordinateSystem(transform.position + Vector3.right * 6, fullRotation);
    }
}

public enum RotationOrder
{
    zxy_Normal,
    zyx,
    xyz,
    xzy,
    yxz,
    yzx
}
