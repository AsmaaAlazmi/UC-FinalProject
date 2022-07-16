using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenue : MonoBehaviour
{
    public static int Selected;
    public static int LevelNumber;
    public static bool RestartValues;


    //Audio:
    public AudioSource src;
    public AudioClip ButtonSound;

    public void Start()
    {
        RestartValues = true;
        Debug.Log("Restart Values " + RestartValues);
        Selected = 0;
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ButtonSoundEffect()
    {
        src.clip = ButtonSound;
        src.Play();
    }
    
}
