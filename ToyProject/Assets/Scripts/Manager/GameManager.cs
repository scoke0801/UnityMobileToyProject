using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 
public class GameManager
{
    bool _isGamePaused = false;
    public bool IsGamePaused { get { return _isGamePaused; } }

    private GameObject _player;
    public GameObject Player { get { return _player; } set { _player = value; } }

    public void GamePause(bool pause)
    {
        Time.timeScale = (pause) ? 0 : 1;
        _isGamePaused = pause;
    }
}