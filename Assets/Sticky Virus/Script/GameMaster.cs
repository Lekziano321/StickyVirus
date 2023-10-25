using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour
{
    public GameObject restartPanel;
    public GameObject yesOrNo;
    public GameObject pausePanel;
    public GameObject continuePanel;
    public GameObject deathEffect;
    public GameObject resumeButton;
    public GameObject backToMenuButton;
    public Text timerDisplay;

    private bool asLost;
    public float timer;
    public int reward = 3;
    public int cost = 1;
    private bool isPaused;

    public void Start()
    {
        Time.timeScale = 1;
    }

    private void Update()
    {
        if (!asLost)
        {
            timerDisplay.text = timer.ToString("f0");
        }

        if (timer <= 0)
        {
            Time.timeScale = 0;
            continuePanel.SetActive(true);
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }

    public void GameOver()
    {
        deathEffect.SetActive(true);
        asLost = true;
        Invoke("Delay", 0.9f);
    }

    void Delay()
    {
        Time.timeScale = 0;
        restartPanel.SetActive(true);
    }

    public void Restart()
    {
        Time.timeScale = 0;
        yesOrNo.SetActive(true);
        restartPanel.SetActive(false);
    }

    public void GoToMainMenu()
    {
        SaveManager.Instance.SaveData();
        SceneManager.LoadScene("Home");
    }

    public void Yes()
    {
        SaveManager.Instance.SaveData();
        if (SaveManager.Instance.bacteriaCoin <= 0)
        {
            Debug.Log("Bacteria Coin Not Enough");
        }
        else
        {
            SaveManager.Instance.DecreaseBacteriaCoin(cost);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void PauseButton()
    {
        isPaused = !isPaused;
        if (isPaused)
        {
            pausePanel.SetActive(true);
            Time.timeScale = 0;
            resumeButton.SetActive(true);
            backToMenuButton.SetActive(true);
        }
        else
        {
            pausePanel.SetActive(false);
            Time.timeScale = 1;
            resumeButton.SetActive(false);
            backToMenuButton.SetActive(false);
        }
    }

    public void ContinueButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SaveManager.Instance.IncreaseBacteriaCoin(reward);
        SaveManager.Instance.SaveData();
    }

    public void ResumeButton()
    {
        isPaused = false;
        pausePanel.SetActive(false);
        Time.timeScale = 1;
        resumeButton.SetActive(false);
        backToMenuButton.SetActive(false);
    }

    public void BackToMenuButton()
    {
        Time.timeScale = 1;
        SaveManager.Instance.SaveData();
        SceneManager.LoadScene("Home");
    }
}
