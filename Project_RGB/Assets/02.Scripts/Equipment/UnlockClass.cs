using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UnlockClass
{
    public static bool[] red;
    public static bool[] green;
    public static bool[] blue;

    public static bool[][] weapon;

    public static bool[] amulet;
    public static bool[] stone;

    public static bool[] food;

    static UnlockClass()
    {
        red = new bool[] { false };
        green = new bool[] { true };
        blue = new bool[] { false };

        weapon = new bool[][] {
            new bool[] {true },
            new bool[] {false },
            new bool[] {true }
            };


        amulet = new bool[] { true };
        stone = new bool[] { true, true };

        food = new bool[] { true };
    }

    public static bool CheckCode(SpawnCode code)
    {
        bool[] arr = GetCodeToArray(code);
        if (arr == null) return false;

        int num = int.Parse(code.ToString().Substring(2));
        return arr[num];
    }

    public static void UnlockCode(SpawnCode code)
    {
        bool[] arr = GetCodeToArray(code);
        if (arr == null) return;

        int num = int.Parse(code.ToString().Substring(2));
        arr[num] = true;
    }

    private static bool[] GetCodeToArray(SpawnCode code)
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
}
