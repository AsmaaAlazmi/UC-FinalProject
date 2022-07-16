using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PopUp : MonoBehaviour
{

    //Audio:
    public AudioSource src;
    public AudioClip PopUpSoundEffect;

    public void PopUPSound()
    {
        src.clip = PopUpSoundEffect;
        src.Play();
    }

}
