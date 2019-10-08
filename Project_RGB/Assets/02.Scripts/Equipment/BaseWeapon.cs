using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Base_Weapon
{
    public float delay;         //무기 쿨타임
    public int power;           //데미지
    public int dualbility;      //내구도
    public string weaponName;   //무기 이름
    public string spritePath;   //무기 이미지 패스
}

public abstract class Weapon_Sword : Base_Weapon { }
public abstract class Weapon_Spear : Base_Weapon { public int speed; public float destroyDelay; }
public abstract class Weapon_Bow : Base_Weapon { public int speed; }
