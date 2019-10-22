using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Red_Fire : Skill_Red //101
{
    public Skill_Red_Fire()
    {
        title = "파이어";
        description = "파이어 입니다. 파이어볼 이라고 생각하겠지만 파이어입니다.";
        code = SpawnCode.R001;
        spritePath = "";
        isUnlock = false;

        power = 0;
        delay = 1.0f;
    }

    public override void ExecuteSkill(GameObject obj)
    {
        Debug.Log("Red Skill -> Fire!");
    }
}