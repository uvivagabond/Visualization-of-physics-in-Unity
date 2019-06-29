using UnityBerserkersGizmos;
using UnityEngine;

[ExecuteInEditMode]
public class QuaternionMultiplication : MonoBehaviour
{
    public bool AreEqual;
    public Quaternion pqWithOperator;
    public Quaternion pqWithMath;

    void Update()
    {
        Quaternion p = Quaternion.Euler(22, 0, 0);
        Quaternion q = Quaternion.Euler(11, 22, 33);


        Vector3 qAxis = new Vector3(q.x, q.y, q.z);
        Vector3 pAxis = new Vector3(p.x, p.y, p.z);

        float qw = q.w;
        float pw = p.w;

        Vector3 pqAxis = qw * pAxis + pw * qAxis + Vector3.Cross(qAxis, pAxis);
        float pqw = qw * pw - Vector3.Dot(qAxis, pAxis);

        Quaternion pq = new Quaternion(pqAxis.x, pqAxis.y, pqAxis.z, pqw);

        this.pqWithOperator = q * p;
        pqWithMath = pq;
        AreEqual = pq == q * p; 
    }
 
}
