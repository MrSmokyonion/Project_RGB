using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultBow : Weapon_Bow
{
    public DefaultBow()
    {
        power = 3;
        delay = 1f;
        weaponName = "그냥 활";
        dualbility = 100;
        speed = 5;
    }
}