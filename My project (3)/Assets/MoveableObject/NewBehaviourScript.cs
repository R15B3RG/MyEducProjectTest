using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.UIElements;
using Vector3 = UnityEngine.Vector3;

public class NewBehaviourScript : MonoBehaviour
{

    [SerializeField] private GameObject _gameObject;
    

    Vector3 vector = new Vector3();

    

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("It's working!");

        Transform myTransform = transform;

        Vector3 myPosition = transform.position;

        transform.position += new Vector3(0, 0, 0);

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, 0, 1) * Time.deltaTime;


    }
}
