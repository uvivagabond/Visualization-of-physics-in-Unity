using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityBerserkersGizmos
{
	internal class DataForCasting
	{
		Vector3 direction, scale, originOfCastShape, endOfCastShape;
		Transform t;
		Quaternion rotation;
		// Constructor for Box2D
		internal DataForCasting (Collider2D collider2D, Vector3 direction, float distance, bool setOffsetToZero = !default(bool))
		{
			this.t = collider2D.GetComponent<Transform> ();
			this.scale = t.lossyScale;
			Vector3 ofset;
			ofset = Vector3.Scale ((Vector3)collider2D.offset, new Vector3 (scale.x, scale.y));//t.TransformVector ((Vector3)collider2D.offset);//
			SetCommonValuesFor2DAnd3D (direction, distance, ofset);
		}
		// Constructor for Nvidia PhysX
		internal DataForCasting (Collider collider, Vector3 direction, float distance)
		{
			this.t = collider.GetComponent<Transform> ();
			Vector3 ofset = new Vector3 (0f, 0f);
			SetCommonValuesFor2DAnd3D (direction, distance, ofset);
		}

		void SetCommonValuesFor2DAnd3D (Vector3 direction, float distance, Vector3 ofset)
		{
			this.direction = new Vector3 (direction.x, direction.y, direction.z).normalized;
			this.direction.Normalize ();
			this.scale = t.lossyScale;
			this.originOfCastShape = t.position + t.TransformDirection (ofset);
			this.endOfCastShape = originOfCastShape + this.direction * distance;
			this.rotation = t.rotation;
		}

		internal void GetDataForCasting (out Vector3 origin, out  Vector3 endOfBC, out  Vector3 direction, out  Quaternion rotation, out  Vector3 scale)
		{
			this.GetDataForCasting (out origin, out  endOfBC, out direction, out rotation);
			scale = this.scale;
		}

		internal void GetDataForCasting (out Vector3 origin, out  Vector3 endOfBC, out  Vector3 direction, out  Quaternion rotation)
		{
			this.GetDataForCasting (out origin, out direction);
			endOfBC = this.endOfCastShape;
			rotation = this.rotation;
		}

		internal void GetDataForCasting (out Vector3 origin, out  Quaternion rotation, out  Vector3 direction, out  Vector3 scale)
		{
			this.GetDataForCasting (out origin, out direction);
			scale = this.scale;
			rotation = this.rotation;
		}

		internal void GetDataForCasting (out Vector3 origin, out  Vector3 direction, out  Vector3 scale)
		{
			this.GetDataForCasting (out origin, out direction);
			scale = this.scale;
		}



		public void GetDataForCasting (out Vector3 origin, out  Vector3 direction)
		{
			origin = this.originOfCastShape;
			direction = this.direction;
		}

		public void GetDataForCasting (out Vector3 origin, out  Quaternion rotation, out  Vector3 scale)
		{
			origin = this.originOfCastShape;
			rotation = this.rotation;
			scale = this.scale;
		}
	}
}




