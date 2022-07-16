using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameMenu : MonoBehaviour
{

    //Audio:
    public AudioSource src;
    public AudioClip PopUpSoundEffect; 
    public AudioClip ButtonSoundEffect;

    public static bool GameIsPause;
    public GameObject pauseMenuUI;


    public void Start()
    {
        GameIsPause = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPause)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        PopUPSound();
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPause = false;
    }

    public void Pause()
    {
        PopUPSound();
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPause = true;
    }

    public void PopUPSound()
    {
        src.clip = PopUpSoundEffect;
        src.Play();
    }

    public void ButtonSound()
    {
        src.clip = ButtonSoundEffect;
        src.Play();
    }

    public void LoadMainMenu()
    {
        Resume();
        ButtonSound();
        SceneManager.LoadScene("MenuScene");
    }

    public void Restart()
    {
        ButtonSound();
        Resume();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
