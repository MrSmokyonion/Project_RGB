using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackButton : MonoBehaviour
{
    public Canvas BackButtonCanvas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BackButtonScript()
    {
        BackButtonCanvas.enabled = false;
    }

    public void NPCQuestCanvas_BackButtonScript()
    {
        BackButtonCanvas.enabled = false;
        transform.parent.GetChild(2).gameObject.SetActive(false);  
    }
}
