using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region Enum
public enum QuestType
{
    Type_Kill,                  //몬스터 종류 처치
    Quantity_Kill,              //몬스터 수량 처치
    NPC_Errands,                //NPC 심부름
}


public enum QuestRewardCode
{
    PARENT,
    Equipment,                  //장비
    Skill,                      //스킬 
    Repair_Coupon               //수리쿠폰

}

public enum QuestState
{
    Success,
    Access,
    Able,
    Enable
}
#endregion

public class QuestInfo
{
    public int quest_code;                      //고유번호
    public int quest_npc_code;                  //npc 고유 번호
    public int quest_chapter;                   //챕터
    public QuestState quest_state;              //퀘스트 상태
    public QuestType quest_type;                //퀘스트 유형
    public MonsterCode questmonstercode;        //몬스터 코드
    public int questcompletecount;              //퀘스트 대상 완료 개수
    public QuestRewardCode quest_reward_type;   //퀘스트 보상 유형
    public int questdetails;                    //퀘스트 진행개수
    public string quest_name;                   //퀘스트 이름
    public string content;                      //퀘스트 내용
    public string summary;                      //퀘스트 요약
    public string script;                       //퀘스트 대사
    public int gold;                            //골드


    //생성자
    //퀘스트 고유 번호, npc 고유 번호,  챕터,  퀘스트 상태,  퀘스트 유형, 몬스터 코드, 퀘스트 대상 완료 개수, 퀘스트 보상 유형, 퀘스트 진행개수, 퀘스트 이름,  퀘스트 내용, 퀘스트 요약, 퀘스트 대사
    public QuestInfo(int _quest_code, int _quest_npc_code, int _quest_chapter, QuestState _quest_state, QuestType _quest_type, MonsterCode _quest_monstercode, int _quest_complete_count, QuestRewardCode _quest_reward_type, int _questdetails, string _quest_name, string _content, string _summary, string _script, int _gold)
    {
        quest_code = _quest_code;
        quest_npc_code = _quest_npc_code;
        quest_chapter = _quest_chapter;
        quest_state = _quest_state;
        quest_type = _quest_type;
        questmonstercode = _quest_monstercode;
        questcompletecount = _quest_complete_count;
        quest_reward_type = _quest_reward_type;
        questdetails = _questdetails;
        quest_name = _quest_name;
        content = _content;
        summary = _summary;
        script = _script;
        gold = _gold;
    }
}


public class Quest : MonoBehaviour
{
    List<QuestInfo> questInfoList = new List<QuestInfo>();
    public List<QuestInfo> playerQuestList = new List<QuestInfo>();
    public List<QuestInfo> questAcessList = new List<QuestInfo>();
    public List<QuestInfo> questSuccessList = new List<QuestInfo>();

    // Start is called before the first frame update
    void Awake()
    {
        Screen.SetResolution(1920, 1080, false);
        QuestList();
        PlayerQuestList();
        UIQuestList();
    }

    // Update is called once per frame
    void Update()
    {

    }

    #region 퀘스트 Setting

