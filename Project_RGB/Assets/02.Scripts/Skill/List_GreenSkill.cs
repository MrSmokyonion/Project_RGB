using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Green_HighJump : Skill_Green
{
    public Skill_Green_HighJump()
    {
        m_value1 = 20;
        m_value2 = 0;
        m_delay = 6f;

        m_title = "하이 점프";
        m_description = string.Format("{0}만큼의 힘으로 높이 점프합니다.", m_value1);
        m_code = SpawnCode.G001;
        m_spritePath = "";
        m_price = 1;
        m_isSale = true;
    }
    
    public override void ExecuteSkill(GameObject obj)
    {
        Debug.Log("Green Skill -> HighJump!");
        FindObjectOfType<SoundManager>().Play("skill_highJump");
        FindObjectOfType<ParticleSupplier>().SetParticle(obj.gameObject.transform.position, "skill_jump");

        Rigidbody2D rigid = obj.GetComponent<Rigidbody2D>();
        rigid.AddForce(Vector2.up * m_value1, ForceMode2D.Impulse);
    }
}

public class Skill_Green_Dash : Skill_Green
{
    public Skill_Green_Dash()
    {
        m_value1 = 20;
        m_value2 = 0;
        m_delay = 4f;

        m_title = "대쉬";
        m_description = string.Format("{0}만큼 앞으로 점멸합니다. (시전하는 동안 무적)", m_value1);
        m_code = SpawnCode.G002;
        m_spritePath = "";
        m_price = 1;
        m_isSale = true;
    }

    public override void ExecuteSkill(GameObject obj)
    {
        Debug.Log("Green Skill -> " + m_title);
    }
}

public class Skill_Green_BackStep : Skill_Green
{
    public Skill_Green_BackStep()
    {
        m_value1 = 5;
        m_value2 = 0;
        m_delay = 3f;

        m_title = "백스텝";
        m_description = string.Format("{0}만큼 뒤로 후퇴합니다. (이때, 모든 행동은 캔슬됨)", m_value1);
        m_code = SpawnCode.G003;
        m_spritePath = "";
        m_price = 1;
        m_isSale = true;
    }

    public override void ExecuteSkill(GameObject obj)
    {
        Debug.Log("Green Skill -> " + m_title);
    }
}

public class Skill_Green_Charger : Skill_Green
{
    public Skill_Green_Charger()
    {
        m_value1 = 0;
        m_value2 = 0;
        m_delay = 6f;

        m_title = "차저";
        m_description = string.Format("{0}의 속도로 돌진합니다. 이때, 부딭히는 적은 끌고갑니다. 벽에 부딭히거나, 적을 너무 많이 끌면 멈춥니다. (최대 4마리)", m_value1);
        m_code = SpawnCode.G004;
        m_spritePath = "";
        m_price = -123456789;
        m_isSale = false;
    }

    public override void ExecuteSkill(GameObject obj)
    {
        Debug.Log("Green Skill -> " + m_title);
    }
}

public class Skill_Green_MoveBuff : Skill_Green
{
    public Skill_Green_MoveBuff()
    {
        m_value1 = 3;
        m_value2 = 15;
        m_delay = 25f;

        m_title = "헤이스트";
        m_description = string.Format("이동속도가 {1}초동안 {0}만큼 상승합니다.", m_value1, m_value2);
        m_code = SpawnCode.G005;
        m_spritePath = "";
        m_price = 1;
        m_isSale = true;
    }

    public override void ExecuteSkill(GameObject obj)
    {
        Debug.Log("Green Skill -> " + m_title);
    }
}