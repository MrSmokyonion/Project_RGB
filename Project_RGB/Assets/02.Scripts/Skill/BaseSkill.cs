using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseSkill
{
    public string skillName;
    public float delay;

    public abstract void ExecuteSkill(GameObject obj);
}

public abstract class RedSkill : BaseSkill { public int power; }
public abstract class GreenSkill : BaseSkill { public int power; }
public abstract class BlueSkill : BaseSkill { public int power; }