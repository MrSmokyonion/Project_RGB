using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseFood : BaseValues
{
    public int price;
    public int foodBonusHp;
}

public class Food_Hamburger : BaseFood
{
    public Food_Hamburger()
    {
        price = 1000;
        foodBonusHp = 30;

        title = "햄버거";
        description = string.Format("햄버거 입니다. {0}만큼의 체력을 임시로 높여줍니다.", foodBonusHp);
        code = SpawnCode.F001;
        spritePath = "";
    }
}

public class Food_Pizza : BaseFood
{
    public Food_Pizza()
    {
        price = 1500;
        foodBonusHp = 50;

        title = "피자";
        description = string.Format("피자 입니다. {0}만큼의 체력을 임시로 높여줍니다.", foodBonusHp);
        code = SpawnCode.F002;
        spritePath = "";
    }
}

public class Food_Noodle : BaseFood
{
    public Food_Noodle()
    {
        price = 2000;
        foodBonusHp = 70;

        title = "국수";
        description = string.Format("국수 입니다. {0}만큼의 체력을 임시로 높여줍니다.", foodBonusHp);
        code = SpawnCode.F003;
        spritePath = "";
    }
}

public class Food_RiceBall : BaseFood
{
    public Food_RiceBall()
    {
        price = 2500;
        foodBonusHp = 100;

        title = "주먹밥";
        description = string.Format("주먹밥 입니다. {0}만큼의 체력을 임시로 높여줍니다.", foodBonusHp);
        code = SpawnCode.F004;
        spritePath = "";
    }
}

public class Food_Steak : BaseFood
{
    public Food_Steak()
    {
        price = 3000;
        foodBonusHp = 120;

        title = "스테이크";
        description = string.Format("스테이크 입니다. {0}만큼의 체력을 임시로 높여줍니다.", foodBonusHp);
        code = SpawnCode.F005;
        spritePath = "";
    }
}