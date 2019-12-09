using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 0.10f;
    public float runspeed = 0.28f;

    private Rigidbody2D rb;
    private Animator animator;

    private bool playerFaceRight = true;
    private bool isShiftDown = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float dir = Input.GetAxisRaw("Horizontal");
        if (dir != 0)
        {
            float tempspeed = speed;
            if (Input.GetKey(KeyCode.LeftShift))
                tempspeed = runspeed;

            // pressed horizontal axis
            Vector2 targetpos = new Vector2(transform.position.x + dir * tempspeed, 0);
            rb.MovePosition(targetpos);

            if (Input.GetKey(KeyCode.LeftShift))
                animator.SetFloat("walking", 2.1f);
            else
                animator.SetFloat("walking", Mathf.Abs(dir));

            if (dir == -1 && playerFaceRight)
            {
                Flip();

            }
            else if(dir==1 && !playerFaceRight)
            {
                Flip();
            } 
        }
        else
            animator.SetFloat("walking", Mathf.Abs(dir));

    }

    void Flip()
    {
        playerFaceRight = !playerFaceRight;
        Vector2 localscale = transform.localScale;
        localscale.x *= -1;
        transform.localScale = localscale;
    }
}