    public void QuestList()                                     //퀘스트의 정보
    {
        //퀘스트 고유 번호, npc 고유 번호,  챕터,  퀘스트 상태,  퀘스트 유형, 몬스터 코드, 퀘스트 대상 완료 개수, 퀘스트 보상 유형, 퀘스트 진행개수, 퀘스트 이름,  퀘스트 내용, 퀘스트 요약, 퀘스트 대사
        questInfoList.Add(new QuestInfo(0, 1, 1, QuestState.Access, QuestType.Type_Kill, 0, 5, QuestRewardCode.Equipment, 3, "열매 요리가 하고 싶어요~1", "길고양이가 갑자기 길목을 막아서더니 바닥에 참치 그림을 그렸다. 불타는 용암 폭포에서 불타는 참치를 구해다 주자.", "7000Gold 기부", "허허허! 자네 더 좋은 무기가 가지고 싶지 않으가!? 좋은 철을 가져오면 내 하나 만들어줌세!!", 0));
        questInfoList.Add(new QuestInfo(1, 1, 1, QuestState.Success, QuestType.Type_Kill, MonsterCode.FLY_MONSTER_1, 5, QuestRewardCode.Equipment, 5, "열매 요리가 하고 싶어요2", "길고양이가 갑자기 길목을 막아서더니 바닥에 참치 그림을 그렸다. 불타는 용암 폭포에서 불타는 참치를 구해다 주자.", "7000Gold 기부", "허허허! 자네 더 좋은 무기가 가지고 싶지 않으가!? 좋은 철을 가져오면 내 하나 만들어줌세!!", 0));
        questInfoList.Add(new QuestInfo(2, 2, 2, QuestState.Enable, QuestType.Type_Kill, MonsterCode.FLY_MONSTER_1, 5, QuestRewardCode.Equipment, 5, "열매 요리가 하고 싶어요~3", "길고양이가 갑자기 길목을 막아서더니 바닥에 참치 그림을 그렸다. 불타는 용암 폭포에서 불타는 참치를 구해다 주자.", "7000Gold 기부", "허허허! 자네 더 좋은 무기가 가지고 싶지 않으가!? 좋은 철을 가져오면 내 하나 만들어줌세!!", 0));
        questInfoList.Add(new QuestInfo(3, 1, 3, QuestState.Access, QuestType.Type_Kill, MonsterCode.FLY_MONSTER_1, 5, QuestRewardCode.Equipment, 5, "열매 요리가 하고 싶어요~4", "길고양이가 갑자기 길목을 막아서더니 바닥에 참치 그림을 그렸다. 불타는 용암 폭포에서 불타는 참치를 구해다 주자.", "7000Gold 기부", "허허허! 자네 더 좋은 무기가 가지고 싶지 않으가!? 좋은 철을 가져오면 내 하나 만들어줌세!!", 0));
        questInfoList.Add(new QuestInfo(4, 2, 1, QuestState.Able, QuestType.Type_Kill, MonsterCode.FLY_MONSTER_1, 5, QuestRewardCode.Equipment, 5, "열매 요리가 하고 싶어요~5", "길고양이가 갑자기 길목을 막아서더니 바닥에 참치 그림을 그렸다. 불타는 용암 폭포에서 불타는 참치를 구해다 주자.", "7000Gold 기부", "허허허! 자네 더 좋은 무기가 가지고 싶지 않으가!? 좋은 철을 가져오면 내 하나 만들어줌세!!", 0));
        questInfoList.Add(new QuestInfo(5, 2, 1, QuestState.Success, QuestType.Type_Kill, MonsterCode.FLY_MONSTER_1, 5, QuestRewardCode.Equipment, 5, "열매 요리가 하고 싶어요~6", "길고양이가 갑자기 길목을 막아서더니 바닥에 참치 그림을 그렸다. 불타는 용암 폭포에서 불타는 참치를 구해다 주자.", "7000Gold 기부", "허허허! 자네 더 좋은 무기가 가지고 싶지 않으가!? 좋은 철을 가져오면 내 하나 만들어줌세!!", 0));
        questInfoList.Add(new QuestInfo(6, 1, 2, QuestState.Enable, QuestType.Type_Kill, MonsterCode.FLY_MONSTER_1, 5, QuestRewardCode.Equipment, 5, "열매 요리가 하고 싶어요~7", "길고양이가 갑자기 길목을 막아서더니 바닥에 참치 그림을 그렸다. 불타는 용암 폭포에서 불타는 참치를 구해다 주자.", "7000Gold 기부", "허허허! 자네 더 좋은 무기가 가지고 싶지 않으가!? 좋은 철을 가져오면 내 하나 만들어줌세!!", 0));
        questInfoList.Add(new QuestInfo(7, 1, 3, QuestState.Enable, QuestType.Type_Kill, MonsterCode.FLY_MONSTER_1, 5, QuestRewardCode.Equipment, 5, "열매 요리가 하고 싶어요~8", "길고양이가 갑자기 길목을 막아서더니 바닥에 참치 그림을 그렸다. 불타는 용암 폭포에서 불타는 참치를 구해다 주자.", "7000Gold 기부", "허허허! 자네 더 좋은 무기가 가지고 싶지 않으가!? 좋은 철을 가져오면 내 하나 만들어줌세!!", 0));

    }

    public void PlayerQuestList()                               //현재 플레이어의 퀘스트 목록
    {
        playerQuestList = questInfoList;
    }

