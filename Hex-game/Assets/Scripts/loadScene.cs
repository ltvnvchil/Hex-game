using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadScene : MonoBehaviour
{
    // Start is called before the first frame update
    public void LoadScene(int level)
    {
        Debug.Log("loadScene "+level);
        if (level == 2)
        {
            SceneManager.LoadScene(level, LoadSceneMode.Additive);
        }
        else SceneManager.LoadScene(level);
    }
    public void LoadSceneAfterPause( int level)
    {
        Debug.Log("loadScene " + level);
        if (level == 1)
        {
            SceneManager.UnloadSceneAsync(2);
        }
        else
        {
            SceneManager.UnloadSceneAsync(2);
            SceneManager.LoadScene(level);
        }
    }

    // Update is called once per frame
    public void Exit()
    {
        Application.Quit();
    }
}
