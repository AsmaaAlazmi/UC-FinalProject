using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public int selectedHero;
    public GameObject Mask;
    public GameObject Ninje;

    //Audio:
    public AudioSource src;
    public AudioClip BackSound;


    // Start is called before the first frame update
    void Start()
    {
        src.clip = BackSound ;
        src.Play();
        selectedHero = SelectChar.selected;
    }

    // Update is called once per frame
    void Update()
    {
        if (selectedHero == 1)
        {
            Mask.SetActive(true);
        }
        else if (selectedHero == -1)
        { 
            Ninje.SetActive(true);
        }
    }

    
}
