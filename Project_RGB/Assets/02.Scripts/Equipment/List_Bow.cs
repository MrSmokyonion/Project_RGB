using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow_Default : Weapon_Bow
{
    public Bow_Default()
    {
        title = "그냥 활";
        code = SpawnCode.W201;
        dualbility = 100;
        spritePath = "Unity_Total_25";
        isUnlock = false;
        power = 3;
        speed = 10;
        delay = 0.5f;
    }
}