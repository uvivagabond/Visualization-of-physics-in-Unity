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

public class GetContactsTest1 : MonoBehaviour
{
	[SerializeField] Rigidbody2D rig;
	[SerializeField] Rigidbody2D rig2;
	[SerializeField] Collider2D Col;

	[SerializeField] Vector3 force1;
	[SerializeField] Vector3 force2;
	[SerializeField] Vector3 vel1;
	[SerializeField]ForceMode2D fm = ForceMode2D.Impulse;
	[SerializeField] Color def = default(Color);

	void Start ()
	{
		if (fm == ForceMode2D.Force) {
			rig.AddForce (force1 / Time.fixedDeltaTime, fm);
			rig2.AddForce (force2 / Time.fixedDeltaTime, fm);
		} else {
			rig.AddForce (force1, fm);
			rig2.AddForce (force2, fm);
		}


//		vel1 = rig.velocity;
//		rig.velocity = force1;
//		rig2.velocity = force2;
	}

	void Update ()
	{
		Debug.Log ("1. " + rig.velocity);
		Debug.Log ("2. " + rig2.velocity);
	}

	void OnDrawGizmos ()
	{
		GizmosForPhysics2D.VizualizeGetContacts (Col);
	}

}




