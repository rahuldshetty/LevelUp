using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 0.10f;
    public float runspeed = 0.28f;
    public float jumpspeed = 0.15f;
    public float updownspeed = 0.12f;
    public float throwspeed = 15f;
    public GameObject stonePrefab;
    
    private Rigidbody2D rb;
    private Animator animator;

    private bool playerFaceRight = true;
    private bool isShiftDown = false;
    private bool isThrowing = false;
    

    private bool isGrounded = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        manageThrow();


        float updown = Input.GetAxisRaw("Vertical");
        float dir = Input.GetAxisRaw("Horizontal");
        if ((dir  !=0  || updown !=0) && isGrounded)
        {
            // manage running things
            float tempspeed = speed;
            if (Input.GetKey(KeyCode.LeftShift))
                tempspeed = runspeed;

            // pressed horizontal axis
            Vector2 targetpos = new Vector2(transform.position.x + dir * tempspeed, transform.position.y + updown*updownspeed);
            rb.MovePosition(targetpos);

            if (dir == 0)
                dir = updown;

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

    void manageThrow()
    {
        if(Input.GetMouseButton(0) && isThrowing == false )
        {
            animator.SetFloat("throw",0.2f);
            isThrowing = true;

            // throw stone
            Vector3 faceDirection = transform.position;
            GameObject obj = Instantiate(stonePrefab, faceDirection,new Quaternion(0,0,0,0));
            Vector2 dir;
            if (playerFaceRight)
                dir = Vector2.right;
            else dir = Vector2.left;
            obj.GetComponent<Rigidbody2D>().velocity = dir * throwspeed;
        }
        else 
        {
            isThrowing = false;
            animator.SetFloat("throw", 0.0f);
        }
            
    }

    void Flip()
    {
        playerFaceRight = !playerFaceRight;
        Vector2 localscale = transform.localScale;
        localscale.x *= -1;
        transform.localScale = localscale;
    }
}
