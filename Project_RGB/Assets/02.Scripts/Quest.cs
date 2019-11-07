using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region Enum
public enum QuestType
{
    Tutorial,
    Type_Kill,                  //몬스터 종류 처치
    Gold_Collect,               //골드 수집
    Repeat,                     //반복
    GetItem_Type_Kill,
    NPC_Errands,                //NPC 심부름
}


public enum QuestRewardCode
{
    Only_Gold,                  //Gold
    Equipment,                  //장비
    Skill,                      //스킬 
    Repair_Coupon               //수리쿠폰

}

public enum QuestState
{
    success,
    accept,
    able,
    enable
}
#endregion

public class QuestInfo
{
    public string quest_code_str;               //고유번호(문자열) 예시: q001
    public int quest_code;                      //고유번호
    public int quest_npc_code;                  //npc 고유 번호
    public int quest_chapter;                   //챕터
    public QuestState quest_state;              //퀘스트 상태
    public QuestType quest_type;                //퀘스트 유형
    public MonsterCode questmonstercode;        //몬스터 코드
    public int questItemMax;                    //퀘스트 대상 완료 개수
    public QuestRewardCode quest_reward_type;   //퀘스트 보상 유형
    public int quest_reward_gold;               //퀘스트 골드 보상
    public SpawnCode quest_reward_item;         //퀘스트 아이템 보상  
    public int questItemCur;                    //퀘스트 진행개수
    public string quest_name;                   //퀘스트 이름
    public string content;                      //퀘스트 내용
    public string summary;                      //퀘스트 요약
    public string script;                       //퀘스트 대사
    public string complete_script;              //퀘스트 완료대사


    //생성자
    //퀘스트 고유 번호 str, 퀘스트 고유 번호, npc 고유 번호,  챕터,  퀘스트 상태,  퀘스트 유형, 몬스터 코드, 퀘스트 대상 완료 개수, 퀘스트 보상 유형, 퀘스트 진행개수, 퀘스트 이름,  퀘스트 내용, 퀘스트 요약, 퀘스트 대사
    public QuestInfo(string _quest_code_str, int _quest_code, int _quest_npc_code, int _quest_chapter, QuestState _quest_state, QuestType _quest_type, MonsterCode _quest_monstercode, int _quest_complete_count, QuestRewardCode _quest_reward_type, int _quest_reward_gold, SpawnCode _quest_reward_item, int _questItemCur, string _quest_name, string _content, string _summary, string _script, string _complete_script)
    {
        quest_code_str = _quest_code_str;
        quest_code = _quest_code;
        quest_npc_code = _quest_npc_code;
        quest_chapter = _quest_chapter;
        quest_state = _quest_state;
        quest_type = _quest_type;
        questmonstercode = _quest_monstercode;
        questItemMax = _quest_complete_count;
        quest_reward_type = _quest_reward_type;
        quest_reward_gold = _quest_reward_gold;
        quest_reward_item = _quest_reward_item;
        questItemCur = _questItemCur;
        quest_name = _quest_name;
        content = _content;
        summary = _summary;
        script = _script;
        complete_script = _complete_script;
    }
}


public class Quest : MonoBehaviour
{
    public NetworkRouter networkRouter = null;
    List<QuestInfo> questInfoList = new List<QuestInfo>();
    public List<QuestInfo> playerQuestList = new List<QuestInfo>();
    public List<QuestInfo> questAcessList = new List<QuestInfo>();
    public List<QuestInfo> questSuccessList = new List<QuestInfo>();

    public NPCQuestUI npcTest = null;


    // Start is called before the first frame update
    void Awake()
    {
        Screen.SetResolution(1920, 1080, false);
        QuestList();
        PlayerQuestList();
        UIQuestList();

        // test
        PlayerPrefs.SetString("UserCode", "#9a1d002a"); // #00000000
        Debug.LogWarning(PlayerPrefs.GetString("UserCode"));
    }

