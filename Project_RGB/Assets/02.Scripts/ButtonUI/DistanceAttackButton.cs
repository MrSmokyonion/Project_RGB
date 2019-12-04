using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DistanceAttackButton : AttackButton
{
    private VariableJoystick stick;
    private GameObject player;
    private float x;
    private float y;

    private void Start()
    {
        IsInteract = false;
        stick = GetComponent<VariableJoystick>();
    }

    private void Update()
    {
        float _x = Mathf.Abs(stick.Horizontal);
        float _y = Mathf.Abs(stick.Vertical);
        if (_x < 0.2 && _y < 0.2) return;

        x = stick.Horizontal;
        y = stick.Vertical;

        //여기에 활 쏘는 모션
    }

    public override void Execute(GameObject obj)
    {
        isPushed = false;
        player = obj;

        FindObjectOfType<SoundManager>().Play("bow_swing");
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        if (IsInteract && (x == 0f) && (y == 0f))
            player.GetComponent<PlayerStatus>().Interact();
        else
        {
            Vector2 pos = new Vector2(0f, 0f);
            Vector2 tar = new Vector2(x, y);
            player.GetComponent<PlayerStatus>().Attack(GetDegree(pos, tar), GetDirection(pos, tar));
        }

        player = null;
        x = y = 0;
    }

    private float GetDegree(Vector2 pos, Vector2 tar)
    {
        float ang = Mathf.Atan2(tar.y - pos.y, tar.x - pos.x) * 180 / Mathf.PI;
        if (ang < 0) ang += 360;
        return ang;
    }
    private Vector2 GetDirection(Vector2 pos, Vector2 tar)
    {
        return new Vector2(tar.x - pos.x, tar.y - pos.y);
    }
}