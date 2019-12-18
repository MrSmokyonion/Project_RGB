using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonManager : MonoBehaviour
{
    //***************Chapter & Stage 관련 변수********
    public GameObject[] chapter012345_Prefab;                                   //(Inspector)
    public int nowChapterNumber = 1;         /*원래 -2인데 빌드를 위해 바꿈*/     // 0는 튜토리얼, -2는 로딩이 안된 것. 챕터 1, 2, 3, ...
    public int nowStageNumber = -2;                                             // 스테이지 1, 2, 3... , -2는 로딩이 안된 것.
    public int maxStageNumber = -2;                                             // -2는 로딩 안된 것.
    int maxClearStageNumber = -1;                                               // 기본 -1, 튜토리얼 클리어 후 0, 1챕터 클리어 후 -> 1로 변경.

    //**************Dungeon & UI 관련 변수************
    public Dictionary<string/*"Stage"+number*/, int> stageMonsterCounts = new Dictionary<string, int>();
    public GameObject PlayerObject;                                             //(Inspector)
    public List<TeleportDoor> teleportDoors = new List<TeleportDoor>();         //(teleportDoor들이 Self Add함)
    public DungeonUI dungeonUI;                                                 //(Inspector)
    public FadeInOutManager fadeInOutManager;                                          //(Inspector)

    //***************NetworkRouter 변수***************
    public NetworkRouter NetworkRouter;                                         //(inspector)

    private void Awake()
    {
        //index 저장
        nowChapterNumber = PlayerPrefs.GetInt("DUNGEON_NUM");
        //nowChapterNumber = 1;
        nowStageNumber = 1;
        switch (nowChapterNumber)
        {
            case 1: maxStageNumber = 3; break;
            case 2: maxStageNumber = 4; break;
            case 3: maxStageNumber = 3; break;
            case 4: maxStageNumber = 4; break;
            case 5: maxStageNumber = 4; break;
        }
        dungeonUI.ProgressSliderSetting(nowStageNumber, maxStageNumber);
        //지금 챕터에 따른 chapter 소환
        GameObject chapterObject = Instantiate(chapter012345_Prefab[nowChapterNumber], this.transform/*0,0위치에 소환.(플레이어도 처음 소환 위치 0,0 맞춰줘야함.)*/);//튜토리얼은 0번째.
        //소환된 Chapter의 stage마다 MonsterCount 확인
        for (int i = 0; i < maxStageNumber; i++)    //i==Stage
        {
            Transform ChapterTransform = chapterObject.transform.GetChild(i)/*stage+(i+1)*/;
            int chatperAllMonsterCount = ChapterTransform.GetChild(1)/*Monsters*/.childCount;   //stage에 있는 모든 몬스터 개수
            int chatperTMOMMonsterCount = 0;                                                    //stage에 있는 Trap과 Object 몬스터 개수
            for (int j = 0; j < chatperAllMonsterCount; j++)    //j==Monster
            {
                //Exclude Trap Or Object (TrapMonster 또는 ObjectMonster 제외함).
                if (ChapterTransform.GetChild(1)/*Monsters*/.GetChild(j).name.Contains("TM") ||
                    ChapterTransform.GetChild(1)/*Monsters*/.GetChild(j).name.Contains("OM"))
                    chatperTMOMMonsterCount++;
            }
            //Debug.Log("챕터 이름 잘 들어갔나요" + chapterObject.transform.GetChild(i).name);
            stageMonsterCounts.Add(ChapterTransform.name,
                chatperAllMonsterCount - chatperTMOMMonsterCount);
        }
    }

    public void BeforeGoToNextStage()
    {
        //화면 천천히 페이드 아웃
        fadeInOutManager.FadeOutPlay();
        //Stage 동기화
        if (nowStageNumber < maxStageNumber)
        {
            nowStageNumber++;
            if (nowStageNumber == maxStageNumber)
            {
                //보스 스테이지!! bgm 바꿈??
            }
        }
    }
    public void AfterGoToNextStage()
    {
        //ProgressSilder UI변경 요청, 캐릭터 위치 옮김.
        dungeonUI.ProgressSliderSetting(nowStageNumber, maxStageNumber);
        fadeInOutManager.FadeInPlay();

        //화면 천천히 페이드 인
        //FadeIn();
    }

    public void MonsterInstantiateProcessing()
    {
        stageMonsterCounts["Stage" + nowStageNumber] += 1;       //죽여야할 녀석이 한 놈 늘었다.
    }

    public void MonsterDestroyProcessing(MonsterCode mCode)
    {
        //이 함수를 부르는 넘은 혹시 또 다른 놈이 생성될지 모르니까 Invoke 0.5초 정도 딜레이.

        stageMonsterCounts["Stage" + nowStageNumber] -= 1;   //죽여야할 녀석이 한 놈 줄었다.
        Debug.Log("NowStageMonsterCount" + stageMonsterCounts["Stage" + nowStageNumber]);

        if (stageMonsterCounts["Stage" + nowStageNumber] <= 0)
        {
            //스테이지 클리어. 다음 스테이지로 넘어갈 수 있도록 처리해줘야함.
            TeleportDoor openDoor = GameObject.Find("TeleportDoor" + (nowStageNumber * 2 - 1)).GetComponent<TeleportDoor>();
            openDoor.teleportOpen = true;
            //Debug.Log("열린문이름:" + openDoor.gameObject.name);
            if (nowStageNumber == maxStageNumber)
            {
                openDoor.chapterClear = true;
            }
        }
    }

    public void ChapterClear()
    {
        fadeInOutManager.FadeOutPlay();
        //Debug.Log("ChapterClear:" + (SceneType.DUNGEON_CHAPTER) + "_" + nowChapterNumber);
        NetworkRouter.PostRouter(PostType.PLAYER_DUNGEON_STATE_UPDATE, ((SceneType.DUNGEON_CHAPTER) + "_" + nowChapterNumber));
        Invoke("GoToDungeonSelectScene",2.2f);
    }

    void GoToVillageScene()
    {
        SceneManager sceneManager = GameObject.Find("SceneManager").GetComponent<SceneManager>();
        sceneManager.ChangeScene(SceneType.VILLAGE);
        //죽음
    }

    void GoToDungeonSelectScene()
    {
        SceneManager sceneManager = GameObject.Find("SceneManager").GetComponent<SceneManager>();
        sceneManager.ChangeScene(SceneType.CHOICE_DUNGEON);
        //클리어
    }
}
