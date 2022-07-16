using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Healing : MonoBehaviour
{

    //heath:
    public int NumberOfHearts;
    public GameObject health1;
    public GameObject health2;
    public GameObject health3;

    private static int Health; 

    //restart values:
    public int level_number = NextLevel.LEVEL;

    //Audio:
    public AudioSource src;
    public AudioClip HealSound;
    public AudioClip DamageSoundEffect;



    public void Start()
    {

        if (level_number == 0)
        {
            NumberOfHearts = 3;
        }
        else
        {
            NumberOfHearts = Health;
        }
       
    }

    private void Update()
    {
        if (NumberOfHearts == 0)
        {
            health3.SetActive(false);
            health2.SetActive(false);
            health1.SetActive(false);

        }

        else if (NumberOfHearts == 1)
        {
            health3.SetActive(true);
            health2.SetActive(false);
            health1.SetActive(false);
        }

        else if (NumberOfHearts == 2)
        {
            health3.SetActive(true);
            health2.SetActive(true);
            health1.SetActive(false);
        }
        else if (NumberOfHearts == 3)
        {
            health3.SetActive(true);
            health2.SetActive(true);
            health1.SetActive(true);
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("enemy") || collision.gameObject.CompareTag("rat") || collision.gameObject.CompareTag("crab")
            || collision.gameObject.CompareTag("trap") || collision.gameObject.CompareTag("bat"))
        {
            //take damage

            NumberOfHearts -= 1;

            if (NumberOfHearts < 0)
            {
                //death(No hearts left)
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
            else
            {
                src.clip = DamageSoundEffect;
                src.Play();
            }
        }

        // Heal:
        if (collision.gameObject.CompareTag("heart"))
        {
            if (NumberOfHearts < 3)
            {
                //play sound
                src.clip = HealSound;
                src.Play();

                Destroy(collision.gameObject);
                NumberOfHearts += 1;
            }
        }

        Health = NumberOfHearts;
    }


}
