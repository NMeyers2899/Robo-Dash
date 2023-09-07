using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerBehavior : MonoBehaviour
{
    [Tooltip("The actor that the player controls.")]
    [SerializeField]
    private PlayerMovementBehavior player;

    [Tooltip("The list of levels in the game.")]
    [SerializeField]
    private LevelBehavior[] _levels;
}
