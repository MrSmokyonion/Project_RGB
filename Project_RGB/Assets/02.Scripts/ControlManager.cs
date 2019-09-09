using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ControlManager : MonoBehaviour
{
    [Header("Controllers")]
    public VariableJoystick joystick;
    public BaseButton jumpButton;

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
        Move_Horizontal();
        InputCheck();
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

    private void InputCheck()
    {
        if (jumpButton.isPushed)
            jumpButton.Action.Invoke();
    }
    private void Move_Jump()
    {
        Debug.Log("Jump!");
    }
}
