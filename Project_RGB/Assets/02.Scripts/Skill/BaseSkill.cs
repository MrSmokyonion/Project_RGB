using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseSkill
{
    public string skillName;
    public float delay;

    public abstract void ExecuteSkill(GameObject obj);
}

public abstract class RedSkill : BaseSkill { }
public abstract class GreenSkill : BaseSkill { }
public abstract class BlueSkill : BaseSkill { }