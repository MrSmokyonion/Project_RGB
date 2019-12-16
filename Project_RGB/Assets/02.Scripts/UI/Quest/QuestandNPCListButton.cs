using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestandNPCListButton : MonoBehaviour
{
    public GameObject OpenUI;
    int nowindex;
    // Start is called before the first frame update
    void Start()
    {
        OpenUI = gameObject.transform.parent.gameObject.transform.parent.gameObject.transform.parent.gameObject;

        //QuestUI = GameObject.Find("QuestCanvas");
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void QuestButtonClick()  //퀘스트 리스트 클릭
    {
        OpenUI.GetComponent<QuestUI>().clickQuestName = gameObject.transform.GetChild(0).GetComponent<Text>().text;
        OpenUI.GetComponent<QuestUI>().QuestBoardClickChange(gameObject.transform.GetChild(0).GetComponent<Text>().text);
        // gameObject.GetComponent<Text>();
    }

    public void NpcQuestButtonClick()   //npc의 퀘스트 리스트 클릭
    {

        NPCQuestUI npcQuestUI = transform.parent.transform.parent.transform.parent.GetComponent<NPCQuestUI>();
        nowindex = int.Parse(gameObject.name.ToString());
        Debug.Log("clickindex : " + nowindex);
        npcQuestUI.NPCQuestBoardSetting(nowindex);
    }

    public void NpcQuestBoardAcceptButtonClick()    //npc의 퀘스트 수락버튼 클릭
    {
       transform.parent.parent.GetComponent<NPCQuestUI>().QuestAceeptButtonClick();
    

    }

    public void QuestCancleButtonClick()
    {
        transform.parent.parent.GetComponent<NPCQuestUI>().QuestCancleButtonClick();
    }

}
