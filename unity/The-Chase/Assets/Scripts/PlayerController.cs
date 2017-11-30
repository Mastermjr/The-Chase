using UnityEngine;
using UnityEngine.Events;
using System.Collections;

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
            rbody.AddForce(new Vector2(0, jumpForce));
        }

    }

    void FixedUpdate() {
        isGrounded = Physics2D.OverlapCircle(feetPosition.position, groundedRadius, terrain);

        float moveDirection = Input.GetAxis("Horizontal");


        rbody.velocity = new Vector2(moveDirection * movementSpeed, rbody.velocity.y);

        if ((moveDirection != 0) && ((moveDirection > 0) == !rightFacing)) {
            rightFacing = !rightFacing;
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }

    }
    
}
