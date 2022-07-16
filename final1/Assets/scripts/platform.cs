using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class platform : MonoBehaviour
{
    public float speed = 4f;
    public Transform posA, posB;
    Vector2 targetPos;

    //Audio:
    public AudioSource src;
    public AudioClip WoodSound;

    // Start is called before the first frame update
    void Start()
    {
        src.clip = WoodSound;
        src.Play();
        targetPos = posB.position;
    }

    private void Update()
    {
        if (Vector2.Distance(transform.position, posA.position) < 0.1f) targetPos = posB.position;

        if (Vector2.Distance(transform.position, posB.position) < 0.1f) targetPos = posA.position;

        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("hero"))
        {
            SceneManager.LoadScene("Level2");
        }
    }

}
