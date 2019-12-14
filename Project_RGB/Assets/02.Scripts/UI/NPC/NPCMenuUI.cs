using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCMenuUI : MonoBehaviour
{
    public Canvas npcquestCanvas;
    public Canvas[] storeCanvas;
    public GameObject storeButton;
    public int npcCode;

    Animator slideNPCMenuAnimator;

    bool isClick = false;
    bool textEnable = true;

    private IEnumerator coroutine;
    public Text npcDialogueText;
    NPCParent npcParentScript;

    private void Start()
    {
        npcParentScript = GetComponent<NPCParent>();
        //npcQuestScript.SetActive(false);
        slideNPCMenuAnimator = transform.GetChild(0).GetComponent<Animator>();

        // Debug.Log("storeAvailable" + GetComponent<NPCParent>().npcInfoList[npcCode].storeAvailable);
        StoreAvailableCheck(npcParentScript.npcInfoList[npcCode].storeAvailable);
        npcquestCanvas.enabled = false;
    }

    public void DialogeueSetting()
    {

        if (textEnable == true)
        {
            npcDialogueText.text = "";
            coroutine = TypeText(npcParentScript.npcInfoList[npcCode].Dialogue, npcDialogueText, true);
            StartCoroutine(coroutine);
        }
    }

    public void DialogueTextClick()
    {
        StopCoroutine(coroutine);
        npcDialogueText.text = npcParentScript.npcInfoList[npcCode].Dialogue;
    }

    public void SlideNPCMenuButtonClick()
    {
        slideNPCMenuAnimator.SetBool("isOpen", true);

    }


    public void QuestCanvasOpen()
    {
        npcquestCanvas.GetComponent<NPCQuestUI>().QuestClear();
        npcquestCanvas.GetComponent<NPCQuestUI>().NpcQuestListSetting();
        npcquestCanvas.transform.GetChild(0).GetComponent<Animator>().SetBool("isOpen", true);
        //npcquestCanvas.GetComponent<NPCQuestUI>().NpcQuestListSetting();
        npcquestCanvas.enabled = true;
    }

    public void StoreCanvasOpen()
    {
        if (npcParentScript.npcInfoList[npcCode].storetype == StoreType.Food) //음식
        {
            storeCanvas[0].enabled = true;
            storeCanvas[0].GetComponent<StoreUI>().ItemCheck();
            storeCanvas[0].transform.GetChild(0).GetComponent<Animator>().SetBool("isOpen", true);

        }
        else if (npcParentScript.npcInfoList[npcCode].storetype == StoreType.WeaponAndRepair) //수리 & 장비 캔버스
        {
            storeCanvas[1].enabled = true;
            //storeCanvas[1].GetComponent<StoreUI>().ItemCheck();
            storeCanvas[1].transform.GetChild(0).GetComponent<Animator>().SetBool("isOpen", true);

        }
        else if (npcParentScript.npcInfoList[npcCode].storetype == StoreType.Skill) //스킬
        {
            storeCanvas[4].enabled = true;
            storeCanvas[4].GetComponent<StoreUI>().ItemCheck();
            storeCanvas[4].transform.GetChild(0).GetComponent<Animator>().SetBool("isOpen", true);

        }

    }

    public void EquipmentCanvasOpen() // 장비
    {
        storeCanvas[2].enabled = true;
        storeCanvas[2].GetComponent<StoreUI>().ItemCheck();
        storeCanvas[2].transform.GetChild(0).GetComponent<Animator>().SetBool("isOpen", true);
    }

    public void RepairCanvasOpen()  //수리
    {
        storeCanvas[3].enabled = true;
        storeCanvas[3].GetComponent<StoreUI>().ItemCheck();
        storeCanvas[3].transform.GetChild(0).GetComponent<Animator>().SetBool("isOpen", true);
    }

    public void StoreAvailableCheck(bool storeavailable)
    {
        storeButton.SetActive(storeavailable);

    }

    public IEnumerator TypeText(string TEXTString, Text label, bool check)
    {

        if (check == true)
        {
            textEnable = false;
            label.text = "";
            foreach (char letter in TEXTString.ToCharArray())
            {

                label.text += letter;
                yield return new WaitForSeconds(0.03f);
            }
        }

        yield return new WaitForSeconds(1.0f);
        textEnable = true;
        yield return null;
    }
}
