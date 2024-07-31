using TMPro;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerHP : MonoBehaviour
{
    public TextMeshProUGUI TextHealth;
    public GameObject Player;

    private float _playerHealth;

    void Update()
    {
        if (_playerHealth <= 0)
        {
            TextHealth.text = _playerHealth.ToString("Dead");
            // Здесь можно добавить дополнительную логику, например, отображение экрана смерти
        }
        if (Player != null)
        {
            _playerHealth = Player.GetComponent<HealthController>().Health;
            TextHealth.text = _playerHealth.ToString();
        }
    }
}
