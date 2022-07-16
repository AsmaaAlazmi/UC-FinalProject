using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectChar : MonoBehaviour
{
    // 1 = Mask , -1 = Ninja
    public static int selected;

    //Audio:
    public AudioSource src;
    public AudioClip SelectSound;
    public AudioClip ButtonSound;

    public void SelectMask()
    {
        selected = MainMenue.Selected;
        selected = 1;

        //play sound
        src.clip = SelectSound;
        src.Play();

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void SelectNinja()
    {
        selected = MainMenue.Selected;
        selected = -1;

        //play sound
        src.clip = SelectSound;
        src.Play();

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void BackButton()
    {
        //play sound
        src.clip = ButtonSound;
        src.Play();

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

}
