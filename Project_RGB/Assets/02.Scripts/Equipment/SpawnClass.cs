using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnClass : MonoBehaviour
{
    public UnlockClass unlock;
    public Dictionary<SpawnCode, int> dict;

    private void Start()
    {
        dict = new Dictionary<SpawnCode, int>();
    }

    public bool GetIsUnlocked(SpawnCode code)
    {
        return unlock.CheckCode(code);
    }
    public void UnlockCode(SpawnCode code, int durability = 100)
    {
        unlock.UnlockCode(code);
        dict.Add(code, durability);
    }

    #region Weapon
    public Weapon_Sword GetWeapon_Sword(SpawnCode weaponCode)
    {
        if (!unlock.CheckCode(weaponCode)) return null;

        Weapon_Sword tmp;
        switch (weaponCode)
        {
            case SpawnCode.W001: tmp = new Sword_Default(); break;
            default: return null;
        }

        //여기에 라우터로 장비 바꿨다는 포스트 날려야함
        return tmp;
    }

    public Weapon_Spear GetWeapon_Spear(SpawnCode weaponCode)
    {
        if (!unlock.CheckCode(weaponCode)) return null;

        Weapon_Spear tmp;
        switch (weaponCode)
        {
            case SpawnCode.W101: tmp = new Spear_Default(); break;
            default: return null;
        }

        //여기에 라우터로 장비 바꿨다는 포스트 날려야함
        return tmp;
    }

    public Weapon_Bow GetWeapon_Bow(SpawnCode weaponCode)
    {
        if (!unlock.CheckCode(weaponCode)) return null;

        Weapon_Bow tmp;
        switch (weaponCode)
        {
            case SpawnCode.W201: tmp = new Bow_Default(); break;
            default: return null;
        }

        //여기에 라우터로 장비 바꿨다는 포스트 날려야함
        return tmp;
    }
    #endregion

    #region Equitment
    public Armor_Amulet GetArmor_Amulet(SpawnCode armorCode)
    {
        if (!unlock.CheckCode(armorCode)) return null;

        Armor_Amulet tmp;
        switch (armorCode)
        {
            case SpawnCode.A001: tmp = new Amulet_Default(); break;
            default: return null;
        }

        //여기에 라우터로 장비 바꿨다는 포스트 날려야함
        return tmp;
    }

    public Armor_Stone GetArmor_Stone(SpawnCode armorCode)
    {
        if (!unlock.CheckCode(armorCode)) return null;

        Armor_Stone tmp;
        switch (armorCode)
        {
            case SpawnCode.S001: tmp = new Stone_Default(); break;
            case SpawnCode.S002: tmp = new Stone_ImproveSkill(); break;
            default: return null;
        }

        //여기에 라우터로 장비 바꿨다는 포스트 날려야함
        return tmp;
    }
    #endregion

    #region Skill
    public Skill_Red GetSkill_Red(SpawnCode skillcode)
    {
        if (!unlock.CheckCode(skillcode)) return null;

        switch (skillcode)
        {
            case SpawnCode.R001: return new Skill_Red_Fire(); 
            default: return null;
        }
    }
    public Skill_Green GetSkill_Green(SpawnCode skillcode)
    {
        if (!unlock.CheckCode(skillcode)) return null;

        Skill_Green tmp;
        switch (skillcode)
        {
            case SpawnCode.G001: tmp = new Skill_Green_HighJump(); break;
            default: return null;
        }

        //여기에 라우터로 장비 바꿨다는 포스트 날려야함
        return tmp;
    }
    public Skill_Blue GetSkill_Blue(SpawnCode skillcode)
    {
        if (!unlock.CheckCode(skillcode)) return null;

        Skill_Blue tmp;
        switch (skillcode)
        {
            case SpawnCode.B001: tmp = new Skill_Blue_Shield(); break;
            default: return null;
        }

        //여기에 라우터로 장비 바꿨다는 포스트 날려야함
        return tmp;
    }
    #endregion

    #region Food
    public BaseFood GetFood(SpawnCode foodcode)
    {
        if (!unlock.CheckCode(foodcode)) return null;

        BaseFood tmp;
        switch (foodcode)
        {
            case SpawnCode.F001: tmp = new Food_Hamburger(); break;
            default: return null;
        }

        //여기에 라우터로 장비 바꿨다는 포스트 날려야함
        return tmp;
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