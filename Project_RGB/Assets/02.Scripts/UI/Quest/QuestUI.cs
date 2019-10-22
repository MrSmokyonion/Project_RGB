using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class QuestUI : MonoBehaviour
{
    public Quest questScript;
    public NPCQuestUI npcQuestUIScript;

    public Text questnameText;
    public Text questDescriptionText;
    public Text questSummary;
    public Image questNPCImage;
    public Image questItemImage;
    public Image questrewardsImage;
    private string choiceName;


    public List<QuestClear> questlist;

    public bool isProgressQuest = true;

    public GameObject questPListSlot;
    public GameObject questCListSlot;

    public GameObject progressQuestList;
    public GameObject completeQuestList;


    public string clickQuestName;

    public class QuestClear
    {
        public Text questName;
        public Text questSummary;
        public bool isClear;
        public GameObject questSlot;
        public Image questSuccessImage;


    }

    // Start is called before the first frame update
    void Start()
    {
        QuestCanvasSetting();
    }

    // Update is called once per frame
    void Update()
    {

    }




    #region Setting

    public void QuestCanvasSetting()
    {

        questlist = new List<QuestClear>();

        QuestPListCreate();
        QuestCListCreate();

        Debug.Log("questlist.Count : " + questlist.Count);
        int i = 0;
        for (i = 0; i < questScript.questAcessList.Count; i++) //태그로 오브젝트 찾아옴.
        {
            Debug.Log("questAcessList.i : " + i);
            Debug.Log(GameObject.FindGameObjectsWithTag("QuestPNameText").Length);
            questlist[i].questName = GameObject.FindGameObjectsWithTag("QuestPNameText")[i].GetComponent<Text>();
            questlist[i].questSummary = GameObject.FindGameObjectsWithTag("QuestPDescriptionText")[i].GetComponent<Text>();
            questlist[i].questSuccessImage = GameObject.FindGameObjectsWithTag("QuestSuccessImage")[i].GetComponent<Image>();
            questlist[i].questSuccessImage.enabled = false;
            questlist[i].isClear = false;

        }

        for (i = 0; i < questScript.questSuccessList.Count; i++) //태그로 오브젝트 찾아옴.
        {
            Debug.Log("SuccessList.i : " + (i + questScript.questAcessList.Count));
            Debug.Log(GameObject.FindGameObjectsWithTag("QuestCNameText").Length);
            questlist[i + questScript.questAcessList.Count].questName = GameObject.FindGameObjectsWithTag("QuestCNameText")[i].GetComponent<Text>();
            questlist[i + questScript.questAcessList.Count].questSummary = GameObject.FindGameObjectsWithTag("QuestCDescriptionText")[i].GetComponent<Text>();

            questlist[i + questScript.questAcessList.Count].isClear = true;

        }

        isProgressQuest = true;
        QuestBoardSetting();


        //처음엔 진행중인 퀘스트 목록 보여줌.

        completeQuestList.SetActive(false);
    }

    public void QuestBoardSetting()                  //UI Setting
    {
        //======================퀘스트 목록 ==============================
        int i = 0;

        for (i = 0; i < questScript.questAcessList.Count; i++)
        {
            questlist[i].questName.text = questScript.questAcessList[i].quest_name;
            questlist[i].questSummary.text = questScript.questAcessList[i].summary + "(" + questScript.questAcessList[i].questdetails + "/" + questScript.questAcessList[i].questcompletecount + ")";
            Debug.Log("questlist i :" + i + " " + questlist[i].questSlot.name);
            Debug.Log("questlist i :" + i + " " + questlist[i].questName.text);
            if (questScript.questAcessList[i].questdetails == questScript.questAcessList[i].questcompletecount)
            {
                questlist[i].questSuccessImage.enabled = true;
            }
        }

        for (i = 0; i < questScript.questSuccessList.Count; i++)
        {

            questlist[i + questScript.questAcessList.Count].questName.text = questScript.questSuccessList[i].quest_name;
            Debug.Log("questlist i :" + questlist[i + questScript.questAcessList.Count].questSlot.name);
            Debug.Log(questScript.questSuccessList[i].quest_name);

            questlist[i + questScript.questAcessList.Count].questSummary.text = questScript.questSuccessList[i].summary + "(" + questScript.questSuccessList[i].questdetails + "/" + questScript.questSuccessList[i].questcompletecount + ")";
            // Debug.Log("i + aceesslist count : " + (i + questScript.questAcessList.Count));
            // Debug.Log("slot name :" + (i + questScript.questAcessList.Count) + " " + questlist[i + questScript.questAcessList.Count].questSlot.name);
            // Debug.Log("quest name" + (i + questScript.questAcessList.Count) + " " + questlist[i + questScript.questAcessList.Count].questName.text);
        }

        Debug.Log(questlist[2].questName.text);
        //======================첫 번째 항목의 세부정보 ==============================
        if (i == 0)
        {
            questnameText.text = "퀘스트가 없습니다.";
            questDescriptionText.text = "퀘스트가 없습니다.";
            questSummary.text = "퀘스트가 없습니다.";
            return;
        }
        //questnameText.text = "퀘스트를 클릭해 주세요.";
        //questDescriptionText.text = "";
        //questSummary.text = "";

        if (isProgressQuest)
        {
            questnameText.text = questScript.questAcessList[0].quest_name;
            questDescriptionText.text = questScript.questAcessList[0].content;
            questSummary.text = questScript.questAcessList[0].summary + "(" + questScript.questAcessList[0].questdetails + "/" + questScript.questAcessList[0].questcompletecount + ")";
            clickQuestName = questnameText.text;
        }
        else
        {
            questnameText.text = questScript.questSuccessList[0].quest_name;
            questDescriptionText.text = questScript.questSuccessList[0].content;
            questSummary.text = questScript.questSuccessList[0].summary + "(" + questScript.questSuccessList[0].questdetails + "/" + questScript.questSuccessList[0].questcompletecount + ")";
            clickQuestName = questnameText.text;
        }

        //Debug.Log("isProgressQuest : " + isProgressQuest);

        //questNPCImage
        //questItemImage
        //questrewardsImage


    }

    public void QuestPListCreate()
    {

        for (int i = 0; i < questScript.questAcessList.Count; i++)
        {
            QuestClear q = new QuestClear();
            if (isProgressQuest)
            {
                GameObject slot = Instantiate(questPListSlot) as GameObject;
                slot.transform.SetParent(progressQuestList.transform.GetChild(0), false);
                slot.name = i.ToString();

                q.questSlot = slot;
                questlist.Add(q);

                Debug.Log("Pquestlist.slotname" + i + " : " + questlist[i].questSlot.name);
            }
        }
    }

    public void QuestCListCreate()
    {

        isProgressQuest = false;
        if (questScript.questSuccessList.Count > 3)
            completeQuestList.transform.GetChild(0).transform.GetComponent<RectTransform>().sizeDelta = new Vector2(800, questScript.questSuccessList.Count * 235);
        for (int i = 0; i < questScript.questSuccessList.Count; i++)
        {
            QuestClear q = new QuestClear();
            if (!isProgressQuest)
            {
                GameObject slot = Instantiate(questCListSlot) as GameObject;
                slot.transform.SetParent(completeQuestList.transform.GetChild(0), false);
                slot.name = (i + questScript.questAcessList.Count).ToString();
                //Debug.Log(slot.name);
                q.questSlot = slot;
                questlist.Add(q);

                Debug.Log("Cquestlist.slotname" + i + questScript.questAcessList.Count + " : " + questlist[i + questScript.questAcessList.Count].questSlot.name);

            }

        }

    }

    #endregion

    public void QuestBoardClickChange(string name)  //퀘스트 항목 선택시 세부정보 출력
    {//null일때 리턴
        Debug.Log(name);
        choiceName = name;

        QuestInfo choicequest = null;

        choicequest = questScript.FindNameToQuestCode(name);


        if (choicequest == null)
            return;

        //======================선택된 항목의 세부정보 ==============================
        questnameText.text = choicequest.quest_name;
        questDescriptionText.text = choicequest.content;
        questSummary.text = choicequest.summary + "(" + choicequest.questdetails + "/" + choicequest.questcompletecount + ")";
        //questNPCImage = choicequest.
        // questItemImage = choicequest.;
        //questrewardsImage;
    }



    public void QuestCancle(string name)
    {
        QuestInfo index = questScript.FindNameToQuestCode(name);
        if (index == null)
            return;
        questScript.RemoveQuest(index);
        Removequestlist(name);

    }

    public void Removequestlist(string name)    //questCancel시
    {
        int i = 0;
        foreach (QuestClear str in questlist)
        {
            if (questlist[i].questName.text == name)
            {
                Destroy(questlist[i].questSlot.gameObject);

                questlist.Remove(str);
                QuestBoardSetting();
                npcQuestUIScript.QuestClear();
                npcQuestUIScript.NpcQuestListSetting();
   
                return;
            }
            i++;
        }
    }

    public void RemovequestSlot()       //슬롯 삭제
    {
        for (int i = 0; i < questlist.Count; i++)
        {
            DestroyImmediate(questlist[i].questSlot.gameObject, true);
        }
        questlist.Clear();

    }
}

