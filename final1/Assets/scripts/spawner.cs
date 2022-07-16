using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{

    //Audio:
    public AudioSource src;
    public AudioClip BatSound;


    public GameObject Bat;

    // Start is called before the first frame update
    void Start()
    {
        src.clip = BatSound;
        src.Play();
        InvokeRepeating("Spawn", 2f, 2f);

    }

    // Update is called once per frame
    void Update()
    {
    }

    void Spawn()
    {
        GameObject spawnObject;

        spawnObject = Bat;
        Vector2 vPosition = transform.position;
        GameObject newSpawn = Instantiate(spawnObject, vPosition, Quaternion.identity);
        newSpawn.transform.position = vPosition;


    }
}
