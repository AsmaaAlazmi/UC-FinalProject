using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class KeyCounter : MonoBehaviour
{
    public static KeyCounter instance;
    public static bool HasKey;

    public TMP_Text KeyScore;
    private int scoreNumber = 0;

    //Door
    public GameObject Old_Door;
    public GameObject New_Door;


    //Audio:
    public AudioSource src;
    public AudioClip keySound;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {

        Old_Door.SetActive(true);
        New_Door.SetActive(false);
        HasKey = false;

        //scoreNumber = 0;
        KeyScore.text = "Door Locked.";
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("hero"))
        {
            //destroies Key
            scoreNumber += 1;
            //KeyScore.text = "x" + scoreNumber;
            if (scoreNumber > 0) 
            {

                KeyScore.text = "Door UnLocked!";

                //play sound
                src.clip = keySound;
                src.Play();

                Old_Door.SetActive(false);
                New_Door.SetActive(true);

                Destroy(gameObject);
                scoreNumber -= 1;

                HasKey = true;
            }
           

        }
    }

}
