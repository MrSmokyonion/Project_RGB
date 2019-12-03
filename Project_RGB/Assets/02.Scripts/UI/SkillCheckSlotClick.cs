using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillCheckSlotClick : MonoBehaviour
{
    // Start is called before the first frame update
    public Canvas SkillDetailsCanvas;
    public int skillType;
    public void Skill_Check_Slot_Click()
    {
        SkillDetailsCanvas.GetComponent<SkillDetailUI>().SlotSetting();
        SkillDetailsCanvas.GetComponent<SkillDetailUI>().skillType = skillType;
        SkillDetailsCanvas.GetComponent<SkillDetailUI>().SkillSlotSetting();
        SkillDetailsCanvas.enabled = true;
        
    }
}
