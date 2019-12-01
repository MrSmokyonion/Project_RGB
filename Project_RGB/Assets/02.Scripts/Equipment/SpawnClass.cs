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
            case SpawnCode.W002: tmp = _child.AddComponent<Sword_HotTuna>(); break;
            case SpawnCode.W003: tmp = _child.AddComponent<Sword_BBQStick>(); break;
            case SpawnCode.W004: tmp = _child.AddComponent<Sword_Broad>(); break;
            case SpawnCode.W005: tmp = _child.AddComponent<Sword_MoonLight>(); break;

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
            case SpawnCode.W102: tmp = _child.AddComponent<Spear_IceNalchi>(); break;
            case SpawnCode.W103: tmp = _child.AddComponent<Spear_Nyan>(); break;
            case SpawnCode.W104: tmp = _child.AddComponent<Spear_DangPa>(); break;
            case SpawnCode.W105: tmp = _child.AddComponent<Spear_PolarStar>(); break;
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
            case SpawnCode.W202: tmp = _child.AddComponent<Bow_NoMoney>(); break;
            case SpawnCode.W203: tmp = _child.AddComponent<Bow_Dryed>(); break;
            case SpawnCode.W204: tmp = _child.AddComponent<Bow_Long>(); break;
            case SpawnCode.W205: tmp = _child.AddComponent<Bow_Apollo>(); break;
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
            case SpawnCode.A002: tmp = _child.AddComponent<Amulet_Richness>(); break;
            case SpawnCode.A003: tmp = _child.AddComponent<Amulet_Drain>(); break;
            case SpawnCode.A004: tmp = _child.AddComponent<Amulet_ImproveSkill>(); break;
            case SpawnCode.A005: tmp = _child.AddComponent<Amulet_PainPatch>(); break;
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
            case SpawnCode.S002: tmp = _child.AddComponent<Stone_Magnetic>(); break;
            case SpawnCode.S003: tmp = _child.AddComponent<Stone_Guardian>(); break;
            case SpawnCode.S004: tmp = _child.AddComponent<Stone_Minor>(); break;
            case SpawnCode.S005: tmp = _child.AddComponent<Stone_Major>(); break;
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
            case SpawnCode.R002: tmp = _child.AddComponent<Skill_Red_ArrowRain>(); break;
            case SpawnCode.R003: tmp = _child.AddComponent<Skill_Red_SwordTrap>(); break;
            case SpawnCode.R004: tmp = _child.AddComponent<Skill_Red_Turret>(); break;
            case SpawnCode.R005: tmp = _child.AddComponent<Skill_Red_PowerBuff>(); break;
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
            case SpawnCode.G002: tmp = _child.AddComponent<Skill_Green_Dash>(); break;
            case SpawnCode.G003: tmp = _child.AddComponent<Skill_Green_BackStep>(); break;
            case SpawnCode.G004: tmp = _child.AddComponent<Skill_Green_Charger>(); break;
            case SpawnCode.G005: tmp = _child.AddComponent<Skill_Green_MoveBuff>(); break;
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
            case SpawnCode.B002: tmp = _child.AddComponent<Skill_Blue_Wall>(); break;
            case SpawnCode.B003: tmp = _child.AddComponent<Skill_Blue_Invisible>(); break;
            case SpawnCode.B004: tmp = _child.AddComponent<Skill_Blue_Shield>(); break;
            case SpawnCode.B005: tmp = _child.AddComponent<Skill_Blue_DefenceBuff>(); break;
            default: return null;
        }

        //여기에 라우터로 장비 바꿨다는 포스트 날려야함
        return tmp;
    }

    public GameObject LoadAll_Skill()
    {
        GameObject result = new GameObject();

        result.AddComponent<Skill_Red_PiercingSpear>();
        result.AddComponent<Skill_Red_ArrowRain>();
        result.AddComponent<Skill_Red_SwordTrap>();
        result.AddComponent<Skill_Red_Turret>();
        result.AddComponent<Skill_Red_PowerBuff>();

        result.AddComponent<Skill_Green_HighJump>();
        result.AddComponent<Skill_Green_Dash>();
        result.AddComponent<Skill_Green_BackStep>();
        result.AddComponent<Skill_Green_Charger>();
        result.AddComponent<Skill_Green_MoveBuff>();

        result.AddComponent<Skill_Blue_Barrier>();
        result.AddComponent<Skill_Blue_Wall>();
        result.AddComponent<Skill_Blue_Invisible>();
        result.AddComponent<Skill_Blue_Shield>();
        result.AddComponent<Skill_Blue_DefenceBuff>();

        return result;
    }
    public GameObject LoadAll_Armor()
    {
        GameObject result = new GameObject();

        result.AddComponent<Amulet_Default>();
        result.AddComponent<Amulet_Richness>();
        result.AddComponent<Amulet_Drain>();
        result.AddComponent<Amulet_ImproveSkill>();
        result.AddComponent<Amulet_PainPatch>();

        result.AddComponent<Stone_Default>();
        result.AddComponent<Stone_Magnetic>();
        result.AddComponent<Stone_Guardian>();
        result.AddComponent<Stone_Minor>();
        result.AddComponent<Stone_Major>();

        return result;
    }
    public GameObject LoadAll_Food()
    {
        GameObject result = new GameObject();

        result.AddComponent<Food_Hamburger>();
        result.AddComponent<Food_Pizza>();
        result.AddComponent<Food_Noodle>();
        result.AddComponent<Food_RiceBall>();
        result.AddComponent<Food_Steak>();

        return result;
    }
    public GameObject LoadAll_Weapon()
    {
        GameObject result = new GameObject();

        result.AddComponent<Sword_Default>();
        result.AddComponent<Sword_HotTuna>();
        result.AddComponent<Sword_BBQStick>();
        result.AddComponent<Sword_Broad>();
        result.AddComponent<Sword_MoonLight>();

        result.AddComponent<Spear_Default>();
        result.AddComponent<Spear_IceNalchi>();
        result.AddComponent<Spear_Nyan>();
        result.AddComponent<Spear_DangPa>();
        result.AddComponent<Spear_PolarStar>();

        result.AddComponent<Bow_Default>();
        result.AddComponent<Bow_NoMoney>();
        result.AddComponent<Bow_Dryed>();
        result.AddComponent<Bow_Long>();
        result.AddComponent<Bow_Apollo>();

        return result;
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
            case SpawnCode.F002: tmp = _child.AddComponent<Food_Pizza>(); break;
            case SpawnCode.F003: tmp = _child.AddComponent<Food_Noodle>(); break;
            case SpawnCode.F004: tmp = _child.AddComponent<Food_RiceBall>(); break;
            case SpawnCode.F005: tmp = _child.AddComponent<Food_Steak>(); break;
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