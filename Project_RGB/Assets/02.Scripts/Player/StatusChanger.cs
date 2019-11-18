using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusChanger : MonoBehaviour
{
    public NetworkRouter router;
    public SpawnClass spawn;

    #region Change Method

    public bool ChangeSkill(SpawnCode code, GameObject _parents, GameObject _child)
    {
        //언락 여부 체크
        if (!spawn.GetIsUnlocked(code)) return false;

        //스킬 생성 & 할당
        string what = (code.ToString().Substring(0, 1));
        switch (what)
        {
            case "R": spawn.GetSkill_Red(code, _child); break;
            case "G": spawn.GetSkill_Green(code, _child); break;
            case "B": spawn.GetSkill_Blue(code, _child); break;
        }

        //스킬 메커니즘 초기화
        _parents.GetComponent<PlayerStatus>().Init_Skill();

        //서버 통신
        router.PostRouter(PostType.PLAYER_SKILL_CHANGE, code);

        return true;
    }

    public bool ChangeWeapon(SpawnCode code, GameObject _parents, GameObject _child)
    {
        //언락 여부 체크
        if (!spawn.GetIsUnlocked(code)) return false;

        //장비 생성 & 할당
        string what = (code.ToString().Substring(0, 2));
        switch (what)
        {
            case "W0": spawn.GetWeapon_Sword(code, _child); break;
            case "W1": spawn.GetWeapon_Spear(code, _child); break;
            case "W2": spawn.GetWeapon_Bow(code, _child); break;
        }

        //무기 메커니즘 초기화
        _parents.GetComponent<PlayerStatus>().Init_HpDefence();

        //서버 통신
        router.PostRouter(PostType.PLAYER_WEAPON_CHANGE, code);

        return true;
    }

    public bool ChangeArmor(SpawnCode code, GameObject _parents, GameObject _child)
    {
        //언락 여부 체크
        if (!spawn.GetIsUnlocked(code)) return false;

        //캐릭터 스테이터스 초기화
        PlayerStatus ps = _parents.GetComponent<PlayerStatus>();
        ps.Init_HpDefence();

        //장비 생성 & 할당, 서버 통신
        Base_Armor ar;
        string what = (code.ToString().Substring(0, 1));
        switch (what)
        {
            case "A":
                ar = spawn.GetArmor_Amulet(code, _child);
                ar.Execute(ps);
                router.PostRouter(PostType.PLAYER_AMULET_CHANGE, code);
                break;

            case "S":
                ar = spawn.GetArmor_Stone(code, _child);
                ar.Execute(ps);
                router.PostRouter(PostType.PLAYER_STONE_CHANGE, code);
                break;
        }

        return true;
    }

    public bool ChangeFood(SpawnCode code, GameObject _parents, GameObject _child)
    {
        //언락 여부 체크
        if (!spawn.GetIsUnlocked(code)) return false;

        //음식 생성 & 할당
        string what = (code.ToString().Substring(0, 1));
        switch (what)
        {
            case "F": spawn.GetFood(code, _child); break;
        }

        //음식 효과 적용
        _parents.GetComponent<PlayerStatus>().Init_Food();

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