    public void UIQuestList()                                   //UI작업을 최소화 하기 위해 진행중, 완료 퀘스트 나눔. 
    {
        for (int i = 0; i < playerQuestList.Count; i++)
        {
            if (playerQuestList[i].quest_state == QuestState.Access)
            {
                Debug.Log(playerQuestList[i].quest_name);
                questAcessList.Add(playerQuestList[i]);
            }
            else if (playerQuestList[i].quest_state == QuestState.Success)
            {
                Debug.Log(playerQuestList[i].quest_name);
                questSuccessList.Add(playerQuestList[i]);
            }
        }
    }
    
    #endregion


    #region 퀘스트 처리

    public void AddQuest(QuestInfo addquest)                    //퀘스트 수락 able -> access
    {
        if (questAcessList.Count <= 3)
        {
            questAcessList.Add(addquest);
            playerQuestList[addquest.quest_code].quest_state = QuestState.Access;
            Debug.Log("addquest : " + addquest.quest_name);

        }
        else
        {
            //NPC UI에 퀘스트가 다 찼다는 신호보냄.
        }
        return;

    }

    public void QuestMonsterCheck(MonsterCode monsterCode)      //퀘스트 진행 상황 체크
    {

        for (int i = 0; i < questAcessList.Count; i++)
        {
            if (questAcessList[i].questmonstercode == monsterCode)
            {

                if (questAcessList[i].questdetails < questAcessList[i].questcompletecount)
                {
                    playerQuestList[FindNameToQuestCode(questAcessList[i].quest_name).quest_code].questdetails++;

                }
            }

            if (questAcessList[i].quest_type == QuestType.Quantity_Kill)//&& 챕터가 맞을 때 던전쪽에서 가져와서 확인)
            {
                playerQuestList[FindNameToQuestCode(questAcessList[i].quest_name).quest_code].questdetails++;
            }

            if (questAcessList[i].quest_type == QuestType.NPC_Errands)//몬스터 코드 같은지)
            {
                //if(questAcessList[i].questEquipment == 지금 장착한 장비 && )
                playerQuestList[FindNameToQuestCode(questAcessList[i].quest_name).quest_code].questdetails++;
            }
            gameObject.transform.GetComponent<QuestUI>().QuestBoardSetting();
        }
    }

    public void SuccessquestComplete()                          //NPC에게 말 걸었을 때 퀘스트 완료
    {
        for (int i = 0; i < questAcessList.Count; i++)
        {
            if (questAcessList[i].questcompletecount == questAcessList[i].questdetails)
            {
                //보상 처리

                questSuccessList.Add(questAcessList[i]);
                questAcessList.Remove(questAcessList[i]);
            }
        }

    }

    public QuestInfo FindNameToQuestCode(string name)           //퀘스트 이름으로 퀘스트 코드 찾기
    {
        foreach (QuestInfo str in playerQuestList)
        {
            if (str.quest_name == name)
            {
                return str;
            }
        }
        return null;
    }

    public void QuestUnlock(int clearChapterNumber)             //퀘스트 해금
    {
        for (int i = 0; i < playerQuestList.Count; i++)
        {
            if(playerQuestList[i].quest_chapter == clearChapterNumber)
            {
                playerQuestList[i].quest_state = QuestState.Able;

                //npcUI 다시 세팅
            }
        }
    }

    public List<QuestInfo> GetnpcQuestList(int questNpcCode)    //NPC에게 해당 퀘스트 전달
    {
        List<QuestInfo> npcquestlist = new List<QuestInfo>();

        for (int i = 0; i < playerQuestList.Count; i++)
        {
           
            if (playerQuestList[i].quest_state == QuestState.Able && playerQuestList[i].quest_npc_code == questNpcCode) //NPC가 가진 able 리스트 리턴.
            {
                npcquestlist.Add(playerQuestList[i]);
            }
        }
        return npcquestlist;
    }

    public List<QuestInfo> GetDungeonQuestList(int dungeonType)        //던전에 해당 퀘스트 전달.
    {
        List<QuestInfo> dungeonQuestList = new List<QuestInfo>();

        for(int i = 0; i <playerQuestList.Count; i++)
        {
            if(playerQuestList[i].quest_chapter == dungeonType)
            {
                dungeonQuestList.Add(playerQuestList[i]);
            }
        }

        return dungeonQuestList;
    }
    #endregion




}

