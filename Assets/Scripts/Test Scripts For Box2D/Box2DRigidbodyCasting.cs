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

public class Box2DRigidbodyCasting : MonoBehaviour
{
	[SerializeField]Rigidbody2D myRigidbody2D;
	[SerializeField]Vector3 direction;
	[SerializeField]float distance = 1;
	// always must be declared table size!
	RaycastHit2D[] hitByRigidbody2DCast = new RaycastHit2D[5];
	[Space (55)][Header ("Results:")]
	[SerializeField]int hitColliderCount;

	void Update ()
	{		
		hitColliderCount = myRigidbody2D.Cast (direction: direction, results: hitByRigidbody2DCast, distance: distance);
	}

	void OnDrawGizmos ()
	{
		GizmosForPhysics2D.DrawRigidbody2D_Cast (rigidbody2D: myRigidbody2D, direction: direction, distance: distance);
	}
}
