using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCMenuUI : MonoBehaviour
{
    public Canvas npcquestCanvas;
    public Canvas storeCanvas;
    public GameObject storeButton;
    public int npcCode;

    Animator slideNPCMenuAnimator;

    bool isClick = false;

    private void Start()
    {
        //npcQuestScript.SetActive(false);
        if (npcquestCanvas.enabled == true)
            slideNPCMenuAnimator = transform.GetChild(0).GetComponent<Animator>();
        Debug.Log("npccode : " + npcCode);
       // Debug.Log("storeAvailable" + GetComponent<NPCParent>().npcInfoList[npcCode].storeAvailable);
        StoreAvailableCheck(transform.GetComponent<NPCParent>().npcInfoList[npcCode].storeAvailable);
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

   public void StoreAvailableCheck(bool storeavailable)
    {
        storeButton.SetActive(storeavailable);

    }

}
