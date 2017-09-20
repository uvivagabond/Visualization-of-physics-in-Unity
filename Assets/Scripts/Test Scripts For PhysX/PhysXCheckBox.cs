using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityBerserkersGizmos;

[ExecuteInEditMode]
public class PhysXCheckBox : MonoBehaviour
{
	[SerializeField]Vector3 center;
	[SerializeField]Vector3 halfExtents;
	[SerializeField]Vector3 eulerAngles;
	Quaternion orientation;

	[Space (55)][Header ("Results:")]
	[SerializeField]	bool isBoxOverlapColliders;

	void Update ()
	{
		orientation = Quaternion.Euler (eulerAngles);
		isBoxOverlapColliders = Physics.CheckBox (center: center, halfExtents: halfExtents, orientation: orientation);			
	}

	void OnDrawGizmos ()
	{
//		GizmosForPhysics3D.DrawCheckBox (isOverlaped: isBoxOverlapColliders, center: center, halfExtents: halfExtents, orientation: orientation);
		GizmosForPhysics3D.DrawCheckBox (center: center, halfExtents: halfExtents, orientation: orientation);
	}
}
