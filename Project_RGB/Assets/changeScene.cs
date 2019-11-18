using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeScene : MonoBehaviour
{
    public SceneManager sceneManagerScript;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Test()
    {
        sceneManagerScript.ChangeScene(SceneType.CHOICE_DUNGEON);
    }
}
