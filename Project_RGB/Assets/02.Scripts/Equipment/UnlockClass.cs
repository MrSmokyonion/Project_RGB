using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UnlockClass
{
    public static BaseValues[] red;
    public static BaseValues[] green;
    public static BaseValues[] blue;

    public static BaseValues[][] weapon;

    public static BaseValues[] amulet;
    public static BaseValues[] stone;

    public static BaseValues[] food;

    static UnlockClass()
    {
        red = new BaseValues[] { new Skill_Red_Fire() };
        green = new BaseValues[] { new Skill_Green_HighJump() };
        blue = new BaseValues[] { new Skill_Blue_Shield() };

        weapon = new BaseValues[][] {
            new BaseValues[] {new Sword_Default() },
            new BaseValues[] {new Spear_Default() },
            new BaseValues[] {new Bow_Default() }
            };


        amulet = new BaseValues[] { new Amulet_Default() };
        stone = new BaseValues[] { new Stone_Default(), new Stone_ImproveSkill() };

        food = new BaseValues[] { new Food_Hamburger() };
    }

    public static bool CheckCode(SpawnCode code)
    {
        BaseValues[] arr = GetCodeToArray(code);
        if (arr == null) return false;

        int num = int.Parse(code.ToString().Substring(2));
        return arr[num-1].isUnlock;
    }

    public static void UnlockCode(SpawnCode code)
    {
        BaseValues[] arr = GetCodeToArray(code);
        if (arr == null) return;

        int num = int.Parse(code.ToString().Substring(2));
        arr[num].isUnlock = true;
    }

    private static BaseValues[] GetCodeToArray(SpawnCode code)
    {
        string str = code.ToString();
        string section = str.Substring(0, 1);
        int num1 = int.Parse(str.Substring(1, 1));
        int num2 = int.Parse(str.Substring(2));

        switch (section)
        {
            case "R": return red;
            case "G": return green;
            case "B": return blue;

            case "W": return weapon[num1];

            case "A": return amulet;
            case "S": return stone;

            case "F": return food;

            default: return null;
        }
    }

    #region Durability Sort

    public static BaseValues[][] GetWeaponSort()
    {
        BaseValues[][] result = new BaseValues[weapon.Length][];

        for(int idx = 0; idx < weapon.Length; idx++)
        {
            result[idx] = new BaseValues[weapon[idx].Length];
            for (int i = 0; i < weapon[idx].Length; i++)
            {
                result[idx][i] = weapon[idx][i];
            }

            for(int i = 0; i < result[idx].Length - 1; i++)
            {
                for(int j = i; j < result[idx].Length - 1; j++)
                {
                    Base_Weapon a = (Base_Weapon)result[idx][j];
                    Base_Weapon b = (Base_Weapon)result[idx][j+1];
                    if (a.dualbility < b.dualbility)
                    {
                        BaseValues tmp = result[idx][j + 1];
                        result[idx][j + 1] = result[idx][j];
                        result[idx][j] = tmp;
                    }
                }
            }
        }

        return result;
    }
    public static BaseValues[] GetAmuletSort()
    {
        BaseValues[] result = new BaseValues[amulet.Length];

        for (int i = 0; i < amulet.Length; i++)
        {
            result[i] = amulet[i];
        }

        for (int i = 0; i < result.Length - 1; i++)
        {
            for (int j = i; j < result.Length - 1; j++)
            {
                Base_Armor a = (Base_Armor)result[j];
                Base_Armor b = (Base_Armor)result[j + 1];
                if (a.dualbility < b.dualbility)
                {
                    BaseValues tmp = result[j + 1];
                    result[j + 1] = result[j];
                    result[j] = tmp;
                }
            }
        }

        return result;
    }
    public static BaseValues[] GetStoneSort()
    {
        BaseValues[] result = new BaseValues[stone.Length];

        for (int i = 0; i < stone.Length; i++)
        {
            result[i] = stone[i];
        }

        for (int i = 0; i < result.Length - 1; i++)
        {
            for (int j = i; j < result.Length - 1; j++)
            {
                Base_Armor a = (Base_Armor)result[j];
                Base_Armor b = (Base_Armor)result[j + 1];
                if (a.dualbility < b.dualbility)
                {
                    BaseValues tmp = result[j + 1];
                    result[j + 1] = result[j];
                    result[j] = tmp;
                }
            }
        }

        return result;
    }

    #endregion
}