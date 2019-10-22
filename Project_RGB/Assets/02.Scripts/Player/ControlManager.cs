using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ControlManager : MonoBehaviour
{
    [Header("Controllers")]
    public VariableJoystick MoveStick;
    public JumpButton jumpButton;
    public SkillButton skillButton;
    public AttackButton attackButton;

    [Space(10)]
    public UI_Controller uicon;

    [Header("Values")]
    public float maxSpeed;
    public float jumpPower;

    private Rigidbody2D rigid;
    private SpriteRenderer sr;
    private PlayerStatus ps;

    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        ps = GetComponent<PlayerStatus>();
    }

    private void Update()
    {
        InputCheck();
    }

    private void FixedUpdate()
    {
        Move_Horizontal();
        LandingPlatform();
    }

    private void InputCheck()
    {
        if (jumpButton.isPushed && !jumpButton.isJumping)
            jumpButton.Execute(gameObject);
        if (skillButton.isPushed)
            skillButton.Execute(gameObject);
        if (attackButton.isPushed)
            attackButton.Execute(gameObject);
    }

    public void SetAttackUI(int code)
    {
        uicon.UIOnOff(code);
        switch(code)
        {
            case 0: attackButton = uicon.UI_Melee.GetComponent<AttackButton>(); ((MeleeAttackButton)attackButton).isSpear = false; break;
            case 1: attackButton = uicon.UI_Melee.GetComponent<AttackButton>(); ((MeleeAttackButton)attackButton).isSpear = true; break;
            case 2: attackButton = uicon.UI_Distance.GetComponent<AttackButton>(); break;
        }
    }

    #region Movements
    private void Move_Horizontal()
    {
        if (MoveStick.Horizontal < 0.2 && MoveStick.Horizontal > -0.2) return;

        //Sprite, Melee Direction
        bool b = MoveStick.Horizontal < 0;
        sr.flipX = b;
        ps.attack_pos.localPosition = new Vector2(ps.range * (b ? -1 : 1), ps.attack_pos.localPosition.y);
        

        //Movement
        rigid.AddForce(Vector2.right * MoveStick.Horizontal, ForceMode2D.Impulse);

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
        if (rigid.velocity.y < 0)
        {
            Debug.DrawRay(rigid.position, Vector2.down, new Color(0.0f, 1.0f, 0.0f));
            RaycastHit2D raycast = Physics2D.Raycast(rigid.position, Vector2.down, 1.0f, LayerMask.GetMask("Platform"));
            if (raycast.collider != null)
            {
                if (raycast.distance < 0.5f)
                    jumpButton.isJumping = false;
            }
        }
    }

    #endregion

    #region Interactive
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "NPC"|| collision.gameObject.tag == "TeleportDoor")
        {
            attackButton.IsInteract = true;
            ps.Interactive = collision.gameObject;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "NPC" || collision.gameObject.tag == "TeleportDoor")
        {
            attackButton.IsInteract = false;
            ps.Interactive = null;
        }
    }
    #endregion
}
