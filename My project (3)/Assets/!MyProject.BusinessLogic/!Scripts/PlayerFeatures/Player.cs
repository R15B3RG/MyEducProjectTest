using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Player : MonoBehaviour
{

    [SerializeField] private GameObject _player;

    [SerializeField] private float _health = 3;

    public float Health
    {
        get => _health;
        set => _health = value;
    }
    void OnCollisionEnter(Collision coll)
    {
        if (!coll.gameObject.CompareTag("Terrain"))
        {

            Health -= 1;

            if (Health == 0)
            {
                Destroy(_player);

            }

        }

    }
}
