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

public class Box2DOverlapBOx : MonoBehaviour
{
	
	[SerializeField]Vector3 point;
	[SerializeField]Vector3 size;
	[SerializeField]float angle;
	RaycastHit2D hitByRayCast;
	[SerializeField]ContactFilter2D cf = new ContactFilter2D ();

	[Space (55)][Header ("Results:")]
	[SerializeField]bool isSomethingHit;
	[SerializeField]int overlappedCollidersCount;
	[SerializeField]Collider2D[] results = new Collider2D[10];

	void Update ()
	{		
		isSomethingHit = Physics2D.OverlapBox (point: point, size: size, angle: angle);
		overlappedCollidersCount = Physics2D.OverlapBox (point, size, angle, cf, results);
	}

	void OnDrawGizmos ()
	{
//		GizmosForPhysics2D.DrawOverlapBox (point: point, size: size, angle: angle);
		GizmosForPhysics2D.DrawOverlapBox (point: point, size: size, angle: angle, contactFilter: cf);
	}
}
