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
    public Weapon_Sword GetWeapon_Sword(SpawnCode weaponCode, GameObject _child)
    {
        if (!unlock.CheckCode(weaponCode)) return null;

        Weapon_Sword dump = _child.GetComponent<Weapon_Sword>();
        if (dump != null)
            Destroy(dump);

        Weapon_Sword tmp;
        switch (weaponCode)
        {
            case SpawnCode.W001: tmp = _child.AddComponent<Sword_Default>(); break;
            default: return null;
        }

        //여기에 라우터로 장비 바꿨다는 포스트 날려야함
        return tmp;
    }

    public Weapon_Spear GetWeapon_Spear(SpawnCode weaponCode, GameObject _child)
    {
        if (!unlock.CheckCode(weaponCode)) return null;

        Weapon_Spear dump = _child.GetComponent<Weapon_Spear>();
        if (dump != null)
            Destroy(dump);

        Weapon_Spear tmp;
        switch (weaponCode)
        {
            case SpawnCode.W101: tmp = _child.AddComponent<Spear_Default>(); break;
            default: return null;
        }

        //여기에 라우터로 장비 바꿨다는 포스트 날려야함
        return tmp;
    }

    public Weapon_Bow GetWeapon_Bow(SpawnCode weaponCode, GameObject _child)
    {
        if (!unlock.CheckCode(weaponCode)) return null;

        Weapon_Bow dump = _child.GetComponent<Weapon_Bow>();
        if (dump != null)
            Destroy(dump);

        Weapon_Bow tmp;
        switch (weaponCode)
        {
            case SpawnCode.W201: tmp = _child.AddComponent<Bow_Default>(); break;
            default: return null;
        }

        //여기에 라우터로 장비 바꿨다는 포스트 날려야함
        return tmp;
    }
    #endregion

    #region Equitment
    public Armor_Amulet GetArmor_Amulet(SpawnCode armorCode, GameObject _child)
    {
        if (!unlock.CheckCode(armorCode)) return null;

        Armor_Amulet dump = _child.GetComponent<Armor_Amulet>();
        if (dump != null)
            Destroy(dump);

        Armor_Amulet tmp;
        switch (armorCode)
        {
            case SpawnCode.A001: tmp = _child.AddComponent<Amulet_Default>(); break;
            default: return null;
        }

        //여기에 라우터로 장비 바꿨다는 포스트 날려야함
        return tmp;
    }

    public Armor_Stone GetArmor_Stone(SpawnCode armorCode, GameObject _child)
    {
        if (!unlock.CheckCode(armorCode)) return null;

        Armor_Stone dump = _child.GetComponent<Armor_Stone>();
        if (dump != null)
            Destroy(dump);

        Armor_Stone tmp;
        switch (armorCode)
        {
            case SpawnCode.S001: tmp = _child.AddComponent<Stone_Default>(); break;
            default: return null;
        }

        //여기에 라우터로 장비 바꿨다는 포스트 날려야함
        return tmp;
    }
    #endregion

    #region Skill
    public Skill_Red GetSkill_Red(SpawnCode skillcode, GameObject _child)
    {
        if (!unlock.CheckCode(skillcode)) return null;

        Skill_Red dump = _child.GetComponent<Skill_Red>();
        if (dump != null)
            Destroy(dump);


        Skill_Red tmp;
        switch (skillcode)
        {
            case SpawnCode.R001: tmp = _child.AddComponent<Skill_Red_PiercingSpear>(); break;
            default: return null;
        }

        //여기에 라우터로 장비 바꿨다는 포스트 날려야함
        return tmp;
    }
    public Skill_Green GetSkill_Green(SpawnCode skillcode, GameObject _child)
    {
        if (!unlock.CheckCode(skillcode)) return null;

        Skill_Green dump = _child.GetComponent<Skill_Green>();
        if (dump != null)
            Destroy(dump);

        Skill_Green tmp;
        switch (skillcode)
        {
            case SpawnCode.G001: tmp = _child.AddComponent<Skill_Green_HighJump>(); break;
            default: return null;
        }

        //여기에 라우터로 장비 바꿨다는 포스트 날려야함
        return tmp;
    }
    public Skill_Blue GetSkill_Blue(SpawnCode skillcode, GameObject _child)
    {
        if (!unlock.CheckCode(skillcode)) return null;

        Skill_Blue dump = _child.GetComponent<Skill_Blue>();
        if (dump != null)
            Destroy(dump);

        Skill_Blue tmp;
        switch (skillcode)
        {
            case SpawnCode.B001: tmp = _child.AddComponent<Skill_Blue_Barrier>(); break;
            case SpawnCode.B005: tmp = _child.AddComponent<Skill_Blue_DefenceBuff>(); break;
            default: return null;
        }

        //여기에 라우터로 장비 바꿨다는 포스트 날려야함
        return tmp;
    }
    #endregion

    #region Food
    public BaseFood GetFood(SpawnCode foodcode, GameObject _child)
    {
        if (!unlock.CheckCode(foodcode)) return null;

        BaseFood dump = _child.GetComponent<BaseFood>();
        if (dump != null)
            Destroy(dump);

        BaseFood tmp;
        switch (foodcode)
        {
            case SpawnCode.F001: tmp = _child.AddComponent<Food_Hamburger>(); break;
            default: return null;
        }

        //여기에 라우터로 장비 바꿨다는 포스트 날려야함
        return tmp;
    }
    #endregion
}
public enum SpawnCode
{
    NONE,

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