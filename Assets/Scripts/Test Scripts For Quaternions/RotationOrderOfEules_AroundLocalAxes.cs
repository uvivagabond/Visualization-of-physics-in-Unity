using System.Collections;
using System.Collections.Generic;
using UnityBerserkersGizmos;
using UnityEngine;

[ExecuteInEditMode]
public class RotationOrderOfEules_AroundLocalAxes : MonoBehaviour
{
    [Header("Rotation angles around individual local axes")]
    public float aroundXAxis;
    public float aroundYAxis;
    public float aroundZAxis;


    [Space(33)] public RotationOrder order;

    [Space(33)]
    [Header("What rotations Unity sees")]
    public Vector3 ReadEulerAngles;
    public Vector3 Euler3Axes;

  
    public Vector3 Euler3AxesEuler;
  //  public Vector3 EulerEulerFull;
    [Space(11)]
    public Vector3 Euler3AxesNormalGlobal;
    public Vector3 Euler3AxesNormalGlobalFull;
    public Vector3 Euler3AxesNormalGlobalFullOTher;
    public Vector3 Euler3AxesNormal;
    public Vector3 Euler3AxesNormalAsOne;
    public Vector3 EulerEuler;
    public Vector3 EulerRotate;

    [Space(11)]
    public Vector3 local;
    public Vector3 global;

