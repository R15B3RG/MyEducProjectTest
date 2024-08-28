using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform _followTarget;

    [SerializeField] private float _distance = 5f;
    [SerializeField] private float _rotationSpeed = 2f;

    [SerializeField] private float _minVerticalAngle = -20f;
    [SerializeField] private float _maxVerticalAngle = 45f;

    [SerializeField] private Vector2 _framingOffset;

    [SerializeField] private Transform _cam;

    private float _rotationY;
    private float _rotationX;

    void Update()
    {
        // Rotera kameran med musens input
        _rotationY += Input.GetAxis("Mouse X") * _rotationSpeed;
        _rotationX -= Input.GetAxis("Mouse Y") * _rotationSpeed;
        _rotationX = Mathf.Clamp(_rotationX, _minVerticalAngle, _maxVerticalAngle);

        // Beräkna kamerans rotation och position
        Quaternion targetRotation = Quaternion.Euler(_rotationX, _rotationY, 0);
        Vector3 focusPosition = _followTarget.position + new Vector3(_framingOffset.x, _framingOffset.y, 0);
        _cam.position = focusPosition - targetRotation * Vector3.forward * _distance;
        _cam.rotation = targetRotation;

        // Flytta spelarobjektet i relation till kamerans riktning
        Vector3 camForward = _cam.forward;
        Vector3 camRight = _cam.right;

        camForward.y = 0; // Vi ignorerar vertikal rörelse för att hålla det plant
        camRight.y = 0;

        Vector3 moveDir = Input.GetAxis("Vertical") * camForward + Input.GetAxis("Horizontal") * camRight;
        moveDir.Normalize();

        // Flytta och rotera spelarobjektet
        if (moveDir.magnitude > 0)
        {
            _followTarget.rotation = Quaternion.LookRotation(moveDir);
            _followTarget.position += moveDir * _rotationSpeed * Time.deltaTime;
        }
    }
}

