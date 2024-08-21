using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UIElements;
using Vector3 = UnityEngine.Vector3;


public class ExplodeOnImpactScript : MonoBehaviour
{

    [SerializeField] private GameObject _moveCube;


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

            Destroy(gameObject);

        }
       
    }
}
