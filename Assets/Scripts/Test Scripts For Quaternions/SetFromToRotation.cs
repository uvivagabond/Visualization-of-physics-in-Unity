using UnityBerserkersGizmos;
using UnityEngine;

[ExecuteInEditMode]
public class SetFromToRotation : MonoBehaviour
{
    [Header("Vectors between we measure angle(in Quaternion)")]
    [SerializeField] Vector3 startDirection = Vector3.right;
    [SerializeField] Vector3 endDirection = Vector3.up;



    [Space(22)]
    [Header("Results:")]
    [SerializeField] Quaternion rotation;

    [Space(55)]
    [Header("Visualization parameters")]
    [Header("Origin of vectors")]
    [SerializeField] Vector3 origin = Vector3.zero;

    void Update()
    {
        rotation = Quaternion.FromToRotation(fromDirection: startDirection, toDirection: endDirection);
    }

    void OnDrawGizmos()
    {
        GizmosForQuaternion.SetFromToRotation(origin: origin, fromDirection: startDirection, toDirection: endDirection);
    }
}
