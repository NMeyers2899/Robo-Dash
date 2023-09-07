using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBehavior : MonoBehaviour
{
    [Tooltip("The level that comes after this one.")]
    [SerializeField]
    private LevelBehavior _nextLevel;

    [Tooltip("The fastest time the player beat the level in.")]
    private float _fastestTime;

    /// <summary>
    /// The level that comes after this one.
    /// </summary>
    public LevelBehavior NextLevel { get { return _nextLevel; } set { _nextLevel = value; } }

    /// <summary>
    /// The fastest time the player beat the level in.
    /// </summary>
    public float FastestTime { get { return _fastestTime; } set { _fastestTime = value; } }
}
