using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleStartButton : MonoBehaviour
{
    public SceneManager sceneManagerScript;     //(Inspector)
    public FadeInOutManager fadeInOutScript;    //(Inspector)

    public void PressStartButton()
    {
        //페이드 아웃
        fadeInOutScript.FadeOutPlay();
        Invoke("GoToVillageScene", 2.3f);
    }

    void GoToVillageScene()
    {
        sceneManagerScript.ChangeScene(SceneType.VILLAGE);
    }
}
