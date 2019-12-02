using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingBarScript : MonoBehaviour
{
    public SceneManager sceneManager;   //(Inspector)

    public void LoadingComplete()
    {
        sceneManager.ChangeScene(SceneType.DUNGEON_CHAPTER);
    }
}
