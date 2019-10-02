using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow_Default : Weapon_Bow
{
    public Bow_Default()
    {
        power = 3;
        delay = 0.5f;
        weaponName = "그냥 활";
        dualbility = 100;
        speed = 10;
    }
}