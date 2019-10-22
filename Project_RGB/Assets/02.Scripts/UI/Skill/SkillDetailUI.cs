using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillDetailUI : MonoBehaviour
{

    public int skillType;
    public GameObject[] skillImageArray;
    //public List<SkillList>();

    //*************************UI 변수*****************************
    public Image useSkillImage;
    public Text skillNameText;
    public Text cooldownText;
    public Text powerText;
    public Text valueText;
    public Text SkillDescriptionText;

    //*************************************************************
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


    }

    public void SkillSlotSetting()
    {

        if (skillType == 0) //Red
        {
            //List = 
        }

        else if (skillType == 0)
        {

        }

        //for (int i = 0; i < skillList.Count; i++)
        //{
        //    if (skillList[i].unlock == false)   //해금시 이미지 안보이게
        //        skillImageArray[i].transform.GetChild(0).GetComponent<Image>().enabled = false;
        //    if(skillList[i].Use == false)       //비장착시 이미지 안보이게
        //        skillImageArray[i].transform.GetChild(1).GetComponent<Image>().enabled = false;
        //}
    }



}
