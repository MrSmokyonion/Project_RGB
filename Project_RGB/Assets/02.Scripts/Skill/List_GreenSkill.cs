using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Green_HighJump : Skill_Green
{
    public Skill_Green_HighJump()
    {
        value1 = 20;
        value2 = 0;
        delay = 6f;

        title = "하이 점프";
        description = string.Format("{0}만큼의 힘으로 높이 점프합니다.", value1);
        code = SpawnCode.G001;
        spritePath = "";
    }
    
    public override void ExecuteSkill(GameObject obj)
    {
        Debug.Log("Green Skill -> HighJump!");
        Rigidbody2D rigid = obj.GetComponent<Rigidbody2D>();
        rigid.AddForce(Vector2.up * value1, ForceMode2D.Impulse);
    }
}

public class Skill_Green_Dash : Skill_Green
{
    public Skill_Green_Dash()
    {
        value1 = 20;
        value2 = 0;
        delay = 4f;

        title = "대쉬";
        description = string.Format("{0}만큼 앞으로 점멸합니다. (시전하는 동안 무적)", value1);
        code = SpawnCode.G002;
        spritePath = "";
    }

    public override void ExecuteSkill(GameObject obj)
    {
        Debug.Log("Green Skill -> " + title);
    }
}

public class Skill_Green_BackStep : Skill_Green
{
    public Skill_Green_BackStep()
    {
        value1 = 5;
        value2 = 0;
        delay = 3f;

        title = "백스텝";
        description = string.Format("{0}만큼 뒤로 후퇴합니다. (이때, 모든 행동은 캔슬됨)", value1);
        code = SpawnCode.G003;
        spritePath = "";
    }

    public override void ExecuteSkill(GameObject obj)
    {
        Debug.Log("Green Skill -> " + title);
    }
}

public class Skill_Green_Charger : Skill_Green
{
    public Skill_Green_Charger()
    {
        value1 = 0;
        value2 = 0;
        delay = 6f;

        title = "차저";
        description = string.Format("{0}의 속도로 돌진합니다. 이때, 부딭히는 적은 끌고갑니다. 벽에 부딭히거나, 적을 너무 많이 끌면 멈춥니다. (최대 4마리)", value1);
        code = SpawnCode.G004;
        spritePath = "";
    }

    public override void ExecuteSkill(GameObject obj)
    {
        Debug.Log("Green Skill -> " + title);
    }
}

public class Skill_Green_MoveBuff : Skill_Green
{
    public Skill_Green_MoveBuff()
    {
        value1 = 3;
        value2 = 15;
        delay = 25f;

        title = "헤이스트";
        description = string.Format("이동속도가 {1}초동안 {0}만큼 상승합니다.", value1, value2);
        code = SpawnCode.G005;
        spritePath = "";
    }

    public override void ExecuteSkill(GameObject obj)
    {
        Debug.Log("Green Skill -> " + title);
    }
}