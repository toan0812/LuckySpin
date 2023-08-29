using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScenes : GameLuckSpin
{
    public void LoadNewScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        Debug.Log("Load Successfull");
    }
}
