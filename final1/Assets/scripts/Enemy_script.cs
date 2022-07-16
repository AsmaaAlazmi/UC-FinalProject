using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_script : MonoBehaviour
{
    public int direction;
    public float speed;
    public Rigidbody2D rb;
    public GameObject left_trigger;
    public GameObject right_trigger;
    public SpriteRenderer sprite;


    // Start is called before the first frame update
    void Start()
    {
        
        speed = 1.5f;
        direction = 1;
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 temp = rb.velocity;

        //flips the character:
        if (temp.x > 0)
            sprite.flipX = false;
        else if (temp.x < 0)
            sprite.flipX = true;
        //////////////////////////////////

        rb.velocity = Vector2.right * speed * direction;

        if (direction > 0)
        {
            Collider2D check = Physics2D.OverlapBox(right_trigger.transform.position, Vector2.one * 0.5f, 0f);

            if (check == null || check.tag != "ground")
                direction = -direction;
        }

        if (direction < 0)
        {
            Collider2D check = Physics2D.OverlapBox(left_trigger.transform.position, Vector2.one * 0.5f, 0f);

            if (check == null || check.tag != "ground")
                direction = -direction;
        }


    }

}
