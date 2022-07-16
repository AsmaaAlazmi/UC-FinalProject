using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EggsCounter : MonoBehaviour
{
    public static EggsCounter instance;

    public TMP_Text scoreText;
    public static int scoreNumber;
    private static int EggScore;

    //restart values:
    public int level_number = NextLevel.LEVEL;


    //Audio:
    public AudioSource src;
    public AudioClip EggSound;


    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Egg Level: "+ level_number);
        if (level_number == 0)
        {
            scoreNumber = 0;
        }
        else
        {
            scoreNumber = EggScore;
        }

        scoreText.text = "x"+ scoreNumber.ToString();

    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("hero"))
        {   //destroies Egg
            Destroy(gameObject);
            EggsCounter.instance.IncreaseEggs(5);

            src.clip = EggSound;
            src.Play();

            EggScore = scoreNumber;
  
        }
    }

    public int IncreaseEggs(int v)
    {
        scoreNumber += v;
        scoreText.text = "x" + scoreNumber.ToString();

        return scoreNumber;
    }
}
