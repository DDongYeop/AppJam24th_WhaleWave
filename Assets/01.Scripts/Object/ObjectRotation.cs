using System;
using System.Collections;
using UnityEngine;

public class ObjectRotation : MonoBehaviour
{
    [SerializeField] private float _duration;
    [SerializeField] private float _rotationEach;
    private Quaternion startRot;

    private void Awake()
    {
        startRot = transform.rotation;
    }

    private void OnEnable()
    {
        transform.rotation = startRot;
        transform.Rotate(new Vector3(0, _rotationEach * .5f, 0));
        StartCoroutine(RotateCo(-_rotationEach));
    }

    private IEnumerator RotateCo(float addRot)
    {
        Vector3 startRot = transform.eulerAngles;
        Vector3 endRot = startRot + new Vector3(0, addRot, 0);
        float currentTime = 0;
        
        while (currentTime < _duration)
        {
            yield return null;
            currentTime += Time.deltaTime;
            float time = currentTime / _duration;
            transform.rotation = Quaternion.Euler(Vector3.Slerp(startRot, endRot, time));
        }
        
        transform.rotation = Quaternion.Euler(endRot);
        StartCoroutine(RotateCo(-addRot));
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }
}
