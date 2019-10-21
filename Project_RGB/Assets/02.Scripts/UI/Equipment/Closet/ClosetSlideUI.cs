using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClosetSlideUI : MonoBehaviour
{
    public RectTransform[] closetSlotImageArray;
    // public List<item> itemList;


    //public Image rockImage;
    public Scrollbar scrollbar;

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

    public bool isSlotClick = false;
    public int index;
    public int[] useEquipment = new int[3];
    public int sortNumber;
    public int thisSlotNumber;
    public int count;
    private void Start()
    {
        if (thisSlotNumber == 0)
        {
            //itemList = Weapon
        }
        else if (thisSlotNumber == 1)
        {
            //itemList =  Amulet
        }
        else
        {
            //itemList = Stone
        }

    }

    private void Update()
    {
        index = (int)(scrollbar.value / 0.19f);
        closetSlotImageArray[index + 2].sizeDelta = Vector2.Lerp(closetSlotImageArray[index + 2].sizeDelta, new Vector2(200.0f, 200.0f), 0.2f); // 스크롤 바의 value 값에 따라 해당 이미지를 키움.
        closetSlotImageArray[index + 2].transform.GetChild(0).GetComponent<RectTransform>().sizeDelta = Vector2.Lerp(closetSlotImageArray[index + 2].transform.GetChild(0).GetComponent<RectTransform>().sizeDelta, new Vector2(200.0f, 200.0f), 0.2f); // 스크롤 바의 value 값에 따라 해당 이미지를 키움.
        closetSlotImageArray[index + 2].transform.GetChild(1).GetComponent<RectTransform>().sizeDelta = Vector2.Lerp(closetSlotImageArray[index + 2].transform.GetChild(1).GetComponent<RectTransform>().sizeDelta, new Vector2(200.0f, 200.0f), 0.2f); // 스크롤 바의 value 값에 따라 해당 이미지를 키움.
    }

    public void ClosetSlotSetting()
    {
        if (sortNumber == 0)    //내구도 순 등등등
        {
            //itemArray[]
        }

        else if (sortNumber == 1)
        {
            //itemList.Sort
        }

        else if (sortNumber == 2)
        {
            //itemList.Sort
        }
    }

    public void MyClosetBoardSetting()   //내가 입고있는 장비 성능확인창UI
    {
        //현재 클릭된 슬롯 확인
        if (thisSlotNumber == 0)
        {
            //itemArray = Weapon
        }
        else if (thisSlotNumber == 1)
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

    //public void ClosetBoardSetting()    // 선택된 장비
    //{
    //    int arrayColumn = index;  //선택 된 인덱스 >> 계산 후에 Column
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

    //}

    public void ClosetSlotImageSizeReset()//커진 이미지를 원상태로
    {

        for (int i = 0; i < closetSlotImageArray.Length; i++)
        {
            if (closetSlotImageArray[i] != closetSlotImageArray[index + 2])
            {
                closetSlotImageArray[i].sizeDelta = new Vector3(150.0f, 150.0f, 1.0f);
                closetSlotImageArray[i].GetChild(0).GetComponent<RectTransform>().sizeDelta = new Vector3(150.0f, 150.0f, 1.0f);
                closetSlotImageArray[i].GetChild(1).GetComponent<RectTransform>().sizeDelta = new Vector3(150.0f, 150.0f, 1.0f);
                count = 0;
            }

        }

        //for (int i = 0; i < closetSlotImageArray.Length; i++)
        //{
        //    closetSlotImageArray[i].sizeDelta = new Vector3(150.0f, 150.0f, 1.0f);
        //}

    }


    public void ClosetSlotClick()   //리스트 클릭시 커지게, 2번 클릭시 해당 인덱스 장비 착용.
    {
        isSlotClick = true;
        count++;
        if (count >= 2)
        {
            //현재 착용 장비를 해당 인덱스의 장비로 바꾸기
            //Player쪽 ChangeWeapon
            //nowUseItem();
        }
        StartCoroutine("ClosetSlotClick_Corutine");
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

    public void ItemUnLock()    //해금된 아이템 이미지 안보이게
    {
        //for(int i = 0; i = closetSlotImageArray.Length;i++)
        //{
        //    if(itemList[i].unlock == true)
        //    {
        //        closetSlotImageArray[i].GetChild(0).GetComponent<Image>().enabled = false;
        //    }
        //}
    }


    public void ClosetSlotClickReset()
    {
        isSlotClick = false;
        StartCoroutine("ClosetSlotClickReset_Corutine");

    }



    IEnumerator ClosetSlotClick_Corutine()
    {
        while (gameObject.GetComponent<RectTransform>().localScale.x <= 2.2f)
        {
            gameObject.GetComponent<RectTransform>().localScale = Vector2.Lerp(gameObject.GetComponent<RectTransform>().localScale, new Vector2(2.3f, 2.3f), 0.2f);

            yield return new WaitForSeconds(0.01f);


        }

        Debug.Log("Courutine1");
        yield return null;
    }

    IEnumerator ClosetSlotClickReset_Corutine()
    {
        while (gameObject.GetComponent<RectTransform>().localScale.x >= 1.6f)
        {
            gameObject.GetComponent<RectTransform>().localScale = Vector2.Lerp(gameObject.GetComponent<RectTransform>().localScale, new Vector2(1.5f, 1.5f), 0.2f);
            Debug.Log("Scale : " + gameObject.GetComponent<RectTransform>().localScale);
            yield return new WaitForSeconds(0.01f);

        }
        Debug.Log("Courutine2");
        yield return null;
    }

}









