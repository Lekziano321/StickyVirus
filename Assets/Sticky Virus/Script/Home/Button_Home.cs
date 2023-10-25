using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Button_Home : MonoBehaviour
{
    public GameObject shoPanel;
    public GameObject background;
    public void Start()
    {
        shoPanel.SetActive(false);
        background.SetActive(false);
        Time.timeScale = 1;
    }
    public void GoToGameScene()
    {
        SceneManager.LoadScene("Level_1");
    }

    public void GoToShop()
    {
        SceneManager.LoadScene("Shopv2");
        Invoke("Delay", 1.25f);
    }

    public void Delay()
    {
        shoPanel.SetActive(true);
    }

    public void GoToMainMenu()
    {
        shoPanel.SetActive(false);
        background.SetActive(false);
    }

}
