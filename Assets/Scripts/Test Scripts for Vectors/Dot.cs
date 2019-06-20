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

public class Dot : MonoBehaviour
{
	[SerializeField]	Vector3 originOfVectors;
	[Space (50)]

	[SerializeField]	Vector3 lhs = new Vector3 (0f, 0f, 0f);
	[SerializeField]	Vector3 rhs = new Vector3 (0f, 0f, 0f);


	[Space (50)]
	[SerializeField]bool useRealScale;
	[Space (20)]
	[SerializeField]	float dotProduct;

	void Update ()
	{
//		lhs.Normalize ();
//		rhs.Normalize ();

		dotProduct = Vector3.Dot (lhs: lhs, rhs: rhs);
	}

	void OnDrawGizmos ()
	{
		GizmosForVector.VisualizeDot (origin: originOfVectors, lhs: lhs, rhs: rhs, realScale: useRealScale);
	}

}
