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
public class AngleAxisTest : MonoBehaviour
{
 
    [Header ("Quaternions in form of euler angle")]
	[SerializeField]Vector3 startRotation = Vector3.right;
	
	[Space (22)]
	[SerializeField]Vector3 axis;
	[SerializeField] float angle;

    [Space(11)]
    [Header("Results:")]
    [SerializeField] Quaternion q;

    [Space(55)]
    [Header("Visualization parameters")]
    [Header("Origin of vectors")]
    [SerializeField] Vector3 origin1 = Vector3.zero;
    [Header("Which version of method")]
    [SerializeField] bool useBuiltinDirection;
    [Space(5)] [SerializeField] BaseVectorDirection builtinDirection;
    [SerializeField] Vector3 customDirectionn = Vector3.right;



    void Update ()	{
        q = Quaternion.AngleAxis (angle:angle,axis: axis);		
	}

	void OnDrawGizmos ()
	{
		Quaternion startQ = Quaternion.Euler (startRotation);
		if (useBuiltinDirection) {
			GizmosForQuaternion.AngleAxis (origin1, angle, axis, startQ, builtinDirection);
		} else {
			GizmosForQuaternion.AngleAxis (origin1, angle, axis, startQ, customDirectionn);
		}
	}


}
