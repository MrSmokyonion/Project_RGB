using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosetSlideButtonClickUI : MonoBehaviour
{
    public ClosetSlideSlotClick closetSlideSlotClick_Script;

    public void ClosetSlideButtonUpClick()
    {
        closetSlideSlotClick_Script.ClosetSlideButtonUpClick();

        Debug.Log("lastClickSlot = " + closetSlideSlotClick_Script.lastClickSlot);
    }

    public void ClosetSlideButtonDownClick()
    {
        closetSlideSlotClick_Script.ClosetSlideButtonDownClick();

        Debug.Log("lastClickSlot = " + closetSlideSlotClick_Script.lastClickSlot);
    }
}
    

