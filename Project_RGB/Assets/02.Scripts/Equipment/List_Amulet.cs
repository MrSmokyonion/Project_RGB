using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Amulet_Default : Armor_Amulet
{
    public Amulet_Default()
    {
        value = 0;
        dualbility = 0;

        m_title = "기본 부적";
        m_description = string.Format("기본 부적입니다. 기본 장비에 뭔 설명을 더 바랍니까.");
        m_code = SpawnCode.A001;
        m_spritePath = "";
        m_price = 100;
        m_isSale = true;
    }

    public override void Execute(PlayerStatus status)
    {
        Debug.Log(m_title);
    }
}

public class Amulet_Richness : Armor_Amulet
{
    public Amulet_Richness()
    {
        value = 2;
        dualbility = 100;

        m_title = "거지의 부적";
        m_description = string.Format("기존의 골드 획득량을 {0}%만큼 더 받습니다.", value);
        m_code = SpawnCode.A002;
        m_spritePath = "";
        m_price = -123456789;
        m_isSale = false;
    }

    public override void Execute(PlayerStatus status)
    {
        Debug.Log(m_title);
    }
}

public class Amulet_Drain : Armor_Amulet
{
    public Amulet_Drain()
    {
        value = 2;
        dualbility = 100;

        m_title = "흡혈의 부적";
        m_description = string.Format("몬스터를 처치할 때마다, 최대체력의 {0}%만큼 회복합니다.", value);
        m_code = SpawnCode.A003;
        m_spritePath = "";
        m_price = -987654321;
        m_isSale = false;
    }

    public override void Execute(PlayerStatus status)
    {
        Debug.Log(m_title);
    }
}

public class Amulet_ImproveSkill : Armor_Amulet
{
    public Amulet_ImproveSkill()
    {
        value = 1;
        dualbility = 100;

        m_title = "스킬 향상의 돌";
        m_description = string.Format("스킬의 쿨타임을 {0}만큼 줄여주는 돌입니다.", value);
        m_code = SpawnCode.A004;
        m_spritePath = "";
        m_price = -123456789;
        m_isSale = false;
    }

    public override void Execute(PlayerStatus status)
    {
        Debug.Log(m_title);
    }
}

public class Amulet_PainPatch : Armor_Amulet
{
    public Amulet_PainPatch()
    {
        value = 1;
        dualbility = 100;

        m_title = "털 부적";
        m_description = string.Format("5초마다 {0}%만큼 체력을 자동회복 합니다.", value);
        m_code = SpawnCode.A005;
        m_spritePath = "";
        m_price = -123456789;
        m_isSale = false;
    }

    public override void Execute(PlayerStatus status)
    {
        Debug.Log(m_title);
    }
}