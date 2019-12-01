using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword_Default : Weapon_Sword
{
    public Sword_Default()
    {
        power = 5;
        dualbility = 100;
        delay = 0.5f;

        m_title = "기본 검";
        m_description = string.Format("기본 검입니다. 뭘 더 바라시나요.");
        m_code = SpawnCode.W001;
        m_spritePath = "";
        m_price = 100;
        m_isSale = true;
    }
}

public class Sword_HotTuna : Weapon_Sword
{
    public Sword_HotTuna()
    {
        power = 5;
        dualbility = 100;
        delay = 0.5f;

        m_title = "뜨거운 참치";
        m_description = string.Format("참치를 뜨겁게 데웠습니다. 노릇노릇 하군요.");
        m_code = SpawnCode.W002;
        m_spritePath = "";
        m_price = -123456789;
        m_isSale = false;
    }
}

public class Sword_BBQStick : Weapon_Sword
{
    public Sword_BBQStick()
    {
        power = 5;
        dualbility = 100;
        delay = 0.5f;

        m_title = "바베큐 스틱";
        m_description = string.Format("고기와 야채를 꽂은 꼬치입니다. 아직 굽지 않아 먹으면 안됩니다.");
        m_code = SpawnCode.W003;
        m_spritePath = "";
        m_price = -123456789;
        m_isSale = false;
    }
}

public class Sword_Broad : Weapon_Sword
{
    public Sword_Broad()
    {
        power = 5;
        dualbility = 100;
        delay = 0.5f;

        m_title = "브로드 소드";
        m_description = string.Format("보병들이 애용하던 검입니다. 베는 맛이 일품이라 합니다.");
        m_code = SpawnCode.W004;
        m_spritePath = "";
        m_price = 100;
        m_isSale = true;
    }
}

public class Sword_MoonLight : Weapon_Sword
{
    public Sword_MoonLight()
    {
        power = 5;
        dualbility = 100;
        delay = 0.5f;

        m_title = "월광검";
        m_description = string.Format("달 빛을 머금은 검입니다. 검귀가 나갈 것만 같습니다.");
        m_code = SpawnCode.W005;
        m_spritePath = "";
        m_price = -987654321;
        m_isSale = false;
    }
}