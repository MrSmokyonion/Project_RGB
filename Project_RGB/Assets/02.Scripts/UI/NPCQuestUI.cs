using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCQuestUI : MonoBehaviour
{
    public GameObject npcQuestDialogue;
    public GameObject npcQuestSlot;
    public GameObject npcQuestList;

    public int questNpcCode = 1;

    public Quest questScript;


    // Start is called before the first frame update
    void Start()
    {
        NpcQuestListSetting();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void NpcQuestListSetting()
    {
        for (int i = 0; i < questScript.playerQuestList.Count; i++)
        {
            if (questScript.playerQuestList[i].quest_state == QuestState.Able && questScript.playerQuestList[i].quest_npc_code == questNpcCode) // 맞는 퀘스트 코드의 NPC라면 해당 퀘스트 넣어줌.
            {
                GameObject slot = Instantiate(npcQuestSlot) as GameObject;
                slot.transform.SetParent(npcQuestList.transform.GetChild(0).transform, false);
                slot.transform.GetChild(0).GetComponent<Text>().text = questScript.playerQuestList[i].quest_name;

            }
        }
    }

    public void QuestListClick()
    {
        npcQuestDialogue.SetActive(true);
    }
}
