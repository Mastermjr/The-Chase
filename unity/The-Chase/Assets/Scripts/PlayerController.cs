using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Diagnostics;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public float movementSpeed = 80f;
    public float jumpForce = 4000f;
    public Transform feetPosition;
    public float groundedRadius = 0.2f;
    public LayerMask terrain;
    
    private bool rightFacing = true;
    private bool isGrounded = false;
    private bool doubleJump = true;
    private Rigidbody2D rbody;

    // Use this for initialization
    void Start () {
        rbody = GetComponent<Rigidbody2D>();
    }

    private void Update() {

        if ((isGrounded || doubleJump) && Input.GetKeyDown(KeyCode.W)) {
            doubleJump = isGrounded;
            if (!isGrounded) {
                Vector2 vel = rbody.velocity;
                vel.y = 0;
                rbody.velocity = vel;
            }
            rbody.AddForce(new Vector2(0, jumpForce));
            isGrounded = false;
        }

    }

    void FixedUpdate() {
        isGrounded = Physics2D.OverlapCircle(feetPosition.position, groundedRadius, terrain);

        if (isGrounded && rbody.velocity.y > 0 && rbody.velocity.y < 10f) {
            Vector2 vel = rbody.velocity;
            vel.y = 0;
            rbody.velocity = vel;
        }

        float moveDirection = Input.GetAxis("Horizontal");


        rbody.velocity = new Vector2(moveDirection * movementSpeed, rbody.velocity.y);

        if ((moveDirection != 0) && ((moveDirection > 0) == !rightFacing)) {
            rightFacing = !rightFacing;
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }

        /*if (isGrounded && rbody.velocity.y > 0 && rbody.velocity.y < 100f) {
            rbody.AddForce(new Vector2(0, -1e7f));
        }*/

    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Finish")) {
            Stopwatch watch = GameObject.FindGameObjectWithTag("GameLoader").GetComponent<GameManager>().getStopWatch();
            //UnityEngine.Debug.Log("Player Finished, time: " + watch.ElapsedMilliseconds);
            GameObject.Find("GameLoader").GetComponent<GameManager>().levelFinish(watch.ElapsedMilliseconds);
        }
    }

}