    [Space(33)]
    public Quaternion fullRotation;
    public Quaternion eulerQ;
    void Update()
    {
        // rotations around local axes
        Quaternion aroundX = Quaternion.AngleAxis(aroundXAxis, transform.right);
        Quaternion aroundY = Quaternion.AngleAxis(aroundYAxis, transform.up);
        Quaternion aroundZ = Quaternion.AngleAxis(aroundZAxis, transform.forward);

    
        transform.rotation = Quaternion.identity;
        Quaternion aaa = Quaternion.Euler(15, 15, 15);

       


        #region Local       
        transform.rotation = aaa;
        transform.rotation *= Quaternion.AngleAxis(aroundYAxis, transform.up);
        transform.rotation *= Quaternion.AngleAxis(aroundXAxis, transform.right);
        transform.rotation *= Quaternion.AngleAxis(aroundZAxis, transform.forward);
        Euler3Axes = transform.rotation.eulerAngles;

  

      
        #endregion



        transform.rotation = aaa;
        transform.rotation *= Quaternion.AngleAxis(aroundZAxis, transform.forward);
        transform.rotation *= Quaternion.AngleAxis(aroundXAxis, transform.right);
        transform.rotation *= Quaternion.AngleAxis(aroundYAxis, transform.up);

        Euler3AxesEuler = transform.rotation.eulerAngles;


        #region LOCAL      

        transform.rotation = aaa;
        transform.rotation = transform.rotation * Quaternion.AngleAxis(aroundYAxis, Vector3.up) * Quaternion.AngleAxis(aroundXAxis, Vector3.right)* Quaternion.AngleAxis(aroundZAxis, Vector3.forward);
   
        Euler3AxesNormalGlobal = transform.rotation.eulerAngles;

        transform.rotation = aaa;

        //base * ZXYGlobal
        Quaternion qqq = Quaternion.AngleAxis(aroundYAxis, Vector3.up) * 
                            Quaternion.AngleAxis(aroundXAxis, Vector3.right) * 
                              Quaternion.AngleAxis(aroundZAxis, Vector3.forward);
        transform.rotation *= qqq;

        Euler3AxesNormalGlobalFull = transform.rotation.eulerAngles;

        

        transform.rotation = aaa;
        transform.rotation = Quaternion.AngleAxis(aroundYAxis, transform.up) * transform.rotation;
        transform.rotation = Quaternion.AngleAxis(aroundXAxis, transform.right) * transform.rotation;
        transform.rotation = Quaternion.AngleAxis(aroundZAxis, transform.forward) * transform.rotation;

        Euler3AxesNormal = transform.rotation.eulerAngles;


        transform.rotation = aaa;

        //  ZXYlocal * base
        // 

        Quaternion full = Quaternion.AngleAxis(aroundYAxis, transform.up) * 
                         Quaternion.AngleAxis(aroundXAxis, transform.right) * 
                            Quaternion.AngleAxis(aroundZAxis, transform.forward) ;

        Quaternion X = Quaternion.AngleAxis(45, transform.right);
        Quaternion Y = Quaternion.AngleAxis(45, transform.up);
        Quaternion Z = Quaternion.AngleAxis(45, transform.forward);
        Quaternion zzzz = Y * X * Z;
     //   transform.rotation = Y * X * Z * transform.rotation;
        transform.rotation = full * transform.rotation ;//    ????? 
        Euler3AxesNormalAsOne = transform.rotation.eulerAngles;

        // base * ZXYGlobal
        transform.rotation = aaa;
        transform.rotation *= Quaternion.Euler(aroundXAxis, aroundYAxis, aroundZAxis);
       // transform.rotation = Quaternion.Euler(aroundXAxis, aroundYAxis, aroundZAxis)* transform.rotation ;

        EulerEuler = transform.rotation.eulerAngles;

        transform.rotation = aaa;
        transform.Rotate(aroundXAxis, aroundYAxis, aroundZAxis, Space.Self);
        EulerRotate = transform.rotation.eulerAngles;


        transform.rotation = aaa;

        //Quaternion a = Quaternion.AngleAxis(aroundZAxis, Vector3.forward) *
        //Quaternion.AngleAxis(aroundXAxis, Vector3.right)  *
        //Quaternion.AngleAxis(aroundYAxis, Vector3.up);

        //Debug.Log(Quaternion.Euler(aroundXAxis, aroundYAxis, aroundZAxis).eulerAngles +" "+ a.eulerAngles);


        //transform.rotation*= a;
        //EulerEulerFull = transform.rotation.eulerAngles;
        #endregion


        Quaternion globall = Quaternion.AngleAxis(aroundYAxis, Vector3.up) *
                         Quaternion.AngleAxis(aroundXAxis, Vector3.right) *
                           Quaternion.AngleAxis(aroundZAxis, Vector3.forward);

        global = globall.eulerAngles;

        Quaternion locall  = Quaternion.AngleAxis(aroundYAxis, transform.forward) * Quaternion.AngleAxis(aroundXAxis, transform.right) * Quaternion.AngleAxis(aroundZAxis, transform.up); 
        local = locall.eulerAngles;

        //transform.rotation = Quaternion.AngleAxis(aroundYAxis, transform.up)* transform.rotation;
        //transform.rotation = Quaternion.AngleAxis(aroundXAxis, transform.right) * transform.rotation;
        //transform.rotation = Quaternion.AngleAxis(aroundZAxis, transform.forward) * transform.rotation;

        //    Quaternion.AngleAxis(aroundZAxis, transform.forward)*
        //    Quaternion.AngleAxis(aroundXAxis, transform.right)*
        //    Quaternion.AngleAxis(aroundYAxis, transform.up);
   
        ReadEulerAngles = fullRotation.eulerAngles;



       

        Quaternion q = Quaternion.Euler(45,45,45);

        // obracamy o jakiś quaternion
        transform.rotation = q * transform.rotation;
        // jeśli chcemy wrócić do rotacji przed obrotem należy wymnożyć przez odwrotność quaternionu
        transform.rotation = Quaternion.Inverse(q) * transform.rotation;



        // wynikiem wymnożenie quaternionu przez jego odwrotność jest quaternion identity
        Quaternion p = q * Quaternion.Inverse(q);

        Debug.Log(p);



        // ReadEulerAngles = transform.rotation.eulerAngles;
        //  eulerQ = Quaternion.Euler(aroundXAxis, aroundYAxis, aroundZAxis);
        //  Euler = eulerQ.eulerAngles;
    }


    void OnDrawGizmos()
    {
        Quaternion aroundX = Quaternion.AngleAxis(aroundXAxis, transform.right);
        Quaternion aroundY = Quaternion.AngleAxis(aroundYAxis, transform.up);
        Quaternion aroundZ = Quaternion.AngleAxis(aroundZAxis, transform.forward);

        GizmosForVector.DrawCoordinateSystem(transform.position, aroundZ * aroundX * aroundY);
        GizmosForVector.DrawCoordinateSystem(transform.position + Vector3.right * 6, fullRotation);
    }
}
