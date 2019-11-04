using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spear_Default : Weapon_Spear
{
    public Spear_Default()
    {
        power = 4;
        dualbility = 100;
        delay = 0.6f;
        speed = 8;

        title = "기본 창";
        description = string.Format("기본 창입니다. 뭘 더 바라시나요.");
        code = SpawnCode.W101;
        spritePath = "";
    }
}

public class Spear_IceNalchi : Weapon_Spear
{
    public Spear_IceNalchi()
    {
        power = 4;
        dualbility = 100;
        delay = 0.6f;
        speed = 8;

        title = "냉동 날치";
        description = string.Format("냉동고에서 꺼낸 날치입니다. 저온 화상에 주의하세요.");
        code = SpawnCode.W102;
        spritePath = "";
    }
}

public class Spear_Nyan : Weapon_Spear
{
    public Spear_Nyan()
    {
        power = 4;
        dualbility = 100;
        delay = 0.6f;
        speed = 8;

        title = "냥냥장창";
        description = string.Format("귀여운 고양이가 메달린 창입니다. 간혹가다 심장마비로 사망할지도 모릅니다.");
        code = SpawnCode.W103;
        spritePath = "";
    }
}

public class Spear_DangPa : Weapon_Spear
{
    public Spear_DangPa()
    {
        power = 4;
        dualbility = 100;
        delay = 0.6f;
        speed = 8;

        title = "당파";
        description = string.Format("끝이 세갈래로 갈라진 창입니다. 본래 방어의 용도로 사용됬다고 합니다.");
        code = SpawnCode.W104;
        spritePath = "";
    }
}

public class Spear_PolarStar : Weapon_Spear
{
    public Spear_PolarStar()
    {
        power = 4;
        dualbility = 100;
        delay = 0.6f;
        speed = 8;

        title = "북극성의 창";
        description = string.Format("북극성을 본따아 만든 창입니다. 머나먼 우주까지 닿을 것 같습니다.");
        code = SpawnCode.W105;
        spritePath = "";
    }
}