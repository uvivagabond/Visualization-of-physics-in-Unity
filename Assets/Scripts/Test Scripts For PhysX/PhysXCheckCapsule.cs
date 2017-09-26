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
public class PhysXCheckCapsule : MonoBehaviour
{

	[SerializeField]Vector3 point0;
	[SerializeField]Vector3 point1;
	[SerializeField]float radius = 1;
	[SerializeField]float maxDistance;
	
	[Space (55)][Header ("Results:")]
	[SerializeField]	bool isCapsuleOverlapSomething;


	void Update ()
	{
		isCapsuleOverlapSomething =	Physics.CheckCapsule (start: point0, end: point1, radius: radius);
	}

	void OnDrawGizmos ()
	{
//		GizmosForPhysics3D.DrawCheckCapsule (isOverlaped: isCapsuleOverlapSomething, start: point0, end: point1, radius: radius);
		GizmosForPhysics3D.DrawCheckCapsule (start: point0, end: point1, radius: radius);

	}
}
