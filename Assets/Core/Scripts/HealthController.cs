using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HealthController : MonoBehaviour
{
    public int Health;
    public int MaxHealth;

    public void TakeHit(int damage)
    {
        Health -= damage;

        if (Health < 0)
            Destroy(gameObject);
    }

    public void SetHealth(int bonusHealth)
    {
        Health += bonusHealth;

        if (Health > MaxHealth)
            Health = MaxHealth;
    }
}
