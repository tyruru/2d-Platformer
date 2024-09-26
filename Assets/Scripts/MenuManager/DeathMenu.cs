using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeathMenu : MonoBehaviour
{
    public GameObject deathMenu;
    public Button pauseButton;
    public GameObject weaponbar;

    private int activeScene;

    void Start()
    {
        Time.timeScale = 1f;
        deathMenu.SetActive(false);
        activeScene = SceneManager.GetActiveScene().buildIndex;
    }

    public void LoseGame()
    {
        pauseButton.gameObject.SetActive(false);
        weaponbar.gameObject.SetActive(false);
        deathMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Level" + activeScene.ToString());
        Time.timeScale = 1f;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
