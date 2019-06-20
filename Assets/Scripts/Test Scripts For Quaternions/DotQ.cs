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
public class DotQ : MonoBehaviour
{

	[Header ("Origin of vectors")]
	[SerializeField]Vector3 origin = Vector3.zero;
	[Space (11)][Header ("Quaternions in form of euler angle")]
	[SerializeField]Vector3 firstRotation = Vector3.right;
	[SerializeField]Vector3 secondRotation = Vector3.up;

	[Space (22)][Header ("Dot product and parameter w")]
	[SerializeField]float dotProduct;
    [SerializeField] float parameterW;

    [SerializeField] Quaternion B;
    [SerializeField] Quaternion A;


    void Update ()
	{
        Quaternion a = Quaternion.Euler (firstRotation);
		Quaternion b =	Quaternion.Euler (secondRotation);

		dotProduct = Quaternion.Dot (a: a, b: b);

        //The difference in rotation between two quaternions
        Quaternion rotationDifferenceBA = Quaternion.Inverse(a) * b;
        parameterW = rotationDifferenceBA.w;
        A = Quaternion.identity;
        B= Quaternion.Euler(secondRotation);
    }

	void OnDrawGizmos ()
	{
		Quaternion a = Quaternion.Euler (firstRotation);
		Quaternion b = Quaternion.Euler (secondRotation);
	
		GizmosForQuaternion.Dot (origin, a, b, 6f);	
	}
}
