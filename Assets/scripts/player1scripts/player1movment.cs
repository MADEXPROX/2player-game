using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player1movmen : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rp;
    float speed = 6f;
    public GameObject player;
    public Animator anim;
    bool isjump = false;
    float jump = 8f;
    bool player1indoor;
    bool player2indoor; 
    public Animator door1anim;
    public Animator door2anim;
    void Start()
    {
        rp = GetComponent<Rigidbody2D>();
        player1indoor = false;
        player2indoor = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player1indoor && player2indoor == true)
        {
            SceneManager.LoadScene("Level2");
        }

    }
    private void FixedUpdate()
    {
        float hor = Input.GetAxis("Horizontal");
        rp.velocity = new Vector2(hor * speed, rp.velocity.y);

        if (Input.GetKey(KeyCode.W) && isjump == false)
        {
            rp.velocity = new Vector2(0, jump);
            isjump = true;

        }
        if (Mathf.Abs(rp.velocity.y) < 0.01f)
        {
            isjump = false;
        }

        if (hor < 0)
        {
            player.transform.localScale = new Vector3(-2, 2, 0);

        }
        if (hor > 0)
        {
            player.transform.localScale = new Vector3(2, 2, 0);

        }

        if (hor > 0 || hor < 0)
        { anim.SetBool("idletorun", true); }
        else if (hor == 0)
        { anim.SetBool("idletorun", false); }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("trap"))
        {
            SceneManager.LoadScene("Level1");
        }
       
        
        if (collision.CompareTag("doortriger1"))
        {
            player1indoor = true;
            door1anim.SetBool("closetoopen", true);

        }

        if (collision.CompareTag("doortriger2"))
        {
                player2indoor = true;
                door2anim.SetBool("closetoopen2", true);
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("doortriger1"))
        {
            
            door1anim.SetBool("closetoopen", false);

        }
        if (collision.CompareTag("doortriger2"))
        {
            
            door2anim.SetBool("closetoopen2", false);

        }
    }
}
