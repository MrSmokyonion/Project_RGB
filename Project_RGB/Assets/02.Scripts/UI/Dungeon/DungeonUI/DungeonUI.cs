using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DungeonUI : MonoBehaviour
{
    //*******************변수**********************
    public Quest questScript;
    public DungeonManager dungeonManager;
    public Capital capitalScript;
    public PlayerStatus playerStatusScript;
    public bool isFoodEat;
    //**********************************************
    //******************UI 변수*********************
    public Slider playerHPSlider;
    public Image playerPlusHPSlider;
    public Text goldText;
    public Image playerImage;
    public Text questText;
    public Slider progressSlider;
    //**********************************************
    // Start is called before the first frame update
    void Start()
    {

       
    }

    // Update is called once per frame
    void Update()
    {
        DungeonUiSetting();
    }

    public string GoldSetting()
    {
        //캐피탈에서 Gold 받아오기
        Debug.Log("capitalScript.money.ToString()");
        return capitalScript.money.ToString();
    }

    public void Questsetting()
    {
        ////Quest에서 해당 던전 quest 가져오기  
        //List<QuestInfo> dungeonQuestList = questScript.GetDungeonQuestList(dungeonManager.nowChapterNumber);

        //questText.text = null;

        //for (int i = 0; i < dungeonQuestList.Count; i++)
        //    questText.text += dungeonQuestList[i].summary + " : " + dungeonQuestList[i].questItemCur + Environment.NewLine;

    }
    public void HPSliderSetting()
    {
        if (isFoodEat == true)
        {
            playerHPSlider.fillRect.parent.GetComponent<RectTransform>().offsetMax = new Vector2(200,0); // 음식 증가값에 따른 조정 필요!
            playerPlusHPSlider.enabled = true;
          
        }
        else
        {
            playerHPSlider.fillRect.parent.GetComponent<RectTransform>().offsetMax = new Vector2(0, 0);
            playerPlusHPSlider.enabled = false;
            
            //playerHPSlider.value = playerStatusScript.curHp / playerStatusScript.maxHp;
        }

     
    }

    public void ProgressSliderSetting()
    {

    }
    public void DungeonUiSetting()
    {
        //playerHPSlider.value = 
        goldText.text = "Gold : " + GoldSetting();
        //playerImage.sprite = 
        Questsetting();
        HPSliderSetting();
        ProgressSliderSetting();
    }
}
