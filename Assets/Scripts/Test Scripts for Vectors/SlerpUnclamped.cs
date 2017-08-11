using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityBerserkersGizmos;

public class SlerpUnclamped : MonoBehaviour
{
	[SerializeField]Vector3 startPosition;
	[SerializeField]Vector3 endPosition = Vector3.zero;
	[SerializeField]float t;
	IEnumerator myLerp;
	[SerializeField] int howfuther;

	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.L)) {
			myLerp = VectorSlerpUnclamped (startPosition, endPosition, t);			
			StartCoroutine (routine: myLerp);
		}
		howfuther = Mathf.Clamp (howfuther, 1, 10);
	}

	void OnDrawGizmos ()
	{
		GizmosForVector.VisualizeSlerpUnclamped (startPosition, endPosition, howfuther);
	}


	public IEnumerator VectorSlerpUnclamped (Vector3 startPosition, Vector3 endPosition, float time)
	{
		float lerpTime = time;
		float currentTime = 0;
		float percentage = 0;

		while (currentTime < time * howfuther) {
			currentTime += Time.deltaTime;
			percentage = currentTime / time; 
			transform.position = Vector3.SlerpUnclamped (a: startPosition, b: endPosition, t: percentage);
			yield return null;
		}
	}


}
