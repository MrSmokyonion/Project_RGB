using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClosetSlideSlotClick : MonoBehaviour
{
    public ClosetSlideUI closetSlide1Script;
    public ClosetSlideUI closetSlide2Script;
    public ClosetSlideUI closetSlide3Script;

    public int lastClickSlot = 0;
    public int clickItemIndex;
    //*****************************UI 변수들************************************
    public Image itemImage;
    public Text itemNameText;
    public Text itemValueText1;
    public Text itemValueText2;
    public Text itemValueText3;
    public Text itemValueText4;
    public Slider itemSlider;
    public Text itemDurability;
    public Text itemdescription;

    public Image useitemImage;
    public Text useitemNameText;
    public Text useitemValueText1;
    public Text useitemValueText2;
    public Text useitemValueText3;
    public Text useitemValueText4;
    public Slider useitemSlider;
    public Text useitemDurability;
    public Text useitemdescription;

    public Image nowUseItemImage;

    //**************************************************************************
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

    public void MyClosetBoardSetting()   //내가 입고있는 장비 성능확인창UI
    {
        //현재 클릭된 슬롯 확인
        if (lastClickSlot == 0)
        {
            //itemArray = Weapon
        }
        else if (lastClickSlot == 1)
        {
            //itemArray = Amulet
        }
        else
        {
            //itemArray = Rock
        }
        //플레이어에서 장착중인 장비 가져오기

        //useitemImage;
        //useitemNameText;
        //useitemValueText1;
        //useitemValueText2;
        //useitemValueText3;
        //useitemValueText4;
        //useitemSlider;
        //useitemDurability;
        //useitemdescription;
    }

    public void ClosetBoardSetting()    // 선택된 장비
    {
        int arrayColumn;
        if (lastClickSlot == 0)
        {
            arrayColumn = closetSlide1Script.index;  //선택 된 인덱스 >> 계산 후에 Column
        }
        else if (lastClickSlot == 1)
        {
            arrayColumn = closetSlide2Script.index;  //선택 된 인덱스 >> 계산 후에 Column
        }
        else
        {
            arrayColumn = closetSlide3Script.index;  //선택 된 인덱스 >> 계산 후에 Column
        }

        //    //플레이어에서 선택된 장비 가져오기
        //    //리스트에서 현재 선택된 장비의 인덱스 찾아 저장해두고 UI 출력

        //    int arrayRow = 0;
        //    if (thisSlotNumber == 0)
        //    {
        //        while (true)
        //        {
        //            if (arrayColumn >= Array.GetLength(arrayRow))
        //            {
        //                arrayColumn -= Array.GetLength(arrayRow);
        //            }
        //            else
        //            {
        //                break;
        //            }

        //            arrayRow++;
        //        }

        //        if (isSlotClick == true)
        //        {
        //            //closetSlotImageArray = new RectTransform[10];
        //            //itemImage.sprite = 
        //            //itemNameText.text = WeaponArray[thisSlotNumber][arrayColumn].itemNmae;
        //            //itemValueText1.text =
        //            //itemValueText2.text =
        //            //itemValueText3.text =
        //            //itemValueText4.text =
        //            //itemSlider.value =
        //            //itemDurability;
        //itemdescription;
        //        }
        //    }
        //    else
        //    {
        //        if (isSlotClick == true)
        //        {
        //            //closetSlotImageArray = new RectTransform[10];
        //            //itemImage.sprite = 
        //            //itemNameText.text = WeaponArray[thisSlotNumber][arrayColumn].itemNmae;
        //            //itemValueText1.text =
        //            //itemValueText2.text =
        //            //itemValueText3.text =
        //            //itemValueText4.text =
        //            //itemSlider.value =
        //useitemdescription;
        //        }
        //    }

    }

    public void SlotItemClick(int index)
    {
        clickItemIndex = index;
       //장착 아이템 교체

        //nowUseItem;
    }

    public void nowUseItem()    //현재 장착 장비 UI 기능
    {
        //for(int i = 0; itemList.Count;i++)
        //{
        //    if(itemList[i].nowUse == true)
        //    {
        //        closetSlotImageArray[i + 2].GetComponent<Image>().sprite = closetSlotImageArray[i + 2].GetChild(1).GetComponent<Image>().sprite;
        //    }
        //}
    }


}

