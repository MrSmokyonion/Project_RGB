using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Base_Weapon
{
    public float delay;
    public int power;
    public string weaponName;
    public int dualbility;
}

public abstract class Weapon_Sword : Base_Weapon { }
public abstract class Weapon_Spear : Base_Weapon { }
public abstract class Weapon_Bow : Base_Weapon { public int speed; }
