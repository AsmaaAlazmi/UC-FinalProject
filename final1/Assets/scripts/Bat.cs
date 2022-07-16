using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : MonoBehaviour
{
    Rigidbody2D rBody;
    public float speed;
    private int direction = -1;

    // Start is called before the first frame update
    void Start()
    {
        speed = 7f;
        rBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rBody.velocity = Vector2.right * speed * direction;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("boder") || collision.gameObject.CompareTag("hero"))
        {
            Destroy(gameObject);
        }
    }
}
