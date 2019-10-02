using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMenuButtonUI : MonoBehaviour
{
    public NPCMenuUI npcQuestUI;
    // Start is called before the first frame update


    public void SlideNPCMenuButtonClick()
    {
        npcQuestUI.SlideNPCMenuButtonClick();
    }


    public void QuestCanvasOpen()
    {
        npcQuestUI.QuestCanvasOpen();
    }

    public void StoreCanvasOpen()
    {

        npcQuestUI.StoreCanvasOpen();
    }
}
