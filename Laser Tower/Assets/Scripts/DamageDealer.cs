﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{

    [SerializeField] int damage;

    public int GetDamage()
    {
        return damage;
    }

    public void OnTriggerEnter2D(Collider2D DamageDealer)
    {
        Destroy(gameObject);
    }

    public void Hit()
    {
        Destroy(gameObject);
    }
}
