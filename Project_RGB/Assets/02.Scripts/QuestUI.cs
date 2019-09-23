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

    //public GameObject progressQuestList;
    //public GameObject completeQuestList;

    public string clickQuestName;

    public class Questclear
    {
        public Text questName;
        public Text questCDescription;
        public bool isClear;
        public GameObject questSlot;


    }


    // Start is called before the first frame update
    void Start()
    {

        questlist = new List<Questclear>();

        QuestPListCreate();
        QuestCListCreate();
        //  questPName = new Text[questScript.questProgressList.Count];
        //questPDescription = new Text[questScript.questProgressList.Count];
        Debug.Log(questlist.Count);

        for (int i = 0; i < questScript.questProgressList.Count; i++) //태그로 오브젝트 찾아옴.
        {
            questlist[i].questName = GameObject.FindGameObjectsWithTag("QuestPNameText")[i].GetComponent<Text>();
            questlist[i].questCDescription = GameObject.FindGameObjectsWithTag("QuestPDescriptionText")[i].GetComponent<Text>();
            questlist[i].isClear = false;




            /*       Questclear q = new Questclear();

                   q.questName = GameObject.FindGameObjectsWithTag("QuestPNameText")[i].GetComponent<Text>();
                   q.questCDescription = GameObject.FindGameObjectsWithTag("QuestPDescriptionText")[i].GetComponent<Text>();
                   q.isClear = false;

                   questlist.Add(q);*/
            /*
           
            Debug.Log("questPName : " + GameObject.FindGameObjectsWithTag("QuestPNameText")[i].GetComponent<Text>());
            questPName[i] = GameObject.FindGameObjectsWithTag("QuestPNameText")[i].GetComponent<Text>();
            questPDescription[i] = GameObject.FindGameObjectsWithTag("QuestPDescriptionText")[i].GetComponent<Text>();
            */
        }

        for (int i = 0; i < questScript.questCompleteList.Count; i++)
        {
            Questclear q = new Questclear();
            q.questName = GameObject.FindGameObjectsWithTag("QuestCNameText")[i].GetComponent<Text>();
            q.questCDescription = GameObject.FindGameObjectsWithTag("QuestCDescriptionText")[i].GetComponent<Text>();
            q.isClear = true;
            questlist.Add(q);


            /* questCName[i] = GameObject.FindGameObjectsWithTag("QuestCNameText")[i].GetComponent<Text>();
            questCDescription[i] = GameObject.FindGameObjectsWithTag("QuestCDescriptionText")[i].GetComponent<Text>();
            */
        }

        QuestBoardProgressSetting();

        QuestBoardCompleteSetting();

        //처음엔 진행중인 퀘스트 목록 보여줌.
        isProgressQuest = true;
        completeQuestList.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }


    #region Setting
    public void QuestBoardProgressSetting()// 진행중 버튼 클릭시
    {
        //======================퀘스트 목록 ==============================
        /*for (int i = 0; i < questScript.questProgressList.Count; i++)
        {
            questPName[i].text = questScript.questProgressList[i].quest_name;
            questPDescription[i].GetComponent<Text>().text = questScript.questProgressList[i].content;

        }*/
        int i = 0;
        foreach (Questclear q in questlist)
        {

            if (q.isClear == false)
            {

                q.questName.text = questScript.questProgressList[i].quest_name;
                q.questCDescription.text = questScript.questProgressList[i].content;

                i++;
            }

        }
        Debug.Log(" questlist[i].questName " + questlist[i].questName.text);
        //======================첫 번째 항목의 세부정보 ==============================
        questnameText.text = questScript.questProgressList[0].quest_name;
        questDescriptionText.text = questScript.questProgressList[0].content;
        questSummary.text = questScript.questProgressList[0].summary;
        //questNPCImage
        //questItemImage
        //questrewardsImage


    }

    public void QuestBoardCompleteSetting()// 완료 버튼 클릭시 
    {
        //======================퀘스트 목록 ==============================
        /* for (int i = 0; i < questScript.questCompleteList.Count; i++)
         {
             questCName[i].GetComponent<Text>().text = questScript.questCompleteList[i].quest_name;
             questCDescription[i].GetComponent<Text>().text = questScript.questCompleteList[i].content;
         }*/
        int i = 0;
        foreach (Questclear q in questlist)
        {
            if (q.isClear == true)
            {
                q.questName.text = questScript.questCompleteList[i].quest_name;
                q.questCDescription.text = questScript.questCompleteList[i].content;
                i++;
            }
        }

        //======================첫 번째 항목의 세부정보 ==============================
        questnameText.text = questScript.questCompleteList[0].quest_name;
        questDescriptionText.text = questScript.questCompleteList[0].content;
        questSummary.text = questScript.questCompleteList[0].summary;
        //questNPCImage
        //questItemImage
        //questrewardsImage
    }

    #endregion

    public void QuestBoardClickChange(string name)  //퀘스트 항목 선택시 세부정보 출력
    {//null일때 리턴
        Debug.Log(name);
        choiceName = name;

        QuestInfo choicequest;

        if (isProgressQuest)
        {
            choicequest = questScript.PFindNameToQuestCode(name);                                                 //진행중
        }
        else
        {
            choicequest = questScript.CFindNameToQuestCode(name);                                                 //완료
        }
        if (choicequest == null)
            return;

        //======================선택된 항목의 세부정보 ==============================
        questnameText.text = choicequest.quest_name;
        questDescriptionText.text = choicequest.content;
        questSummary.text = choicequest.summary;
        //questNPCImage = choicequest.
        // questItemImage = choicequest.;
        //questrewardsImage;
    }


    public void QuestPListCreate()
    {
        GameObject slot;

        for (int i = 0; i < questScript.questProgressList.Count; i++)
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
        completeQuestList.transform.GetChild(0).transform.GetComponent<RectTransform>().sizeDelta = new Vector2(0, questScript.questCompleteList.Count * 235);
        for (int i = 0; i < questScript.questCompleteList.Count; i++)
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
        QuestInfo index = questScript.PFindNameToQuestCode(name);
        if (index == null)
            return;
        questScript.questProgressList.Remove(index);
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
                return;
            }
            i++;
        }
    }
}
