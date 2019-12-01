using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillUI : MonoBehaviour
{
    public Image SkillImage1;
    public Text SkillText1;
    public Image SkillImage2;
    public Text SkillText2;
    public Image SkillImage3;
    public Text SkillText3;
    public PlayerStatus ps;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SkillUISetting()
    {
        //플레이어의 착용중인 장비 가져오기
        Skill_Red tmpr = ps.skill.GetComponent<Skill_Red>();
        //SkillImage1 = tmpr.m_path
        SkillText1.text = tmpr.m_title;

        Skill_Blue tmpb = ps.skill.GetComponent<Skill_Blue>();
        //SkillImage2 = tmpr.m_path
        SkillText2.text = tmpb.m_title;

        Skill_Green tmpg = ps.skill.GetComponent<Skill_Green>();
        //SkillImage3 = tmpr.m_path
        SkillText3.text = tmpg.m_title;
        //SkillImage1 = 어쩌고저쩌고.
    }
}
