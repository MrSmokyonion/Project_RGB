using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleStartButton : MonoBehaviour
{
    public SceneManager sceneManagerScript;     //(Inspector)
    public FadeInOutManager fadeInOutScript;    //(Inspector)
    bool isReadyToGo = false;

    private void Start()
    {
        StartCoroutine(LoadVillageScene());
    }

    public void PressStartButton()
    {
        //페이드 아웃
        fadeInOutScript.FadeOutPlay();
        Invoke("GoToVillageScene", 2.3f);
    }

    private IEnumerator LoadVillageScene()
    {
        AsyncOperation operation = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync("VillageScene");
        operation.allowSceneActivation = false;

        while (!operation.isDone)
        {
            yield return null;
            if (isReadyToGo)
                operation.allowSceneActivation = true;
        }
    }

    void GoToVillageScene()
    {
        //sceneManagerScript.ChangeScene(SceneType.VILLAGE);
        isReadyToGo = true;
    }
}
