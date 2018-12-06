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

namespace UnityBerserkersGizmos
{
	
	public class GizmosForTransform
	{

		public static void RotateAround (Transform objectToRotate, Vector3 point, float angle, Vector3 axis, float halfAxisLenght = 6)
		{
			float offset = 0f;
			bool showPoints = true;
			DrawRotateGizmo (objectToRotate, point, angle, axis, halfAxisLenght, offset, showPoints);
		}

		static void DrawRotateGizmo (Transform objectToRotate, Vector3 point, float angle, Vector3 axis, float halfAxisLenght, float offset, bool showPoints)
		{
			if (!objectToRotate) {
				return;
			}

			Vector3 binormal = Vector3.zero;
			Vector3 tangent = Vector3.zero;
			Vector3.OrthoNormalize (ref axis, ref binormal, ref tangent);

			Vector3 directionFromPointToObject = point - objectToRotate.position;

			Vector3 distanceBetweenPointAndPivotBelongAxis = Vector3.Project (directionFromPointToObject, axis.normalized);
			Vector3 pivot = point - distanceBetweenPointAndPivotBelongAxis;
			Quaternion pendicularQ0 = Quaternion.AngleAxis (0, -axis.normalized);
			Quaternion pendicularQ90 = Quaternion.AngleAxis (90, -axis.normalized);


			float radius = (objectToRotate.position - pivot).magnitude + offset;
			Vector3 dir = axis.normalized;
			Color startColor = ColorsAndDirections.GetColors ((BaseVectorDirection)0) [0];
			Color endColor = ColorsAndDirections.GetColors ((BaseVectorDirection)7) [1];
			int iterations = 200;
			List<Quaternion> points = new List<Quaternion> (iterations);
			List<Color> colors = new List<Color> (iterations);

			Vector3 direction = binormal;
			Gizmos.DrawRay (pivot - axis.normalized * halfAxisLenght * halfAxisLenght, axis.normalized * halfAxisLenght * halfAxisLenght * 2);

			for (int i = 0; i < iterations; i++) {
				float t = i * 4 / (float)iterations;
				points.Add (Quaternion.SlerpUnclamped (pendicularQ0, pendicularQ0 * pendicularQ90, t));
				colors.Add (Color.Lerp (startColor, endColor, t * 0.25f));
			}
			for (int i = 0; i < iterations - 1; i++) {
				if (i % 2 == 0) {
					Gizmos.color = colors [i];
					Gizmos.DrawLine (pivot + points [i] * direction * radius, pivot + points [i + 1] * direction * radius);
				}
			}
			if (showPoints) {
				GizmosForVector.ShowVectorValue (point, "point", point, Color.red);
				GizmosForVector.ShowVectorValue (pivot, "pivot", pivot, Color.green);
				Gizmos.color = Color.red;
				Gizmos.DrawSphere (point, 0.2f);
				Gizmos.color = Color.green;
				Gizmos.DrawSphere (pivot, 0.2f);
			}
		}

		public static void LookAt (Transform origin, Transform target, Vector3 worldUp = default(Vector3), float lenght = 5)
		{
			if (!origin || !target) {
				return;
			}
			worldUp = worldUp == default(Vector3) ? Vector3.up : worldUp;
			Vector3 originV = origin.position;
			Vector3 forwardDirection = target.position - originV;
			GizmosForQuaternion.LookRotation (originV, forwardDirection, worldUp, lenght);
		}

		public static void LookAt (Transform origin, Vector3 worldPosition, Vector3 worldUp = default(Vector3), float lenght = 5)
		{
			if (!origin) {
				return;
			}
			worldUp = worldUp == default(Vector3) ? Vector3.up : worldUp;
			Vector3 originV = origin.position;
			Vector3 forwardDirection = worldPosition - originV;
			GizmosForQuaternion.LookRotation (originV, forwardDirection, worldUp, lenght);
			GizmosForVector.ShowVectorValue (worldPosition, "worldPosition", worldPosition, Color.red);
			Color temp = Gizmos.color;
			Gizmos.color = Color.red;
			Gizmos.DrawSphere (worldPosition, 0.2f);
			Gizmos.color = temp;
		}


		public static void Rotate (Transform origin, Vector3 eulerAngles, Space relativeTo = Space.Self, float halfAxisLenght = 1.5f)
		{
			Vector3 start = origin.position;
			Vector3 axis;
			float angle;
			Quaternion actualRotation = Quaternion.FromToRotation (Vector3.right, origin.right);
			Quaternion endRotation = Quaternion.Euler (eulerAngles);

			endRotation.ToAngleAxis (out angle, out axis);
			Rotate (origin, axis, angle, relativeTo, halfAxisLenght);
		}

		public static void Rotate (Transform origin, float xAngle, float yAngle, float zAngle, Space relativeTo = Space.Self, float halfAxisLenght = 1.5f)
		{
			Rotate (origin, new Vector3 (xAngle, yAngle, zAngle), relativeTo, halfAxisLenght);
		}

		public static void Rotate (Transform origin, Vector3 axis, float angle, Space relativeTo = Space.Self, float halfAxisLenght = 1.5f)
		{
			if (relativeTo == Space.Self) {
				axis = origin.rotation * axis;
			}
			DrawRotateGizmo (origin, origin.position, angle, axis, halfAxisLenght, halfAxisLenght * 2, false);
		}
	}

  
}
