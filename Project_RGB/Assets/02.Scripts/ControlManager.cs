using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ControlManager : MonoBehaviour
{
    [Header("Controllers")]
    public VariableJoystick joystick;
    public JumpButton jumpButton;

    [Header("Values")]
    public float maxSpeed;
    public float jumpPower;

    private Rigidbody2D rigid;

    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        InputCheck();
        Move_Horizontal();
        LandingPlatform();
    }

    private void InputCheck()
    {
        if (jumpButton.isPushed && !jumpButton.isJumping)
            jumpButton.Execute(gameObject);
    }

    private void Move_Horizontal()
    {
        if (joystick.Horizontal < 0.2 && joystick.Horizontal > -0.2) return;

        rigid.AddForce(Vector2.right * joystick.Horizontal, ForceMode2D.Impulse);

        if (rigid.velocity.x > maxSpeed)
            rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y);
        else if (rigid.velocity.x < maxSpeed * (-1))
            rigid.velocity = new Vector2(maxSpeed * (-1), rigid.velocity.y);
    }
    public void Move_Jump()
    {
        rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
    }
    private void LandingPlatform()
    {
        if(rigid.velocity.y < 0)
        {
            Debug.DrawRay(rigid.position, Vector2.down, new Color(0.0f, 1.0f, 0.0f));
            RaycastHit2D raycast = Physics2D.Raycast(rigid.position, Vector2.down, 1.0f, LayerMask.GetMask("Platform"));
            if(raycast.collider != null)
            {
                if (raycast.distance < 0.5f)
                    jumpButton.isJumping = false;
            }
        }
    }
}
