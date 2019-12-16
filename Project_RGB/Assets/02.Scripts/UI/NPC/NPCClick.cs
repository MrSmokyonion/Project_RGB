using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCClick : MonoBehaviour
{
    public int clicknpccode;
    public Canvas npcCanvas;
    public NPCMenuUI npcMenuUI;
    // Start is called before the first frame update
    private void Start()
    {
        npcCanvas.enabled = false;
        npcMenuUI = npcCanvas.GetComponent<NPCMenuUI>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void NpcClick()
    {
        npcCanvas.enabled = true;
        npcMenuUI.npcCode = clicknpccode;
        npcMenuUI.DialogeueSetting();
        npcCanvas.transform.GetChild(0).GetComponent<Image>().enabled = true;
        npcMenuUI.SlideNPCMenuButtonClick();
        npcMenuUI.StoreAvailableCheck(npcCanvas.GetComponent<NPCParent>().npcInfoList[clicknpccode].storeAvailable);


    }

}
