using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCMenuUI : MonoBehaviour
{
    public Canvas npcquestCanvas;
    public Canvas storeCanvas;

    Animator slideNPCMenuAnimator;

    bool isClick = false;

    private void Start()
    {
        //npcQuestScript.SetActive(false);
        if (npcquestCanvas.enabled == true)
            slideNPCMenuAnimator = gameObject.transform.GetComponent<Animator>();
       
    }


    public void SlideNPCMenuButtonClick()
    {
        isClick = !isClick;
        if (isClick)
        {
            slideNPCMenuAnimator.SetBool("npc_ui_animation_open", true);
        }
        else
        {
            slideNPCMenuAnimator.SetBool("npc_ui_animation_close", false);
        }
    }


    public void QuestCanvasOpen()
    {
        npcquestCanvas.enabled = true;
    }

    public void StoreCanvasOpen()
    {
        storeCanvas.enabled = true;
    }

   

}
