﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuLogic : MonoBehaviour
{
    public Canvas pauseMenu;
    public Button backButton;
    public Button mainMenuButton;
    public Button saveButton;
    public Button randomTask;
    public Text health;
    public Text electricity;
    public bool doingTask;
    private void loadRandomTask()
    {
        if (doingTask == true)
        {
            GetComponent<Tasks>().arithmeticTaskUI.gameObject.SetActive(false);
            doingTask = false;
        }
        else
        {
            doingTask = true;
            GameObject.Find("GameManager").GetComponent<Tasks>().loadTask(0);
        }
    }
    private void loadMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    private void backToGame()
    {
        if(pauseMenu.gameObject.activeSelf)
        {
            Time.timeScale = 1;
            pauseMenu.gameObject.SetActive(false);
        }
        else
        {
            Time.timeScale = 0;
            pauseMenu.gameObject.SetActive(true);
        }
    }
    private void Start()
    {
        Time.timeScale = 1;
        doingTask = false;
        pauseMenu.gameObject.SetActive(false);
        mainMenuButton.onClick.AddListener(loadMainMenu);
        backButton.onClick.AddListener(backToGame);
        randomTask.onClick.AddListener(loadRandomTask);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            backToGame();
        }
        electricity.text = "Electricity: " + GetComponent<LevelData>().playerInstance.GetComponent<PlayerData>().electricity.ToString();
        health.text = "Health: " + GetComponent<LevelData>().playerInstance.GetComponent<EntityData>().getHealth().ToString();
    }
}
