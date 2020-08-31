using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuLogic : MonoBehaviour
{
    public Button startGameButton;
    public Button loadGameButton;
    public Button exitGameButton;

    void startGame()
    {
        SceneManager.LoadScene(1);
    }
    void loadGame()
    {

    }
    void exitGame()
    {
        Application.Quit();
    }
    private void Start()
    {
        startGameButton.onClick.AddListener(startGame);
        exitGameButton.onClick.AddListener(exitGame);
    }
}
