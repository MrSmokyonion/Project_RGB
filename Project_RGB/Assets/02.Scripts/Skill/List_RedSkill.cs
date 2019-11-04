using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Red_PiercingSpear : Skill_Red //101
{
    public Skill_Red_PiercingSpear()
    {
        value1 = 0;
        value2 = 5;
        delay = 6.0f;

        title = "피어싱스피어";
        description = string.Format("{0}의 데미지를 주는 창을 전방으로 던집니다.(최대 {1}명)", value1, value2);
        code = SpawnCode.R001;
        spritePath = "";
    }

    public override void ExecuteSkill(GameObject obj)
    {
        Debug.Log("Red Skill -> Fire!");
    }
}

public class Skill_Red_ArrowRain : Skill_Red //101
{
    public Skill_Red_ArrowRain()
    {
        value1 = 0;
        value2 = 3;
        delay = 8.0f;

        title = "애로우레인";
        description = string.Format("{0}의 데미지를 {1}번주는 화살비를 내립니다.", value1, value2);
        code = SpawnCode.R002;
        spritePath = "";
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
        value1 = 0;
        value2 = 20f;
        delay = 15.0f;

        title = "스워드트랩";
        description = string.Format("발동 시, {0}의 데미지를 주는 트랩을 전방에 설치합니다.({1}초 동안)", value1, value2);
        code = SpawnCode.R003;
        spritePath = "";
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
        value1 = 0;
        value2 = 10f;
        delay = 20.0f;

        title = "터렛";
        description = string.Format("발동 시, 주변 적 1명에게 {0}의 데미지를 주는 터렛을 소환해 플레이어 주변에 떠돌게 합니다. ({1}초 동안)", value1, value2);
        code = SpawnCode.R004;
        spritePath = "";
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
        value1 = 0;
        value2 = 10f;
        delay = 25.0f;

        title = "플레임웨폰";
        description = string.Format("발동 시, 무기를 강화하여 무기의 공격력을 {0}만큼 상승시킵니다. ({1}초 동안)", value1, value2);
        code = SpawnCode.R005;
        spritePath = "";
    }

    public override void ExecuteSkill(GameObject obj)
    {
        Debug.Log("Red Skill -> Fire!");
    }
}