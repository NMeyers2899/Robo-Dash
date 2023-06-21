using JetBrains.Rider.Unity.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementBehavior : MonoBehaviour
{
    [SerializeField]
    private float _speed, _maxSpeed, _jumpForce;

    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        _rigidbody.velocity += Vector3.forward * _speed;

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            _rigidbody.velocity += Vector3.up * _jumpForce;

        if(_rigidbody.velocity.z > _maxSpeed)
            _rigidbody.velocity = new Vector3(0, _rigidbody.velocity.y, _maxSpeed);
    }
}
