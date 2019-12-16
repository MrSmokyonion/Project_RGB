using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Red_PiercingSpear : Skill_Red //101
{
    public Skill_Red_PiercingSpear()
    {
        m_value1 = 0;
        m_value2 = 5;
        m_delay = 6.0f;

        m_title = "피어싱스피어";
        m_description = string.Format("{0}의 데미지를 주는 창을 전방으로 던집니다.(최대 {1}명)", m_value1, m_value2);
        m_code = SpawnCode.R001;
        m_spritePath = "";
        m_price = 1;
        m_isSale = true;
    }

    public override void ExecuteSkill(GameObject obj)
    {
        Debug.Log("Red Skill -> PiercingSpear!");
        bool dir = obj.GetComponent<SpriteRenderer>().flipX;

        GameObject go = GameObject.Instantiate(obj.GetComponent<PlayerStatus>().skillCollector.piercingSpear);
        SkillEffect.PiercingSpear ps = go.GetComponent<SkillEffect.PiercingSpear>();

        Vector3 pos = obj.transform.position;
        go.transform.position = new Vector2(pos.x + (dir ? -1.0f : 1.0f), pos.y);

        ps.speed = (dir ? -8.0f : 8.0f);
    }
}

public class Skill_Red_ArrowRain : Skill_Red //101
{
    public Skill_Red_ArrowRain()
    {
        m_value1 = 0;
        m_value2 = 3;
        m_delay = 8.0f;

        m_title = "애로우레인";
        m_description = string.Format("{0}의 데미지를 {1}번주는 화살비를 내립니다.", m_value1, m_value2);
        m_code = SpawnCode.R002;
        m_spritePath = "";
        m_price = 1;
        m_isSale = true;
    }

    public override void ExecuteSkill(GameObject obj)
    {
        Debug.Log("Red Skill -> Fire!");
    }
}

public class Skill_Red_SwordTrap : Skill_Red //101
{
    public Skill_Red_SwordTrap()
    {
        m_value1 = 0;
        m_value2 = 20f;
        m_delay = 15.0f;

        m_title = "스워드트랩";
        m_description = string.Format("발동 시, {0}의 데미지를 주는 트랩을 전방에 설치합니다.({1}초 동안)", m_value1, m_value2);
        m_code = SpawnCode.R003;
        m_spritePath = "";
        m_price = 1;
        m_isSale = true;
    }

    public override void ExecuteSkill(GameObject obj)
    {
        Debug.Log("Red Skill -> Fire!");
    }
}

public class Skill_Red_Turret : Skill_Red //101
{
    public Skill_Red_Turret()
    {
        m_value1 = 0;
        m_value2 = 10f;
        m_delay = 20.0f;

        m_title = "터렛";
        m_description = string.Format("발동 시, 주변 적 1명에게 {0}의 데미지를 주는 터렛을 소환해 플레이어 주변에 떠돌게 합니다. ({1}초 동안)", m_value1, m_value2);
        m_code = SpawnCode.R004;
        m_spritePath = "";
        m_price = 1;
        m_isSale = true;
    }

    public override void ExecuteSkill(GameObject obj)
    {
        Debug.Log("Red Skill -> Fire!");
    }
}

public class Skill_Red_PowerBuff : Skill_Red //101
{
    public Skill_Red_PowerBuff()
    {
        m_value1 = 0;
        m_value2 = 10f;
        m_delay = 25.0f;

        m_title = "플레임웨폰";
        m_description = string.Format("발동 시, 무기를 강화하여 무기의 공격력을 {0}만큼 상승시킵니다. ({1}초 동안)", m_value1, m_value2);
        m_code = SpawnCode.R005;
        m_spritePath = "";
        m_price = 1;
        m_isSale = true;
    }

    public override void ExecuteSkill(GameObject obj)
    {
        Debug.Log("Red Skill -> Fire!");
    }
}