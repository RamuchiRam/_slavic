using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    // <��������> Speed = 5, jumpForce = 15, Mass = 1, Gravity = 5 <��������>
    // ��� �������� ��������� 

    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpForce = 15f;
    
    private bool isGrounded = false;
    private Rigidbody2D rb;
    private SpriteRenderer sprite;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    private void Update()
    {
        if (Input.GetButton("Horizontal"))
            Run();
        if (isGrounded && Input.GetButtonDown("Jump"))//GetButton("Jump"))
            Jump();
    }
    private void FixedUpdate()
    {
        CheckGround();
    }
    private void Run()
    {
        Vector2 dir = transform.right * Input.GetAxis("Horizontal");

        rb.position = Vector2.MoveTowards(rb.position, rb.position + dir, speed * Time.deltaTime); // ���� ������� ����� rb, �������� �� ��� �����������

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
}