    // Update is called once per frame
    void Update()
    {

    }

    #region 퀘스트 Setting


    public void RequestQuestData()
    {
        networkRouter.PostRouter(PostType.PLAYER_CHARACTER_GET_ALLDATA);
    }

    // Get Quest Datas from Server or Database.
    public void LoadQuestData(string[] infolist)
    {
        try
        {
            for (int qCount = 0; qCount < infolist.Length; qCount++)
            {
                string[] questDetailData = infolist[qCount].Split('!');

                /*** questDetailData ---> [0] state / [1] max / [2] cur ***/

                QuestState state = QuestState.enable;

                switch (questDetailData[0])
                {
                    case "enable": state = QuestState.enable; break;
                    case "able": state = QuestState.able; break;
                    case "accept": state = QuestState.accept; break;
                    case "success": state = QuestState.success; break;
                    default: throw new System.Exception("퀘스트 로드 에러");
                }

                playerQuestList[qCount].quest_state = state;                             // state
                playerQuestList[qCount].questItemMax = int.Parse(questDetailData[1]);    // max
                playerQuestList[qCount].questItemCur = int.Parse(questDetailData[2]);    // cur

                Debug.LogWarning(questDetailData[0]);
                Debug.LogWarning(int.Parse(questDetailData[1]));
                Debug.LogWarning(int.Parse(questDetailData[2]));
            }
        }
        catch (System.Exception ex)
        {
            Debug.LogWarning(ex);
        }
    }


