using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadScene : MonoBehaviour
{
    // Start is called before the first frame update
    public void LoadScene(int level)
    {
        if (level == 2)
        {
            SceneManager.LoadScene(level, LoadSceneMode.Additive);
        }
        else SceneManager.LoadScene(level);
    }
    public void LoadSceneAfterPause( int level)
    {
        if (level == 1 )
        {
            SceneManager.UnloadSceneAsync(2);
        }
        
    }

    // Update is called once per frame
    public void Exit()
    {
        Application.Quit();
    }
}
