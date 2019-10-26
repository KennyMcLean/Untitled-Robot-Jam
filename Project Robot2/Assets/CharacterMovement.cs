using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float speed, jumpStrength;

    private float movement;

    private bool lookingRight = true;

    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        if (Input.GetButtonDown("Jump"))
        {
            if (isGrounded)
            {
                Debug.Log("On the Ground");
                rb.velocity = new Vector2(rb.velocity.x, jumpStrength);
            }
        }
    }

    private void FixedUpdate()
    {

      

        movement = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(speed * movement, rb.velocity.y);

        if (lookingRight == true)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                Flip();
            }
        }
        else if (lookingRight == false)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                Flip();
            }
        }
    }

    private void Flip()
    {
        lookingRight = !lookingRight;
        Vector3 Scalar = transform.localScale;
        Scalar.x *= -1;
        transform.localScale = Scalar;
    }
}
