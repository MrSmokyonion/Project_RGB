using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Base_Weapon : BaseValues
{
    public int dualbility;      //내구도

    public int power;           //데미지
    public float delay;         //무기 쿨타임
}

public abstract class Weapon_Sword : Base_Weapon { }
public abstract class Weapon_Spear : Base_Weapon { public int speed; }
public abstract class Weapon_Bow : Base_Weapon { public int speed; }
