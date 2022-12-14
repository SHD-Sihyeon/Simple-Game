using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
    public float springForce = 500;
    private Collision2D collision;
    private bool bouncing = false;
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (!bouncing)
        {
            bouncing = true;
            collision = coll;
        }
    }
    void FixedUpdate()
    {
        if (bouncing)
        {
            var rb = collision.gameObject.GetComponent<Rigidbody2D>();
            rb.velocity = new Vector3(0, 0, 0);
            rb.AddForce(new Vector2(0f, springForce));
            bouncing = false;
        }
    }
}
