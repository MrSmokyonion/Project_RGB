using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillDetailUI : MonoBehaviour
{

    public int skillType;
    //public int clickIndex; //슬롯 선택 Index
    public Image[] skillImageArray;

    [Space(10)]
    public GameObject skill;
    public List<Skill_Red> list_red;
    public List<Skill_Green> list_green;
    public List<Skill_Blue> list_blue;

    [Space(10)]
    public SpawnClass sc;
    public PlayerStatus ps;
    //*************************UI 변수*****************************
    [Header("UI Variables")]
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
        skill = sc.LoadAll_Skill();

        list_red.Add(skill.GetComponent<Skill_Red_PiercingSpear>());
        list_red.Add(skill.GetComponent<Skill_Red_ArrowRain>());
        list_red.Add(skill.GetComponent<Skill_Red_SwordTrap>());
        list_red.Add(skill.GetComponent<Skill_Red_Turret>());
        list_red.Add(skill.GetComponent<Skill_Red_PowerBuff>());

        list_green.Add(skill.GetComponent<Skill_Green_HighJump>());
        list_green.Add(skill.GetComponent<Skill_Green_Dash>());
        list_green.Add(skill.GetComponent<Skill_Green_BackStep>());
        list_green.Add(skill.GetComponent<Skill_Green_Charger>());
        list_green.Add(skill.GetComponent<Skill_Green_MoveBuff>());

        list_blue.Add(skill.GetComponent<Skill_Blue_Barrier>());
        list_blue.Add(skill.GetComponent<Skill_Blue_Wall>());
        list_blue.Add(skill.GetComponent<Skill_Blue_Shield>());
        list_blue.Add(skill.GetComponent<Skill_Blue_Invisible>());
        list_blue.Add(skill.GetComponent<Skill_Blue_DefenceBuff>());

    }


    public void SkillSlotSetting()
    {
        if (skillType == 0) //Red
        {
            // for (int i = 0; i < list_red.Count; i++)
            //skillImageArray[i].sprite = list_red[i].m_spritePath;
            Skill_Red tmp = ps.skill.GetComponent<Skill_Red>();
            skillNameText.text = tmp.m_title;
            cooldownText.text = tmp.m_delay.ToString();
            powerText.text = tmp.m_value1.ToString();
            valueText.text = tmp.m_value2.ToString();
            SkillDescriptionText.text = tmp.m_description;
        }

        else if (skillType == 1)//Green
        {
            //SkillList = RedSkillLIst
            //for(int i =0; i<skillImageArray.Length;i++)
            //skillImageArray[i].sprite = SkillList[i].Image;
            Skill_Green tmp = ps.skill.GetComponent<Skill_Green>();
            skillNameText.text = tmp.m_title;
            cooldownText.text = tmp.m_delay.ToString();
            powerText.text = tmp.m_value1.ToString();
            valueText.text = tmp.m_value2.ToString();
            SkillDescriptionText.text = tmp.m_description;
        }

        else
        {
            //SkillList = RedSkillLIst
            //for(int i =0; i<skillImageArray.Length;i++)
            //skillImageArray[i].sprite = SkillList[i].Image;

            Skill_Blue tmp = ps.skill.GetComponent<Skill_Blue>();
            skillNameText.text = tmp.m_title;
            cooldownText.text = tmp.m_delay.ToString();
            powerText.text = tmp.m_value1.ToString();
            valueText.text = tmp.m_value2.ToString();
            SkillDescriptionText.text = tmp.m_description;
        }

        //for (int i = 0; i < skillList.Count; i++)
        //{
        //    if (skillList[i].unlock == false)   //해금시 이미지 안보이게
        //        skillImageArray[i].transform.GetChild(0).GetComponent<Image>().enabled = false;
        //    if(skillList[i].Use == false)       //비장착시 이미지 안보이게
        //        skillImageArray[i].transform.GetChild(1).GetComponent<Image>().enabled = false;
        //}
    }

    public void ChangeSkill(int index)
    {
        Base_Skill tmp;

        if (skillType == 0)
            tmp = list_red[index];

        else if (skillType == 1)
            tmp = list_green[index];

        else
            tmp = list_blue[index];

        ChangeSkillUI(tmp);
    }

    public void ChangeSkillUI(Base_Skill tmp)
    {

        //useSkillImage.sprite = list_red[0].m_spritePath;
        skillNameText.text = tmp.m_title;
        cooldownText.text = tmp.m_delay.ToString();
        powerText.text = tmp.m_value1.ToString();
        valueText.text = tmp.m_value2.ToString();
        SkillDescriptionText.text = tmp.m_description;
    }

}
