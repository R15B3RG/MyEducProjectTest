using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Threading;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;
using Quaternion = UnityEngine.Quaternion;


public class Obstacle : MonoBehaviour
{
    [SerializeField] private GameObject _obstacle;
    // Start is called before the first frame update

    public float Speed = 5.0f;

    public float RandPosX;

    public float RandPosZ;

    private Vector3 _newPosition;

    private Vector3 _initPosition;

    void Start()
    {
        _initPosition = transform.position;

        RandPosX = Random.Range(-1.5f, 1.5f);

        RandPosZ = Random.Range(-1.5f, 1.5f);

        _newPosition = new Vector3(RandPosX, 0, RandPosZ);
    }


    void Update()
    {

        transform.position += new Vector3(_newPosition.x, 0, _newPosition.z) * Time.deltaTime * Speed;

        if (Vector3.Distance(transform.position, _newPosition) <= 1)
        {
            
        }

        transform.position = Vector3.MoveTowards(transform.position, _initPosition, Speed * Time.deltaTime);

    }
}
