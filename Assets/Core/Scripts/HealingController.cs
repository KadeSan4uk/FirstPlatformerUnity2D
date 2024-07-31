using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HealingController : MonoBehaviour
{
    public int CollisionHealing = 10;
    public string CollisionTag;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == CollisionTag)
        {
            HealthController Health = collision.gameObject.GetComponent<HealthController>();
            Health.SetHealth(CollisionHealing);
            Destroy(gameObject);
        }
    }
}
