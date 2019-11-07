using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonManager : MonoBehaviour
{
    int nowChapterNumber = -2;              // 0는 튜토리얼, -2는 로딩이 안된 것.
    int nowStageNumber = -2;                // 스테이지 1, 2, 3... , -2는 로딩이 안된 것.
    int maxClearStageNumber = -1;            // 기본 -1, 튜토리얼 클리어 후 0, 1챕터 클리어 후 -> 1로 변경.

    public Dictionary<string/*"stage"+number*/, int> stageMonsterCount = new Dictionary<string, int>(); //(Inspecter)

    public GameObject[] chapter012345_Prefab;   //(Inspector창에서 직접 넣어줘야함.)

    private void Awake()
    {

        //    //지금 Chapter가 어디인지 확인 ( 씬 넘겨서, 로컬에 저장했던 것 가져옴!) TARGET_SCENE?

        //    //지금 챕터에 따른 chapter 소환
        //    Instantiate(chapter012345_Prefab[nowChapterNumber], this.transform/*0,0위치에 소환.(플레이어도 처음 소환 위치 0,0 맞춰줘야함.)*/);//튜토리얼은 0번째.

    }

    public void GoToNextStage()
    {
        nowStageNumber++;
        //UI변경도 요청.
    }

    public void MonsterInstantiateProcessing()
    {
        stageMonsterCount["stage" + nowStageNumber] += 1;       //죽여야할 녀석이 한 놈 늘었다.
    }

    public void MonsterDestroyProcessing(MonsterCode mCode)
    {
        if (stageMonsterCount["stage" + nowStageNumber] <= 0)
        {
            //혹시 또 다른 놈이 생성될지 모르니까 0.5초 정도 딜레이.
            //스테이지 클리어. 다음 스테이지로 넘어가는 처리해줘야함.
            //챕터 자체가 클리어된 건지도 확인해야함.
        }
        else
        {
            stageMonsterCount["stage" + nowStageNumber] -= 1;   //죽여야할 녀석이 한 놈 줄었다.
        }
    }

}
