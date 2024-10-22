﻿/* ********************************************************* *
 *                          DevDong                          *
 * ********************************************************* */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SceneType
{
    EMPTY,
    SPLASH,
    TITLE,
    LOADING,
    VILLAGE,
    CHOICE_DUNGEON,
    DUNGEON_LOADING,
    TUTORIAL,
    DUNGEON_CHAPTER
}

public class SceneManager : MonoBehaviour
{
    public SceneType nowScene = SceneType.EMPTY;

    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(1920, 1080, true);
        
        //nowScene가 EMPTY일시 서버 또는 로컬데이터를 통해 자신이 TARGET_SCENE(가려하는 씬) 어디인지 확인.

        //Unity 로고 -> SceneType.SPLASH

        //Tltle. -> 통신 설정 SceneType.TITLE

        //1.신규유저 로그인 및 시작 -> SceneType.TUTORIAL로 이동;
        //2.튜토리얼을 클리어한 경우/ 스킵한 경우/ '튜토리얼 완료' 기존유저가 Start를 누르는 경우 -> nowScene = SceneType.VILLAGE로 이동;
    }

    public void GoToVillage()
    {
        //BackButton 구현하기귀찬항서 임의로 만ㄷ름
        GameObject.Find("FadeInOut").GetComponent<FadeInOutManager>().FadeOutPlay();
        Invoke("VillageCall", 2.2f);
    }
    void VillageCall()
    {
        ChangeScene(SceneType.VILLAGE);
    }

    // 씬 전환
    public void ChangeScene(SceneType type)
    {
        string scene = string.Empty;

        switch (type)
        {
            case SceneType.SPLASH: scene = "SplashScene"; break;
            case SceneType.TITLE: scene = "TitleScene"; break;
            case SceneType.VILLAGE: scene = "VillageScene"; break;
            case SceneType.CHOICE_DUNGEON:
                PlayerPrefs.SetInt("MONEY", GameObject.Find("Player").GetComponent<Capital>().money);   //급하게 넣어둠
                scene = "ChoiceDungeonScene"; break;
            case SceneType.DUNGEON_LOADING: scene = "DungeonLoadingScene"; break;
            case SceneType.TUTORIAL:
            case SceneType.DUNGEON_CHAPTER: scene = "DungeonChapterScene"; break;

                //SplashScene, TitleScene, VillageScene, ChoiceDungeonScene, DungeonChapterScene
                //DungeonSelectionTestRoom, MonsterTestRoom
        }
        UnityEngine.SceneManagement.SceneManager.LoadScene(scene);
    }
}
