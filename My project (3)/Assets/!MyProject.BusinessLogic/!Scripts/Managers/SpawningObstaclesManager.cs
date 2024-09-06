using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawningObstaclesManager : MonoBehaviour
{

    public GameObject SpawningObstacle;

    public float MinVal = -10f;

    public float MaxVal = 10f;

    private Vector3 _startPosition;

    private Vector3 _randomPosition;

    void Start()
    {
        _startPosition = transform.position;
    }

    void Spawning()
    {
        _randomPosition = _startPosition + new Vector3(Random.Range(MinVal, MaxVal), 0, Random.Range(MinVal, MaxVal));

        Instantiate(SpawningObstacle, _randomPosition, Quaternion.identity);
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
