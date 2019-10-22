using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region Enum
public enum StoreType
{
    Weapon,
    Accessories,        //몬스터 종류 처치
    Skill,              //몬스터 수량 처치
    Food,               //NPC 심부름
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

    private void NPCInfoListSetting()
    {
        npcInfoList.Add(new NpcInfo(0, npcSpriteList[0], false, StoreType.Food, "아ㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏ"));
        npcInfoList.Add(new NpcInfo(1, npcSpriteList[1], true, StoreType.Weapon, "아ㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏ"));
        npcInfoList.Add(new NpcInfo(2, npcSpriteList[2], true, StoreType.Skill, "아ㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏ"));
        npcInfoList.Add(new NpcInfo(3, npcSpriteList[3], true, StoreType.Accessories, "아ㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏ"));
        npcInfoList.Add(new NpcInfo(4, npcSpriteList[4], false, StoreType.Food, "아ㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏ"));
    }



    #region NPC 기능
    //NPCQuestUI.NpcCode = mynpcCode;

    #endregion
}
