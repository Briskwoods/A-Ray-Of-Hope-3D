using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public string mainMenuScene;
    public GameObject pauseMenu;
    static bool isPaused;
   //public GameObject Player;
    public CameraController camera;

	// Use this for initialization
	void Start ()
    {

    }
	
	// Update is called once per frame
	void Update ()
    {
		if(Input.GetKeyDown(KeyCode.Escape))

        {
            if (isPaused == true)
            {
                isPaused = false;
                pauseMenu.SetActive(false);
                Time.timeScale = 1f;
               // Player.GetComponent<CharacterController>().enabled = true;
                AudioListener.volume = 1;
                camera.GetComponent<CameraController>().enabled = true;
            }
            else
            {
                isPaused = true;
                pauseMenu.SetActive(true);
                Time.timeScale = 0f;
              // Player.GetComponent<CharacterController>().enabled = false;
                camera.GetComponent<CameraController>().enabled = false;
                AudioListener.volume = 0;
            }
        } 
	}

    public void ResumeGame()
    {
        isPaused = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void ReturnToMain()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(mainMenuScene);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
