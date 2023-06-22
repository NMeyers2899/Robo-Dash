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

    [Tooltip("Determines whether or not the player should be hit by obstacles.")]
    private bool _shouldBeHit = true;

    [Tooltip("The camera that is following the player.")]
    [SerializeField]
    private CameraMovementBehavior _camera;

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
        // If the player presses the given key or left click, if they are off the ground, and have at least one dash left, push them forward.
        else if((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && !_isOnGround && _dashes > 0)
        {
            _rigidbody.AddForce(Vector3.forward * 50, ForceMode.Impulse);
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

            _camera.DampeningHeight = transform.position.y + 1.5f;
        }
            
        // If the other is an obstacle, remove the player's velocity on the z and send them backwards.
        else if (other.gameObject.CompareTag("Obstacle") && _shouldBeHit)
        {
            // Don't allow the player to jump or dash after hitting an obstacle.
            _dashes = 0;

            // Reset the velocity on the z-axis, and then send the player back.
            _rigidbody.velocity = new Vector3(0, _rigidbody.velocity.y, 0);
            _rigidbody.AddForce(Vector3.back * 75, ForceMode.Impulse);
            RoutineBehavior.Instance.StartNewTimedAction(arguments => _rigidbody.AddForce(Vector3.forward * 72, ForceMode.Impulse), TimedActionCountType.SCALEDTIME, 0.1f);

            // Turn the collider off for a fraction of a second, and then turn it back on.
            _shouldBeHit = false;
            RoutineBehavior.Instance.StartNewTimedAction(arguments => _shouldBeHit = true, TimedActionCountType.SCALEDTIME, 0.2f);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // If the other is a floor, set _isOnGround to false.
        if (other.gameObject.CompareTag("Floor"))
            _isOnGround = false;
    }
}
