using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    [Range(0f, 10f)]
    private float JumpPower = 3f;
    [SerializeField]
    private float movePower = 1f;
    [SerializeField]
    private float maxJumpTime = 0.3f;
    private float jumpTime = 0.0f;
    private bool ifJumping = false;
    private Rigidbody2D rigidBody;
    private Animator animator;
    private Vector3 movement;
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        if (ifJumping == true)
        {
            jumpTime += Time.deltaTime;
            if (jumpTime >= maxJumpTime)
            {
                JumpEnd();
            }
        }
        else if (ifJumping == false && JumpKeyDown())
        {
            JumpStart();
        }
        Debug.Log(ifJumping);
    }
    void FixedUpdate()
    {
        Move();
    }
    private void JumpStart()
    {
        jumpTime = 0.0f;
        ifJumping = true;
        animator.SetBool("ifJumping", true);
        rigidBody.velocity = new Vector2(0f, JumpPower);
    }
    private void JumpEnd()
    {
        ifJumping = false;
        animator.SetBool("ifJumping", ifJumping);
    }
    private bool JumpKeyDown()
    {
        return Input.GetKeyDown(KeyCode.Space);
    }
    void Move()
    {
        Vector3 moveVelocity = Vector3.zero;
        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            moveVelocity = Vector3.left;
        }
        else if (Input.GetAxisRaw("Horizontal") > 0)
        {
            moveVelocity = Vector3.right;
        }
        transform.position += moveVelocity * movePower * Time.deltaTime;
    }
}
