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




