using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RepairItemInfo
{
    public Image ItemImage;
    public Text goldText;
    public Text itemNameText;
}

public class RepairSlotUI : MonoBehaviour
{
    // public Item clickItem;
    public int slotNumber;

    //public RepairItemInfo[]RepairSlotArray; //아이템 배열


    public Image[] ItemImage;
    public Text[] goldText;
    public Text[] itemNameText;

    public RepairPanelUI repairPanelUIScript;
    //=============== UI 변수들 ======================
    public GameObject repairCheckPanel;
    public GameObject AllRepairCheckPanel;
    public GameObject RepairSlotlCheckPanel;

    public GameObject NoRepairItmeText;

    public Button SlotButton;


    //=================================================
    //플레이어 쪽에서 쿠폰 가져오기

    public List<Base_Weapon> list_repair_weapon;
    public List<Armor_Amulet> list_repair_amulet;
    public List<Armor_Stone> list_repair_stone;


    // Start is called before the first frame update
    void Start()
    {
        RepairSlotSetting(slotNumber);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void getslotNumber(int i)
    {
        slotNumber = i;
    }
    public void RepairSlotSetting(int slotNumber)
    {
        repairPanelUIScript.myGoldtext.text = repairPanelUIScript.capital.money.ToString();
        repairPanelUIScript.myCoupontext.text = repairPanelUIScript.capital.coupon.ToString();

        RectTransform rt = gameObject.transform.GetChild(0).GetComponent<RectTransform>();

        list_repair_weapon = repairPanelUIScript.list_weapon_R;

        list_repair_amulet = repairPanelUIScript.list_amulet_R;

        list_repair_stone = repairPanelUIScript.list_stone_R;

        if (slotNumber == 0)
        {
            //무기

            if (list_repair_weapon.Count == 0)
            {
                repairPanelUIScript.slot1.gameObject.SetActive(false);
                repairPanelUIScript.slot1.SlotButton.interactable = false;
                repairPanelUIScript.slot1.NoRepairItmeText.SetActive(true);

            }
            else
            {
                repairPanelUIScript.slot1.gameObject.SetActive(true);
                repairPanelUIScript.slot1.SlotButton.interactable = true;
                repairPanelUIScript.slot1.NoRepairItmeText.SetActive(false);

                rt.sizeDelta = new Vector2(list_repair_weapon.Count * 300 + list_repair_weapon.Count - 1 * 30, rt.rect.height);


                for (int i = 0; i < list_repair_weapon.Count; i++)
                {
                    //ItemImage[i].sprite = list_repair_weapon[i].m_spritePath;
                    goldText[i].text = RepairPrice(list_repair_weapon[i].m_price, list_repair_weapon[i].dualbility).ToString();
                    itemNameText[i].text = list_repair_weapon[i].m_title;
                }
            }
        }
        else if (slotNumber == 1)
        {
            //부적


            if (list_repair_amulet.Count == 0)
            {
                repairPanelUIScript.slot2.gameObject.SetActive(false);
                repairPanelUIScript.slot2.SlotButton.interactable = false;
                repairPanelUIScript.slot2.NoRepairItmeText.SetActive(true);
            }
            else
            {
                repairPanelUIScript.slot2.gameObject.SetActive(true);
                repairPanelUIScript.slot2.SlotButton.interactable = true;
                repairPanelUIScript.slot2.NoRepairItmeText.SetActive(false);

                rt.sizeDelta = new Vector2(list_repair_amulet.Count * 300 + list_repair_amulet.Count - 1 * 30, rt.rect.height);

                for (int i = 0; i < list_repair_amulet.Count; i++)
                {
                    //ItemImage[i].sprite = list_repair_amulet[i].m_spritePath;
                    goldText[i].text = RepairPrice(list_repair_amulet[i].m_price, list_repair_amulet[i].dualbility).ToString();
                    itemNameText[i].text = list_repair_amulet[i].m_title;
                }
            }
        }
        else
        {
            //돌

            if (list_repair_stone.Count == 0)
            {
                repairPanelUIScript.slot3.gameObject.SetActive(false);
                repairPanelUIScript.slot3.SlotButton.interactable = false;
                repairPanelUIScript.slot3.NoRepairItmeText.SetActive(true);
            }
            else
            {
                repairPanelUIScript.slot3.gameObject.SetActive(true);
                repairPanelUIScript.slot3.SlotButton.interactable = true;
                repairPanelUIScript.slot3.NoRepairItmeText.SetActive(false);

                rt.sizeDelta = new Vector2(list_repair_stone.Count * 300 + list_repair_stone.Count - 1 * 30, rt.rect.height);

                for (int i = 0; i < list_repair_stone.Count; i++)
                {
                    //ItemImage[i].sprite = list_repair_stone[i].m_spritePath;
                    goldText[i].text = RepairPrice(list_repair_stone[i].m_price, list_repair_stone[i].dualbility).ToString();
                    itemNameText[i].text = list_repair_stone[i].m_title;
                }
            }
        }



        //for (int i = 0; i < RepairSlotArray.Length; i++)
        //{
        //    //if(itemlist[i].Durability <100)
        //    // RepairSlotArray[i].sprite = itemlist[i].sprite;
        //    //RepairSlotArray[i].GetComponent<ButtonChoiceUI>().index = i;
        //}
    }


    public void DurabilityTest()
    {
        repairPanelUIScript.sc.UnlockCode(SpawnCode.W003);
        repairPanelUIScript.list_weapon[2].dualbility = 30;
        repairPanelUIScript.RepairListSetting();
        RepairSlotSetting(slotNumber);

    }

    public int RepairPrice(int itemPrice, int itemDualbility)
    {
        if (itemDualbility <= 0)
            return (int)(itemPrice * 1.5f);
        else
            return (itemPrice * (100 - itemDualbility) / 100);

    }



    public int SlotRepairPrice(int slotNumber)
    {
        int price = 0;
        switch (slotNumber)
        {
            case 0:
                if (list_repair_weapon.Count == 0)
                    return 0;
                for (int i = 0; i < list_repair_weapon.Count; i++)
                {
                    if (list_repair_weapon[i].dualbility <= 0)
                        price += (int)(list_repair_weapon[i].m_price * 1.5f);
                    else
                        price += (list_repair_weapon[i].m_price * (100 - list_repair_weapon[i].dualbility) / 100);
                }
                repairPanelUIScript.clickType = 0;
                break;

            case 1:
                if (list_repair_amulet.Count <= 0)
                    return 0;

                for (int i = 0; i < list_repair_amulet.Count; i++)
                {
                    if (list_repair_amulet[i].dualbility <= 0)
                        price += (int)(list_repair_amulet[i].m_price * 1.5f);
                    else
                        price += (list_repair_amulet[i].m_price * (100 - list_repair_amulet[i].dualbility) / 100);
                }
                repairPanelUIScript.clickType = 1;
                break;

            case 2:
                if (list_repair_stone.Count == 0)
                    return 0;

                for (int i = 0; i < list_repair_stone.Count; i++)
                {
                    if (list_repair_stone[i].dualbility <= 0)
                        price += (int)(list_repair_stone[i].m_price * 1.5f);
                    else
                        price += (list_repair_stone[i].m_price * (100 - list_repair_stone[i].dualbility) / 100);
                }
                repairPanelUIScript.clickType = 2;
                break;

        }

        return price;
    }





    public void SlotClick(int index)
    {
        // clickItem = ItemArray[index]
        RepairButtonClick(index);
    }

    public void RepairButtonClick(int index)    //단일 수리
    {
        //clickitem
        //수리 비용 계산
        //Ui띄우기

        if (slotNumber == 0)

        {
            repairPanelUIScript.buyGoldText.text = goldText[index].text;
            repairPanelUIScript.clickType = 0;
        }
        else if (slotNumber == 1)
        {
            repairPanelUIScript.buyGoldText.text = goldText[index].text;
            repairPanelUIScript.clickType = 1;
        }
        else
        {
            repairPanelUIScript.buyGoldText.text = goldText[index].text;
            repairPanelUIScript.clickType = 2;
        }
        repairCheckPanel.SetActive(true);
        repairPanelUIScript.clickItem = index;
        repairPanelUIScript.RepairPanelUISetting(index);




    }


    public void SlotRepairButtonClick()     //슬롯 수리
    {
        //repairPanelUIScript.buttonMyCouponText
        //     repairPanelUIScript.buttonMyGoldText
        //     repairPanelUIScript.buyGoldText
        repairPanelUIScript.buttonSMyCouponText.text = repairPanelUIScript.capital.coupon.ToString();
        repairPanelUIScript.buttonSMyGoldText.text = repairPanelUIScript.capital.money.ToString();

        Debug.Log("buttonSMyGoldText : " + repairPanelUIScript.buttonSMyGoldText.text);

        repairPanelUIScript.buySlotGoldText.text = (SlotRepairPrice(slotNumber)).ToString();


        if (repairPanelUIScript.clickType == 0)
        {
            repairPanelUIScript.SlotButtonEnableFalse(list_repair_weapon.Count);
        }
        else if (repairPanelUIScript.clickType == 1)
        {
            repairPanelUIScript.SlotButtonEnableFalse(list_repair_amulet.Count);
        }
        else
        {
            repairPanelUIScript.SlotButtonEnableFalse(list_repair_stone.Count);
        }

        RepairSlotlCheckPanel.SetActive(true);
    }

    public void AllRepairButtonClick()  //전체 수리
    {
        //전체 수리 비용 계산
        repairPanelUIScript.buttonAMyCouponText.text = repairPanelUIScript.capital.coupon.ToString();
        repairPanelUIScript.buttonAMyGoldText.text = repairPanelUIScript.capital.money.ToString();

        int AllRepairPrice = SlotRepairPrice(0) + SlotRepairPrice(1) + SlotRepairPrice(2);

        repairPanelUIScript.buyAllGoldText.text = AllRepairPrice.ToString();

        repairPanelUIScript.AllButtonEnableFalse(list_repair_weapon.Count + list_repair_amulet.Count + list_repair_stone.Count);

        //Ui띄우기
        AllRepairCheckPanel.SetActive(true);
    }

    public void CancelRepairAllButtonClick()
    {
        AllRepairCheckPanel.SetActive(false);
    }

    public void CancelRepairBUttonClick()
    {
        repairCheckPanel.SetActive(false);
    }

    public void CancelRepairSlotButtonClick()
    {
        RepairSlotlCheckPanel.SetActive(false);
    }

    public void BuyCouponButtonClick()
    {
        //해당 아이템의 내구도 교체 함수
        if (slotNumber == 0)
        {
            list_repair_weapon[repairPanelUIScript.clickItem].dualbility = 100;
        }
        else if (slotNumber == 1)
        {
            list_repair_amulet[repairPanelUIScript.clickItem].dualbility = 100;

        }
        else
        {
            list_repair_stone[repairPanelUIScript.clickItem].dualbility = 100;
        }

        //나의 쿠폰 개수 -1
        repairPanelUIScript.capital.MinusCoupon(1);

        repairPanelUIScript.RepairSetting();
        RepairSlotSetting(repairPanelUIScript.clickType);

        repairCheckPanel.SetActive(false);
    }

    public void BuyGoldButtonClick()
    {
        //해당 아이템의 내구도 교체 함수
        if (repairPanelUIScript.clickType == 0)
        {
            list_repair_weapon[repairPanelUIScript.clickItem].dualbility = 100;
        }
        else if (repairPanelUIScript.clickType == 1)
        {
            list_repair_amulet[repairPanelUIScript.clickItem].dualbility = 100;
        }
        else
        {
            list_repair_stone[repairPanelUIScript.clickItem].dualbility = 100;
        }

        //나의 골드 - 아이템 수리 비용
        repairPanelUIScript.capital.MinusMoney(int.Parse(repairPanelUIScript.buyGoldText.text));

        repairPanelUIScript.RepairSetting();
        RepairSlotSetting(repairPanelUIScript.clickType);

        repairCheckPanel.SetActive(false);
    }

    public void BuySlotCouponButtonClick()
    {
        //해당 아이템의 내구도 교체 함수
        if (repairPanelUIScript.clickType == 0)
        {
            for (int i = 0; i < list_repair_weapon.Count; i++)
                list_repair_weapon[i].dualbility = 100;
        }
        else if (repairPanelUIScript.clickType == 1)
        {
            for (int i = 0; i < list_repair_amulet.Count; i++)
                list_repair_amulet[i].dualbility = 100;
        }
        else
        {
            for (int i = 0; i < list_repair_stone.Count; i++)
                list_repair_stone[i].dualbility = 100;
        }

        //쿠폰 개수
        repairPanelUIScript.capital.MinusCoupon(list_repair_weapon.Count + list_repair_amulet.Count + list_repair_stone.Count);

        repairPanelUIScript.RepairSetting();
        RepairSlotSetting(repairPanelUIScript.clickType);

        RepairSlotlCheckPanel.SetActive(false);
    }

    public void BuySlotGoldButtonClick()
    {
        //해당 아이템의 내구도 교체 함수
        if (repairPanelUIScript.clickType == 0)
        {
            for (int i = 0; i < list_repair_weapon.Count; i++)
                list_repair_weapon[i].dualbility = 100;
        }
        else if (repairPanelUIScript.clickType == 1)
        {
            for (int i = 0; i < list_repair_amulet.Count; i++)
                list_repair_amulet[i].dualbility = 100;
        }
        else
        {
            for (int i = 0; i < list_repair_stone.Count; i++)
                list_repair_stone[i].dualbility = 100;
        }

        //나의 골드 - 아이템 수리 비용

        repairPanelUIScript.capital.MinusMoney(int.Parse(repairPanelUIScript.buySlotGoldText.text));

        repairPanelUIScript.RepairSetting();
        RepairSlotSetting(repairPanelUIScript.clickType);

        RepairSlotlCheckPanel.SetActive(false);
    }

    public void BuyAllCouponButtonClick()
    {
        //해당 아이템의 내구도 교체 함수

        for (int i = 0; i < list_repair_weapon.Count; i++)
            list_repair_weapon[i].dualbility = 100;

        for (int i = 0; i < list_repair_amulet.Count; i++)
            list_repair_amulet[i].dualbility = 100;


        for (int i = 0; i < list_repair_stone.Count; i++)
            list_repair_stone[i].dualbility = 100;


        //나의 쿠폰 개수 -1
        repairPanelUIScript.capital.MinusCoupon(list_repair_weapon.Count + list_repair_amulet.Count + list_repair_stone.Count);

        repairPanelUIScript.RepairSetting();
        RepairSlotSetting(repairPanelUIScript.clickType);

        AllRepairCheckPanel.SetActive(false);
    }

    public void BuyAllGoldButtonClick()
    {
        //해당 아이템의 내구도 교체 함수
        for (int i = 0; i < list_repair_weapon.Count; i++)
        {
            list_repair_weapon[i].dualbility = 100;

        }

        for (int i = 0; i < list_repair_amulet.Count; i++)
            list_repair_amulet[i].dualbility = 100;


        for (int i = 0; i < list_repair_stone.Count; i++)
            list_repair_stone[i].dualbility = 100;


        //나의 골드 - 아이템 수리 비용
        repairPanelUIScript.capital.MinusMoney(int.Parse(repairPanelUIScript.buyAllGoldText.text));

        repairPanelUIScript.RepairSetting();
        RepairSlotSetting(repairPanelUIScript.clickType);

        AllRepairCheckPanel.SetActive(false);
    }


}
