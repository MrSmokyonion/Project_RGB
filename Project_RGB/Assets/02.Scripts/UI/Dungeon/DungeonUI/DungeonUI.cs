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
    public PlayerStatus ps;
    public bool isFoodEat;
    public bool isQuestOpen = true;
    //**********************************************
    //******************UI 변수*********************
    public Slider playerHPSlider;
    public Image playerPlusHPImage;
    public Image playerHPImage;
    public Text goldText;
    public Text questText;
    public Slider progressSlider;
    public Sprite questCloseSprite;
    public Sprite questOpenSprite;
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
        //Debug.Log("capitalScript.money.ToString()");
        return capitalScript.money.ToString();
    }

    public void Questsetting()
    {
        //Quest에서 해당 던전 quest 가져오기  
        List<QuestInfo> dungeonQuestList = questScript.GetDungeonQuestList(dungeonManager.nowChapterNumber);

        questText.text = null;

        for (int i = 0; i < dungeonQuestList.Count; i++)
            questText.text += dungeonQuestList[i].summary + " : " + dungeonQuestList[i].questItemCur + Environment.NewLine;

    }
    public void HPSliderSetting()
    {
        int bonusHP = FoodCheck();
        if (bonusHP != 0)
        {
            isFoodEat = true;
            playerHPSlider.fillRect.parent.GetComponent<RectTransform>().offsetMax = new Vector2(200 + (200 / bonusHP), 0); // 음식 증가값에 따른 조정 필요!
            playerHPSlider.maxValue = ps.maxHp + bonusHP;
            playerHPImage.enabled = true;
            playerPlusHPImage.enabled = false;


        }
        else
        {
            isFoodEat = false;
            playerHPSlider.fillRect.parent.GetComponent<RectTransform>().offsetMax = new Vector2(0, 0);
            playerHPSlider.maxValue = ps.maxHp;
            playerPlusHPImage.enabled = true;
            playerHPImage.enabled = false;
            
            playerHPSlider.value = ps.maxHp - ps.curHp;
        }


    }

    public int FoodCheck()
    {
        BaseFood food = ps.food.GetComponent<BaseFood>();
        if (food == null)
            return 0;
        else
            return food.m_foodBonusHp;

    }

    public void ProgressSliderSetting(int nowStageNumber, int maxStageNumber)
    {
        progressSlider.value = nowStageNumber / maxStageNumber;
    }

    public void DungeonUiSetting()
    {
        //playerHPSlider.value = 
        goldText.text = "Gold : " + GoldSetting();
        //playerImage.sprite = 
        Questsetting();
        HPSliderSetting();
    }

    public void QuestTextOpen()
    {
        isQuestOpen = !isQuestOpen;

        if (isQuestOpen == true)
        {
            questText.transform.GetChild(0).GetComponent<Image>().sprite = questOpenSprite;
        }
        else
        {
            questText.transform.GetChild(0).GetComponent<Image>().sprite = questCloseSprite;
        }

        questText.GetComponent<Animator>().SetBool("isOpen", isQuestOpen);
    }
}
