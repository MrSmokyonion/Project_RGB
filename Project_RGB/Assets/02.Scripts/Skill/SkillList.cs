using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SkillList
{
    public static RedSkill GetSkill_Red(int skillcode)
    {
        switch (skillcode)
        {
            case 101: return new R_Fire();
        }
        return null;
    }
    public static GreenSkill GetSkill_Green(int skillcode)
    {
        switch (skillcode)
        {
            case 201: return new G_HighJump();
        }
        return null;
    }
    public static BlueSkill GetSkill_Blue(int skillcode)
    {
        switch (skillcode)
        {
            case 301: return new B_Shild();
        }
        return null;
    }
}
