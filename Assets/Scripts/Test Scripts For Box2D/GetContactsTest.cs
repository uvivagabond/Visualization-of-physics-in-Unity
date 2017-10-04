using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityBerserkersGizmos;

[ExecuteInEditMode]
public class GetContactsTest : MonoBehaviour
{
	[SerializeField]Rigidbody2D rig;
	[SerializeField]Collider2D kolliderKtoryDotyka;
	[SerializeField]ContactFilter2D cf = new ContactFilter2D ();
	[SerializeField]LayerMask layerMask = -1;
	[Space (11)]
	[SerializeField] ContactPoint2DSerialized cps;


	void Update ()
	{
		ContactPoint2D[] cp = new ContactPoint2D[11];
		Collider2D[] colliders = new Collider2D[11];

		Physics2D.GetContacts (collider: kolliderKtoryDotyka, contacts: cp);

		kolliderKtoryDotyka.GetContacts (contacts: cp);
		kolliderKtoryDotyka.GetContacts (contactFilter: cf, contacts: cp);
//
//
//		rig.GetContacts (colliders: colliders);
//		rig.GetContacts (contactFilter: cf, colliders: colliders);
//
//		rig.GetContacts (contacts: cp);
//		rig.GetContacts (contactFilter: cf, contacts: cp);
		cps = new ContactPoint2DSerialized (cp [0]);
	}

	void OnDrawGizmos ()
	{
		GizmosForPhysics2D.VizualizeGetContacts (kolliderKtoryDotyka);
	}

}

[System.Serializable]
struct ContactPoint2DSerialized
{
	public Collider2D collider;
	public Collider2D otherCollider;
	public Rigidbody2D rigidbody;
	public Rigidbody2D otherRigidbody;
	[Space (10)]
	public bool enabled;
	[Space (10)]
	public Vector2 normal;
	public Vector2 point;
	public Vector2 relativeVelocity;
	[Space (10)]
	public float normalImpulse;
	public float separation;
	public float tangentImpulse1M;

	public ContactPoint2DSerialized (ContactPoint2D contactPoint2D)
	{		
		this.collider = contactPoint2D.collider;
		this.otherCollider = contactPoint2D.otherCollider;
		this.rigidbody = contactPoint2D.rigidbody;
		this.otherRigidbody = contactPoint2D.otherRigidbody;
		this.enabled = contactPoint2D.enabled;

		this.normal = GizmosForVector.Round (contactPoint2D.normal, 2);
		this.point = GizmosForVector.Round (contactPoint2D.point, 2);
		this.relativeVelocity = contactPoint2D.relativeVelocity;// GizmosForVector.Round (contactPoint2D.relativeVelocity, 2);

		this.normalImpulse = contactPoint2D.normalImpulse;
		this.separation = contactPoint2D.separation;
		this.tangentImpulse1M = contactPoint2D.tangentImpulse * 1000000; 
	}

}
