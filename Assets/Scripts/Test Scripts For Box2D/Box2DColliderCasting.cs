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
using UnityBerserkersGizmos;

[ExecuteInEditMode]
public class Box2DColliderCasting : MonoBehaviour
{

	[SerializeField]Collider2D myCollider2D;
	[SerializeField]Vector3 direction;
	[SerializeField]float distance = 1;
	[SerializeField]bool ignoreSiblingsColliders = false;
	// remember to always initialize this array!!!
	RaycastHit2D[] hitByCollider2DCast = new RaycastHit2D[11];
	[Space (55)][Header ("Results:")]
	[SerializeField]int hitColliderCount;

	void Update ()
	{		
		hitColliderCount = myCollider2D.Cast (direction: direction, results: hitByCollider2DCast, distance: distance, ignoreSiblingColliders: ignoreSiblingsColliders);
	}

	void OnDrawGizmos ()
	{
		GizmosForPhysics2D.DrawCollider2D_Cast (collider: myCollider2D, direction: direction, distance: distance, ignoreSiblingColliders: ignoreSiblingsColliders);
	}
}
