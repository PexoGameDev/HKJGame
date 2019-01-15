using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public Button StartGame;
    public Button QuitGame;

    void Awake()
    {
        StartGame.onClick.AddListener(delegate { SceneManager.LoadScene("Main"); Time.timeScale = 1; });
        QuitGame.onClick.AddListener(delegate { Application.Quit(); });
    }
}
