using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow_Default : Weapon_Bow
{
    public Bow_Default()
    {
        delay = 0.5f;
        power = 3;
        speed = 10;
        dualbility = 100;
        weaponName = "그냥 활";
        spritePath = "Unity_Total_25";
    }
}