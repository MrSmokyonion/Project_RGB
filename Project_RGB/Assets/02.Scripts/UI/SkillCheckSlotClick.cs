using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillCheckSlotClick : MonoBehaviour
{
    // Start is called before the first frame update
    public Canvas SkillDetailsCanvas;

    public void Skill_Check_Slot_Click()
    {
        SkillDetailsCanvas.enabled = true;
    }
}
