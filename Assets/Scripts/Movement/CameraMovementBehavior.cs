using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovementBehavior : MonoBehaviour
{
    [Tooltip("The subject the camera will follow.")]
    [SerializeField]
    private GameObject _subject;

    [Tooltip("How high the subject must be before the camera begins to follow it upwards.")]
    [SerializeField]
    private float _dampeningHeight;

    /// <summary>
    /// How high the subject must be before the camera begins to follow it upwards.
    /// </summary>
    public float DampeningHeight { get { return _dampeningHeight;}  set { _dampeningHeight = value; } }

    // Update is called once per frame
    void Update()
    {
        Vector3 subjectPosition = _subject.transform.position;

        if(subjectPosition.y < _dampeningHeight)
            transform.position = new Vector3(subjectPosition.x + 6, _dampeningHeight, subjectPosition.z + 2.5f);
        else
            transform.position = new Vector3(subjectPosition.x + 6, subjectPosition.y + _dampeningHeight, subjectPosition.z + 2.5f);
    }       
}
