﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public void PlayTheGame()
    {
        SceneManager.LoadScene(1);
    }
    public void QuitTheGame()
    {
        Application.Quit();
    }
}
