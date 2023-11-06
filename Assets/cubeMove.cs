using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cubeMove : MonoBehaviour
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
        rb.velocity = new Vector2(speed * move*10, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && isJump == false)
        {
            rb.AddForce(new Vector2(10, jump));
        }
        float yPosition = transform.position.y;
        if (yPosition < target.transform.position.y + 0.5)
        {
            Debug.LogError("Game Over !");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
            
        }
        Debug.Log("Y Position circle: " + yPosition);
        Debug.Log("Y Position plane: " + target.transform.position.y);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJump = false;
        }
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJump = true;
        }
    }
}
