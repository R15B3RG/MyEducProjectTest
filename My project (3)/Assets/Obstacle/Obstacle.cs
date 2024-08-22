using System.Collections;
using System.Collections.Generic;
using System.Numerics;
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

    public float RandPosX;

    public float RandPosZ;

    private Vector3 _newPosition;

    private Vector3 _initPosition;

    private bool _isMoving = true;

    void Start()
    {
        _initPosition = transform.position;

        RandPosX = Random.Range(-1.5f, 1.5f);

        RandPosZ = Random.Range(-1.5f, 1.5f);

        _newPosition = new Vector3(RandPosX, 0, RandPosZ);
    }


    void Update()
    {

        while (true)
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
            }
        }
        //Vector3.Distance(transform.position, _newPosition) <= 2
        //transform.position += new Vector3(_newPosition.x, 0, _newPosition.z) * Speed * Time.deltaTime;
        //transform.position = Vector3.MoveTowards(transform.position, _initPosition, Speed * Time.deltaTime);

    }
}
