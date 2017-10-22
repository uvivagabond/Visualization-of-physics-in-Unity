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
public class DistanceTest : MonoBehaviour
{
	[SerializeField]Rigidbody2D myRigidbody2D;

	[SerializeField]Collider2D firstCollider;
	[SerializeField]Collider2D secondCollider;

    ColliderDistance2D colliderDistance2D;
    [Space(15)][SerializeField] Vector3 normal;
    [SerializeField]Vector3 pointA;
    [SerializeField]Vector3 pointB;
    [Space(15)][SerializeField]bool isOverlaped;
	[SerializeField]bool isValid;


	void Update ()
	{
        //colliderDistance2D=Physics2D.Distance (colliderA: firstCollider, colliderB: secondCollider);

        //colliderDistance2D = firstCollider.Distance(collider: secondCollider);

        colliderDistance2D = myRigidbody2D.Distance(collider: secondCollider);

        normal = GizmosForVector.Round (colliderDistance2D.normal, 2);
		isValid = colliderDistance2D.isValid;
		isOverlaped = colliderDistance2D.isOverlapped;
        pointA = GizmosForVector.Round(colliderDistance2D.pointA,2);
        pointB = GizmosForVector.Round(colliderDistance2D.pointB,2);
    }


	void OnDrawGizmos ()
	{
		GizmosForPhysics2D.VizualizeDistance (colliderDistance2D);
	}
}

