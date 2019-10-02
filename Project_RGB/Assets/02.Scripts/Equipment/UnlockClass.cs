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
        stone = new bool[] { true };

        food = new bool[] { true };
    }

    public static bool IsUnlockCode(SpawnCode code)
    {
        string str = code.ToString();
        string section = str.Substring(0, 1);
        int num1 = int.Parse(str.Substring(1, 1));
        int num2 = int.Parse(str.Substring(2));

        switch(section)
        {
            case "R": return red[num2-1];
            case "G": return green[num2 - 1];
            case "B": return blue[num2 - 1];

            case "W": return weapon[num1][num2 - 1];

            case "A": return amulet[num2 - 1];
            case "S": return amulet[num2 - 1];

            case "F": return food[num2 - 1];

            default: return false;
        }
    }
}
