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
    #region Skill

    R001, //Skill_Red_PiercingSpear
    R002, //Skill_Red_ArrowRain
    R003, //Skill_Red_SwordTrap
    R004, //Skill_Red_Turret
    R005, //Skill_Red_PowerBuff

    G001, //Skill_Green_HighJump
    G002, //Skill_Green_Dash
    G003, //Skill_Green_BackStep
    G004, //Skill_Green_Charger
    G005, //Skill_Green_MoveBuff

    B001, //Skill_Blue_Barrier
    B002, //Skill_Blue_Wall
    B003, //Skill_Blue_Invisible
    B004, //Skill_Blue_Shield
    B005, //Skill_Blue_DefenceBuff

    #endregion

    #region Weapon
    W001, //Sword_Default
    W002, //Sword_HotTuna
    W003, //Sword_BBQStick
    W004, //Sword_Broad
    W005, //Sword_MoonLight
          //
    W101, //Spear_Default
    W102, //Spear_IceNalchi
    W103, //Spear_Nyan
    W104, //Spear_DangPa
    W105, //Spear_PolarStar

    W201, //Bow_Default
    W202, //Bow_NoMoney
    W203, //Bow_Dryed
    W204, //Bow_Long
    W205, //Bow_Apollo
    #endregion

    #region Equitment
    A001, //Amulet_Default
    A002, //Amulet_Richness
    A003, //Amulet_Drain
    A004, //Amulet_ImproveSkill
    A005, //Amulet_PainPatch

    S001, //Stone_Default
    S002, //Stone_Magnetic
    S003, //Stone_Guardian
    S004, //Stone_Minor
    S005, //Stone_Major
    #endregion

    #region Food
    F001, //Food_Hamburger
    F002, //Food_Pizza
    F003, //Food_Noodle
    F004, //Food_RiceBall
    F005  //Food_Steak
    #endregion
}