    public void QuestList()                                     //퀘스트의 정보
    {
        //퀘스트 고유 번호 str, 퀘스트 고유 번호, npc 고유 번호,  챕터,  퀘스트 상태,  퀘스트 유형, 몬스터 코드, 퀘스트 대상 완료 개수, 퀘스트 보상 유형, 퀘스트 골드 보상, 퀘스트 진행개수, 퀘스트 이름,  퀘스트 내용, 퀘스트 요약, 퀘스트 대사
        
        //==================================================================================Chapter 1=====================================================================================================
        questInfoList.Add(new QuestInfo("Q001", 0, 6, 1, QuestState.enable, QuestType.Type_Kill,            MonsterCode.WM101, 5,   QuestRewardCode.Only_Gold,    3000, 0, 0,
            "꽃 때문에 못살겠어!",                  "꽃들 사이에 숨어서 주민을 공격하는 걷는 꽃 몬스터가 골칫거리라고 한다. 평화로운 숲에서 걷는 꽃 몬스터를 5마리 처치하자.",    "걷는 꽃",                 "으잉으잉으잉 쯔쯔쯔… 나쁜 꽃놈들이 마을 사람들을 자꾸 습격하는구먼.자네가 좀 해결해주게.", "오잉어잉어잉 쯔쯔쯔… 고생했구만… 고맙다네."));

        questInfoList.Add(new QuestInfo("Q002", 1, 0, 1, QuestState.enable, QuestType.Type_Kill,            MonsterCode.OM401, 10,  QuestRewardCode.Only_Gold,    3000, 0, 0,
            "[반복]열매 요리가 하고싶어요~",        "여관주인이 맛있는 열매 요리를 만들고 싶어한다. 평화로운 숲에서 자연의 열매를 10개 찾아 여관주인에게 가져다 주자.",            "자연의 열매 수집",        "야생에서 나오는 열매는 매우 맛있지만 구하기 힘들어요… 혹시 구해다주실 수 있나요?", "어머!싱싱하고 좋은 열매네요.감사해요!"));

        questInfoList.Add(new QuestInfo("Q003", 2, 5, 1, QuestState.enable, QuestType.Gold_Collect,         0,                 3000, QuestRewardCode.Equipment,   3000, SpawnCode.A002, 0,
            "과연 거지인가(거지 같은 사람)",        "거지?가 3000Gold를 달라고 한다. 과연 줘야할까?",                                                                              "Gold",                     "거, 주머니가 두둑해보이네? 조금 나눠주지 않겠어? 아님말고.", "아 아니다 필요없어. 이것도 가져"));

        questInfoList.Add(new QuestInfo("Q004", 3, 7, 1, QuestState.enable, QuestType.Type_Kill,            MonsterCode.WM102, 8,   QuestRewardCode.Only_Gold,    3000, 0, 0, 
            "소원을 이루는 탑",                    "건방진 꼬맹이가 움직이는 돌멩이가 필요하다고 한다. 평화로운 숲에서 뛰는 돌을 처치하여 신기한 돌멩이 8개를 구해다주자.",       "신기한 돌맹이",             "야 너! 마을 밖에는 돌멩이가 움직인대! 그 돌로 탑을 쌓으면 소원을 이뤄준댔어! 하지만 엄마가 밖으로 나가는 걸 반대하셔…",  "이제 엄마가 안 아프겠지?! 고마워!"));

        questInfoList.Add(new QuestInfo("Q005", 4, 1, 1, QuestState.enable, QuestType.Type_Kill,            MonsterCode.TM501, 5,   QuestRewardCode.Repair_Coupon,  3000, 0, 0,
        "근거없는 싸움",                          "대장장이가 자신의 무기를 검증해달라고 한다. 대장장이가 준 무기를 장착하고, 평화로운 숲에서 무는 악어를 5대 때리고 오자.",    "무는 악어 때리기",            "아니! 저 망나니가 악어 가죽은 세상에서 가장 질겨서 상처 하나 낼 수 없다지 않나! 자존심이 있지! 이 검으로 내 무기는 세상의 어떤 것보다 날이 잘 든다는 것을 증명해주게나!" ,"그게 정말인가!? 생채기 하나 안 났다고? 에이! 오늘 술값 날렸구만 그래!!!"));


        //==================================================================================Chapter 2=====================================================================================================
        questInfoList.Add(new QuestInfo("Q006", 5, 0, 2, QuestState.enable, QuestType.Type_Kill,            MonsterCode.OM402, 5,    QuestRewardCode.Only_Gold,    3000, 0, 0,
            "예쁜 전등을 원해요~",      "여관 주인이 예쁘고 밝은 등불이 필요하다고 한다. 불타는 용암 폭포에서 불타는 꽃을 찾아 5개 꺾어다 주자.",                                         "불타는 꽃 수집",    "예쁘고 밝은 둥불이 필요해요...혹시 구해다 주실 수 있나요 ?", "어머!정말 예쁘고 밝은 꽃이네요!좋은 전등이 되겠어요!"));

        questInfoList.Add(new QuestInfo("Q007", 6, 1, 2, QuestState.enable, QuestType.Type_Kill,            MonsterCode.WM104, 5,    QuestRewardCode.Repair_Coupon,3000, 0, 0,
            "전설의 검을 위하여",       "대장장이가 좋은 무기를 만들어준다고 한다. 불타는 용암 폭포에서 불타는 돌을 처치하여 불의 돌 5개를 구해다 주자.",                                   "불의 돌 수집",    "허허허! 자네 더 좋은 무기가 가지고 싶지 않으가!? 좋은 돌을 가져오면 내 하나 만들어줌세!!", "으하하! 좋은 재료를 가져왔는데 망쳐버렸구만!! 미안허이! 대신 수리쿠폰을 줌세!"));

        questInfoList.Add(new QuestInfo("Q008", 7, 4, 2, QuestState.enable, QuestType.Type_Kill,            MonsterCode.FM201, 5,    QuestRewardCode.Equipment,    3000, 0, 0,
            "참치가 먹고 싶은 고양이", "길고양이가 갑자기 길목을 막아서더니 바닥에 참치 그림을 그렸다. 불타는 용암 폭포에서 불타는 참치를 처치하여 뜨거운 참치 5마리를 구해다 주자.",        "뜨거운 참치",     "마옹.(바닥에 참치를 그린다)", "(하악질)"));

        questInfoList.Add(new QuestInfo("Q009", 8, 5, 2, QuestState.enable, QuestType.Gold_Collect,         0,                 7000, QuestRewardCode.Equipment,    3000, SpawnCode.S002, 0,
            "거지인 거지?",             "거지? 가 7000Gold를 달라고 한다.과연 줘야할까?",                                                                                                       "Gold",         "너 돈 참 많구나 ? 조금만 나눠줘라.아님말고.", "아 아니다 필요없네 이것도 가져."));

        questInfoList.Add(new QuestInfo("Q010", 9, 7, 2, QuestState.enable, QuestType.GetItem_Type_Kill,    MonsterCode.TM503, 5,    QuestRewardCode.Only_Gold,    3000, SpawnCode.W003, 0,
            "화끈한 용암 꼬치",        "건방진 꼬맹이가 화끈한 용암맛을 느끼고 싶다고 한다. 불타는 용암 폭포에서 꼬치 검으로 용암 폭포를 5회 타격하자. ",                                   "꼬치 굽기",        "흠… 더 화끈한 불 맛이 좋은데… 야 너! 이 꼬치 좀 용암에 구워다주라!", "와! 진짜 바싹 구워졌네? 고마워!"));


        //==================================================================================Chapter 3=====================================================================================================
        questInfoList.Add(new QuestInfo("Q011", 10, 4, 3, QuestState.enable, QuestType.Type_Kill,   MonsterCode.FM202, 5,   QuestRewardCode.Equipment,      3000, SpawnCode.W102, 0,
          "날치가 먹고 싶은 고양이", "길고양이가 갑자기 길목을 막아서더니 바닥에 날치 그림을 그렸다.차가운 얼음 호수에서 얼음 날치를 잡아 냉동 날치 5마리를 구해다 주자.",         "냉동 날치",            "애옹.(바닥에 날치를 그린다)",                                                          "(하악질)"));

        questInfoList.Add(new QuestInfo("Q012", 11, 6, 3, QuestState.enable, QuestType.Type_Kill,   MonsterCode.WM109, 5,   QuestRewardCode.Repair_Coupon,  3000, 0, 0,
            "[반복]너무나도 추워!", "날이 추워 마을 사람들이 추위에 떨고 있다고 한다. 차가운 얼음 호수에서 하얀 눈사람을 처치하여 목도리 5개를 구해다 주자.",                      "목도리",               "으잉으잉으잉 쯔쯔쯔… 나쁜 날씨 같으니.마을 사람들을 위해 따뜻한 것 좀 구해다 주게.", "오잉어잉어잉 쯔쯔쯔… 고생했구만… 정말 고맙다네."));

        questInfoList.Add(new QuestInfo("Q013", 12, 2, 3, QuestState.enable, QuestType.Type_Kill,   MonsterCode.OM403, 20,   QuestRewardCode.Only_Gold,     3000, 0, 0,
            "치료가 필요해", "요정이 발목을 다쳤다고 한다.요정을 위해 차가운 얼음 호수에서 얼음 덩어리 20개를 찾아서 구해다 주자.",                                                "얼음 덩어리 수집",     "아얏. 아퍼. 저번에 돌에 깔려서 발목을 좀 삐었나 봐. 차가운 얼음 좀 구해다 줄래?" ,"오오…!정말 고마워!덕분에 좀 나아지겠어!"));

        questInfoList.Add(new QuestInfo("Q014", 13, 8, 3, QuestState.enable, QuestType.Type_Kill, MonsterCode.WM107,                5, QuestRewardCode.Equipment,        3000, SpawnCode.A005, 0,
            "아들이 걱정돼요", "아이 어머니가 날이 추워지는 것을 걱정하여 아들의 옷을 만들어주고 싶어한다. 차가운 얼음 호수에서 하얀 곰을 처치하여 털가죽 5개를 구해다주자.",      "털가죽 수집",          "너 돈 참 많구나 ? 조금만 나눠줘라.아님말고.", "아 아니다 필요없네 이것도 가져."));


        //==================================================================================Chapter 4=====================================================================================================
        questInfoList.Add(new QuestInfo("Q015", 14, 0, 4, QuestState.enable, QuestType.Type_Kill,   MonsterCode.FM204, 10, QuestRewardCode.Only_Gold, 3000, 0,            0,
         "차를 마시고 싶어요~", "여관주인이 몽실몽실한 차를 마시고 싶어한다. 꽃이 가득한 들판에서 꽃구름을 처치하여 구름 조각 10개를 가져다주자.", "구름 조각", "몽실몽실한 차가 그립네요… 혹시 적절한 재료를 구해다 주실 수 있나요 ?", "어머! 정말 몽실몽실한 재료네요! 감사해요!"));

        questInfoList.Add(new QuestInfo("Q016", 15, 1, 4, QuestState.enable, QuestType.Type_Kill,   MonsterCode.OM404, 3, QuestRewardCode.Only_Gold, 3000, 0,              0,
            "몸보신을 위하여", "최근 대장장이의 몸이 쇠하다고 한다. 꽃이 가득한 들판에서 구름초 3개를 찾아  가져다 주자.", "구름초", "어허허… 최근 몸이 쇠하구먼!! 좋은 풀을 가져오면 내 하나 귀한 걸 줌세!", "으하하!! 자네 덕분에 몸이 아주 튼튼해지겠구먼!"));

        questInfoList.Add(new QuestInfo("Q017", 16, 3, 4, QuestState.enable, QuestType.Type_Kill,   MonsterCode.WM110, 3, QuestRewardCode.Equipment, 3000, SpawnCode.G004, 0,
            "새로운 스킬", "RGB 정령이 힘을 보충하고 싶어한다. 무지개 꽃을 잡아 씨앗을 가져다 주자.", "무지개 씨앗", "스킬을 해금하기 위해서 마력이 필요해, 혹시 우리 힘을 보충할만한 무언가를 갖다 줄 수 있어 ?", "고마워!앞으로 더 많은 스킬을 쓸 수 있을거야."));

        questInfoList.Add(new QuestInfo("Q018", 17, 4, 4, QuestState.enable, QuestType.Gold_Collect,MonsterCode.FM203, 5, QuestRewardCode.Equipment, 3000, SpawnCode.W103, 0,
            "치킨이 먹고 싶은 고양이", "길고양이가 갑자기 길목을 막아서더니 바닥에 치킨 그림을 그렸다. 꽃이 가득한 들판에서 무지개 새를 처치하여 무지개 맛있는 치킨 5마리를 구해다 주자.", "무지개 맛있는 치킨", "미야옹. (바닥에 무지개 치킨을 그린다.)", "냐아옹!! (매우 기뻐한다)"));


        //==================================================================================Chapter 5=====================================================================================================
        questInfoList.Add(new QuestInfo("Q019", 18, 1, 5, QuestState.enable, QuestType.Type_Kill, MonsterCode.WM112, 5,     QuestRewardCode.Equipment, 3000, SpawnCode.W205, 0,
         "전설의 활을 위하여", "대장장이가 좋은 무기를 만들어준다고 한다. 정령을 모시는 신전에서 신전 기사를 처치하여 아다만티움 5개를  구해다 주자.", "아다만티움", "허허허!자네 더 좋은 무기가 가지고 싶지 않으가!? 좋은 철을 가져오면 내 하나 만들어줌세!!", "으하하!좋은 재료를 가져왔는데 망쳐버렸구만!!으하하 농담일세!여기 아주 좋은 무기를 만들었네."));

        questInfoList.Add(new QuestInfo("Q020", 19, 2, 5, QuestState.enable, QuestType.Type_Kill, MonsterCode.WM113, 10,    QuestRewardCode.Equipment, 3000, SpawnCode.S005, 0,
            "재료가 필요해", "요정이 돌을 만드는데 재료가 부족하다고 한다. 정령을 모시는 신전에서 신전 케로베로스를 잡아 케로베로스의 심장을 10개 가져다 주자.", "케로베로스의 심장", "돌을 만드는데 재료가 부족해.마력이 가득 담긴 무언가를 가져다줄래?", "오오…! 정말 고마워! 덕분에 좋은 돌을 만들 수 있겠어!"));

        questInfoList.Add(new QuestInfo("Q021", 20, 3, 5, QuestState.enable, QuestType.Type_Kill, MonsterCode.OM405, 1,     QuestRewardCode.Equipment, 3000, SpawnCode.R003, 0,
            "더 강력한 힘", "정령들이 정령을 모시는 신전에 색의 정수를 숨겨두었다고 한다. 정령을 모시는 신전에서 색의 정수 1개를 찾아 가져다 주자.", "색의 정수", "우리가 예전에 비상시를 대비하여 우리의 힘을 담은 색의 정수를 정령을 모시는 신전 어딘가에 숨겨뒀어.위치는 기억나지 않지만 찾아다 줄 수 있어?", "고마워! 앞으로 더 강력한 스킬을 쓸 수 있을거야."));

        questInfoList.Add(new QuestInfo("Q022", 21, 5, 5, QuestState.enable, QuestType.Gold_Collect, 0,              20000, QuestRewardCode.Equipment, 20000, SpawnCode.W202, 0,
            "뭐하는거지?", "거지?가 20000Gold를 달라고 한다. 과연 줘야할까?", "Gold", "돈 정말 많이 모았네? 조금만 줘봐.아님말고.", "아 아니다 필요없네 이것도 가져."));



    }

