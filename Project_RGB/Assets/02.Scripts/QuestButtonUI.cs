using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestButtonUI : MonoBehaviour
{

    public GameObject QuestUI;
    private QuestUI quest;
    public GameObject cancleButton;
    // Start is called before the first frame update
    void Start()
    {
        quest = QuestUI.GetComponent<QuestUI>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void QuestCompleteButtonClick()
    {
      
        quest.isProgressQuest = false;
        quest.progressQuestList.SetActive(false);
        quest.completeQuestList.SetActive(true);
        quest.QuestBoardCompleteSetting();
        cancleButton.SetActive(false);
    }

    public void QuestProgressButtonClick()
    {
        quest.isProgressQuest = true;
        quest.progressQuestList.SetActive(true);
        quest.completeQuestList.SetActive(false);
        quest.QuestBoardProgressSetting();
        cancleButton.SetActive(true);
    }

    public void QuestCancleButtonClick()
    {
        quest.QuestCancle(quest.clickQuestName);
    }
}
