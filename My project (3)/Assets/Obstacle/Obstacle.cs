using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class ExplodeOnImpact : MonoBehaviour
{
    [SerializeField] private GameObject _obstacle;
    // Start is called before the first frame update
    void Start()
    {

        Transform myTransform = transform;

        Vector3 myPosition = transform.position;

        transform.position += new Vector3(0, 0, 0);
    }
}
