using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UIElements;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;



public class PlayerController : MonoBehaviour
{

    [SerializeField] private Player _player = new();

    [SerializeField] private Transform _cameraTransform;

    [SerializeField] private float _moveSpeed = 3;

    [SerializeField] private float _runSpeed = 7;




    // Update is called once per frame
    void Update()
    { 

        Movement();

        if (Input.GetKey(KeyCode.Space))
            transform.position += new Vector3(0, 7, 0) * Time.deltaTime;
        
    }

    

    private void Movement()
    {
        Vector3 forward = _cameraTransform.forward;

        Vector3 right = _cameraTransform.right;

        forward.y = 0;
        right.y = 0;

        forward.Normalize();
        right.Normalize();

        Vector3 moveDirection = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            moveDirection += forward;
        }

        if (Input.GetKey(KeyCode.S))
        {
            moveDirection -= forward;
        }

        if (Input.GetKey(KeyCode.A))
        {
            moveDirection -= right;
        }

        if (Input.GetKey(KeyCode.D))
        {
            moveDirection += right;
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            transform.position += moveDirection * _runSpeed * Time.deltaTime;
        }
        else
        {
            transform.position += moveDirection * _moveSpeed * Time.deltaTime;
        }

        if (moveDirection != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(moveDirection);
        }
    }

}
