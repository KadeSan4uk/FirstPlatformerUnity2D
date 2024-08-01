using UnityEngine;

public class HealthController : MonoBehaviour
{
    [SerializeField] private HealthBar _healthBar;
    public int Health;
    public int MaxHealth;

    private void Start()
    {
        Health = MaxHealth;
        UpdateHealthBar();
    }

    public void TakeHit(int damage)
    {
        Health -= damage;
        if (Health <= 0)
        {
            Health = 0;
            Destroy(gameObject);
        }
        UpdateHealthBar();
    }

    public void SetHealth(int bonusHealth)
    {
        Health += bonusHealth;
        if (Health > MaxHealth)
        {
            Health = MaxHealth;
        }
        UpdateHealthBar();
    }

    private void UpdateHealthBar()
    {
        if (_healthBar != null)
        {
            _healthBar.UpdateHealthBar(MaxHealth, Health);
        }
    }
}
