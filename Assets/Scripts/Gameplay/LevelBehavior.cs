using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBehavior : MonoBehaviour
{
    [Tooltip("The level that comes after this one.")]
    [SerializeField]
    private LevelBehavior _nextLevel;

    /// <summary>
    /// The level that comes after this one.
    /// </summary>
    public LevelBehavior NextLevel { get { return _nextLevel; }  set { _nextLevel = value; } }
}
