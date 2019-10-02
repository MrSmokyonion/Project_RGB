using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Base_Skill
{
    public string skillName;
    public float delay;

    public abstract void ExecuteSkill(GameObject obj);
}

public abstract class Skill_Red : Base_Skill { public int power; }
public abstract class Skill_Green : Base_Skill { public int power; }
public abstract class Skill_Blue : Base_Skill { public int power; }