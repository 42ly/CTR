using System.Collections;
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
    public Text headHP;
    public Text torsoHP;
    public Text leftLegHP;
    public Text rightLegHP;
    public Text rightArmHP;
    public Text leftArmHP;

    private void updateHP()
    {
        LevelData levelData = GameObject.Find("GameManager").GetComponent<LevelData>();
        if (levelData.playerInstance)
        {
            headHP.text = levelData.playerInstance.GetComponent<EntityData>().headHP.ToString();
            torsoHP.text = levelData.playerInstance.GetComponent<EntityData>().torsoHP.ToString();
            leftArmHP.text = levelData.playerInstance.GetComponent<EntityData>().leftArmHP.ToString();
            rightArmHP.text = levelData.playerInstance.GetComponent<EntityData>().rightArmHP.ToString();
            leftLegHP.text = levelData.playerInstance.GetComponent<EntityData>().leftLegHP.ToString();
            rightLegHP.text = levelData.playerInstance.GetComponent<EntityData>().rightLegHP.ToString();
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
        pauseMenu.gameObject.SetActive(false);
        mainMenuButton.onClick.AddListener(loadMainMenu);
        backButton.onClick.AddListener(backToGame);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            backToGame();
        }
        updateHP();
    }
}
