using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hero_walk : MonoBehaviour
{
    

    Rigidbody2D rb;
    public float speed;
    public float jump;
    public bool canJump;
    public SpriteRenderer sprite;
    public Animator animator;

    //item drops:
    public GameObject jump_potion;
    public GameObject hearts;
    public GameObject Key;

    //Audio:
    [SerializeField] private AudioSource JumpSoundEffect;
    [SerializeField] private AudioSource CollectSoundEffect;
    [SerializeField] private AudioSource KillSoundEffect;
    [SerializeField] private AudioSource DoorSoundEffect;

    //Door
    public GameObject DoorOpened;
    public GameObject DoorClosed;
    private bool IsClosed = false;


    // Start is called before the first frame update
    void Start()
    {
        speed = 6f;
        jump = 9f;
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {

        Vector2 temp = rb.velocity;

        //flips the character:
        if (Input.GetAxis("Horizontal") > 0)
            sprite.flipX = false;
        else if (Input.GetAxis("Horizontal") < 0)
            sprite.flipX = true;
        ///////////////////////////////////////


        if (canJump && Input.GetKeyDown(KeyCode.Space))
        {   //jumping:

            JumpSoundEffect.Play();

            temp.y = jump;
            canJump = false;
            animator.SetBool("jump", true);
            animator.SetBool("run", false);

        }

        //running:
        temp.x = Input.GetAxis("Horizontal") * speed;
        rb.velocity = temp;

        if (Input.GetAxisRaw("Horizontal") != 0 && IsClosed == false)
        {
            DoorSoundEffect.Play();
            DoorOpened.SetActive(false);
            DoorClosed.SetActive(true);
            IsClosed = true;
        }

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {

        if ((collision.gameObject.tag == "ground" || collision.gameObject.tag == "platform") && Input.GetAxisRaw("Horizontal") != 0)
        {
            canJump = true;
            animator.SetBool("jump", false);
            animator.SetBool("run", true);
            
        }
        else if ((collision.gameObject.tag == "ground" || collision.gameObject.tag == "platform" )&& Input.GetAxisRaw("Horizontal") == 0) {
            canJump = true;
            animator.SetBool("jump", false);
            animator.SetBool("run", false);
        }


        //jump potion
        if (collision.gameObject.tag == "potion")
        {
            CollectSoundEffect.Play();
            jump = 12f;
            Destroy(collision.gameObject);

            if (collision.gameObject.CompareTag("start"))
            {
                jump = 9f;
            }
        }


    }


    private void OnTriggerEnter2D(Collider2D Enemy) 
    {   // destroys the enemy and drop items:

        if (Enemy.gameObject.tag == "rat")
        {   //higher jump:
            
            GameObject potion = Instantiate(jump_potion, Enemy.gameObject.transform.position, Enemy.gameObject.transform.rotation);
            potion.transform.position = new Vector2(9f, -1.7f);
            Debug.Log(potion.transform.position);

            KillSoundEffect.Play();
            Destroy(Enemy.gameObject);
        }
        else if (Enemy.gameObject.tag == "crab")
        {   //restores health:
           
            GameObject health = Instantiate(hearts, Enemy.gameObject.transform.position, Enemy.gameObject.transform.rotation);
            health.transform.position = new Vector2(-2f, 3.5f);

            KillSoundEffect.Play();
            Destroy(Enemy.gameObject);
        }
        else if (Enemy.gameObject.tag == "enemy")
        {   //drops Key:

            GameObject key = Instantiate(Key, Enemy.gameObject.transform.position, Enemy.gameObject.transform.rotation);
            key.transform.position = new Vector2(2f, -2.8f);

            KillSoundEffect.Play();
            Destroy(Enemy.gameObject);
        }

    }

    
}
