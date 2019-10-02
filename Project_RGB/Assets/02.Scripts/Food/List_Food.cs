using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseFood
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
    }
}