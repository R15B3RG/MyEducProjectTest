using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Threading;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;
using Quaternion = UnityEngine.Quaternion;
using Vector2 = System.Numerics.Vector2;


public class Obstacle : MonoBehaviour
{
    [SerializeField] private GameObject _obstacle;


    // Start is called before the first frame update

    public float Speed = 3f;

    public float MinVal = -10f;

    public float MaxVal = 10f;

    private Vector3 _newPosition;

    private Vector3 _initPosition;

    private bool _isMoving = true;

    void Start()
    {
        _initPosition = transform.position;

        SetNewRandomPosition();

    }

    void SetNewRandomPosition()
    {

        _newPosition = _initPosition + new Vector3(Random.Range(MinVal, MaxVal), 0, Random.Range(MinVal, MaxVal));

        Debug.Log(_newPosition);
    }


    void Update()
    {

        if (_isMoving)
        {
            transform.position = Vector3.MoveTowards(transform.position, _newPosition, Speed * Time.deltaTime);

            if (Vector3.Distance(transform.position, _newPosition) <= 2)
            {
                _isMoving = false;
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, _initPosition, Speed * Time.deltaTime);

            if (Vector3.Distance(transform.position, _initPosition) <= 1)
            {
                SetNewRandomPosition();

                _isMoving = true;

               
            }
        }

    }
}
