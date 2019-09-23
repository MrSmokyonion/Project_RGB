using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosetSlideSlotClick : MonoBehaviour
{
    public ClosetSlideUI closetSlide1Script;
    public ClosetSlideUI closetSlide2Script;
    public ClosetSlideUI closetSlide3Script;

    public int lastClickSlot = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (closetSlide1Script.isSlotClick == true)
        {
            ClosetSlide1SizeSet();
            lastClickSlot = 0;
            Debug.Log("lastClickSlot : " + lastClickSlot);
        }

        if (closetSlide2Script.isSlotClick == true)
        {
            ClosetSlide2SizeSet();
            lastClickSlot = 1;
            Debug.Log("lastClickSlot : " + lastClickSlot);
        }

        if (closetSlide3Script.isSlotClick == true)
        {
            ClosetSlide3SizeSet();
            lastClickSlot = 2;
            Debug.Log("lastClickSlot : " + lastClickSlot);
        }

    }
    #region 옷장 슬롯 클릭시 커짐 & 초기화
    void ClosetSlide1SizeSet()
    {
        AllClosetSlideSetFalse();
        closetSlide2Script.ClosetSlotClickReset();
        closetSlide3Script.ClosetSlotClickReset();
    }

    void ClosetSlide2SizeSet()
    {
        AllClosetSlideSetFalse();

        closetSlide1Script.ClosetSlotClickReset();
        closetSlide3Script.ClosetSlotClickReset();
    }

    void ClosetSlide3SizeSet()
    {
        AllClosetSlideSetFalse();
        closetSlide1Script.ClosetSlotClickReset();
        closetSlide2Script.ClosetSlotClickReset();
    }

    void AllClosetSlideSetFalse()
    {
        closetSlide1Script.isSlotClick = false;
        closetSlide2Script.isSlotClick = false;
        closetSlide3Script.isSlotClick = false;
    }
    #endregion

    public void ClosetSlideButtonUpClick()
    {
        if (lastClickSlot == 0)
        {
            closetSlide3Script.ClosetSlotClick();
            ClosetSlide3SizeSet();
            lastClickSlot = 2;
        }
        else if (lastClickSlot == 1)
        {
            closetSlide1Script.ClosetSlotClick();
            ClosetSlide1SizeSet();
            lastClickSlot = 0;
        }
        else
        {
            closetSlide2Script.ClosetSlotClick();
            ClosetSlide2SizeSet();
            lastClickSlot = 1;
        }
    }

    public void ClosetSlideButtonDownClick()
    {
        if (lastClickSlot == 0)
        {
            closetSlide2Script.ClosetSlotClick();
            ClosetSlide2SizeSet();
            lastClickSlot = 1;
        }
        else if (lastClickSlot == 1)
        {
            closetSlide3Script.ClosetSlotClick();
            ClosetSlide3SizeSet();
            lastClickSlot = 2;
        }
        else
        {
            closetSlide1Script.ClosetSlotClick();
            ClosetSlide1SizeSet();
            lastClickSlot = 0;
        }



        //public void ClosetSlideButtonUpClick()
        //{
        //    AllClosetSlideSetFalse();

        //    if (lastClickSlot == 0)
        //    {

        //        closetSlide3Script.isSlotClick = true;
        //    }
        //    else if (lastClickSlot == 1)
        //    {
        //        closetSlide1Script.isSlotClick = true;
        //    }
        //    else
        //    {
        //        closetSlide2Script.isSlotClick = true;
        //    }
        //}

        //public void ClosetSlideButtonDownClick()
        //{
        //    AllClosetSlideSetFalse();

        //    if (lastClickSlot == 0)
        //    {
        //        closetSlide3Script.isSlotClick = true;
        //    }
        //    else if (lastClickSlot == 1)
        //    {
        //        closetSlide1Script.isSlotClick = true;
        //    }
        //    else
        //    {
        //        closetSlide2Script.isSlotClick = true;
        //    }
        //}

    }
}

