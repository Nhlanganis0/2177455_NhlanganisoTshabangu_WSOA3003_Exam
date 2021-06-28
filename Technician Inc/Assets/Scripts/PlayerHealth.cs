using System.Collections;
using System.Collections.Generic;
using MLAPI;
using MLAPI.NetworkVariable;
using UnityEngine;

public class PlayerHealth : NetworkBehaviour
{
    NetworkVariableInt health = new NetworkVariableInt(100);
    public int ActualHealth = 100;

    void Update()
    {
        ActualHealth = health.Value;
    }

    public void TakeDamage(int damage)
    {
        health.Value -= damage;
    }
}
