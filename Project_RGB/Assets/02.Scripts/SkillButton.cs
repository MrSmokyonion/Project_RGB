﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SkillButton : BaseButton
{
    private VariableJoystick stick;
    private Image handle;
    private SkillState ss;

    private bool isActive;

    //여기에 스킬 3개 박혀있을꺼임 ====
    //===============================

    private void Start()
    {
        stick = GetComponent<VariableJoystick>();
        handle = transform.GetChild(0).GetChild(0).GetComponent<Image>();
        ss = SkillState.Idle;
        isActive = false;
    }

    private void Update()
    {
        if(isActive)
        {
            float h = Mathf.Abs(stick.Horizontal);
            float v = Mathf.Abs(stick.Vertical);

            if (v <= 0.2f && h <= 0.2f)
            {
                ChangeStickColor();
                return;
            }

            if (stick.Horizontal < stick.Vertical)
            {
                if (h < v)
                {
                    ss = SkillState.Idle;
                }
                else if (h > v)
                {
                    ss = SkillState.Red;
                }
            }
            else if (stick.Horizontal > stick.Vertical)
            {
                if (h < v)
                {
                    ss = SkillState.Green;
                }
                else if (h > v)
                {
                    ss = SkillState.Blue;
                }
            }
            ChangeStickColor();
        }
    }
    private void ChangeStickColor()
    {
        switch (ss)
        {
            case SkillState.Idle: handle.color = Color.white; break;
            case SkillState.Red: handle.color = Color.red; break;
            case SkillState.Green: handle.color = Color.green; break;
            case SkillState.Blue: handle.color = Color.blue; break;
        }
    }

    public override void Execute(GameObject obj)
    {
        isPushed = false;
        isActive = true;
        Debug.Log("슬로ㅗ오오오ㅗ옹ㅇ오오오ㅗ오우");
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        isActive = false;
        Debug.Log(ss.ToString() + " 스킬 온!"); 
        ss = SkillState.Idle;
        ChangeStickColor();
    }

    enum SkillState { Idle = 0, Red, Green, Blue }
}