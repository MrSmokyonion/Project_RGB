using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Amulet_Default : Armor_Amulet
{
    public Amulet_Default()
    {
        title = "기본 부적";
        description = "기본 부적입니다. 기본 장비에 뭔 설명을 더 바랍니까.";
        code = SpawnCode.A001;
        spritePath = "";


        dualbility = 100;
    }
}