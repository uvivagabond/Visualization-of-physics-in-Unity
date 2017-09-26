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
public class Box2DCollider2DOverlapCollider : MonoBehaviour
{

	[SerializeField]Collider2D collider2D;
	[SerializeField]ContactFilter2D cf = new ContactFilter2D ();

	[Space (22)][Header ("Results:")]
	[SerializeField]int overlappedCollidersCount;
	[SerializeField]Collider2D[] results = new Collider2D[3];

	void Update ()
	{		
		collider2D = GetComponent<Collider2D> ();
//		Collider2D[] results = new Collider2D[2];
		overlappedCollidersCount = collider2D.OverlapCollider (contactFilter: cf.NoFilter (), results: results);

	}

	void OnDrawGizmos ()
	{
		GizmosForPhysics2D.DrawCollider2D_OverlapCollider (collider: collider2D, contactFilter: cf);

	}
}
