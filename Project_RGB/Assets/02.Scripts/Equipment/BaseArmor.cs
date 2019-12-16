using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Base_Armor : BaseValues
{
    public int value;
    public int dualbility;

    public virtual void Execute(PlayerStatus status) { Debug.Log("***ARMOR***"); }
}

public abstract class Armor_Stone : Base_Armor { }
public abstract class Armor_Amulet : Base_Armor { }