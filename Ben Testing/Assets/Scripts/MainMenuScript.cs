using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour {

    public void StartGameButton(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

    public void QuitGameButton()
    {
        Application.Quit();
    }
	
}

