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
    public SpriteSupplier spriteSupplier;

    void Start()
    {
       SkillUISetting();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //주석
    public void SkillUISetting()
    {
        //플레이어의 착용중인 장비 가져오기
        Skill_Red tmpr = ps.skill.GetComponent<Skill_Red>();
        SkillImage1.sprite = spriteSupplier.GetSource(tmpr.m_code);
        SkillText1.text = tmpr.m_title;

        Skill_Blue tmpb = ps.skill.GetComponent<Skill_Blue>();
        SkillImage2.sprite = spriteSupplier.GetSource(tmpb.m_code);
        SkillText2.text = tmpb.m_title;

        Skill_Green tmpg = ps.skill.GetComponent<Skill_Green>();
        SkillImage3.sprite = spriteSupplier.GetSource(tmpg.m_code);
        SkillText3.text = tmpg.m_title;
   
    }
}
