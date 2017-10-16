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

public class VizualizeRotateTowardsTest : MonoBehaviour
{
	[Header ("Press Play and will start to rotate!")]	[Space (22)]

	[Header ("Origin and end of rotation:")]
	[SerializeField]Vector3 origin;
	[SerializeField]Vector3 endDirection = Vector3.zero;
	[Tooltip ("Velocity in degrees/s")][SerializeField]float maxDegreesVelocity = 6;
	[Tooltip ("Constraint for lenght of vector")][SerializeField]float maxMagnitudeDelta = 3;


	void Update ()
	{
		float maxAngleInDegrees = maxDegreesVelocity * Mathf.Deg2Rad * Time.deltaTime;
		// if you want to see rotation for other transform direction change CURRENT value here and in VisualizeRotateTowards
		Vector3 direction = Vector3.RotateTowards (current: transform.up, target: endDirection, maxRadiansDelta: maxAngleInDegrees, maxMagnitudeDelta: maxMagnitudeDelta);
		transform.up = direction;
	}

	void OnDrawGizmos ()
	{ 		
		GizmosForVector.VisualizeRotateTowards (origin: origin, current: transform.up, target: endDirection);	
	}
}
