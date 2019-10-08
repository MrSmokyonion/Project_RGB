using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spear_Default : Weapon_Spear
{
    public Spear_Default(int _dualbility = 100)
    {
        delay = 1.5f;
        power = 2;
        speed = 8;
        dualbility = _dualbility;
        weaponName = "기본 창";
        spritePath = "Unity_Total_24";
        destroyDelay = 3f;
    }
}