    public void PlayerQuestList()                               //현재 플레이어의 퀘스트 목록
    {
        playerQuestList = questInfoList;
    }

    public void UIQuestList()                                   //UI작업을 최소화 하기 위해 진행중, 완료 퀘스트 나눔. 
    {
        for (int i = 0; i < playerQuestList.Count; i++)
        {
            if (playerQuestList[i].quest_state == QuestState.accept)
            {
                questAcessList.Add(playerQuestList[i]);
            }
            else if (playerQuestList[i].quest_state == QuestState.success)
            {
                questSuccessList.Add(playerQuestList[i]);
            }
        }
    }

    #endregion


    #region 퀘스트 처리

    public void AddQuest(QuestInfo addquest)                    //퀘스트 수락 able -> accept
    {
        if (questAcessList.Count <= 3)
        {
            questAcessList.Add(addquest);
            playerQuestList[addquest.quest_code].quest_state = QuestState.accept;

            npcTest.NpcQuestListSetting();


            // 라우터 ( able ---> accept )
            networkRouter.PostRouter(PostType.PLAYER_QUEST_STATE_UPDATE, playerQuestList[addquest.quest_code]);

        }
        else
        {
            //NPC UI에 퀘스트가 다 찼다는 신호보냄.
        }
        return;

    }

