using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Base_Armor
{
    public string armorName;
    public int dualbility;
}

public abstract class Armor_Stone : Base_Armor { public int defence; }
public abstract class Armor_Amulet : Base_Armor { public int hp; }