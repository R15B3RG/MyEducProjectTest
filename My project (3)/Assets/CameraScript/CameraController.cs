using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    [SerializeField] private Transform _followTarget;

    [SerializeField] private float _distance = 5;

    [SerializeField] private float _rotationSpeed = 2f;

    [SerializeField] private float _minVerticalAngle = -20f;
    [SerializeField] private float _maxVerticalAngle = 45f;

    [SerializeField] private Vector2 _framingOffset;


    private float _rotationY;
    private float _rotationX;

    void Update()
    {
        _rotationY += Input.GetAxis("Mouse X") * _rotationSpeed;

        _rotationX += Input.GetAxis("Mouse Y") * _rotationSpeed;
        _rotationX = Math.Clamp(_rotationX, _minVerticalAngle, _maxVerticalAngle);

        var targetRotation = Quaternion.Euler(_rotationX, _rotationY, 0);

        var focusPosition = _followTarget.position + new Vector3(_framingOffset.x, _framingOffset.y);

        transform.position = focusPosition - targetRotation * new Vector3(0, 0, _distance);

        transform.rotation = targetRotation;
    }
}
