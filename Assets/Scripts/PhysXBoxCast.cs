using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysXBoxCast : MonoBehaviour
{

	[SerializeField]Vector3 center;
	[SerializeField]Vector3 halfExtents;
	[SerializeField]Vector3 direction;
	[SerializeField]Vector3 eulerAngles;
	Quaternion orientation;
	[SerializeField]float maxDistance = 1;

	// hitinfo
	RaycastHit hittedByBox;
	RaycastHit[] hittedByBoxCastTab;

	void Update ()
	{
		bool czyTrafiloWCos = Physics.BoxCast (center: center, halfExtents: halfExtents, direction: direction, hitInfo: out hittedByBox, orientation: orientation, maxDistance: maxDistance);
			
		RaycastHit[] infoOWszystkichTrafionychColliderach;
		
		hittedByBoxCastTab = Physics.BoxCastAll (center: center, halfExtents: halfExtents, direction: direction, orientation: orientation, maxDistance: maxDistance);
		int iloscTrafionychColliderow =	Physics.BoxCastNonAlloc (center: center, halfExtents: halfExtents, direction: direction, results: hittedByBoxCastTab, orientation: orientation, maxDistance: maxDistance);

	}
}
