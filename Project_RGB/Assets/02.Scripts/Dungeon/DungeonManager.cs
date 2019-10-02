using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonManager : MonoBehaviour
{
    public int nowChapterNumber = -1;               //0번째는 튜토리얼

    public GameObject[] chapter012345_Prefab;

    //private void Awake()
    //{
    //    //지금 Chapter가 어디인지 확인 ( 씬 넘겨서, 어디서 불러오지?)

    //    //지금 챕터에 따른 chapter 소환
    //    Instantiate(chapter012345_Prefab[nowChapterNumber], this.transform/*0,0위치에 소환.(플레이어도 처음 소환 위치 0,0 맞춰줘야함.)*/);//튜토리얼은 0번째.

    //}
}
