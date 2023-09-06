using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerBehavior : MonoBehaviour
{
    public delegate LevelBehavior ChangeLevel();

    [SerializeField]
    private LevelBehavior[] _levels;
}
