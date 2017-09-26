/* MIT License
Copyright (c) 2017 Uvi Vagabond, UnityBerserkers
Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:
The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.
THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/
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