    public void RemoveQuest(QuestInfo index)
    {
        if (questAcessList.Count >= 0)
        {
            playerQuestList[index.quest_code].quest_state = QuestState.able;
            playerQuestList[index.quest_code].questItemCur = 0;
            questAcessList.Remove(index);

            networkRouter.PostRouter(PostType.PLAYER_QUEST_STATE_UPDATE, playerQuestList[index.quest_code]);
        }
        return;

    }

    public void QuestMonsterCheck(MonsterCode monsterCode)      //퀘스트 진행 상황 체크
    {
        int i;
        for (i = 0; i < questAcessList.Count; i++)
        {
            QuestType questType = questAcessList[i].quest_type;
            switch (questType)
            {
                case QuestType.Type_Kill:
                    if (questAcessList[i].questItemCur < questAcessList[i].questItemMax)
                    {
                        playerQuestList[FindNameToQuestCode(questAcessList[i].quest_name).quest_code].questItemCur++;
                    }
                    break;

                case QuestType.Tutorial:

                    if (questAcessList[i].quest_code == 23)//&& questAcessList[i].questEquipment == 지금 장착한 장비)
                    {
                        playerQuestList[FindNameToQuestCode(questAcessList[i].quest_name).quest_code].questItemCur++;
                        break;
                    }
                    else if (questAcessList[i].quest_code == 23)
                    {
                        playerQuestList[FindNameToQuestCode(questAcessList[i].quest_name).quest_code].questItemCur++;
                        break;
                    }
                    else
                    {
                        playerQuestList[FindNameToQuestCode(questAcessList[i].quest_name).quest_code].questItemCur++;
                        break;
                    }

                case QuestType.Repeat:
                    if (questAcessList[i].questItemCur < questAcessList[i].questItemMax)
                    {
                        playerQuestList[FindNameToQuestCode(questAcessList[i].quest_name).quest_code].questItemCur++;
                    }
                    break;

                case QuestType.Gold_Collect:
                    {
                        //questAcessList[i].questItemCur = 현재골드
                        //playerQuestList[FindNameToQuestCode(questAcessList[i].quest_name).quest_code].questItemCur = 현재골드
                    }
                    break;



            }


        }

        gameObject.transform.GetComponent<QuestUI>().QuestBoardSetting();
        // 라우터 ( Quest item )
        networkRouter.PostRouter(PostType.PLAYER_QUEST_ITEM_UPDATE, playerQuestList[questAcessList[i].quest_code]);

    }

