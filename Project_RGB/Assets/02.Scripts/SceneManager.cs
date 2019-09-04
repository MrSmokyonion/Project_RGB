/* ********************************************************* *
 *                          DevDong                          *
 * ********************************************************* */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SceneType
{
    SPLASH,
    TITLE,
    TUTORIAL,
    TOWN,
    CHOICE_DUNGEON,
    DUNGEON_CHAPTER_1,
    DUNGEON_CHAPTER_2,
    DUNGEON_CHAPTER_3,
    DUNGEON_CHAPTER_4,
    DUNGEON_CHAPTER_5
}

public class SceneManager : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // 씬 전환
    public void ChangeScene(SceneType type)
    {
        string scene = string.Empty;

        switch (type)
        {
            case SceneType.SPLASH:            scene = "SplashScene";           break;
            case SceneType.TITLE:             scene = "TitleScene";            break;
            case SceneType.TUTORIAL:          scene = "TutorialScene";         break;
            case SceneType.TOWN:              scene = "TownScene";             break;
            case SceneType.CHOICE_DUNGEON:    scene = "ChoiceDungeonScene";    break;
            case SceneType.DUNGEON_CHAPTER_1: scene = "DungeonChapterScene_1"; break;
            case SceneType.DUNGEON_CHAPTER_2: scene = "DungeonChapterScene_2"; break;
            case SceneType.DUNGEON_CHAPTER_3: scene = "DungeonChapterScene_3"; break;
            case SceneType.DUNGEON_CHAPTER_4: scene = "DungeonChapterScene_4"; break;
            case SceneType.DUNGEON_CHAPTER_5: scene = "DungeonChapterScene_5"; break;
        }
        UnityEngine.SceneManagement.SceneManager.LoadScene(scene);
    }
}
