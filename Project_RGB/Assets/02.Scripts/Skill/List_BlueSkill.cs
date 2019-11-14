using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Skill_Blue_Barrier : Skill_Blue
{
    public Skill_Blue_Barrier()
    {
        value1 = 0;
        value2 = 10;
        delay = 20f;

        title = "배리어";
        description = string.Format("{1}초동안 플레이어에게 {0}만큼 피해를 흡수하는 보호막을 씌워줍니다.", value1, value2);
        code = SpawnCode.B001;
        spritePath = "";
    }

    public override void ExecuteSkill(GameObject obj)
    {
        Debug.Log("Blue Skill -> " + title);
    }
}

public class Skill_Blue_Wall : Skill_Blue
{
    public Skill_Blue_Wall()
    {
        value1 = 0;
        value2 = 15;
        delay = 30f;

        title = "배리어";
        description = string.Format("발동 시, 주위에 {1}초동안 {0}만큼의 피해를 막아주는 돔을 생성합니다.", value1, value2);
        code = SpawnCode.B002;
        spritePath = "";
    }

    public override void ExecuteSkill(GameObject obj)
    {
        Debug.Log("Blue Skill -> " + title);
    }
}

public class Skill_Blue_Invisible : Skill_Blue
{
    public Skill_Blue_Invisible()
    {
        value1 = 0;
        value2 = 2;
        delay = 15f;

        title = "인비지블";
        description = string.Format("발동 즉시, {0}초만큼 무적이 됩니다. 시전하는 동안엔 이동할 수 없습니다.", value2);
        code = SpawnCode.B003;
        spritePath = "";
    }

    public override void ExecuteSkill(GameObject obj)
    {
        Debug.Log("Blue Skill -> " + title);
    }
}

public class Skill_Blue_Shield : Skill_Blue
{
    public Skill_Blue_Shield()
    {
        value1 = 0;
        value2 = 5;
        delay = 10f;

        title = "실드";
        description = string.Format("전방에 {1}초 동안 받는 피해의 {0}만큼을 감소시키는 방패를 듭니다. (시전시, 방향전환x)(On/Off 스킬)", value1, value2);
        code = SpawnCode.B004;
        spritePath = "";
    }

    public override void ExecuteSkill(GameObject obj)
    {
        Debug.Log("Blue Skill -> " + title);
    }
}

public class Skill_Blue_DefenceBuff : Skill_Blue
{
    GameObject target = null;
    public Skill_Blue_DefenceBuff()
    {
        value1 = 9999;
        value2 = 5;
        delay = 25f;

        title = "풀 아머";
        description = string.Format("{1}초동안 플레이어에게 {0}만큼의 방어력을 증가시킵니다.", value1, value2);
        code = SpawnCode.B005;
        spritePath = "";
    }

    public override void ExecuteSkill(GameObject obj)
    {
        Debug.Log("Blue Skill -> " + title);

        obj.GetComponent<PlayerStatus>().defence += (int)value1;
        target = obj;

        Thread thread = new Thread(new ThreadStart(CancelSkill));
        thread.Start();
        thread.Join();
        Debug.Log("여기입니다 SOSOSOSOSOSOSOOSOSOSOSOOSOSOSOSOOSOSOS");
    }

    void CancelSkill()
    {
        Thread.Sleep((int)value2 * 1000);
        target.GetComponent<PlayerStatus>().defence -= (int)value1;
    }
}