using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    private bool CanPress_W = false;
    public TMP_Text NoKeyTXT;
    public GameObject NextMenuUI;

    //Audio:
    public AudioSource src;
    public AudioClip ErrorSoundEffect;
    public AudioClip enterSoundEffect;


    // Update is called once per frame
    void Update()
    {

        if (KeyCounter.HasKey == true)
        {
            NoKeyTXT.text = "";
        }

        if (Input.GetKeyDown(KeyCode.W) && CanPress_W)
        {
            if (KeyCounter.HasKey == true)
            {
                EnterNextLevel();
            }

            if (KeyCounter.HasKey == false)
            {
                DoorIsLocked();
                NoKeyTXT.text = "Door Is Locked, Find The Key!";
            }

        }
     
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("hero"))
        {
            CanPress_W = true;
        }
    }

    public void EnterNextLevel()
    {
        
        src.clip = enterSoundEffect;
        src.Play();
        NextMenuUI.SetActive(true);

    }

    public void DoorIsLocked()
    {

        src.clip = ErrorSoundEffect;
        src.Play();
    }
}
