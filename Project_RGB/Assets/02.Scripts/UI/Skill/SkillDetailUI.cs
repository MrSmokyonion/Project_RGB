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

    public Text SkillDescriptionText;

    //*************************************************************

    public SkillUI skillUIscript;
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
            cooldownText.text = "쿨타임 : " + tmp.m_delay.ToString();
            SkillDescriptionText.text = tmp.m_description;
            for (int i = 0; i < list_red.Count; i++)
            {
                if (sc.GetIsUnlocked(list_red[i].m_code) == false)
                {
                    skillImageArray[i].transform.GetChild(0).gameObject.SetActive(false);
                    skillImageArray[i].GetComponent<Button>().interactable = false;

                }
                if (list_red[i].m_code != tmp.m_code)
                {
                    skillImageArray[i].transform.GetChild(1).gameObject.SetActive(false);
                }
            }

        }

        else if (skillType == 1)//Green
        {
            //SkillList = RedSkillLIst
            //for(int i =0; i<skillImageArray.Length;i++)
            //skillImageArray[i].sprite = SkillList[i].Image;
            Skill_Green tmp = ps.skill.GetComponent<Skill_Green>();
            skillNameText.text = tmp.m_title;
            cooldownText.text = "쿨타임 : " + tmp.m_delay.ToString();
            SkillDescriptionText.text = tmp.m_description;

            for (int i = 0; i < list_green.Count; i++)
            {
                if (sc.GetIsUnlocked(list_green[i].m_code) == false)
                {
                    skillImageArray[i].transform.GetChild(0).gameObject.SetActive(false);
                    skillImageArray[i].GetComponent<Button>().interactable = false;

                }
                if (list_green[i].m_code != tmp.m_code)
                {
                    skillImageArray[i].transform.GetChild(1).gameObject.SetActive(false);
                }
            }
        }

        else
        {
            //SkillList = RedSkillLIst
            //for(int i =0; i<skillImageArray.Length;i++)
            //skillImageArray[i].sprite = SkillList[i].Image;

            Skill_Blue tmp = ps.skill.GetComponent<Skill_Blue>();
            skillNameText.text = tmp.m_title;
            cooldownText.text = "쿨타임 : " + tmp.m_delay.ToString();
            SkillDescriptionText.text = tmp.m_description;

            for (int i = 0; i < list_blue.Count; i++)
            {
                if (sc.GetIsUnlocked(list_blue[i].m_code) == false)
                {
                    skillImageArray[i].transform.GetChild(0).gameObject.SetActive(false);
                    skillImageArray[i].GetComponent<Button>().interactable = false;

                }
                if (list_blue[i].m_code != tmp.m_code)
                {
                    skillImageArray[i].transform.GetChild(1).gameObject.SetActive(false);
                }
            }
        }

        //for (int i = 0; i < skillList.Count; i++)
        //{
        //    if (skillList[i].unlock == false)   //해금시 이미지 안보이게
        //        skillImageArray[i].transform.GetChild(0).GetComponent<Image>().enabled = false;
        //    if(skillList[i].Use == false)       //비장착시 이미지 안보이게
        //        skillImageArray[i].transform.GetChild(1).GetComponent<Image>().enabled = false;
        //}
    }

    public void SlotSetting()
    {
        for (int i = 0; i < skillImageArray.Length; i++)
        {
            skillImageArray[i].transform.GetChild(0).gameObject.SetActive(true);
            skillImageArray[i].GetComponent<Button>().interactable = true;
            skillImageArray[i].transform.GetChild(1).gameObject.SetActive(true);
        }
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

        skillUIscript.ps.changer.ChangeSkill(tmp.m_code, ps.gameObject, ps.skill);
        ChangeSkillUI(tmp);
        skillUIscript.SkillUISetting();
    }

    public void ChangeSkillUI(Base_Skill tmp)
    {

        //useSkillImage.sprite = list_red[0].m_spritePath;
        skillNameText.text = tmp.m_title;
        cooldownText.text = tmp.m_delay.ToString();
        SkillDescriptionText.text = tmp.m_description;
        
    }

}
