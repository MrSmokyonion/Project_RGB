using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseFood : BaseValues
{
    public int m_foodBonusHp;
}

public class Food_Hamburger : BaseFood
{
    public Food_Hamburger()
    {
        m_price = 1000;
        m_foodBonusHp = 30;

        m_title = "햄버거";
        m_description = string.Format("햄버거 입니다. {0}만큼의 체력을 임시로 높여줍니다.", m_foodBonusHp);
        m_code = SpawnCode.F001;
        m_spritePath = "";
    }
}

public class Food_Pizza : BaseFood
{
    public Food_Pizza()
    {
        m_price = 1500;
        m_foodBonusHp = 50;

        m_title = "피자";
        m_description = string.Format("피자 입니다. {0}만큼의 체력을 임시로 높여줍니다.", m_foodBonusHp);
        m_code = SpawnCode.F002;
        m_spritePath = "";
    }
}

public class Food_Noodle : BaseFood
{
    public Food_Noodle()
    {
        m_price = 2000;
        m_foodBonusHp = 70;

        m_title = "국수";
        m_description = string.Format("국수 입니다. {0}만큼의 체력을 임시로 높여줍니다.", m_foodBonusHp);
        m_code = SpawnCode.F003;
        m_spritePath = "";
    }
}

public class Food_RiceBall : BaseFood
{
    public Food_RiceBall()
    {
        m_price = 2500;
        m_foodBonusHp = 100;

        m_title = "주먹밥";
        m_description = string.Format("주먹밥 입니다. {0}만큼의 체력을 임시로 높여줍니다.", m_foodBonusHp);
        m_code = SpawnCode.F004;
        m_spritePath = "";
    }
}

public class Food_Steak : BaseFood
{
    public Food_Steak()
    {
        m_price = 3000;
        m_foodBonusHp = 120;

        m_title = "스테이크";
        m_description = string.Format("스테이크 입니다. {0}만큼의 체력을 임시로 높여줍니다.", m_foodBonusHp);
        m_code = SpawnCode.F005;
        m_spritePath = "";
    }
}