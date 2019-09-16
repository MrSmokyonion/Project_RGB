using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillButton : MonoBehaviour
{
    private VariableJoystick stick;
    private Image handle;

    private void Start()
    {
        stick = GetComponent<VariableJoystick>();
        handle = transform.GetChild(0).GetChild(0).GetComponent<Image>();
        Debug.LogWarning(handle.gameObject.name);
    }

    private void Update()
    {
        float h = Mathf.Abs(stick.Horizontal);
        float v = Mathf.Abs(stick.Vertical);
        SkillState ss = SkillState.Idle;

        if(v <= 0.2f && h <= 0.2f)
        {
            ss = SkillState.Idle;
            goto result;
        }

        if(stick.Horizontal < stick.Vertical)
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
        else if(stick.Horizontal > stick.Vertical)
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

    result:
        switch (ss)
        {
            case SkillState.Idle:  handle.color = Color.white; break;
            case SkillState.Red:   handle.color = Color.red;   break;
            case SkillState.Green: handle.color = Color.green; break;
            case SkillState.Blue:  handle.color = Color.blue;  break;
        }
    }

    enum SkillState { Idle = 0, Red, Green, Blue }
}
