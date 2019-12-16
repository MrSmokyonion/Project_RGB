using System;
using UnityEngine;

//스프라이트 공급해주는 객체
public class SpriteSupplier : MonoBehaviour
{
    [Header("Weapon")]
    public SpriteSource[] weapon_sword;
    public SpriteSource[] weapon_spear;
    public SpriteSource[] weapon_bow;

    [Header("Skill")]
    public SpriteSource[] skill_red;
    public SpriteSource[] skill_green;
    public SpriteSource[] skill_blue;

    [Header("Armor")]
    public SpriteSource[] armor_Amulet;
    public SpriteSource[] armor_Stone;

    [Header("Food")]
    public SpriteSource[] food;



    public static SpriteSupplier instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    public Sprite GetSource(SpawnCode code)
    {
        SpriteSource s = null;

        switch(code)
        {
            case SpawnCode.W001: case SpawnCode.W002: case SpawnCode.W003: case SpawnCode.W004: case SpawnCode.W005:
                s = Array.Find(weapon_sword, tmp => tmp.code == code); break;
            case SpawnCode.W101: case SpawnCode.W102: case SpawnCode.W103: case SpawnCode.W104: case SpawnCode.W105:
                s = Array.Find(weapon_spear, tmp => tmp.code == code); break;
            case SpawnCode.W201: case SpawnCode.W202: case SpawnCode.W203: case SpawnCode.W204: case SpawnCode.W205:
                s = Array.Find(weapon_bow, tmp => tmp.code == code); break;
                
            case SpawnCode.R001: case SpawnCode.R002: case SpawnCode.R003: case SpawnCode.R004: case SpawnCode.R005:
                s = Array.Find(skill_red, tmp => tmp.code == code); break;
            case SpawnCode.G001: case SpawnCode.G002: case SpawnCode.G003: case SpawnCode.G004: case SpawnCode.G005:
                s = Array.Find(skill_green, tmp => tmp.code == code); break;
            case SpawnCode.B001: case SpawnCode.B002: case SpawnCode.B003: case SpawnCode.B004: case SpawnCode.B005:
                s = Array.Find(skill_blue, tmp => tmp.code == code); break;


            case SpawnCode.A001:
            case SpawnCode.A002:
            case SpawnCode.A003:
            case SpawnCode.A004:
            case SpawnCode.A005:
                s = Array.Find(armor_Amulet, tmp => tmp.code == code); break;
            case SpawnCode.S001:
            case SpawnCode.S002:
            case SpawnCode.S003:
            case SpawnCode.S004:
            case SpawnCode.S005:
                s = Array.Find(armor_Stone, tmp => tmp.code == code); break;

            case SpawnCode.F001: case SpawnCode.F002: case SpawnCode.F003: case SpawnCode.F004: case SpawnCode.F005:
                s = Array.Find(food, tmp => tmp.code == code); break;


        }

        if(s == null)
        {
            Debug.LogWarning("SpriteSupplier: " + code.ToString() + " does not found!");
            return null;
        }

        return s.source;
    }

    public Sprite GetSource(string name)
    {
        //여기에 UI 등등 할당해주면 될듯
        return null;   
    }
}
