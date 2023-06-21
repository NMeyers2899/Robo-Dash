using JetBrains.Rider.Unity.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementBehavior : MonoBehaviour
{
    [Tooltip("How far the player can move in a given direction.")]
    [SerializeField]
    private float _speed = 1.0f, _jumpForce = 1.0f;

    [Tooltip("The max amount of movement the player can have on the z-axis.")]
    [SerializeField]
    private float _maxSpeed = 5.0f;

    [Tooltip("The amount of times the player can dash while in the air.")]
    [SerializeField]
    private int _maxDashes = 1, _dashes;

    [Tooltip("The rigidbody attached to the player.")]
    private Rigidbody _rigidbody;

    [Tooltip("Lets the player know whether or not its on the ground.")]
    private bool _isOnGround = false;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _dashes = _maxDashes;
    }

    // Update is called once per frame
    void Update()
    {
        // Adds a force to the player's z-axis.
        _rigidbody.velocity += Vector3.forward * _speed;

        // If the player presses the given key or left click, and if they are on the ground, they jump.
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && _isOnGround)
        {
            _rigidbody.velocity += Vector3.up * _jumpForce;
            _isOnGround = false;
        }
        else if((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && !_isOnGround && _dashes > 0)
        {
            _rigidbody.AddForce(Vector3.forward * 75, ForceMode.Impulse);
            _dashes--;
        }

        // If the player's velocity on the z is greater than the max speed, set it to the max speed.
        if(_rigidbody.velocity.z > _maxSpeed)
            _rigidbody.velocity = new Vector3(0, _rigidbody.velocity.y, _maxSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        // If the other is a floor, set _isOnGround to true.
        if (other.gameObject.CompareTag("Floor"))
        {
            _isOnGround = true;

            // Resets the number of dashes the player can do.
            _dashes = _maxDashes;
        }
            
        // If the other is an obstacle, remove the player's velocity on the z and send them backwards.
        else if (other.gameObject.CompareTag("Obstacle"))
        {
            _rigidbody.velocity = new Vector3(0, _rigidbody.velocity.y, 0);
            _rigidbody.AddForce(Vector3.back * 75, ForceMode.Impulse);

            ToggleCollider();
            RoutineBehavior.Instance.StartNewTimedAction(arguments => ToggleCollider(), TimedActionCountType.SCALEDTIME, 0.2f);
        }
    }

    private void ToggleCollider()
    {
        SphereCollider collider = GetComponent<SphereCollider>();

        if (collider.enabled)
            collider.enabled = false;
        else 
            collider.enabled = true;
    }
}
