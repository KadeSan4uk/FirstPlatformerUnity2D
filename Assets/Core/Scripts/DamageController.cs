using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DamageController : MonoBehaviour
{
    public int CollisionDamage = 10;
    public string CollisionTag;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == CollisionTag)
        {
            HealthController Health = collision.gameObject.GetComponent<HealthController>();
            Health.TakeHit(CollisionDamage);
        }
    }
}
