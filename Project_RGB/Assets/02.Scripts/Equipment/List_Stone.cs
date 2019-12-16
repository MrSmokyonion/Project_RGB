using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone_Default : Armor_Stone
{
    public Stone_Default()
    {
        value = 10;
        dualbility = 100;

        m_title = "기본 돌";
        m_description = string.Format("기본 돌입니다. 방어력을 {0}만큼 상승 시킵니다.", value);
        m_code = SpawnCode.S001;
        m_spritePath = "";
        m_price = 100;
        m_isSale = false;
    }

    public override void Execute(PlayerStatus status)
    {
        Debug.Log(m_title);
    }
}

public class Stone_Magnetic : Armor_Stone
{
    public Stone_Magnetic()
    {
        value = 5;
        dualbility = 100;

        m_title = "거지의 돌";
        m_description = string.Format("주변 {0}m 거리의 골드를 끌어당깁니다.", value);
        m_code = SpawnCode.S002;
        m_spritePath = "";
        m_price = -123456789;
        m_isSale = false;
    }

    public override void Execute(PlayerStatus status)
    {
        Debug.Log(m_title);
    }
}

public class Stone_Guardian : Armor_Stone
{
    public Stone_Guardian()
    {
        value = 20;
        dualbility = 100;

        m_title = "수호자의 돌";
        m_description = string.Format("방어력을 {0}만큼 상승 시킵니다.", value);
        m_code = SpawnCode.S003;
        m_spritePath = "";
        m_price = 100;
        m_isSale = true;
    }

    public override void Execute(PlayerStatus status)
    {
        Debug.Log(m_title);
    }
}

public class Stone_Minor : Armor_Stone
{
    public Stone_Minor()
    {
        value = 15;
        dualbility = 100;

        m_title = "마이너의 돌";
        m_description = string.Format("일반 몬스터의 공격에 대해 {0}%만큼 피해를 덜 받습니다.", value);
        m_code = SpawnCode.S004;
        m_spritePath = "";
        m_price = 100;
        m_isSale = false;
    }

    public override void Execute(PlayerStatus status)
    {
        Debug.Log(m_title);
    }
}

public class Stone_Major : Armor_Stone
{
    public Stone_Major()
    {
        value = 20;
        dualbility = 100;

        m_title = "메이저의 돌";
        m_description = string.Format("보스 몬스터의 공격에 대해 {0}%만큼 피해를 덜 받습니다.", value);
        m_code = SpawnCode.S005;
        m_spritePath = "";
        m_price = -123456789;
        m_isSale = false;
    }

    public override void Execute(PlayerStatus status)
    {
        Debug.Log(m_title);
    }
}