using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _healthBarSlider;

    public void UpdateHealthBar(int maxHealth, int currentHealth)
    {
        _healthBarSlider.maxValue = maxHealth;
        _healthBarSlider.minValue = 0;
        _healthBarSlider.value = currentHealth;
    }
}
