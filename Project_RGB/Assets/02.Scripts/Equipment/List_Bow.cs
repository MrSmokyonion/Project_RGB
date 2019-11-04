using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow_Default : Weapon_Bow
{
    public Bow_Default()
    {
        power = 3;
        dualbility = 100;
        delay = 0.75f;
        speed = 10;

        title = "기본 활";
        description = string.Format("기본 활입니다. 뭘 더 바라시나요.");
        code = SpawnCode.W201;
        spritePath = "";
    }
}

public class Bow_NoMoney : Weapon_Bow
{
    public Bow_NoMoney()
    {
        power = 3;
        dualbility = 100;
        delay = 0.75f;
        speed = 10;

        title = "거지의 활";
        description = string.Format("거지가 선물한 활입니다. 거지다운 성능이군요.");
        code = SpawnCode.W202;
        spritePath = "";
    }
}

public class Bow_Dryed : Weapon_Bow
{
    public Bow_Dryed()
    {
        power = 3;
        dualbility = 100;
        delay = 0.75f;
        speed = 10;

        title = "드라이어드의 활";
        description = string.Format("나무의 요정이 만든 활 입니다. 왠지 들고 있으니 나무를 심고 싶어집니다.");
        code = SpawnCode.W203;
        spritePath = "";
    }
}

public class Bow_Long : Weapon_Bow
{
    public Bow_Long()
    {
        power = 3;
        dualbility = 100;
        delay = 0.75f;
        speed = 10;

        title = "롱보우";
        description = string.Format("평범한 롱 보우 입니다. 마을 사람들이 종종 사용하곤 합니다.");
        code = SpawnCode.W201;
        spritePath = "";
    }
}

public class Bow_Apollo : Weapon_Bow
{
    public Bow_Apollo()
    {
        power = 3;
        dualbility = 100;
        delay = 0.75f;
        speed = 10;

        title = "아폴론의 활";
        description = string.Format("옛 전설속 신이 사용했다던 활입니다. 놀라운 화력을 자랑합니다.");
        code = SpawnCode.W205;
        spritePath = "";
    }
}