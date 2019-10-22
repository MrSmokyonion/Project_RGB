/* ********************************************************* *
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
    TOWN,
    CHOICE_DUNGEON,
    TUTORIAL,
    DUNGEON_CHAPTER_1,
    DUNGEON_CHAPTER_2,
    DUNGEON_CHAPTER_3,
    DUNGEON_CHAPTER_4,
    DUNGEON_CHAPTER_5
}

public class SceneManager : MonoBehaviour
{
    public SceneType nowScene = SceneType.EMPTY;

    // Start is called before the first frame update
    void Start()
    {
        //nowScene가 EMPTY일시 서버 또는 로컬데이터를 통해 자신이 TARGET_SCENE(가려하는 씬) 어디인지 확인.

        //Unity 로고 -> SceneType.SPLASH

        //Tltle. -> 통신 설정 SceneType.TITLE

        //1.신규유저 로그인 및 시작 -> SceneType.TUTORIAL로 이동;
        //2.튜토리얼을 클리어한 경우/ 스킵한 경우/ '튜토리얼 완료' 기존유저가 Start를 누르는 경우 -> nowScene = SceneType.TOWN로 이동;

        //
    }

    // 씬 전환
    public void ChangeScene(SceneType type)
    {
        string scene = string.Empty;

        switch (type)
        {
            case SceneType.SPLASH: scene = "SplashScene"; break;
            case SceneType.TITLE: scene = "TitleScene"; break;
            case SceneType.TOWN: scene = "TownScene"; break;
            case SceneType.CHOICE_DUNGEON: scene = "ChoiceDungeonScene"; break;
            case SceneType.TUTORIAL:
            case SceneType.DUNGEON_CHAPTER_1:
            case SceneType.DUNGEON_CHAPTER_2:
            case SceneType.DUNGEON_CHAPTER_3:
            case SceneType.DUNGEON_CHAPTER_4:
            case SceneType.DUNGEON_CHAPTER_5: scene = "DungeonChapterScene"; break;
        }
        UnityEngine.SceneManagement.SceneManager.LoadScene(scene);
    }
}
