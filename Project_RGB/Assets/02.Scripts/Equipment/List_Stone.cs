using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone_Default : Armor_Stone
{
    public int defence;
    public Stone_Default()
    {
        armorName = "기본 돌";
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
        armorName = "스킬 향상 돌";
        dualbility = 100;
    }

    public override void Execute(PlayerStatus status)
    {
        status.green.delay -= 1;
    }
}