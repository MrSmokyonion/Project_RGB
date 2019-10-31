using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spear_Default : Weapon_Spear
{
    public Spear_Default(int _dualbility = 100)
    {
        title = "기본 창";
        description = "기본 창입니다. 뭘 더 바라시나요.";
        code = SpawnCode.W101;
        dualbility = _dualbility;
        spritePath = "Sprites/Unity_Total.png";

        power = 2;
        speed = 8;
        delay = 1.5f;
        destroyDelay = 3f;
    }
}
