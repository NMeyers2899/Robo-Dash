using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    [Tooltip("The health behavior attached to the player.")]
    private HealthBehavior _healthBehavior;

    [Tooltip("The movement behavior attached to the player.")]
    private PlayerMovementBehavior _playerMovement;

    private void Awake()
    {
        _healthBehavior = GetComponent<HealthBehavior>();
        _playerMovement = GetComponent<PlayerMovementBehavior>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Should Get Hit");
        }
    }
}
