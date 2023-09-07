using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerBehavior : MonoBehaviour
{
    [Tooltip("The actor that the player controls.")]
    [SerializeField]
    private PlayerMovementBehavior _player;

    [Tooltip("The list of levels in the game.")]
    [SerializeField]
    private LevelBehavior[] _levels;

    [Tooltip("The timer meant to see how fast the player completes a level.")]
    private float _timer = 0.0f;

    /// <summary>
    /// The timer meant to see how fast the player completes a level.
    /// </summary>
    public float Timer { get { return _timer; } }
}
