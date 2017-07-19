using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysXCheckBox : MonoBehaviour
{
	[SerializeField]Vector3 center;
	[SerializeField]Vector3 halfExtents;
	[SerializeField]Vector3 eulerAngles;
	Quaternion orientation;
	[Space (55)][Header ("Wyniki:")]

	[SerializeField]	bool czySzescianNachodziNaJakiesCollidery;
	[SerializeField]	Collider[] overlapedColliders;

	void Update ()
	{
		orientation = Quaternion.Euler (eulerAngles);

		Collider[] collideryNaKtoreNachodziSzescian;
		
		overlapedColliders = Physics.OverlapBox (center: center, halfExtents: halfExtents, orientation: orientation);
			
	}

	void OnDrawGizmos ()
	{
		GizmosForPhysics3D.DrawOverlapBox (overlapedColliders: overlapedColliders, center: center, halfExtents: halfExtents, orientation: orientation);
		GizmosForPhysics3D.DrawCheckBox (isOverlaped: czySzescianNachodziNaJakiesCollidery, center: center, halfExtents: halfExtents, orientation: orientation);

	}
}
