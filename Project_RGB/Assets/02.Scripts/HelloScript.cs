using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelloScript : MonoBehaviour
{

    // 테스트 (씬)
    public SceneType sceneType;
    public void SceneTest()
    {
        GameObject.FindObjectOfType<SceneManager>().ChangeScene(sceneType);
    }
    // 테스트 (텔레포트)
    public GameObject cube;
    public void TeleportTest()
    {
        // GameObject.FindObjectOfType<TeleportManager>().TeleportTarget(cube, new Vector3(5, 5, 5));
        GameObject.FindObjectOfType<TeleportManager>().TeleportFindTarget("Cube", new Vector3(5, 5, 5));
    }
}
