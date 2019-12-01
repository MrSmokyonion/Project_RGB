using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//스프라이트 공급해주는 객체
public class SpriteSupplier : MonoBehaviour
{
    [Header("Weapon")]
    public List<Sprite> m_weapon_sword;
    public List<Sprite> m_weapon_spear;
    public List<Sprite> m_weapon_bow;

    [Header("Skill")]
    public List<Sprite> m_skill_red;
    public List<Sprite> m_skill_green;
    public List<Sprite> m_skill_blue;

    public Sprite GetSprite(SpawnCode code)
    {
        Sprite result = null;

        switch(code)
        {
            case SpawnCode.W001: case SpawnCode.W002: case SpawnCode.W003: case SpawnCode.W004: case SpawnCode.W005:
            case SpawnCode.W101: case SpawnCode.W102: case SpawnCode.W103: case SpawnCode.W104: case SpawnCode.W105:
            case SpawnCode.W201: case SpawnCode.W202: case SpawnCode.W203: case SpawnCode.W204: case SpawnCode.W205:
                result = GetSprite_Weapon(code);
                break;

            case SpawnCode.R001: case SpawnCode.R002: case SpawnCode.R003: case SpawnCode.R004: case SpawnCode.R005:
            case SpawnCode.G001: case SpawnCode.G002: case SpawnCode.G003: case SpawnCode.G004: case SpawnCode.G005:
            case SpawnCode.B001: case SpawnCode.B002: case SpawnCode.B003: case SpawnCode.B004: case SpawnCode.B005:
                result = GetSprite_Skill(code);
                break;
        }

        return result;
    }

    private Sprite GetSprite_Weapon(SpawnCode code)
    {
        switch(code)
        {
            case SpawnCode.W001: return m_weapon_sword[0];
            case SpawnCode.W002: return m_weapon_sword[1];
            case SpawnCode.W003: return m_weapon_sword[2];
            case SpawnCode.W004: return m_weapon_sword[3];
            case SpawnCode.W005: return m_weapon_sword[4];

            case SpawnCode.W101: return m_weapon_spear[0];
            case SpawnCode.W102: return m_weapon_spear[1];
            case SpawnCode.W103: return m_weapon_spear[2];
            case SpawnCode.W104: return m_weapon_spear[3];
            case SpawnCode.W105: return m_weapon_spear[4];

            case SpawnCode.W201: return m_weapon_bow[0];
            case SpawnCode.W202: return m_weapon_bow[1];
            case SpawnCode.W203: return m_weapon_bow[2];
            case SpawnCode.W204: return m_weapon_bow[3];
            case SpawnCode.W205: return m_weapon_bow[4];

            default: return null;
        }
    }
    private Sprite GetSprite_Skill(SpawnCode code)
    {
        //TODO: 스킬 아이콘 할때랑 스킬 시전할때 스프라이트 구분할 필요가 있음
        switch (code)
        {
            case SpawnCode.R001: return m_skill_red[0];
            case SpawnCode.R002: return m_skill_red[1];
            case SpawnCode.R003: return m_skill_red[2];
            case SpawnCode.R004: return m_skill_red[3];
            case SpawnCode.R005: return m_skill_red[4];

            case SpawnCode.G001: return m_skill_green[0];
            case SpawnCode.G002: return m_skill_green[1];
            case SpawnCode.G003: return m_skill_green[2];
            case SpawnCode.G004: return m_skill_green[3];
            case SpawnCode.G005: return m_skill_green[4];

            case SpawnCode.B001: return m_skill_blue[0];
            case SpawnCode.B002: return m_skill_blue[1];
            case SpawnCode.B003: return m_skill_blue[2];
            case SpawnCode.B004: return m_skill_blue[3];
            case SpawnCode.B005: return m_skill_blue[4];

            default: return null;
        }
    }
}
