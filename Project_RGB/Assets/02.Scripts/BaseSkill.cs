using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseSkill : MonoBehaviour
{
    public SkillElements elements;
    public string skillName;
    public float delay;
    protected float value;

    public abstract void ExecuteSkill();
}
public enum SkillElements { None = 0, R, G, B }