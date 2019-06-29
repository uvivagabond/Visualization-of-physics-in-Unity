using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityBerserkersGizmos;

public class LerpUnclampedTestQ : MonoBehaviour
{

    [Header("SHOWING CHANGE OF ROTATION")]
    [Space(11)]
    [Header("Press Space to start lerping")]
    [Header("Press R to reset lerpUnclamped")]
    [Space(11)]
    [Header("Quaternions in form of euler angle")]
    [SerializeField] Vector3 start = Vector3.right;
    [SerializeField] Vector3 end = Vector3.up;
    [Space(11)]

    [Range(1, 20)] [SerializeField] float lerpTime = 5;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isRotating)
        {
            Quaternion startRotation = Quaternion.Euler(start);
            Quaternion endRotation = Quaternion.Euler(end);

            IEnumerator lerp = LerpUnclamped(startRotation, endRotation, lerpTime);

            StartCoroutine(lerp);

            isRotating = true;
        }

        // when we press R we set cube to start rotation
        ResetLerpExample();

        UpdateTimer();
    }


    public IEnumerator LerpUnclamped(Quaternion startRotation, Quaternion endRotation, float lerpTime)
    {
        float currentTime = 0;
        float percentage = 0;

        while (currentTime < lerpTime)
        {
            currentTime += Time.deltaTime;
            percentage = currentTime / lerpTime;
            transform.rotation = Quaternion.LerpUnclamped(startRotation, endRotation, percentage);
            yield return null;
        }
    }

    private void ResetLerpExample()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            transform.rotation = Quaternion.Euler(start);
            isRotating = false;
            timeCount = 0;
        }
    }

    private void UpdateTimer()
    {
        if (isRotating)
        {
            timeCount += Time.deltaTime;
        }
    }


    float timeCount = 0.0f;
    bool isRotating = false;

    void OnDrawGizmos()
    {
        Quaternion startQ = Quaternion.Euler(start);
        Quaternion endQ = Quaternion.Euler(end);

        GizmosForQuaternion.Lerp(Vector3.zero, startQ, endQ, Mathf.Clamp(timeCount / lerpTime, 0, 1), BaseVectorDirection.right, 6f);
    }
}