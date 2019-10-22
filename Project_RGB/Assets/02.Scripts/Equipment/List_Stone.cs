using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone_Default : Armor_Stone
{
    public int defence;
    public Stone_Default()
    {
        title = "기본 돌";
        description = "기본 돌입니다. 기본 장비에 뭔 설명을 더 바랍니까.";
        code = SpawnCode.S001;
        spritePath = "";
        isUnlock = false;

        dualbility = 100;
        defence = 10;
    }

    public override void Execute(PlayerStatus status)
    {
        status.defence = defence;
    }
}

public class Stone_ImproveSkill : Armor_Stone
{
    public Stone_ImproveSkill()
    {
        title = "스킬 향상의 돌";
        description = "스킬의 쿨타임을 줄여주는 돌입니다.";
        code = SpawnCode.S002;
        spritePath = "";
        isUnlock = false;

        dualbility = 100;
    }

    public override void Execute(PlayerStatus status)
    {
        status.green.delay -= 1;
    }
}