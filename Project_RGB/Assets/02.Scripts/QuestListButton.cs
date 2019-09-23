using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestListButton : MonoBehaviour
{
    public GameObject QuestUI;
    // Start is called before the first frame update
    void Start()
    {
        QuestUI = gameObject.transform.parent.gameObject.transform.parent.gameObject.transform.parent.gameObject;

        //QuestUI = GameObject.Find("QuestCanvas");
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ButtonClick()
    {
        QuestUI.GetComponent<QuestUI>().clickQuestName = gameObject.transform.GetChild(0).GetComponent<Text>().text;
        QuestUI.GetComponent<QuestUI>().QuestBoardClickChange(gameObject.transform.GetChild(0).GetComponent<Text>().text);
        // gameObject.GetComponent<Text>();
    }
}
