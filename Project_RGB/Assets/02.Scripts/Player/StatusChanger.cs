using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusChanger : MonoBehaviour
{
    public NetworkRouter router;
    public SpawnClass spawn;

    #region Change Method

    public bool ChangeSkill(SpawnCode code, PlayerStatus _player)
    {
        //언락 여부 체크
        if (!spawn.GetIsUnlocked(code)) return false;

        //스킬 생성 & 할당
        string what = (code.ToString().Substring(0, 1));
        switch (what)
        {
            case "R": _player.red = spawn.GetSkill_Red(code); break;
            case "G": _player.green = spawn.GetSkill_Green(code); break;
            case "B": _player.blue = spawn.GetSkill_Blue(code); break;
        }

        //스킬 메커니즘 초기화
        _player.Init_Skill();

        //서버 통신
        router.PostRouter(PostType.PLAYER_SKILL_CHANGE, code);

        return true;
    }

    public bool ChangeWeapon(SpawnCode code, PlayerStatus _player)
    {
        //언락 여부 체크
        if (!spawn.GetIsUnlocked(code)) return false;

        //장비 생성 & 할당
        string what = (code.ToString().Substring(0, 2));
        switch (what)
        {
            case "W0": _player.weapon = spawn.GetWeapon_Sword(code); break;
            case "W1": _player.weapon = spawn.GetWeapon_Spear(code); break;
            case "W2": _player.weapon = spawn.GetWeapon_Bow(code); break;
        }

        //무기 메커니즘 초기화
        _player.Init_HpDefence();

        //서버 통신
        router.PostRouter(PostType.PLAYER_WEAPON_CHANGE, code);

        return true;
    }

    public bool ChangeArmor(SpawnCode code, PlayerStatus _player)
    {
        //언락 여부 체크
        if (!spawn.GetIsUnlocked(code)) return false;

        //캐릭터 스테이터스 초기화
        _player.Init_HpDefence();

        //장비 생성 & 할당, 서버 통신
        string what = (code.ToString().Substring(0, 1));
        switch (what)
        {
            case "A":
                _player.amulet = spawn.GetArmor_Amulet(code); _player.amulet.Execute(_player);
                router.PostRouter(PostType.PLAYER_AMULET_CHANGE, code); break;
            case "S":
                _player.stone = spawn.GetArmor_Stone(code); _player.stone.Execute(_player);
                router.PostRouter(PostType.PLAYER_STONE_CHANGE, code); break;
        }

        return true;
    }

    public bool ChangeFood(SpawnCode code, PlayerStatus _player)
    {
        //언락 여부 체크
        if (!spawn.GetIsUnlocked(code)) return false;

        //음식 생성 & 할당
        string what = (code.ToString().Substring(0, 1));
        switch (what)
        {
            case "F": _player.food = spawn.GetFood(code); break;
        }

        //음식 효과 적용
        _player.Init_Food();

        return true;
    }
    #endregion

    #region Unlock
    public void UnlockCode(SpawnCode code)
    {
        spawn.UnlockCode(code);
    }
    #endregion
}
