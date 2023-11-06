using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    public float speed;
    private float move;
    public float jump;
    public bool isJump;
    public GameObject target;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        move = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(speed * move, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && isJump == false)
        {
            rb.AddForce(new Vector2(10, jump));
        }
        float yPosition = transform.position.y;
        if (yPosition < target.transform.position.y + 0.5)
        {
           
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        }

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        // if (other.gameObject.CompareTag("Ground"))
        // {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJump = false;
        }
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.transform.position.y+0.5 < transform.position.y)
        {

            isJump = true;
        }
    }
}
