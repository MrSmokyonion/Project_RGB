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
    VILLAGE,
    CHOICE_DUNGEON,
    TUTORIAL,
    DUNGEON_CHAPTER
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
        //2.튜토리얼을 클리어한 경우/ 스킵한 경우/ '튜토리얼 완료' 기존유저가 Start를 누르는 경우 -> nowScene = SceneType.VILLAGE로 이동;
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
            case SceneType.CHOICE_DUNGEON: scene = "ChoiceDungeonScene"; break;
            case SceneType.TUTORIAL:
            case SceneType.DUNGEON_CHAPTER : scene = "DungeonChapterScene"; break;

                //SplashScene, TitleScene, VillageScene, ChoiceDungeonScene, DungeonChapterScene
                //DungeonSelectionTestRoom, MonsterTestRoom
        }
        UnityEngine.SceneManagement.SceneManager.LoadScene(scene);
    }
}
