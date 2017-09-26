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
public class PhysXOverlapBox : MonoBehaviour
{
	[SerializeField]Vector3 center;
	[SerializeField]Vector3 halfExtents;
	[SerializeField]Vector3 eulerAngles;
	Quaternion orientation;
	[Space (55)][Header ("Results:")]
	[SerializeField]	Collider[] overlapedColliders;

	void Update ()
	{
		orientation = Quaternion.Euler (eulerAngles);
		overlapedColliders = Physics.OverlapBox (center: center, halfExtents: halfExtents, orientation: orientation);			
	}

	void OnDrawGizmos ()
	{
//		GizmosForPhysics3D.DrawOverlapBox (overlapedColliders: overlapedColliders, center: center, halfExtents: halfExtents, orientation: orientation);
		GizmosForPhysics3D.DrawOverlapBox (center: center, halfExtents: halfExtents, orientation: orientation);

	}
}
