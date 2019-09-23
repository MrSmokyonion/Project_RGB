using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region Enum
public enum QuestType
{
    Type_Kill,                  //몬스터 종류 처치
    Quantity_Kill,              //몬스터 수량 처치
    Item_Collection,            //아이템 수집 임무 
    NPC_Errands                 //NPC 심부름
}

public enum QuestRewardCode
{
    PARENT,

    Gold,                       //골드
    Equipment,                  //장비
    Skill,                      //스킬 
    Repair_Coupon               //수리쿠폰

}
#endregion

public class QuestInfo
{
    public int quest_code;                  //고유번호
    public int quest_npc_code;              //npc 고유 번호
    public bool quest_unlock;               //해금여부
    public bool is_accept;                  //수락 여부
    public int quest_type;                  //퀘스트 유형
    public int quest_reward_type;          //퀘스트 보상 유형
    public string quest_name;               //퀘스트 이름
    public string content;                  //퀘스트 내용
    public string summary;                  //퀘스트 요약


    //생성자
    //퀘스트 고유 번호, npc 고유 번호,  해금여부,  수락 여부,  퀘스트 유형,  퀘스트 보상 유형,  퀘스트 이름,  퀘스트 내용, 퀘스트 요약
    public QuestInfo(int _quest_code, int _quest_npc_code, bool _quest_unlock, bool _is_accept, int _quest_type, int _quest_reward_type, string _quest_name, string _content, string _summary)

    {
        quest_code = _quest_code;
        quest_npc_code = _quest_npc_code;
        quest_unlock = _quest_unlock;
        is_accept = _is_accept;
        quest_type = _quest_type;
        quest_reward_type = _quest_reward_type;
        quest_name = _quest_name;
        content = _content;
        summary = _summary;
    }
}




public class Quest : MonoBehaviour
{
    public List<QuestInfo> questCompleteList = new List<QuestInfo>();
    public List<QuestInfo> questProgressList = new List<QuestInfo>();
    public void QuestProgressList()
    {
        //퀘스트 고유 번호, npc 고유 번호,  해금여부,  수락 여부,  퀘스트 유형,  퀘스트 보상 유형,  퀘스트 이름,  퀘스트 내용, 퀘스트 요약
        //진행중 인 것, 완료된 것
        questProgressList.Add(new QuestInfo(1, 1, true, true, 1, 1, "진행중1", "진행중", "진행중"));
        questProgressList.Add(new QuestInfo(2, 1, true, true, 1, 1, "진행중2", "진행중", "진행중22"));
    }

    //QuestCompleteList
    public void QuestCompleteList()
    {
        //퀘스트 고유 번호, npc 고유 번호,  해금여부,  수락 여부,  퀘스트 유형,  퀘스트 보상 유형,  퀘스트 이름,  퀘스트 내용, 퀘스트 요약
        //진행중 인 것, 완료된 것
        questCompleteList.Add(new QuestInfo(1, 1, true, true, 1, 1, "완료1", "완료", "완료"));
        questCompleteList.Add(new QuestInfo(2, 1, true, true, 1, 1, "완료2", "완료", "완료22"));
        questCompleteList.Add(new QuestInfo(2, 1, true, true, 1, 1, "완료3", "완료", "완료33"));
        questCompleteList.Add(new QuestInfo(2, 1, true, true, 1, 1, "완료4", "완료", "완료44"));
    }

    public QuestInfo PFindNameToQuestCode(string name)
    {
        foreach (QuestInfo str in questProgressList)
        {
            if (str.quest_name == name)
            {
                return str;
            }
        }
        return null;
    }

    public QuestInfo CFindNameToQuestCode(string name)
    {
        foreach (QuestInfo str in questCompleteList)
        {
            if (str.quest_name == name)
            {
                return str;
            }
        }
        return null;
    }


    // Start is called before the first frame update
    void Awake()
    {
        QuestProgressList();
        QuestCompleteList();
    }

    // Update is called once per frame
    void Update()
    {

    }
}

