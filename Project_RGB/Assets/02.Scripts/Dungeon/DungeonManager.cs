using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonManager : MonoBehaviour
{
    int nowChapterNumber = -1;              //0번째는 튜토리얼, -1는 아직 로딩 안됨...
    int nowStageNumber = 1;                 //스테이지 1, 2, 3...

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
    }
}
