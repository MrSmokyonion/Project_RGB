using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Skill_Blue_Barrier : Skill_Blue
{
    public Skill_Blue_Barrier()
    {
        m_value1 = 3;
        m_value2 = 10;
        m_delay = 20f;

        m_title = "배리어";
        m_description = string.Format("{1}초동안 플레이어에게 {0}번의 피해를 방어하는 보호막을 씌워줍니다.", m_value1, m_value2);
        m_code = SpawnCode.B001;
        m_spritePath = "";
        m_price = 1;
        m_isSale = true;
    }

    public override void ExecuteSkill(GameObject obj)
    {
        Debug.Log("Blue Skill -> " + m_title);

        GameObject barrierObj = GameObject.Instantiate(FindObjectOfType<SkillEffect.SkillCollector>().barrier, obj.transform);
        Barrier barrierClass = barrierObj.GetComponent<Barrier>();

        barrierClass.barrierCnt = m_value1;
        barrierClass.time = m_value2;
    }
}

public class Skill_Blue_Wall : Skill_Blue
{
    public Skill_Blue_Wall()
    {
        m_value1 = 0;
        m_value2 = 15;
        m_delay = 30f;

        m_title = "배리어";
        m_description = string.Format("발동 시, 주위에 {1}초동안 {0}만큼의 피해를 막아주는 돔을 생성합니다.", m_value1, m_value2);
        m_code = SpawnCode.B002;
        m_spritePath = "";
        m_price = 1;
        m_isSale = true;
    }

    public override void ExecuteSkill(GameObject obj)
    {
        Debug.Log("Blue Skill -> " + m_title);
    }
}

public class Skill_Blue_Invisible : Skill_Blue
{
    public Skill_Blue_Invisible()
    {
        m_value1 = 0;
        m_value2 = 2;
        m_delay = 15f;

        m_title = "인비지블";
        m_description = string.Format("발동 즉시, {0}초만큼 무적이 됩니다. 시전하는 동안엔 이동할 수 없습니다.", m_value2);
        m_code = SpawnCode.B003;
        m_spritePath = "";
        m_price = 1;
        m_isSale = true;
    }

    public override void ExecuteSkill(GameObject obj)
    {
        Debug.Log("Blue Skill -> " + m_title);
    }
}

public class Skill_Blue_Shield : Skill_Blue
{
    public Skill_Blue_Shield()
    {
        m_value1 = 0;
        m_value2 = 5;
        m_delay = 10f;

        m_title = "실드";
        m_description = string.Format("전방에 {1}초 동안 받는 피해의 {0}만큼을 감소시키는 방패를 듭니다. (시전시, 방향전환x)(On/Off 스킬)", m_value1, m_value2);
        m_code = SpawnCode.B004;
        m_spritePath = "";
        m_price = 1;
        m_isSale = true;
    }

    public override void ExecuteSkill(GameObject obj)
    {
        Debug.Log("Blue Skill -> " + m_title);
    }
}

public class Skill_Blue_DefenceBuff : Skill_Blue
{
    GameObject target = null;
    public Skill_Blue_DefenceBuff()
    {
        m_value1 = 9999;
        m_value2 = 5;
        m_delay = 25f;

        m_title = "풀 아머";
        m_description = string.Format("{1}초동안 플레이어에게 {0}만큼의 방어력을 증가시킵니다.", m_value1, m_value2);
        m_code = SpawnCode.B005;
        m_spritePath = "";
        m_price = 1;
        m_isSale = true;
    }

    public override void ExecuteSkill(GameObject obj)
    {
        Debug.Log("Blue Skill -> " + m_title);

        //obj.GetComponent<PlayerStatus>().defence += (int)m_value1;
        //target = obj;

        //Thread thread = new Thread(new ThreadStart(CancelSkill));
        //thread.Start();
        //thread.Join();
        //Debug.Log("여기입니다 SOSOSOSOSOSOSOOSOSOSOSOOSOSOSOSOOSOSOS");
    }

    //void CancelSkill()
    //{
    //    Thread.Sleep((int)m_value2 * 1000);
    //    target.GetComponent<PlayerStatus>().defence -= (int)m_value1;
    //}
}