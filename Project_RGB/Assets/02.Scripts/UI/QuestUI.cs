using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class QuestUI : MonoBehaviour
{
    public Quest questScript;

    public Text questnameText;
    public Text questDescriptionText;
    public Text questSummary;
    public Image questNPCImage;
    public Image questItemImage;
    public Image questrewardsImage;
    private string choiceName;


    public List<Questclear> questlist;

    public bool isProgressQuest = true;

    public GameObject questPListSlot;
    public GameObject questCListSlot;

    public GameObject progressQuestList;
    public GameObject completeQuestList;


    public string clickQuestName;

    public class Questclear
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

        questlist = new List<Questclear>();

        QuestPListCreate();
        QuestCListCreate();

        int i = 0;
        for (i = 0; i < questScript.questAcessList.Count; i++) //태그로 오브젝트 찾아옴.
        {
            questlist[i].questName = GameObject.FindGameObjectsWithTag("QuestPNameText")[i].GetComponent<Text>();
            questlist[i].questSummary = GameObject.FindGameObjectsWithTag("QuestPDescriptionText")[i].GetComponent<Text>();
            questlist[i].questSuccessImage = GameObject.FindGameObjectsWithTag("QuestSuccessImage")[i].GetComponent<Image>();
            questlist[i].questSuccessImage.enabled = false;
            questlist[i].isClear = false;

        }

        for (i = 0; i < questScript.questSuccessList.Count; i++)
        {
            Questclear q = new Questclear();
            q.questName = GameObject.FindGameObjectsWithTag("QuestCNameText")[i].GetComponent<Text>();
            q.questSummary = GameObject.FindGameObjectsWithTag("QuestCDescriptionText")[i].GetComponent<Text>();
            q.isClear = true;
            questlist.Add(q);

        }

        Debug.Log("questlist.Count : " + questlist.Count);
        isProgressQuest = true;
        QuestSetting();


        //처음엔 진행중인 퀘스트 목록 보여줌.

        completeQuestList.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }


    #region Setting
    public void QuestSetting()// 진행중 버튼 클릭시
    {
        //======================퀘스트 목록 ==============================
        /*for (int i = 0; i < questScript.questProgressList.Count; i++)
        {
            questPName[i].text = questScript.questProgressList[i].quest_name;
            questPDescription[i].GetComponent<Text>().text = questScript.questProgressList[i].content;

        }*/
        int i = 0;
        for (i = 0; i < questScript.questAcessList.Count; i++)
        {
            questlist[i].questName.text = questScript.questAcessList[i].quest_name;
            questlist[i].questSummary.text = questScript.questAcessList[i].summary + "(" + questScript.questAcessList[i].questdetails + "/" + questScript.questAcessList[i].questcompletecount + ")";
            if (questScript.questAcessList[i].questdetails == questScript.questAcessList[i].questcompletecount)
            {
                Debug.Log("questlist[i].questSuccessImage.enabled : " + questlist[i].questSuccessImage.enabled);
                questlist[i].questSuccessImage.enabled = true;
            }
        }

        for (i = 0; i < questScript.questSuccessList.Count; i++)
        {
            questlist[i + questScript.questSuccessList.Count].questName.text = questScript.questSuccessList[i].quest_name;
            questlist[i + questScript.questSuccessList.Count].questSummary.text = questScript.questSuccessList[i].summary + "(" + questScript.questSuccessList[i].questdetails + "/" + questScript.questSuccessList[i].questcompletecount + ")";
        }

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

        Debug.Log("isProgressQuest : " + isProgressQuest);

        //questNPCImage
        //questItemImage
        //questrewardsImage


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


    public void QuestPListCreate()
    {
        GameObject slot;

        for (int i = 0; i < questScript.questAcessList.Count; i++)
        {
            Questclear q = new Questclear();
            if (isProgressQuest)
            {
                slot = Instantiate(questPListSlot) as GameObject;
                slot.transform.SetParent(progressQuestList.transform.GetChild(0), false);
                slot.name = i.ToString();
                q.questSlot = slot;
                questlist.Add(q);
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
            GameObject slot = Instantiate(questCListSlot) as GameObject;

            if (!isProgressQuest)
            {
                slot.transform.SetParent(completeQuestList.transform.GetChild(0), false);

            }

        }
    }

    public void QuestCancle(string name)
    {
        QuestInfo index = questScript.FindNameToQuestCode(name);
        if (index == null)
            return;
        questScript.playerQuestList.Remove(index);
        Removequestlist(name);

    }

    public void Removequestlist(string name)
    {
        int i = 0;
        foreach (Questclear str in questlist)
        {
            if (questlist[i].questName.text == name)
            {
                Destroy(questlist[i].questSlot.gameObject);
                questlist.Remove(str);
                QuestSetting();
                return;
            }
            i++;
        }
    }
}
