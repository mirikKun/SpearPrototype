using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    
    [SerializeField] private MenuController menuController;
    [SerializeField] private AttemptShow attemptShow;
    [SerializeField] private int tryCount;
    private int _currentAttemptCount=4;
    public static GameManager GM;
    
    private void Awake()
    {
        if (GM == null)
            GM = GetComponent<GameManager>();
    }

    private void Start()
    {
        attemptShow.ChangeAttemptsCount(_currentAttemptCount);
    }

    public void Victory()
    {
        menuController.OpenVictoryMenu();
    }

    public void TryAttempt()
    {
        _currentAttemptCount--;
        attemptShow.ChangeAttemptsCount(_currentAttemptCount);
        if (_currentAttemptCount < 0)
        {
            Lose();
        }
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Lose()
    {
        menuController.OpenLoseMenu();
    }
  
}
