using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    [SerializeField]
    [Range(0f, 10f)]
    private float JumpPower = 3f;
    [SerializeField]
    private float movePower = 1f;
    [SerializeField]
    private float maxJumpTime = 0.3f;
    [SerializeField]
    private GameObject GameOverUI;
    [SerializeField]
    private GameObject GameClearUI;
    [SerializeField]
    private TextMeshProUGUI TimeText;
    private float jumpTime = 0.0f;
    private bool ifJumping = false;
    private Rigidbody2D rigidBody;
    private Animator animator;
    private Vector3 movement;
    private float time;
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        time = 0;
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
        time += Time.deltaTime;
        TimeText.text = ((int)time).ToString();
        if (Input.GetAxisRaw("Horizontal") == 0)
        {
            animator.SetBool("ifRunning", false);
        }
    }
    void FixedUpdate()
    {
        Move();
    }
    private void Awake()
    {
        GameOverUI.SetActive(false);
        GameClearUI.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject gameObject = collision.gameObject;
        if (gameObject.CompareTag("FailBox"))
        {
            Time.timeScale = 0f;
            GameOverUI.SetActive(true);
        }
        if (gameObject.CompareTag("EndPoint"))
        {
            Time.timeScale = 0f;
            GameClearUI.SetActive(true);
        }
    }
    public static void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public static void NextStage()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Stage2");
    }
    public static void GoHome()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main");
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
        animator.SetBool("ifRunning", true);
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
