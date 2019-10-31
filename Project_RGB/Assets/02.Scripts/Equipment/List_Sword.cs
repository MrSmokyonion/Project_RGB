using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword_Default : Weapon_Sword
{
    public Sword_Default()
    {
        title = "기본 검";
        code = SpawnCode.W001;
        dualbility = 100;
        spritePath = "";

        power = 5;
        delay = 0.5f;
    }
}