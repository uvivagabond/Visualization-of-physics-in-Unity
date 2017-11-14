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
	
	public static class GizmosForQuaternion
	{
		const float lenght6 = 6;
		static Color fireBrick = new Color32 (178, 34, 34, 255);
		static Color funkyBlue = new Color32 (30, 144, 255, 255);
		static  Vector3 right = Vector3.right;
		static  Vector3 vectorUp = Vector3.up;
		// custom direction
		static BaseVectorDirection customVectorDirection = (BaseVectorDirection)4;

		#region Angle

	
		public static void Angle (Vector3 origin, Quaternion startRotation, Quaternion endRotation, 
		                          BaseVectorDirection builtinDirection = default(BaseVectorDirection), float lenght = lenght6)
		{
			Slerp (origin, startRotation, endRotation, builtinDirection, lenght);
			GizmosForVector.ShowLabel (origin, "angle: " + System.Math.Round (Quaternion.Angle (startRotation, endRotation), 0) + "\xB0", new Color32 (127, 0, 255, 255));
		}

		public static void Angle (Vector3 origin, Quaternion startRotation, Quaternion endRotation, 
		                          Vector3 customDirection, float lenght = lenght6)
		{
			Slerp (origin, startRotation, endRotation, customDirection, lenght);
			GizmosForVector.ShowLabel (origin, "angle: " + System.Math.Round (Quaternion.Angle (startRotation, endRotation), 0) + "\xB0", new Color32 (127, 0, 255, 255));
		}

		#endregion

		#region ToAngleAxis

		public static void ToAngleAxis (Vector3 origin, Quaternion rotation,  
		                                BaseVectorDirection builtinDirection = default(BaseVectorDirection), float halfAxisLenght = 3)
		{
			float angle;
			Vector3 axis; 
			rotation.ToAngleAxis (out angle, out  axis);
			Vector3 direction = ColorsAndDirections.GetBaseDirection (builtinDirection);
			Quaternion startRotation = Quaternion.FromToRotation (Vector3.right, direction);
			AngleAxisRaw (origin, angle, axis, startRotation, builtinDirection, halfAxisLenght, Vector3.right);
		}

		public static void ToAngleAxis (Vector3 origin, Quaternion rotation,
		                                Vector3 customDirection, float halfAxisLenght = 3)
		{
			float angle;
			Vector3 axis; 
			rotation.ToAngleAxis (out angle, out  axis);
			Quaternion startRotation = Quaternion.FromToRotation (Vector3.right, customDirection);
			AngleAxisRaw (origin, angle, axis, Quaternion.identity, customVectorDirection, halfAxisLenght, customDirection.normalized);
		}

		#endregion

		#region AngleAxis

		public static void AngleAxis (Vector3 origin, float angle, Vector3 axis, Quaternion startRotation, 
		                              BaseVectorDirection builtinDirection = default(BaseVectorDirection), float halfAxisLenght = 3)
		{
			Vector3 direction = ColorsAndDirections.GetBaseDirection (builtinDirection);
			AngleAxisRaw (origin, angle, axis, startRotation, builtinDirection, halfAxisLenght, direction);
		}

		public static void AngleAxis (Vector3 origin, float angle, Vector3 axis, Quaternion startRotation, 
		                              Vector3 customDirection, float halfAxisLenght = 3)
		{
			AngleAxisRaw (origin, angle, axis, startRotation, customVectorDirection, halfAxisLenght, customDirection.normalized);
		}

		static void AngleAxisRaw (Vector3 origin, float angle, Vector3 axis, Quaternion startRotation, BaseVectorDirection builtinDirection, float halfAxisLenght, Vector3 direction)
		{
			Color temp = Gizmos.color;
			direction.Normalize ();
			Gizmos.color = new Color32 (162, 0, 255, 255);
			Gizmos.DrawRay (origin - axis.normalized * halfAxisLenght, axis.normalized * halfAxisLenght * 2);
			Quaternion endRotation = Quaternion.AngleAxis (angle, axis);
			endRotation = endRotation * startRotation;
			Slerp (origin, startRotation, endRotation, builtinDirection, halfAxisLenght, direction);

			Quaternion middle = Quaternion.Slerp (startRotation, endRotation, 0.5f);
//		DrawQuaternion (origin, middle, Color.yellow, 6, direction);////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
			GizmosForVector.ShowLabel (origin + middle * direction * halfAxisLenght, //* startRotation
				System.Math.Round (Quaternion.Angle (startRotation, endRotation), 0) + "\xB0", Color.magenta);
			Gizmos.color = temp;
		}

		#endregion

		#region LookRotation and SetLookRotation

		/// <summary>
		/// Show forward direction and up direction(up direction is projected on plane vector which normal is forward vector)
		/// </summary>
		/// <param name="origin">Origin.</param>
		/// <param name="forward">The direction to look in.</param>
		/// <param name="upwards">The vector that defines in which direction up is. We use it to project on plane (which normal is forward vector). By default is directed to Vector3.up</param>
		public static void LookRotation (Vector3 origin, Vector3 forward, Vector3 upwards = default(Vector3), float lenght = 5)
		{
            upwards=upwards==default(Vector3)?Vector3.up:upwards;
            Vector3 up = Vector3.ProjectOnPlane (upwards, forward);
			Quaternion forwardRotation = Quaternion.FromToRotation (Vector3.right, forward);
			Quaternion upwardsRotation = Quaternion.FromToRotation (Vector3.right, up);
			Slerp (origin, Quaternion.identity, forwardRotation, (BaseVectorDirection)5, lenght, right);
			Slerp (origin, Quaternion.identity, upwardsRotation, (BaseVectorDirection)6, lenght, right);
		}

		public static void SetLookRotation (Vector3 origin, Vector3 forward, Vector3 upwards = default(Vector3), float lenght = 5)
		{
			LookRotation (origin, forward, upwards, lenght);
		}

		#endregion

		#region Inverse

		public static void Inverse (Vector3 origin, Quaternion rotation, float lenght = lenght6)
		{
			Quaternion inverseRotation = Quaternion.Inverse (rotation);
			Slerp (origin, Quaternion.identity, rotation, (BaseVectorDirection)6, lenght, right, true, "", "rotation");
			Slerp (origin, Quaternion.identity, inverseRotation, (BaseVectorDirection)7, lenght, right, true, "", "inverseRotation");
			float angle;
			Vector3 axis; 
			rotation.ToAngleAxis (out angle, out axis);
			Vector3 cross = Vector3.Cross (axis, right);
			GizmosForVector.DrawPlane (origin, cross, lenght);
		}

		#endregion

		#region RotateTowards

		public static void RotateTowards (Vector3 origin, Quaternion from, Quaternion to,
		                                  BaseVectorDirection builtinDirection = default(BaseVectorDirection), float lenght = lenght6)
		{
			Vector3 direction = ColorsAndDirections.GetBaseDirection (builtinDirection);
			Slerp (origin, from, to, builtinDirection, lenght, direction, true, "from", "to");

		}

		public static void RotateTowards (Vector3 origin, Quaternion from, Quaternion to,
		                                  Vector3 customDirection, float lenght = lenght6)
		{
			Slerp (origin, from, to, customVectorDirection, lenght, customDirection.normalized, true, "from", "to");
		}


		#endregion

		#region Other

		public static void Dot (Vector3 origin, Quaternion a, Quaternion b, float lenght = 5)
		{
			Slerp (origin, a, b, (BaseVectorDirection)5, lenght, right);
			GizmosForVector.ShowLabel (origin, "dotProduct: " + System.Math.Round (Quaternion.Dot (a, b), 4), new Color32 (0, 199, 29, 255));
		}

		static void DrawAxis (Vector3 origin, Quaternion startRotation, Quaternion endRotation, float halfAxisLenght = 3)
		{
			Color temp = Gizmos.color;
			Vector3 axis;
			float angle;
			Quaternion halfOfRotation = Quaternion.Slerp (startRotation, endRotation, 0.5f);
			halfOfRotation.ToAngleAxis (out angle, out axis);
			Gizmos.color = new Color32 (162, 0, 255, 255);
			Gizmos.DrawRay (origin - axis.normalized * halfAxisLenght, axis.normalized * halfAxisLenght * 2);
			Gizmos.color = temp;
		}

		public static void ShowQuaternions (Vector3 origin, Vector3 startPosition, Vector3 endPosition, float time)
		{
			float lenght = (startPosition.magnitude > endPosition.magnitude) ? startPosition.magnitude : endPosition.magnitude;

			GizmosForVector.DrawVector (origin, Quaternion.identity * startPosition, lenght, Color.red, "");
			GizmosForVector.DrawVector (origin, endPosition, lenght, Color.green, "");

			Quaternion endQ = Quaternion.FromToRotation (startPosition, endPosition);
			int iterations = 100;
			List<Quaternion> points = new List<Quaternion> (100 * iterations);
			List<Color> colors = new List<Color> (100 * iterations);

			for (int i = 0; i < iterations; i++) {
				float t = i / (float)iterations;
				points.Add (Quaternion.Slerp (Quaternion.identity, endQ, t));
				colors.Add (Color.Lerp (Color.red, Color.green, t));

			}
			for (int i = 0; i < iterations - 1; i++) {
				if (i % 2 == 0) {
					Gizmos.color = colors [i];
					Gizmos.DrawLine (points [i] * startPosition + origin, points [i + 1] * startPosition + origin);
				}
			}
		}

		#endregion


		#region FromToRotation

		public static void FromToRotation (Vector3 origin, Vector3 fromDirection, Vector3 toDirection, 
		                                   float lenght = lenght6)
		{
			Quaternion startRotation = Quaternion.FromToRotation (Vector3.right, fromDirection);
			Quaternion endRotation = Quaternion.FromToRotation (Vector3.right, toDirection);
			Slerp (origin, startRotation, endRotation, BaseVectorDirection.right, lenght);
		}

		#endregion

		#region SetFromToRotation

		// work only for variables, not for properties like transform.rotation
		public static void SetFromToRotation (Vector3 origin, Vector3 fromDirection, Vector3 toDirection, 
		                                      float lenght = lenght6)
		{
			FromToRotation (origin, fromDirection, toDirection, lenght);
		}

		#endregion

		#region Lerp

		public static void Lerp (Vector3 origin, Quaternion startRotation, Quaternion endRotation, 
		                         BaseVectorDirection builtinDirection = default(BaseVectorDirection), 
		                         float lenght = lenght6)
		{
			Vector3 direction = ColorsAndDirections.GetBaseDirection (builtinDirection);
			InterpolateQuaternions (Quaternion.Lerp, origin, startRotation, endRotation, builtinDirection, lenght, direction);
		}

		public static void Lerp (Vector3 origin, Quaternion startRotation, Quaternion endRotation, 
		                         Vector3 customDirection, float halfAxisLenght = 3)
		{
			InterpolateQuaternions (Quaternion.Lerp, origin, startRotation, endRotation, customVectorDirection, halfAxisLenght, customDirection);
		}

		#endregion
#region LerpUnclamped
	public static void LerpUnclamped (Vector3 origin, Quaternion startRotation, Quaternion endRotation, 
		                                   float howFuther, BaseVectorDirection builtinDirection = default(BaseVectorDirection), 
		                                   float lenght = lenght6)
		{
			Vector3	direction = ColorsAndDirections.GetBaseDirection (builtinDirection);
		SlerpUnclampedRaw ( origin,  startRotation,  endRotation, howFuther,  builtinDirection, lenght,direction )	;
		}

		public static void LerpUnclamped (Vector3 origin, Quaternion startRotation, Quaternion endRotation, 
		                                   float howFuther, Vector3 customDirection, float lenght = 3)
		{
SlerpUnclampedRaw ( origin,  startRotation,  endRotation, howFuther,  customVectorDirection, lenght,customDirection )	;	
}
#endregion

		#region SlerpUnclamped
public static void SlerpUnclampedRaw (Vector3 origin, Quaternion startRotation, Quaternion endRotation, 
		                                   float howFuther, BaseVectorDirection builtinDirection = default(BaseVectorDirection), 
		                                   float lenght = lenght6, Vector3 direction= default(Vector3))
		{

			float angle;
			Vector3 axis;
			Quaternion sub = startRotation.Substraction (endRotation);
			sub.ToAngleAxis (out angle, out axis);

			float halfAxisLenght = lenght * 0.5f;
			Gizmos.DrawRay (origin - axis.normalized * halfAxisLenght, axis.normalized * halfAxisLenght * 2);
			//Vector3	direction = ColorsAndDirections.GetBaseDirection (builtinDirection);
					//	directionn = (directionn == Vector3.zero) ? Vector3.right : directionn.normalized;///w bok

			direction = (direction == Vector3.zero) ? Vector3.right : direction.normalized;
			Color startColor = ColorsAndDirections.GetColors (builtinDirection) [0];
			Color endColor = ColorsAndDirections.GetColors (builtinDirection) [1];

			DrawQuaternion (origin, startRotation, startColor, lenght, direction, true, "start");
			DrawQuaternion (origin, endRotation, endColor, lenght, direction, true, "end");
			Color finishColor=(builtinDirection==customVectorDirection)?(Color)new Color32 (0,174,219, 255): ColorsAndDirections.GetColors ((BaseVectorDirection)7) [1];
			DrawQuaternion (origin, Quaternion.SlerpUnclamped (startRotation, endRotation, howFuther),finishColor, lenght, direction, true, "howFuther: " + howFuther + "\nfinal Position: ");

			Quaternion pendicularQ0 = Quaternion.AngleAxis (0, axis);
			Quaternion pendicularQ90 = Quaternion.AngleAxis (90, axis);
			pendicularQ0 *= startRotation;
			pendicularQ90 *= startRotation;
			int iterations = 200;
			List<Quaternion> points = new List<Quaternion> (iterations);
			List<Color> colors = new List<Color> (iterations);

			for (int i = 0; i < iterations; i++) {
				float t = i * 4 / (float)iterations;
				points.Add (Quaternion.SlerpUnclamped (pendicularQ0, pendicularQ90, t));
				colors.Add (Color.Lerp (startColor, endColor, t * 0.25f));
			}
			for (int i = 0; i < iterations - 1; i++) {
				if (i % 2 == 0) {
					Gizmos.color = colors [i];
					Gizmos.DrawLine (points [i] * direction * lenght + origin, points [i + 1] * direction * lenght + origin);
				}
			}
		}

		public static void SlerpUnclamped (Vector3 origin, Quaternion startRotation, Quaternion endRotation, 
		                                   float howFuther, BaseVectorDirection builtinDirection = default(BaseVectorDirection), 
		                                   float lenght = lenght6)
		{
			Vector3	direction = ColorsAndDirections.GetBaseDirection (builtinDirection);
		SlerpUnclampedRaw ( origin,  startRotation,  endRotation, howFuther,  builtinDirection, lenght,direction )	;
		}

		public static void SlerpUnclamped (Vector3 origin, Quaternion startRotation, Quaternion endRotation, 
		                                   float howFuther, Vector3 customDirection, float lenght = 3)
		{
SlerpUnclampedRaw ( origin,  startRotation,  endRotation, howFuther,  customVectorDirection, lenght,customDirection )	;	
}

		#endregion

	

		#region Slerp + InterpolateQuaternion

		public static void Slerp (Vector3 origin, Quaternion startRotation, Quaternion endRotation, 
		                          BaseVectorDirection builtinDirection = default(BaseVectorDirection), 
		                          float lenght = lenght6)
		{
			Vector3 direction = ColorsAndDirections.GetBaseDirection (builtinDirection);
			InterpolateQuaternions (Quaternion.Slerp, origin, startRotation, endRotation, builtinDirection, lenght, direction);
		}

		public static void Slerp (Vector3 origin, Quaternion startRotation, Quaternion endRotation, 
		                          Vector3 customDirection, float halfAxisLenght = 3)
		{
			InterpolateQuaternions (Quaternion.Slerp, origin, startRotation, endRotation, customVectorDirection, halfAxisLenght, customDirection);
		}

		static void Slerp (Vector3 origin, Quaternion startRotation, Quaternion endRotation, 
		                   BaseVectorDirection builtinDirection, 
		                   float lenght, Vector3 customDirection, bool showVectorLabel = default(bool), string name1 = "", string name2 = "")
		{		
			InterpolateQuaternions (Quaternion.Slerp, origin, startRotation, endRotation, builtinDirection, lenght, customDirection, showVectorLabel, name1, name2);
		}

		static void InterpolateQuaternions (System.Func<Quaternion,Quaternion,float,Quaternion> func, Vector3 origin, Quaternion startRotation, Quaternion endRotation, 
		                                    BaseVectorDirection builtinDirection	= default(BaseVectorDirection),
		                                    float lenght = lenght6, Vector3 direction = default(Vector3), bool showVectorLabel = default(bool), string name1 = "", string name2 = "")
		{
			Color temp = Gizmos.color;
			int iterations = 100;
			direction = (direction == Vector3.zero) ? Vector3.right : direction.normalized;
			Color startColor = ColorsAndDirections.GetColors (builtinDirection) [0];
			Color endColor = ColorsAndDirections.GetColors (builtinDirection) [1];

			DrawQuaternion (origin, startRotation, startColor, lenght, direction, showVectorLabel, name1);
			DrawQuaternion (origin, endRotation, endColor, lenght, direction, showVectorLabel, name2);
			DrawDotsConnectingQuaternions (func, origin, startRotation, endRotation, lenght, direction, iterations, startColor, endColor);
			Gizmos.color = temp;
			;
		}

		static void DrawDotsConnectingQuaternions (System.Func<Quaternion, Quaternion, float, Quaternion> func, Vector3 origin, Quaternion startRotation, Quaternion endRotation, float lenght, Vector3 direction, int iterations, Color startColor, Color endColor)
		{
			List<Quaternion> points = new List<Quaternion> (iterations);
			List<Color> colors = new List<Color> (iterations);
			for (int i = 0; i < iterations; i++) {
				float t = i / (float)iterations;
				points.Add (func (startRotation, endRotation, t));
				colors.Add (Color.Lerp (startColor, endColor, t));
			}
			for (int i = 0; i < iterations - 1; i++) {
				if (i % 2 == 0) {
					Gizmos.color = colors [i];
					Gizmos.DrawLine (points [i] * direction * lenght + origin, points [i + 1] * direction * lenght + origin);
				}
			}
		}

		#endregion

		#region Draw Quaternion


		/// <summary>
		/// Draws the quaternion based of quaternion value.
		/// </summary>
		/// <param name="origin">Origin.</param>
		/// <param name="rotation">Rotation.</param>
		/// <param name="vectorColor">Vector color.</param>
		/// <param name="direction">Direction of Draw Vector - by default its Vector3.right. It's for showing other directions of vectors</param>
		/// <param name="vectorLenght">Vector lenght.</param>
		/// <param name="showVectorLabel">If set to <c>true</c> show vector label.</param>
		/// <param name="name">Name.</param>
		public static void DrawQuaternion (Vector3 origin, Quaternion rotation, Color vectorColor, 
		                                   float vectorLenght = lenght6, Vector3 custormDirection = default(Vector3), bool showVectorLabel = default(bool), string name = "")
		{
			Vector3 basicVector = (custormDirection == Vector3.zero) ? Vector3.right : custormDirection.normalized;
			DrawRawQuaternion (origin, rotation, basicVector, vectorColor, vectorLenght, showVectorLabel, name);	
		}

		static void DrawRawQuaternion (Vector3 origin, Quaternion rotation, Vector3 basicVector, Color vectorColor, 
		                               float vectorLenght = lenght6, bool showVectorLabel = default(bool), string name = "",
		                               bool showLabel = !default(bool))
		{
			Vector3 tempPositionOrEulerAngles = (showVectorLabel) ? rotation * basicVector : rotation.eulerAngles;	
			basicVector = rotation * basicVector;
			#if UNITY_EDITOR
			UnityEditor.Handles.matrix = Matrix4x4.identity;
			Color temp = Gizmos.color;
			Color temp2 = UnityEditor.Handles.color;
			basicVector.Normalize ();
			GUIStyle g = new GUIStyle ();	
			vectorColor.a = 1;
			g.normal.textColor = vectorColor;
			vectorColor.a = 0.5f;
			Gizmos.color = vectorColor;
			UnityEditor.Handles.color = vectorColor;
			if (vectorLenght > 1) {
				UnityEditor.Handles.ArrowHandleCap (0, origin + basicVector * (vectorLenght - 1), Quaternion.LookRotation (basicVector), 0.88f, EventType.Repaint);
				Gizmos.DrawRay (origin, basicVector * (vectorLenght - 1));
			} else {
				UnityEditor.Handles.ArrowHandleCap (0, origin, rotation, vectorLenght - 0.11f * vectorLenght, EventType.Repaint);
			}
			System.Text.StringBuilder sb = new System.Text.StringBuilder ();
			string anglesOrVector = (showVectorLabel) ? " ({0}, {1}, {2})" : " ({0}\xB0, {1}\xB0, {2}\xB0)";
			int digits = (showVectorLabel) ? 2 : 0;
			sb.AppendFormat (name + anglesOrVector, System.Math.Round (tempPositionOrEulerAngles.x, digits), 
				System.Math.Round (tempPositionOrEulerAngles.y, digits), System.Math.Round (tempPositionOrEulerAngles.z, digits));		

			if (showLabel) {
				UnityEditor.Handles.Label (origin + basicVector * (vectorLenght + 0.3f), sb.ToString (), g);
			}
			UnityEditor.Handles.color = temp2;
			Gizmos.color = temp;
			Gizmos.matrix = Matrix4x4.identity;
			#endif
		}

		#endregion

	
	}
}
public static class QuaternionExtentions
{
	public static Quaternion Add (this Quaternion first, Quaternion second)
	{
		return first * second;
	}

	public static Quaternion Substraction (this Quaternion first, Quaternion second)
	{
		return first * Quaternion.Inverse (second);
	}

	/// <summary>
	/// Return axis for difference rotation between start and end rotation
	/// </summary>
	/// <returns>The angle axis custom.</returns>
	/// <param name="endRotation">Second rotation.</param>
	/// <param name="angle">Angle between rotations.</param>
	/// <param name="axis">Rotatio axis.</param>
	public static void ToAngleAxisCustom (this Quaternion startRotation, Quaternion endRotation, out float angle, out Vector3 axis)
	{
		Quaternion sub = startRotation.Substraction (endRotation);
		sub.ToAngleAxis (out angle, out axis);
	}

}