    public string SuccessquestComplete(int npccode)                          //NPC에게 말 걸었을 때 퀘스트 완료
    {
        for (int i = 0; i < questAcessList.Count; i++)
        {

            if ((questAcessList[i].quest_npc_code == npccode) && (questAcessList[i].questItemMax == questAcessList[i].questItemCur)) //퀘스트 npc 확인
            {

                //보상 처리

                questSuccessList.Add(questAcessList[i]);
                playerQuestList[questAcessList[i].quest_code].quest_state = QuestState.success;


                // 라우터 ( accept ---> success )
                networkRouter.PostRouter(PostType.PLAYER_QUEST_STATE_UPDATE, playerQuestList[questAcessList[i].quest_code]);

                string successQuestname = questAcessList[i].quest_name;
                questAcessList.Remove(questAcessList[i]);

                return successQuestname;
            }
        }
        return null;
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
            if (playerQuestList[i].quest_chapter == clearChapterNumber)
            {
                playerQuestList[i].quest_state = QuestState.able;

                //npcUI 다시 세팅

                // 라우터 ( eable ---> able )
                networkRouter.PostRouter(PostType.PLAYER_QUEST_STATE_UPDATE, playerQuestList[i]);

            }
        }
        npcTest.NpcQuestListSetting();
    }

    public List<QuestInfo> GetnpcQuestList(int questNpcCode)    //NPC에게 해당 퀘스트 전달
    {
        List<QuestInfo> npcquestlist = new List<QuestInfo>();

        for (int i = 0; i < playerQuestList.Count; i++)
        {
            if ((playerQuestList[i].quest_npc_code == questNpcCode) && (playerQuestList[i].quest_state == QuestState.able)) //NPC가 가진 able 리스트 리턴.
            {

                npcquestlist.Add(playerQuestList[i]);
            }
        }
        return npcquestlist;
    }


    public List<QuestInfo> GetDungeonQuestList(int dungeonType)        //던전에 해당 퀘스트 전달.
    {
        List<QuestInfo> dungeonQuestList = new List<QuestInfo>();

        for (int i = 0; i < playerQuestList.Count; i++)
        {
            if (playerQuestList[i].quest_chapter == dungeonType)
            {
                dungeonQuestList.Add(playerQuestList[i]);
            }
        }

        return dungeonQuestList;
    }


    #endregion




}

