using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityBerserkersGizmos
{
	

	public static class GizmosForVector
	{
		#region Variables

		static Color nonHitColorB2 = new Color (r: 0.129f, g: 0.108f, b: 0.922f, a: 0.25f);
		static Color hitColorO = new Color (r: 0.18f, g: 0.88f, b: 0.49f, a: 1f);
		static Color hitColorR2 = new Color (r: 1f, g: 0.058f, b: 0.01f, a: 0.25f);
		static Color fireBrick = new Color32 (178, 34, 34, 255);
		static Color funkyBlue = new Color32 (30, 144, 255, 255);

		#endregion

		/// <summary>
		/// Visualizes the cross.
		/// </summary>
		/// <param name="origin">Start position of vectors</param>
		/// <param name="lhs">First Vector</param>
		/// <param name="rhs">Second Vector</param>
		/// <param name="realScale">If set to true vector will have true lenght otherwise 5 units</param>
		public static void VisualizeCross (Vector3 origin, Vector3 lhs, Vector3 rhs, bool realScale = default(bool), float lenght = 5f)
		{
			Vector3 result = Vector3.Cross (lhs, rhs);

			float lhsLenght = (realScale) ? lhs.magnitude : lenght;
			float rhsLenght = (realScale) ? rhs.magnitude : lenght;
			float resultLenght = (realScale) ? result.magnitude : lenght;
			float max = (realScale) ? Mathf.Max (lhsLenght, rhsLenght) : lenght;
			DrawVector (origin, lhs, lhsLenght, Color.red, "lhs");
			DrawVector (origin, rhs, rhsLenght, Color.green, "rhs");
			DrawVector (origin, result, resultLenght, Color.blue, "crossResult");
			DrawPlane (origin, result, max);
		}

		public static void VisualizeDot (Vector3 origin, Vector3 lhs, Vector3 rhs, bool realScale = default(bool), float lenght = 5f)
		{
			float result = Vector3.Dot (lhs, rhs);

			float lhsLenght = (realScale) ? lhs.magnitude : lenght;
			float rhsLenght = (realScale) ? rhs.magnitude : lenght;
			float max = (realScale) ? Mathf.Min (lhsLenght, rhsLenght) : lenght;
			#if UNITY_EDITOR
			DrawVector (origin, lhs, lhsLenght, Color.red, "lhs");
			DrawVector (origin, rhs, rhsLenght, Color.green, "rhs");
			UnityEditor.Handles.color = new Color32 (255, 0, 0, 25);
			UnityEditor.Handles.DrawSolidArc (origin, Vector3.Cross (lhs, rhs).normalized, lhs, Vector3.Angle (lhs, rhs), max * 0.8f);
			ShowLabel (origin + new Vector3 (0, 0.5f, 0), "dotProduct: " + result, Color.blue);
			#endif
		}

		/// <summary>
		/// Visualizes the orthonormalize of vector.
		/// </summary>
		/// <param name="origin">Start position of vectors</param>
		/// <param name="normal">Normal vector.</param>
		/// <param name="tangent">Tangent vector</param>
		/// <param name="binormal">Binormal vector</param>
		/// <param name="lenght">Lenght of vectors</param>
		public static void VisualizeOrthonormalize (Vector3 origin, Vector3 normal,	Vector3 tangent, float lenght = 5)
		{
			lenght = Mathf.Clamp (lenght, 1, 20);
			Vector3 binormal = Vector3.Cross (normal, tangent);
			DrawVector (origin, normal, lenght, Color.red, "normal");
			DrawVector (origin, tangent, lenght, Color.green, "tangent");
			DrawVector (origin, binormal, lenght, Color.blue, "binormal");
		}

		public static void VisualizeOrthonormalize (Vector3 origin, Vector3 normal,	Vector3 tangent, Vector3 binormal, float lenght = 5)
		{
			lenght = Mathf.Clamp (lenght, 1, 20);
			DrawVector (origin, normal, lenght, Color.red, "normal");
			DrawVector (origin, tangent, lenght, Color.green, "tangent");
			DrawVector (origin, binormal, lenght, Color.blue, "binormal");
		}

		/// <summary>
		/// /*Visualizes the project on plane.*/
		/// </summary>
		/// <param name="origin">Start position of lines</param>
		/// <param name="vector">Vector to project</param>
		/// <param name="planeNormal">Normal to plane</param>
		/// <param name="realScale">If set to true vectors will have true lenght otherwise 5 units</param>
		public static void VisualizeProjectOnPlane (Vector3 origin, Vector3 vector, Vector3 planeNormal, bool realScale = default(bool))
		{
			Color temp = Gizmos.color;					
			Vector3 projected = Vector3.ProjectOnPlane (vector, planeNormal);
			float vectorLenght = (realScale) ? vector.magnitude : 5f;
			float projectedLenght = (realScale) ? projected.magnitude : projected.magnitude / vector.magnitude * 5f;
			float planetNormalL = Vector3.Project (vector, planeNormal).magnitude;
			float planeNormalLenght = (realScale) ? ((planetNormalL > 1) ? planetNormalL : 1)
			: (planetNormalL > 1) ? Vector3.Project (vector.normalized * 5, planeNormal).magnitude : 5;

			DrawVector (origin, vector, vectorLenght, Color.red, "vector");
			DrawVector (origin, projected, projectedLenght, Color.yellow, "result");
			DrawVector (origin, planeNormal, planeNormalLenght, nonHitColorB2, "planeNormal");
			DrawPlane (origin, planeNormal, vectorLenght);
			DrawDottedLine (vector.normalized * vectorLenght, projected.normalized * projectedLenght, 3, Color.green);

			Gizmos.color = temp;
		}

		/// <summary>
		/// Visualizes the reflected vector.
		/// </summary>
		/// <param name="originOfInDirection">Begin position of inDirection vector.</param>
		/// <param name="inDirection">Vector to reflect.</param>
		/// <param name="inNormal">Normal to plane (Vector3.Reflect() and this method need normalized value of inNormal).</param>
		/// <param name="realScale">If set to true vectors will have true lenght otherwise 5 units</param>
		public static void VisualizeReflect (Vector3 originOfInDirection, Vector3 inDirection, Vector3 inNormal, bool realScale = default(bool))
		{
			Vector3 enter = inDirection;
			Vector3 tempInDirection = inDirection;
			inDirection.Normalize ();
			Color temp = Gizmos.color;		
			Vector3 reflected = Vector3.Reflect (inDirection, inNormal);
			float inDirectLenght = (realScale) ? inDirection.magnitude : 5f;

			float projectedLenght = (realScale) ? reflected.magnitude : reflected.magnitude / inDirection.magnitude * 5f;

			float planetNormalL = Vector3.Project (inDirection, inNormal).magnitude;
			float inNormalLenght = (realScale) ? ((planetNormalL > 1) ? planetNormalL : 1)
			: (planetNormalL > 1) ? Vector3.Project (inDirection.normalized * 5, inNormal).magnitude : 5;

			DrawVector (originOfInDirection, tempInDirection, inDirectLenght, Color.red, "inDirection");
			DrawVector (originOfInDirection + inDirection * inDirectLenght, reflected * tempInDirection.magnitude, projectedLenght, Color.green, "reflected");
			DrawVector (originOfInDirection + inDirection * inDirectLenght, inNormal, inNormalLenght, nonHitColorB2, "inNormal");

			DrawPlane (originOfInDirection + inDirection * inDirectLenght, inNormal, inDirectLenght);
			Gizmos.color = temp;
			#if UNITY_EDITOR
			UnityEditor.Handles.Label (originOfInDirection, "origin");	

			#endif
		}

		static void DrawPlane (Vector3 origin, Vector3 planeNormal, float vectorLenght)
		{
			Vector3 tangent = new Vector3 (0, 0, 0), binormal = new Vector3 (0, 0, 0);
			Vector3.OrthoNormalize (ref planeNormal, ref tangent, ref binormal);
			for (float i = 0.1f; i < 1.1f; i = i + 0.1f) {
				Vector3 bt = origin + (tangent + binormal) * vectorLenght * i;
				Vector3 bmt = origin + (-tangent + binormal) * vectorLenght * i;
				Vector3 mbmt = origin + (-tangent - binormal) * vectorLenght * i;
				Vector3 mbt = origin + (tangent - binormal) * vectorLenght * i;
				Gizmos.color = nonHitColorB2;
				Gizmos.DrawLine (bt, bmt);
				Gizmos.DrawLine (bmt, mbmt);
				Gizmos.DrawLine (mbmt, mbt);
				Gizmos.DrawLine (mbt, bt);
			}
		}


		public static void DrawVector (Vector3 origin, Vector3 direction, float vectorLenght, Color vectorColor, string name, Vector3 labelOffset = default(Vector3), bool showLabel = !default(bool))
		{
			#if UNITY_EDITOR
			Color temp = Gizmos.color;
			Color temp2 = UnityEditor.Handles.color;
			Vector3 tempPosition = direction;
			direction.Normalize ();
			GUIStyle g = new GUIStyle ();	
			vectorColor.a = 1;
			g.normal.textColor = vectorColor;
			vectorColor.a = 0.5f;
			Gizmos.color = vectorColor;
			UnityEditor.Handles.color = vectorColor;
			if (vectorLenght > 1) {
				UnityEditor.Handles.ArrowHandleCap (0, origin + direction * (vectorLenght - 1), Quaternion.LookRotation (direction), 0.88f, EventType.Repaint);
				Gizmos.DrawRay (origin, direction * (vectorLenght - 1));
			} else {
				UnityEditor.Handles.ArrowHandleCap (0, origin, Quaternion.LookRotation (direction), vectorLenght - 0.11f * vectorLenght, EventType.Repaint);
			}
			System.Text.StringBuilder sb = new System.Text.StringBuilder ();
			sb.AppendFormat (name + " ({0}, {1}, {2})", System.Math.Round (tempPosition.x, 2), System.Math.Round (tempPosition.y, 2), System.Math.Round (tempPosition.z, 2));
			if (showLabel) {
				UnityEditor.Handles.Label (origin + labelOffset + direction * (vectorLenght + 0.3f), sb.ToString (), g);
			}
			UnityEditor.Handles.color = temp2;
			Gizmos.color = temp;
			#endif
		}

		public static void VisualizeLerp (Vector3 startPosition, Vector3 endPosition)
		{	
			GetPointAndDrawInterpolation (Vector3.Lerp, startPosition, endPosition);
			WriteStartEndLabels (startPosition, endPosition);
		}

		public static void VisualizeSlerp (Vector3 startPosition, Vector3 endPosition)
		{	
			GetPointAndDrawInterpolation (Vector3.Slerp, startPosition, endPosition);
			WriteStartEndLabels (startPosition, endPosition);
		}

		public static void VisualizeSlerpUnclamped (Vector3 startPosition, Vector3 endPosition, int howFutherDrawLine = 1)
		{	
			GetPointAndDrawInterpolation (Vector3.SlerpUnclamped, startPosition, endPosition, howFutherDrawLine);
			WriteStartEndLabels (startPosition, endPosition);
		}

		public static void VisualizeLerpUnclamped (Vector3 startPosition, Vector3 endPosition, int howFutherDrawLine = 1)
		{	
			GetPointAndDrawInterpolation (Vector3.LerpUnclamped, startPosition, endPosition, howFutherDrawLine);
			WriteStartEndLabels (startPosition, endPosition);
		}

		static void WriteStartEndLabels (Vector3 startPosition, Vector3 endPosition)
		{
			#if UNITY_EDITOR
			GUIStyle g = new GUIStyle ();
			g.normal.textColor = Color.blue;
			UnityEditor.Handles.Label (startPosition, "startPosition", g);
			g.normal.textColor = Color.red;
			UnityEditor.Handles.Label (endPosition, "endPosition", g);
			#endif
		}


		static void GetPointAndDrawInterpolation (System.Func<Vector3,Vector3,float,Vector3> func, Vector3 startPosition, Vector3 endPosition, int howMuchFuther = 1)
		{
			Color temp = Gizmos.color;
			Gizmos.color = funkyBlue;
			howMuchFuther = Mathf.Clamp (howMuchFuther, 1, 10);
			int iterations = 100 * howMuchFuther;
			List<Vector3> points = new List<Vector3> (100 * iterations);
			for (int i = 0; i < iterations; i++) {
				float t = i * howMuchFuther / (float)iterations;
				points.Add (func (startPosition, endPosition, t));

			}
			for (int i = 0; i < iterations - 1; i++) {
				if (i % 2 == 0) {
					Gizmos.DrawLine (points [i], points [i + 1]);
				}
			}
			for (int i = 0; i < iterations - 1; i++) {
				if (i % 100 == 0 && i > 100) {
					Gizmos.color = hitColorO;
					Gizmos.DrawSphere (points [i], 0.3f);
				}
			}
			if (howMuchFuther > 1) {
				Gizmos.DrawSphere (points [points.Count - 1], 0.3f);
			}

			Gizmos.color = Color.blue;
			Gizmos.DrawSphere (startPosition, 0.3f);
			Gizmos.color = Color.red;
			Gizmos.DrawSphere (endPosition, 0.3f);
			Gizmos.color = temp;
		}

		/// <summary>
		/// /*Visualizes trajectory of smooth damp - (we CAN'T set parameters when application is playing)*/
		/// </summary>
		/// <param name="current">Start position </param>
		/// <param name="target">Target position.</param>
		/// <param name="currentVelocity">Start velocity.</param>
		/// <param name="smoothTime">We can't get values greater then 60s - or not full trajectory will be drawn</param>
		/// <param name="maxSpeed">Max speed.</param>
		public static void VisualizeSmoothDampPath (Vector3 current, Vector3 target, Vector3 currentVelocity, float smoothTime, 
		                                            float maxSpeed = Mathf.Infinity)
		{
			#if UNITY_EDITOR
			Color tempColor = Gizmos.color;
			Gizmos.color = fireBrick;
			Vector3 currentVelocityHardCoded = new Vector3 (0, 0, 0), currentPositionHardCoded;

			if (!UnityEditor.EditorApplication.isPlaying) {
				currentVelocityHardCoded = currentVelocity;
				currentPositionHardCoded = current;
				EditorPrefsTagsForSmoothDamp.SaveVector (current, "current");
				EditorPrefsTagsForSmoothDamp.SaveVector (currentVelocity, "currentVelocity");
			} else {
				currentPositionHardCoded = EditorPrefsTagsForSmoothDamp.LoadVector ("current");
				currentVelocityHardCoded = EditorPrefsTagsForSmoothDamp.LoadVector ("currentVelocity");
			}
			int capacity = 148;
			int iterations = 2000;
			Vector3 temp;
			Vector3 last = currentPositionHardCoded;

			if (!UnityEditor.EditorApplication.isPlaying || !arePointsCached) {
				for (int i = 0; i < iterations; i++) {
					float t = i / (float)iterations;
					temp = (Vector3.SmoothDamp ((i > 0) ? last : currentPositionHardCoded, target, ref currentVelocityHardCoded, smoothTime, maxSpeed, 0.1f));
					last = temp;

					if (i > 50 && i % 20 == 0) {
						points [i / 20 + 46] = temp;
					} else if (i < 50) {
						points [i] = temp;
					}
				}
				arePointsCached = true;
			}
			for (int i = 0; i < points.Length - 3; i++) {	
				if (points [i] != null) {
					Gizmos.DrawLine (points [i], points [i + 1]);//								
				}
			}
			Gizmos.DrawLine (points [capacity - 3], target);	
			Gizmos.DrawLine (points [0], currentPositionHardCoded);	
			Gizmos.color = Color.red;
			Gizmos.DrawSphere (target, 0.3f);
			Gizmos.color = Color.blue;
			Gizmos.DrawSphere (currentPositionHardCoded, 0.3f);

			GUIStyle g = new GUIStyle ();
			g.normal.textColor = Color.blue;
			UnityEditor.Handles.Label (currentPositionHardCoded, "start Position");	
			g.normal.textColor = Color.red;
			UnityEditor.Handles.Label (target, "target Position");	
			Gizmos.color = tempColor;
			#endif
		}

		static bool arePointsCached = false;
		static Vector3[] points = new Vector3[148];

		static class EditorPrefsTagsForSmoothDamp
		{
			#if UNITY_EDITOR
			public static void SaveVector (Vector3 actualValue, string vectorName)
			{	
				System.Text.StringBuilder sb = new System.Text.StringBuilder ();
				sb.AppendFormat ("{0}X", vectorName);
				UnityEditor.EditorPrefs.SetFloat (sb.ToString (), actualValue.x);
				sb.Remove (0, sb.Length);
				sb.AppendFormat ("{0}Y", vectorName);
				UnityEditor.EditorPrefs.SetFloat (sb.ToString (), actualValue.y);
				sb.Remove (0, sb.Length);
				sb.AppendFormat ("{0}Z", vectorName);
				UnityEditor.EditorPrefs.SetFloat (sb.ToString (), actualValue.z);
			}

			public static Vector3 LoadVector (string vectorName)
			{
				System.Text.StringBuilder sb = new System.Text.StringBuilder ();
				sb.AppendFormat ("{0}X", vectorName);
				float x = UnityEditor.EditorPrefs.GetFloat (sb.ToString ());
				sb.Remove (0, sb.Length);
				sb.AppendFormat ("{0}Y", vectorName);
				float y = UnityEditor.EditorPrefs.GetFloat (sb.ToString ());
				sb.Remove (0, sb.Length);
				sb.AppendFormat ("{0}Y", vectorName);
				float z =	UnityEditor.EditorPrefs.GetFloat (sb.ToString ());
				return new Vector3 (x, y, z);
			}
			#endif

		}

		/// <summary>
		/// Visualizes the angle.
		/// </summary>
		/// <param name="origin">Start position of vectors</param>
		/// <param name="from">Vector FROM which we measure angle.</param>
		/// <param name="to">Vector TO which we measure angle.</param>
		/// <param name="lenght">Lenght of drawed vectors.</param>
		/// <param name="realScale">If set to true vector have original lenght</param>
		public	static  void VisualizeAngle (Vector3 origin, Vector3 from, Vector3 to, float lenght = 5)
		{
			float angle = Vector3.Angle (from, to);
			Vector3 normal = Vector3.Cross (from, to).normalized;
			DrawAngles (origin, normal, from, to, angle, "Angle", lenght);
		}

		/// <summary>
		/// Visualizes the signed angle 2D.
		/// </summary>
		/// <param name="origin">Start position of vectors</param>
		/// <param name="from">Vector FROM which we measure angle.</param>
		/// <param name="to">Vector TO which we measure angle.</param>
		/// <param name="lenght">Lenght of drawed vectors.</param>
		/// <param name="realScale">If set to true vector have original lenght</param>
		public static  void VisualizeSignedAngle2D (Vector3 origin, Vector2 from, Vector2 to, float lenght = 5)
		{
			float signedAngle = Vector2.SignedAngle (from, to);
			float angle = Vector3.Angle (from, to);
			Vector3 normal = Vector3.Cross (from, to).normalized;
			#if UNITY_EDITOR
			DrawVector (origin, from, lenght, Color.red, "from");
			DrawVector (origin, to, lenght, Color.blue, "to");
			UnityEditor.Handles.color = new Color32 (255, 0, 0, 25);
			UnityEditor.Handles.Label (origin, "SignedAngle2D(deg): " + System.Math.Round (signedAngle, 0) + "\xB0");
			UnityEditor.Handles.DrawSolidArc (origin, normal, from, angle, lenght * 0.8f);
			#endif	
		}

		/// <summary>
		/// Visualizes the signed angle 3D.
		/// </summary>
		/// <param name="origin">Start position of vectors</param>
		/// <param name="from">Vector FROM which we measure angle.</param>
		/// <param name="to">Vector TO which we measure angle.</param>
		/// <param name="axis">Normal to plane on which angle is measured and vector are cast</param>
		/// <param name="lenght">Lenght of drawed vectors.</param>
		/// <param name="realScale">If set to true vector have original lenght</param>
		public static  void VisualizeSignedAngle3D (Vector3 origin, Vector3 from, Vector3 to, Vector3 axis, float lenght = 5)
		{
			float signedAngle = Vector3.SignedAngle (from, to, axis);
			float sign = Vector3.Dot (axis, Vector3.Cross (from.normalized, to.normalized));
			DrawAngles (origin, -sign * Vector3.Cross (to, from), from, to, signedAngle, "SignedAngle3D", lenght);
			DrawVector (origin, axis, lenght / 2f, Color.blue, "axis");
		}

		static void DrawAngles (Vector3 origin, Vector3 axis, Vector3 from, Vector3 to, float angle, string nameOfAngle, float lenght = 5)
		{
			#if UNITY_EDITOR
			DrawVector (origin, from, lenght, Color.red, "from");
			DrawVector (origin, to, lenght, Color.green, "to");
			UnityEditor.Handles.color = new Color32 (255, 0, 0, 25);
			UnityEditor.Handles.Label (origin, nameOfAngle + "(deg): " + System.Math.Round (angle, 0) + "\xB0");
			UnityEditor.Handles.DrawSolidArc (origin, axis, from, angle, lenght * 0.8f);
			#endif
		}

		public static void VisualizeProject (Vector3 origin, Vector3 vector, Vector3 onNormal, float lenght = 5, bool realScale = default(bool))
		{
			Vector3 result = Vector3.Project (vector, onNormal);

			float vectorLenght = (realScale) ? vector.magnitude : lenght;
			float onNormalLenght = 1;// (realScale) ? onNormal.magnitude : onNormal.magnitude / vector.magnitude * 5f;
			float projectedLenght = (realScale) ? Vector3.Project (vector, result).magnitude : Vector3.Project (vector, result).magnitude * lenght / vector.magnitude;
//		
			DrawDottedLine (vector.normalized * vectorLenght, result.normalized * projectedLenght, 3, funkyBlue);

			DrawVector (origin, vector, vectorLenght, Color.green, "vector");
			DrawVector (origin, result, projectedLenght, Color.red, "result", new Vector3 (0, 0.5f));
			DrawVector (origin, onNormal, onNormalLenght, funkyBlue, "onNormal");

		}

		static void DrawDottedLine (Vector3 p2, Vector3 p1, float screenSpaceSize, Color color)
		{
			#if UNITY_EDITOR
			Color temp = UnityEditor.Handles.color;
			UnityEditor.Handles.color = color;
			UnityEditor.Handles.DrawDottedLine (p1, p2, screenSpaceSize);
			UnityEditor.Handles.color = temp;
			#endif
		}

		public static Vector3 Round (this Vector3 v, int digits)
		{
			v.x = (float)System.Math.Round (v.x, digits);
			v.y = (float)System.Math.Round (v.y, digits);
			v.z = (float)System.Math.Round (v.z, digits); 
			return v;
		}

		internal static void ShowVectorValue (Vector3 origin, string name, Vector3 value, Color color = default(Color), Vector3 labelOffset = default(Vector3))
		{
			#if UNITY_EDITOR
			Color temp2 = UnityEditor.Handles.color;
			GUIStyle g = new GUIStyle ();	
			g.normal.textColor = color;
			System.Text.StringBuilder sb = new System.Text.StringBuilder ();
			sb.AppendFormat (name + " ({0}, {1}, {2})", System.Math.Round (value.x, 2), System.Math.Round (value.y, 2), System.Math.Round (value.z, 2));
			UnityEditor.Handles.Label (origin + labelOffset, sb.ToString (), g);
			UnityEditor.Handles.color = temp2;
			#endif
		}

		public 	static void ShowLabel (Vector3 origin, string name, Color color = default(Color), Vector3 labelOffset = default(Vector3))
		{
			#if UNITY_EDITOR
			Color temp2 = UnityEditor.Handles.color;
			GUIStyle g = new GUIStyle ();	
			g.normal.textColor = color;
			UnityEditor.Handles.Label (origin + labelOffset, name, g);
			UnityEditor.Handles.color = temp2;
			#endif
		}

		public 	static void ShowVectorLabel (Vector3 origin, Vector3 valueToDisplay, Color color = default(Color), Vector3 labelOffset = default(Vector3))
		{
			#if UNITY_EDITOR
			Color temp2 = UnityEditor.Handles.color;
			GUIStyle g = new GUIStyle ();	
			g.normal.textColor = color;
			UnityEditor.Handles.Label (origin + labelOffset, "(" + valueToDisplay.x + "," + valueToDisplay.y + "," + valueToDisplay.z + ")", g);
			UnityEditor.Handles.color = temp2;
			#endif
		}
	}
}

