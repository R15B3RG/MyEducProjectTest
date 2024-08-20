using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UIElements;
using Vector3 = UnityEngine.Vector3;


public class NewBehaviourScript : MonoBehaviour
{

    [SerializeField] private GameObject _moveCube;

    // Start is called before the first frame update
    void Start()
    {

        Transform myTransform = transform;

        Vector3 myPosition = transform.position;

        transform.position += new Vector3(0, 0, 0);

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, 0, 3) * Time.deltaTime;

        
    }

    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag != "Terrain")
        {

            Destroy(gameObject);

        }
       
    }
}
