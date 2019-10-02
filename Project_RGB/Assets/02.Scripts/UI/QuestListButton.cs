using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestListButton : MonoBehaviour
{
    public GameObject OpenUI;
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
    public void QuestButtonClick()
    {
        OpenUI.GetComponent<QuestUI>().clickQuestName = gameObject.transform.GetChild(0).GetComponent<Text>().text;
        OpenUI.GetComponent<QuestUI>().QuestBoardClickChange(gameObject.transform.GetChild(0).GetComponent<Text>().text);
        // gameObject.GetComponent<Text>();
    }

    public void NpcQuestButtonClick()
    {
       
        string ClickQuestName;
        ClickQuestName = gameObject.transform.GetChild(0).GetComponent<Text>().text;


        OpenUI.SetActive(true);
    }
}
