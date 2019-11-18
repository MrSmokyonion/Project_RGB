using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockClass : MonoBehaviour
{
    public NetworkRouter router;           //라우터 참조

    private List<SpawnCode> list;           //언락 정보를 담고있는 리스트

    private void Start()
    {
        list = new List<SpawnCode>();

        list.Add(SpawnCode.R001);
        list.Add(SpawnCode.G001);
        list.Add(SpawnCode.B005);

        list.Add(SpawnCode.W001);
        list.Add(SpawnCode.W101);
        list.Add(SpawnCode.W201);

        list.Add(SpawnCode.A001);
        list.Add(SpawnCode.S001);

        list.Add(SpawnCode.F001);
    }

    //해당 코드의 아이템이 언락이 되어있는지 확인함
    public bool CheckCode(SpawnCode code)
    {
        bool b = list.Contains(code);
        return b;
    }

    //해당 코드를 언락함.
    public void UnlockCode(SpawnCode code)
    {
        //이미 언락이 되어 있다면 막기
        if (list.Contains(code)) return;

        //리스트 올리고 서버에 통신
        list.Add(code);

        string str = code.ToString().Substring(0, 1);
        switch(str)
        {
            case "R":
            case "G":
            case "B":
                router.PostRouter(PostType.PLAYER_SKILL_UNLOCK, code); break;

            case "W":
                router.PostRouter(PostType.PLAYER_WEAPON_UNLOCK, code); break;

            case "A":
                router.PostRouter(PostType.PLAYER_AMULET_UNLOCK, code); break;
            case "S":
                router.PostRouter(PostType.PLAYER_STONE_UNLOCK, code); break;
        }
    }

    //테스트용 코드
    public void test()
    {
        
        router.PostRouter(PostType.PLAYER_CHARACTER_GET_CHARDATA);
    }
}