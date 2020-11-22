using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move2D : MonoBehaviour
{
    public Rigidbody2D rb;

    public float launchForce;
    public float moveSpeed = 5f;

    public bool isGrounded = false;
    public bool onIce = false;
    Vector3 movement;
    float conveyorSpeed = 0f;
    
    void Update()
    {
        Jump();
        if(onIce == false) {
            movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        }
        transform.position += movement * Time.deltaTime * (moveSpeed - conveyorSpeed);
    }
    
    void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded == true && onIce == false)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 5f), ForceMode2D.Impulse);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("JumpPad"))
        {
            rb.velocity = Vector2.up * launchForce;
        }
    }

    public void OnTriggerEnter2D(Collider2D collider) {
        if(collider.tag == "IcePlatform") {
            onIce = true;
        }

        else if(collider.tag == "ConveyorBeltLeft") {
            conveyorSpeed = 4f;
        }

        else if(collider.tag == "ConveyorBeltRight") {
            conveyorSpeed = -4f;
        }
    }
    public void OnTriggerExit2D(Collider2D collider) {
        if(collider.tag == "IcePlatform") {
            onIce = false;
        }

        else {
            conveyorSpeed = 0f;
        }
    }
}
