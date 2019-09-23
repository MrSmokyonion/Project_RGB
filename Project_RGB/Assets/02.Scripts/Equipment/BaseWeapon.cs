using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseWeapon
{
    public float delay;
    public int power;
    public string weaponName;
    public int dualbility;
}

public abstract class Weapon_Sword : BaseWeapon { }
public abstract class Weapon_Spear : BaseWeapon { }
public abstract class Weapon_Bow : BaseWeapon { public int speed; }
