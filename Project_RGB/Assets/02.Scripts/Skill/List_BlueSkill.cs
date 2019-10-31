using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Blue_Shield : Skill_Blue //301
{
    public Skill_Blue_Shield()
    {
        title = "실드";
        code = SpawnCode.B001;
        spritePath = "";


        power = 0;
        delay = 1.0f;
    }

    public override void ExecuteSkill(GameObject obj)
    {
        Debug.Log("Blue Skill -> Shield!");
    }
}