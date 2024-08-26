using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;
using UnityEngine.UIElements;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;


public class Player : MonoBehaviour
{

    [SerializeField] private GameObject _player;

    [SerializeField] private float _health = 3;

    public float Health
    {
        get => _health; 
        set => _health = value;
    }

    private Vector3 _startPosition;

    void Start()
    {
        _startPosition = transform.position;
    }

    void Spawning()
    {
        transform.position = _startPosition;

        Instantiate(_player, _startPosition, Quaternion.identity);
    }



    // Update is called once per frame
    void Update()
    {
        //transform.position += new Vector3(0, 0, 3) * Time.deltaTime;

        Movement();

        if (Input.GetKey(KeyCode.Space))
            transform.position += new Vector3(0, 7, 0) * Time.deltaTime;
        

        Running();
    }

    private void Running()
    {
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W))
        {
            transform.position += new Vector3(0, 0, 7) * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.S))
        {
            transform.position += new Vector3(0, 0, -7) * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(7, 0, 0) * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(-7, 0, 0) * Time.deltaTime;
        }
    }

    private void Movement()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += new Vector3(0, 0, 3) * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.position += new Vector3(0, 0, -3) * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(3, 0, 0) * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(-3, 0, 0) * Time.deltaTime;
        }
    }

    void OnCollisionEnter(Collision coll)
    {
        if (!coll.gameObject.CompareTag("Terrain"))
        {

            Health -= 1;

            if (Health == 0)
            {
                Destroy(_player);

                Spawning();
            }

        }

    }
}
