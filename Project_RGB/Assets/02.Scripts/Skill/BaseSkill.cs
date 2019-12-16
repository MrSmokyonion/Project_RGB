using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Base_Skill : BaseValues
{
    public float m_value1;
    public float m_value2;
    public float m_delay;

    public abstract void ExecuteSkill(GameObject obj);
}

public abstract class Skill_Red : Base_Skill { }
public abstract class Skill_Green : Base_Skill { }
public abstract class Skill_Blue : Base_Skill { }