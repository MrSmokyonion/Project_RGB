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
        title = "햄버거";
        description = "햄버거는 역시 어머니의 손길이 최곱니다.";
        code = SpawnCode.F001;
        spritePath = "";
        isUnlock = false;

        price = 1000;
        foodBonusHp = 30;
    }
}