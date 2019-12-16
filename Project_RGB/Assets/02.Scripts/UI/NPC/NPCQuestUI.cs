using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class NPCQuestUI : MonoBehaviour
{
    public Text npcQuestDialogue;
    public GameObject npcQuestSlot;
    public GameObject npcQuestList;
    public GameObject npcQuestBoard;

    public Image npcImage;
    public Text questName;
    public Text questDescription;
    public Text questSummary;
    public Image questRewardImage;


    public int questNpcCode;
    int clickslotindex;

    public Quest questScript;

    public List<QuestInfo> npcquestlist;
    public List<NpcQuestSlot> questslotlist;

    private IEnumerator coroutine;

    public class NpcQuestSlot
    {
        public Text questName;
        public GameObject questSlot;
    }


    void Start()
    {
        questslotlist = new List<NpcQuestSlot>();

        NpcQuestListSetting();

    }



    public void NpcQuestListSetting()   //해당 NPC 퀘스트 받아오기
    {
        //if(npcquestlist.Count!=0)
            
        questNpcCode = transform.parent.GetComponent<NPCMenuUI>().npcCode;
       
        npcquestlist = questScript.GetnpcQuestList(questNpcCode);


        for (int i = 0; i < npcquestlist.Count; i++)
        {
            NpcQuestSlot QuestSlot = new NpcQuestSlot();

            GameObject slot = Instantiate(npcQuestSlot) as GameObject;

            slot.name = i.ToString();
            slot.transform.SetParent(npcQuestList.transform.GetChild(0).transform, false);
            slot.transform.GetChild(0).GetComponent<Text>().text = npcquestlist[i].quest_name;  //퀘스트 이름

            QuestSlot.questSlot = slot;
            QuestSlot.questName = slot.transform.GetChild(0).GetComponent<Text>();

            questslotlist.Add(QuestSlot);
        }
        Debug.Log(questslotlist.Count);
    }


    public void NPCQuestBoardSetting(int index)
    {
        coroutine = TypeText(npcquestlist[index].script, npcQuestDialogue, true);
        StartCoroutine(coroutine);
        //npcQuestDialogue.text = npcquestlist[index].script;
        questName.text = npcquestlist[index].quest_name;
        
        questDescription.text = npcquestlist[index].content;
        questSummary.text = "퀘스트 요약 : " + npcquestlist[index].summary;

        //questRewardImage = npcquestlist[index].quest_rewardImage;
        //npcImage = npcquestlist[index].npcImage;
        clickslotindex = index;
        npcQuestBoard.SetActive(true);
    }


    public void QuestAceeptButtonClick()        //npc에서 퀘스트 수락 버튼
    {
        questScript.AddQuest(npcquestlist[clickslotindex]);


        for (int i = 0; i < questslotlist.Count; i++)
            Destroy(questslotlist[i].questSlot);

        npcquestlist.Clear();
        questslotlist.Clear();

        questScript.GetComponent<QuestUI>().completeQuestList.SetActive(true);
        questScript.GetComponent<QuestUI>().progressQuestList.SetActive(true);
        questScript.GetComponent<QuestUI>().RemovequestSlot();

        NpcQuestListSetting();

        questScript.GetComponent<QuestUI>().QuestCanvasSetting();

        npcQuestBoard.SetActive(false);
    }

    public void QuestCancleButtonClick()
    {
        //NpcQuestListSetting();
        npcQuestBoard.SetActive(false);
    }

    public void QuestClear()
    {
        for (int i = 0; i < questslotlist.Count; i++)
            Destroy(questslotlist[i].questSlot);
        npcquestlist.Clear();
        
    }

    public void ScriptBackgroundClick()
    {
        StopCoroutine(coroutine);
        npcQuestDialogue.text = npcquestlist[clickslotindex].script;
    }

    public void QuestCompeleteScript(int index)
    {
        npcQuestDialogue.text = npcquestlist[index].complete_script;
        questScript.SuccessquestComplete(questNpcCode);
    }

    public IEnumerator TypeText(string TEXTString, Text label, bool check)
    {

        if (check == true)
        {
            label.text = "";
            foreach (char letter in TEXTString.ToCharArray())
            {

                label.text += letter;
                yield return new WaitForSeconds(0.03f);
            }
        }
       
        yield return new WaitForSeconds(1.0f);
      
         yield return null;
    }
}
