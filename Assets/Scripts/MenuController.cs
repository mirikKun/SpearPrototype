using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MenuController : MonoBehaviour
{
    
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject victoryMenu;
    [SerializeField] private GameObject loseMenu;
    private bool _gameEnded;
    private void Start()
    {
        Time.timeScale = 0;
    }

    public void OpenVictoryMenu()
    {
        _gameEnded = true;
        victoryMenu.SetActive(true);
        Time.timeScale = 0;
    }
    public void OpenLoseMenu()
    {
        _gameEnded = true;
        loseMenu.SetActive(true);
        Time.timeScale = 0;
    }
    public void ContinueGame()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
    }
    public void PauseGame()
    {
        if(_gameEnded)
            return;
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
    }
    public void RestartGame()
    {
        Time.timeScale = 1;
        victoryMenu.SetActive(false);
        GameManager.GM.Restart();
    }
    public void Exit()
    {
        Application.Quit();
    }
}
