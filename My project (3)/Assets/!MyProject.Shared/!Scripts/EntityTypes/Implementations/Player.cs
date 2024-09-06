using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Player : IPlayer
{
    public bool IsDead => Health <= 0 ? true : false;

    private Guid _id = Guid.NewGuid();
    public Guid Id
    {
        get => _id;
        private set => _id = value;
    }

    [SerializeField] private float _health = 3;

    public float Health
    {
        get => _health;
        set => _health = value;
    }

}
