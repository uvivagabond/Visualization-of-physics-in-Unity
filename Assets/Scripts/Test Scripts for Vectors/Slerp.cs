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
public class Slerp : MonoBehaviour
{
	[Header ("Press L to start moving ball")][Space (10)]
	[SerializeField]Vector3 startPosition;
	[SerializeField]Vector3 endPosition = Vector3.zero;
	[SerializeField]float t;
	IEnumerator myLerp;

	void Update ()
	{
		//press L to start slerp
		if (Input.GetKeyDown (KeyCode.L)) {
			myLerp = VectorSlerp (startPosition, endPosition, t);
			StartCoroutine (routine: myLerp);
		}
	}

	void OnDrawGizmos ()
	{
		GizmosForVector.VisualizeSlerp (startPosition, endPosition);
	}

	public IEnumerator VectorSlerp (Vector3 startPosition, Vector3 endPosition, float time)
	{
		float lerpTime = time;
		float currentTime = 0;
		float percentage = 0;

		while (currentTime < time * 2) {
			currentTime += Time.deltaTime;
			percentage = currentTime / time; 
			transform.position = Vector3.Slerp (a: startPosition, b: endPosition, t: percentage);
			yield return null;
		}
	}

	public IEnumerator VectorLerp (Vector3 startPosition, Vector3 endPosition, float time)
	{
		float lerpTime = time;
		float currentTime = 0;
		float percentage = 0;

		while (currentTime < time) {
			currentTime += Time.deltaTime;
			percentage = currentTime / time; 
			transform.position = Vector3.Lerp (a: startPosition, b: endPosition, t: percentage);
			yield return null;
		}
	}
}
