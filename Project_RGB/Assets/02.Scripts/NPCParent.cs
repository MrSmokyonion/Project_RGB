using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region Enum
public enum StoreType
{
    WeaponAndRepair,
    Skill,
    Food,   
}
#endregion

public class NpcInfo
{
    public int npcCode;
    public Sprite npcSprite;
    public bool storeAvailable;
    public StoreType storetype;

    public string Dialogue;

    public NpcInfo(int _npcCode, Sprite _npcSprite, bool _storeAvailable, StoreType _storetype, string _Dialogue)
    {
        npcCode = _npcCode;
        npcSprite = _npcSprite;
        storeAvailable = _storeAvailable;
        storetype = _storetype;
        Dialogue = _Dialogue;
    }
}

public class NPCParent : MonoBehaviour
{
    public Quest questScript;
    public List<Sprite> npcSpriteList = new List<Sprite>();

    public List<NpcInfo> npcInfoList = new List<NpcInfo>();

    private void Awake()
    {
        NPCInfoListSetting();
    }

    public void NPCInfoListSetting()
    {
        npcInfoList.Add(new NpcInfo(0, npcSpriteList[0], true, StoreType.Food, "저희 여관의 음식과 침대는 최고랍니다~ 쉬고 가시겠어요?"));
        npcInfoList.Add(new NpcInfo(1, npcSpriteList[1], true, StoreType.WeaponAndRepair, "허허허! 이 근육을 한 번 보게나! 이게 바로 20년의 망치질로 단련된 근육이라네!"));
        npcInfoList.Add(new NpcInfo(2, npcSpriteList[2], false, 0, "왜 이렇게 세상이 허전한지 모르겠어. 네가 어떻게 좀 해줄래?"));
        npcInfoList.Add(new NpcInfo(3, npcSpriteList[3], true, StoreType.Skill, "..."));
        npcInfoList.Add(new NpcInfo(4, npcSpriteList[4], false, 0, "먀옹(바닥에 그림을 그린다)"));
        npcInfoList.Add(new NpcInfo(0, npcSpriteList[5], false, 0, "너 좋은거 가지고 있네? 좀만 나눠줘라. 아님말고.		"));
        npcInfoList.Add(new NpcInfo(1, npcSpriteList[6], false, 0, "으잉으잉으잉 쯔쯔쯔… 고생이 많구먼"));
        npcInfoList.Add(new NpcInfo(1, npcSpriteList[7], false, 0, "야 너!"));

    }



    #region NPC 기능
    //NPCQuestUI.NpcCode = mynpcCode;

    #endregion
}
