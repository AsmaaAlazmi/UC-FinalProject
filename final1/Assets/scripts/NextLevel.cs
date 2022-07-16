using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class NextLevel : MonoBehaviour
{
    //Audio:
    public AudioSource src;
    public AudioClip ButtonSoundEffect;

    public static int OldEggScore;
    public TMP_Text EggscoreText;
    public TMP_Text LevelText;

    public static int LEVEL = 1;
    private bool restartValues = MainMenue.RestartValues;
    private static int CurrentLevel;
    private bool restart;

    private void Start()
    {
        if (restart == true)
        {
            LEVEL = 1;
            restart = false;
            Debug.Log("restart " + restart);

        }
        else if (restart == false)
        {
            LEVEL = CurrentLevel;
            Debug.Log("Current Level = " + LEVEL);
        }

        LevelText.text = "Level ( " + (LEVEL + 1).ToString() + " ) Completed!!";

    }

    // Update is called once per frame
    void Update()
    {
        restart = restartValues;

        OldEggScore = EggsCounter.scoreNumber;
        EggscoreText.text = "Eggs collected: x" + OldEggScore;

    }

    public void RestartBTN()
    {
        ButtonSound();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

    public void LoadMainMenu()
    {
        ButtonSound();
        SceneManager.LoadScene("MenuScene");
    }

    public void ButtonSound()
    {
        src.clip = ButtonSoundEffect;
        src.Play();
    }

    public void LoadNextLevel()
    {
        ButtonSound();
        if (LEVEL == 2)
        {
            SceneManager.LoadScene("MenuScene");
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            LEVEL += 1;
            Debug.Log("Level: " + LEVEL);
        }

        CurrentLevel = LEVEL;
    }
}
