﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadScene : MonoBehaviour
{
    // Start is called before the first frame update
    public void LoadScene(int level)
    {
        SceneManager.LoadScene(level);
    }

    // Update is called once per frame
    public void Exit()
    {
        Application.Quit();
    }
}
