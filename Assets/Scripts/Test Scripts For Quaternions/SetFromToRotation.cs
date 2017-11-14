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

public class SetFromToRotation : MonoBehaviour
{
	[Header ("Origin of vectors")]
	[SerializeField]Vector3 origin = Vector3.zero;
	[Header ("Vectors between we measure angle(in Quaternion)")]
	[SerializeField]Vector3 start = Vector3.right;
	[SerializeField]Vector3 end = Vector3.up;

	[Space (11)][Header ("Results:")]
	[SerializeField]Vector3 f2d = Vector3.right;
	[SerializeField]Vector3 sf2d = Vector3.up;
	[SerializeField]Vector3 sf3d = Vector3.up;



	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.O)) {
			Quaternion q1 =	Quaternion.FromToRotation (fromDirection: start, toDirection: end);
			transform.rotation.SetFromToRotation (fromDirection: start, toDirection: end);	
			f2d = q1.eulerAngles;
			sf2d = transform.rotation.eulerAngles;

			Quaternion q2 = q1;
			q2.SetFromToRotation (fromDirection: start, toDirection: end);
			sf3d = q2.eulerAngles;
			Debug.Log ("wywołane");

		}
	}

	void OnDrawGizmos ()
	{
		GizmosForQuaternion.SetFromToRotation (origin: origin, fromDirection: start, toDirection: end);		
	}
}
