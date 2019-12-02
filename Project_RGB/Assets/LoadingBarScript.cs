using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingBarScript : MonoBehaviour
{
    public SceneManager sceneManager;           //(Inspector)
    public FadeInOutManager fadeInOutManager;   //(Inspector)
    bool isReadyToGo = false;                       //(Inspector)

    private void Start()
    {
        //미리 DungeonChapterScene 실행, isReadyToGo == true면 실행
        StartCoroutine(LoadDungeonChapterScene());
    }

    private IEnumerator LoadDungeonChapterScene()
    {
        AsyncOperation operation = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync("DungeonChapterScene");
        operation.allowSceneActivation = false;

        while (!operation.isDone)
        {
            yield return null;
            if (isReadyToGo)
                operation.allowSceneActivation = true;
        }
    }

    public void LoadingComplete()
    {
        fadeInOutManager.FadeOutPlay();
        Invoke("GoToDungeonChapterScene", 2f);
    }

    void GoToDungeonChapterScene()
    {
        //sceneManager.ChangeScene(SceneType.DUNGEON_CHAPTER);
        isReadyToGo = true;
    }
}
