using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotButtonChoiceUI : MonoBehaviour     //슬롯에서 항목 선택시
{
    public int index;
    public bool isClick;
    public SkillDetailUI skilldetailScript;
    public RepairSlotUI repairScript;

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #region 스킬 세부사항
    public void SkillSlotImageClick()   //클릭시 장착중인 스킬 교체 및 UI 처리
    {
        //장비 쪽에 알리기
        //skilldetailScript.useSkillImage.sprite = skillList[index].Image;
    }
    #endregion

    #region 수리창
    public void SlotCheck() //수리할 목록 선택시
    {
        isClick = !isClick;
        if(isClick == true)
        repairScript.SlotClick(isClick, index);
    }


    #endregion
}
