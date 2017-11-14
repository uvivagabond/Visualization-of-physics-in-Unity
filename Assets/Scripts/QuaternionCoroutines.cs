using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class QuaternionCoroutines
{
	public static IEnumerator Slerp (Transform objectToRotate, Quaternion startRotation, Quaternion endRotation, float slerpTime)
	{
		float currentTime = 0;
		float percentage = 0;

		while (currentTime < slerpTime) {
			currentTime += Time.deltaTime;
			percentage = currentTime / slerpTime; 
			objectToRotate.rotation = Quaternion.Slerp (startRotation, endRotation, percentage);
			yield return null;
		}
	}

	public static IEnumerator SlerpUnclamped (Transform objectToRotate, Quaternion startRotation, Quaternion endRotation, float slerpTime, float howFuther)
	{
		float currentTime = 0;
		float percentage = 0;

		while (currentTime < slerpTime * howFuther) {
			currentTime += Time.deltaTime;
			percentage = currentTime / slerpTime; 
			objectToRotate.rotation = Quaternion.SlerpUnclamped (startRotation, endRotation, percentage);
			yield return null;
		}
	}

	public static IEnumerator Lerp (Transform objectToRotate, Quaternion startRotation, Quaternion endRotation, float lerpTime)
	{
		float currentTime = 0;
		float percentage = 0;

		while (currentTime < lerpTime) {
			currentTime += Time.deltaTime;
			percentage = currentTime / lerpTime; 
			objectToRotate.rotation = Quaternion.Lerp (startRotation, endRotation, percentage);
			yield return null;
		}
	}
	public static IEnumerator LerpUnclamped (Transform objectToRotate, Quaternion startRotation, Quaternion endRotation, float slerpTime, float howFuther)
	{
		float currentTime = 0;
		float percentage = 0;

		while (currentTime < slerpTime * howFuther) {
			currentTime += Time.deltaTime;
			percentage = currentTime / slerpTime; 
			objectToRotate.rotation = Quaternion.LerpUnclamped (startRotation, endRotation, percentage);
			yield return null;
		}
	}
}
