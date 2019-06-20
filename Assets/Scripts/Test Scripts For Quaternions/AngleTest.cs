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
public class AngleTest : MonoBehaviour
{	
	[Header ("Quaternions in form of euler angle")]
	[SerializeField]Vector3 eulerAnglesA = Vector3.right;
	[SerializeField]Vector3 eulerAnglesB = Vector3.up;

    [Space(11)]
    [Header("Results:")]
    [SerializeField] float angle;

    [Space(22)]
    [Header("Results from extebtion methods:")]
    [SerializeField] float signedAngle;
    [SerializeField] float angleOfB;

    [Space(55)]
    [Header("Visualization parameters")]
    [Header("Origin of vectors")]
    [SerializeField] Vector3 origin = Vector3.zero;
   [Header ("Which version of method")]
	[SerializeField] bool useBuiltinDirection;
	[Space (5)][SerializeField]BaseVectorDirection builtinDirection;
	[SerializeField]Vector3 customDirectionn = Vector3.right;

	void Update ()
	{
		Quaternion a = Quaternion.Euler (eulerAnglesA);
		Quaternion b = Quaternion.Euler (eulerAnglesB);
		angle =	Quaternion.Angle (a: a, b: b);

        // extentions methods
        signedAngle = b.SignedAngle();
    }

	void OnDrawGizmos ()
	{ 
		Quaternion startQ = Quaternion.Euler (eulerAnglesA);
		Quaternion endQ = Quaternion.Euler (eulerAnglesB);
		if (useBuiltinDirection) {
			GizmosForQuaternion.Angle (origin: origin, startRotation: startQ, endRotation: endQ, builtinDirection: builtinDirection, lenght: 6);	
		} else {
			GizmosForQuaternion.Angle (origin: origin, startRotation: startQ, endRotation: endQ, customDirection: customDirectionn, lenght: 6);		
		}
	}
}
