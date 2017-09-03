using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box2DRaycastVersions : MonoBehaviour
{
	[SerializeField]Vector3 origin;
	[SerializeField]Vector3 direction;

	[SerializeField]float distance = 1;


	void Update ()
	{

		#region Filtering colliders
		RaycastHit2D hitInfo = Physics2D.Raycast (origin: origin, direction: direction, distance: distance,

			                       layerMask: Physics2D.DefaultRaycastLayers, minDepth: -Mathf.Infinity, maxDepth: Mathf.Infinity);


		ContactFilter2D cf = new ContactFilter2D ();
		RaycastHit2D[] hitInfos = new RaycastHit2D[3];

		int hitCollidersCount = Physics2D.Raycast (origin: origin, direction: direction, contactFilter: cf, results: hitInfos);


		RaycastHit2D[] hitInfos2 = new RaycastHit2D[3];

		int hitCollidersCount2 = Physics2D.RaycastNonAlloc (origin: origin, direction: direction, results: hitInfos2, distance: distance,
			                         layerMask: Physics2D.DefaultRaycastLayers, minDepth: -Mathf.Infinity, maxDepth: Mathf.Infinity);
		#endregion


		#region Number of returned elements
//		RaycastHit2D hitInfo = Physics2D.Raycast (origin: origin, direction: direction, distance: distance);
//
//		bool isSomethingHit = Physics2D.Raycast (origin: origin, direction: direction, distance: distance);
//
//		RaycastHit2D[] hitInfos = Physics2D.RaycastAll (origin: origin, direction: direction, distance: distance);
//
//		RaycastHit2D[] hitInfos2 = new RaycastHit2D[2];
//		int hitCollidersCount = Physics2D.RaycastNonAlloc (origin: origin, direction: direction, results: hitInfos2, distance: distance);
		#endregion

	}
}
