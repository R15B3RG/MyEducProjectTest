using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawningObstacles : MonoBehaviour
{

    public GameObject SpawningObstacle;

    public float MinVal = -10f;

    public float MaxVal = 10f;

    private Vector3 _startPosition;

    private Vector3 _randomPosition;
    // Start is called before the first frame update
    void Start()
    {
        _startPosition = transform.position;
    }

    void Spawning()
    {
        _randomPosition = _startPosition + new Vector3(Random.Range(MinVal, MaxVal), 0, Random.Range(MinVal, MaxVal));

        Instantiate(SpawningObstacle, _randomPosition, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision coll)
    {
        if (!coll.gameObject.CompareTag("Terrain"))
        {
            Destroy(SpawningObstacle);

            Spawning();
        }
    }
}
