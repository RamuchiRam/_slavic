using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    // <«Ќј„≈Ќ»я> Speed = 3, jumpForce = 7, Mass = 1, Gravity = 3 <«Ќј„≈Ќ»я>
    //  “ќ ѕќћ≈Ќя≈“  ј—“–»–”ё 

    [SerializeField] private float speed = 4f;
    [SerializeField] private float jumpForce = 6f;
    
    private bool isGrounded = false;
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Animator anim;

    private States State
    {
        get { return (States)anim.GetInteger("state"); }
        set { anim.SetInteger("state", (int)value); }
    }
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        anim = GetComponent<Animator>();
        rb.mass = 1f;
        rb.gravityScale = 1f;
    }

    private void Update()
    {
        if (isGrounded) State = States.idle;

        if (Input.GetButton("Horizontal"))
            Run();
        if (isGrounded && Input.GetButtonDown("Jump"))
            Jump();
    }
    private void FixedUpdate()
    {
        CheckGround();
    }
    private void Run()
    {
        if (isGrounded) State = States.walk;

        Vector2 dir = transform.right * Input.GetAxis("Horizontal");

        rb.position = Vector2.MoveTowards(rb.position, rb.position + dir, speed * Time.deltaTime); // если двигать через rb, коллизии не так выеживаютс€

        //transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, speed * Time.deltaTime);
        sprite.flipX = dir.x < 0;
    }
    private void Jump()
    {
        rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
    }
    private void CheckGround()
    {
        Collider2D[] collider = Physics2D.OverlapCircleAll(transform.position, 0.3f);
        isGrounded = collider.Length > 1;
    }
    public enum States
    {
        idle,
        walk
    }
}
