using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Tasks : MonoBehaviour
{
    public Canvas arithmeticTaskUI;
    public Text problemText;
    public InputField solution;
    private bool onTask;
    private int correctProblems, answer;
    private void arithmeticTask()
    {
        arithmeticTaskUI.gameObject.SetActive(true);
        solution.Select();
        int num1 = Random.Range(1, 99), num2 = Random.Range(1, 99);
        problemText.text = num1.ToString() + " + " + num2.ToString() + " =";
        answer = num1 + num2;
    }
    public void loadTask(int taskNumber)
    {
        if(taskNumber == 0)
        {
            arithmeticTask();
        }
    }
    private void Start()
    {
        correctProblems = 0;
        answer = 0;
        arithmeticTaskUI.gameObject.SetActive(false);
    }
    private void Update()
    {
        if(solution && int.Parse(solution.text) == answer)
        {
            arithmeticTask();
            solution.text = "";
            correctProblems += 1;
        }
        if(correctProblems >= 10)
        {
            GetComponent<LevelData>().playerInstance.GetComponent<PlayerData>().electricity = 200;
            correctProblems = 0;
            arithmeticTaskUI.gameObject.SetActive(false);
            GameObject.Find("GameManager").GetComponent<MenuLogic>().doingTask = false;
        }
    }
}
