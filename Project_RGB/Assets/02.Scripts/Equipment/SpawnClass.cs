using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SpawnClass
{
    #region Weapon
    public static Weapon_Sword GetWeapon_Sword(SpawnCode weaponCode)
    {
        if (!UnlockClass.CheckCode(weaponCode)) return null;

        switch (weaponCode)
        {
            case SpawnCode.W001: return new Sword_Default();
        }
        return null;
    }

    public static Weapon_Spear GetWeapon_Spear(SpawnCode weaponCode)
    {
        if (!UnlockClass.CheckCode(weaponCode)) return null;

        switch (weaponCode)
        {
            case SpawnCode.W101: return new Spear_Default();
        }
        return null;
    }

    public static Weapon_Bow GetWeapon_Bow(SpawnCode weaponCode)
    {
        if (!UnlockClass.CheckCode(weaponCode)) return null;

        switch (weaponCode)
        {
            case SpawnCode.W201: return new Bow_Default();
        }
        return null;
    }
    #endregion

    #region Equitment
    public static Armor_Amulet GetArmor_Amulet(SpawnCode armorCode)
    {
        if (!UnlockClass.CheckCode(armorCode)) return null;

        switch (armorCode)
        {
            case SpawnCode.A001: return new Amulet_Default();
        }
        return null;
    }

    public static Armor_Stone GetArmor_Stone(SpawnCode armorCode)
    {
        if (!UnlockClass.CheckCode(armorCode)) return null;

        switch (armorCode)
        {
            case SpawnCode.S001: return new Stone_Default();
            case SpawnCode.S002: return new Stone_ImproveSkill();
        }
        return null;
    }
    #endregion

    #region Skill
    public static Skill_Red GetSkill_Red(SpawnCode skillcode)
    {
        if (!UnlockClass.CheckCode(skillcode)) return null;

        switch (skillcode)
        {
            case SpawnCode.R001: return new Skill_Red_Fire();
        }
        return null;
    }
    public static Skill_Green GetSkill_Green(SpawnCode skillcode)
    {
        if (!UnlockClass.CheckCode(skillcode)) return null;

        switch (skillcode)
        {
            case SpawnCode.G001: return new Skill_Green_HighJump();
        }
        return null;
    }
    public static Skill_Blue GetSkill_Blue(SpawnCode skillcode)
    {
        if (!UnlockClass.CheckCode(skillcode)) return null;

        switch (skillcode)
        {
            case SpawnCode.B001: return new Skill_Blue_Shield();
        }
        return null;
    }
    #endregion

    #region Food
    public static BaseFood GetFood(SpawnCode foodcode)
    {
        if (!UnlockClass.CheckCode(foodcode)) return null;

        switch (foodcode)
        {
            case SpawnCode.F001: return new Food_Hamburger();
        }
        return null;
    }
    #endregion
}
public enum SpawnCode
{
    //None
    NONE,

    //Skill R
    R001,
    G001, //HighJump
    B001,

    //Weapon
    W001, //Default Sword
    W101, //Default Spear
    W201, //Default Bow

    //Equitment
    A001, //Default Amulet
    S001, //Default Stone
    S002, //ImproveSkill Stone

    //Food
    F001 //Hamburger
}