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

   
    public int[] useItemIndex = new int[] { 0, 0, 0 };

    public SpawnClass sc;
    public PlayerStatus ps;

    public List<Base_Weapon> list_weapon;
    public List<Armor_Amulet> list_amulet;
    public List<Armor_Stone> list_stone;
    //*****************************UI 변수들************************************
    public Image    itemImage;
    public Text     itemNameText;
    public Text     itemValueText1;
    public Text     itemValueText2;
    public Text     itemValueText3;
    public Text     itemValueText4;
    public Slider   itemSlider;
    public Text     itemDurability;


    public Image    nowitemImage;
    public Text     nowitemNameText;
    public Text     nowitemValueText1;
    public Text     nowitemValueText2;
    public Text     nowitemValueText3;
    public Text     nowitemValueText4;
    public Slider   nowitemSlider;
    public Text     nowitemDurability;
    public Text     nowitemdescription;

   // public Image nowUseItemImage;

    //**************************************************************************
    // Start is called before the first frame update
    void Awake()
    {
        ClosetSetting();
    }

    private void Start()
    {
        Invoke("ClosetBoardSetting", 0.3f);
       
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

        closetSlide1Script.GetComponent<ScrollRect>().enabled = true;
        closetSlide2Script.GetComponent<ScrollRect>().enabled = false;
        closetSlide3Script.GetComponent<ScrollRect>().enabled = false;
        closetSlide2Script.panel.GetComponent<Image>().raycastTarget = true;
        closetSlide3Script.panel.GetComponent<Image>().raycastTarget = true;
        closetSlide1Script.panel.GetComponent<Image>().raycastTarget = false;
    }

    void ClosetSlide2SizeSet()
    {
        AllClosetSlideSetFalse();

        closetSlide1Script.ClosetSlotClickReset();
        closetSlide3Script.ClosetSlotClickReset();

        closetSlide2Script.GetComponent<ScrollRect>().enabled = true;
        closetSlide1Script.GetComponent<ScrollRect>().enabled = false;
        closetSlide3Script.GetComponent<ScrollRect>().enabled = false;

        closetSlide1Script.panel.GetComponent<Image>().raycastTarget = true;
        closetSlide3Script.panel.GetComponent<Image>().raycastTarget = true;
        closetSlide2Script.panel.GetComponent<Image>().raycastTarget = false;
    }

    void ClosetSlide3SizeSet()
    {
        AllClosetSlideSetFalse();

        closetSlide1Script.ClosetSlotClickReset();
        closetSlide2Script.ClosetSlotClickReset();

        closetSlide3Script.GetComponent<ScrollRect>().enabled = true;
        closetSlide1Script.GetComponent<ScrollRect>().enabled = false;
        closetSlide2Script.GetComponent<ScrollRect>().enabled = false;

        closetSlide1Script.panel.GetComponent<Image>().raycastTarget = true;
        closetSlide2Script.panel.GetComponent<Image>().raycastTarget = true;
        closetSlide3Script.panel.GetComponent<Image>().raycastTarget = false;


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

    void ClosetSetting()
    {
        //여기 수정중
        //GameObject tmp = sc.LoadAll_Armor();

        //list_weapon.Add(tmp.GetComponent<Sword_Default>());
        //list_weapon.Add(tmp.GetComponent<Sword_HotTuna>());
        //list_weapon.Add(tmp.GetComponent<Sword_BBQStick>());
        //list_weapon.Add(tmp.GetComponent<Sword_Broad>());
        //list_weapon.Add(tmp.GetComponent<Sword_MoonLight>());

        //list_weapon.Add(tmp.GetComponent<Spear_Default>());
        //list_weapon.Add(tmp.GetComponent<Spear_IceNalchi>());
        //list_weapon.Add(tmp.GetComponent<Spear_Nyan>());
        //list_weapon.Add(tmp.GetComponent<Spear_DangPa>());
        //list_weapon.Add(tmp.GetComponent<Spear_PolarStar>());

        //list_weapon.Add(tmp.GetComponent<Bow_Default>());
        //list_weapon.Add(tmp.GetComponent<Bow_NoMoney>());
        //list_weapon.Add(tmp.GetComponent<Bow_Dryed>());
        //list_weapon.Add(tmp.GetComponent<Bow_Long>());
        //list_weapon.Add(tmp.GetComponent<Bow_Apollo>());

        GameObject tmp = sc.LoadAll_Armor();

        list_amulet.Add(tmp.GetComponent<Amulet_Default>());
        list_amulet.Add(tmp.GetComponent<Amulet_Richness>());
        list_amulet.Add(tmp.GetComponent<Amulet_Drain>());
        list_amulet.Add(tmp.GetComponent<Amulet_ImproveSkill>());
        list_amulet.Add(tmp.GetComponent<Amulet_PainPatch>());

        list_stone.Add(tmp.GetComponent<Stone_Default>());
        list_stone.Add(tmp.GetComponent<Stone_Magnetic>());
        list_stone.Add(tmp.GetComponent<Stone_Guardian>());
        list_stone.Add(tmp.GetComponent<Stone_Minor>());
        list_stone.Add(tmp.GetComponent<Stone_Major>());

        Debug.Log("list_amulet : " + list_amulet.Count);
        Debug.Log("list_stone : " + list_stone.Count);

        
    }


    public void ClosetBoardSetting()    // 선택된 장비
    {

        int index;
        if (lastClickSlot == 0)
        {
            index = closetSlide1Script.index;
        }
        else if (lastClickSlot == 1)
        {
            index = closetSlide2Script.index;
        }
        else
        {
            index = closetSlide3Script.index;
        }

        //선택된 장비 가져오기


        //리스트에서 현재 선택된 장비의 인덱스 찾아 저장해두고 UI 출력

        if (lastClickSlot == 0)
        {
            //for (int i = 0; i < list_weapon.Count; i++)
            //{
            //    if (list_weapon[i] == ps.weapon.GetComponent<Base_Weapon>())
            //    {
            //        useItemIndex[0] = i;
            //        Base_Weapon bw = list_weapon[i];
            //        closetSlide1Script.closetSlotImageArray = new RectTransform[list_weapon.Count];
            //        //itemImage.sprite =
            //        itemNameText.text = bw.m_title;
            //        itemValueText1.text = "공격력 : " + bw.power.ToString();
            //        //itemValueText2.text =
            //        //itemValueText3.text =
            //        //itemValueText4.text =
            //        itemSlider.value = bw.dualbility / 100.0f;
            //        itemDurability.text = bw.dualbility.ToString();
            //        itemdescription.text = bw.m_description;
            //          closetSlide1Script.closetSlotImageArray[index + 2].GetChild(1).GetComponent<Image>().enabled = true;
            //    }
            //}
        }
        else if (lastClickSlot == 1)
        {
            for (int i = 0; i < list_amulet.Count; i++)
            {
                //Debug.Log("착용 무기 : " + ps.armor.GetComponent<Armor_Amulet>().m_title);
                //Debug.Log("현재 인덱스 무기 : " + list_amulet[i].m_title);
                if (list_amulet[i].m_code == ps.armor.GetComponent<Armor_Amulet>().m_code)
                {
                    useItemIndex[1] = i;
                    
                    Base_Armor amulet = list_amulet[i];
                    //closetSlide1Script.closetSlotImageArray = new RectTransform[list_weapon.Count];
                    //itemImage.sprite =
                    itemNameText.text = amulet.m_title;
                    itemValueText1.text = amulet.value.ToString();
                    //itemValueText2.text =
                    //itemValueText3.text =
                    //itemValueText4.text =
                    itemSlider.value = amulet.dualbility / 100.0f;
                    itemDurability.text = amulet.dualbility.ToString();
                   
                    closetSlide2Script.closetSlotImageArray[i+2].GetChild(1).GetComponent<Image>().enabled = true;
                }
                nowitemNameText.text = list_amulet[index].m_title;
                nowitemValueText1.text = list_amulet[index].value.ToString();
                nowitemSlider.value = list_amulet[index].dualbility / 100.0f;
                nowitemDurability.text = list_amulet[index].dualbility.ToString();
                nowitemdescription.text = list_amulet[index].m_description;
            }
        }
        else 
        {
            for (int i = 0; i < list_stone.Count; i++)
            {
                if (list_stone[i].m_code == ps.armor.GetComponent<Armor_Stone>().m_code)
                {
                    useItemIndex[2] = i;
                    Base_Armor stone = list_stone[i];

                    //closetSlide1Script.closetSlotImageArray = new RectTransform[list_weapon.Count];
                    //itemImage.sprite =
                    itemNameText.text = stone.m_title;
                    nowitemValueText1.text = stone.value.ToString();
                    //itemValueText2.text =
                    //itemValueText3.text =
                    //itemValueText4.text =
                    itemSlider.value = stone.dualbility / 100.0f;
                    itemDurability.text = stone.dualbility.ToString();
                    
                    closetSlide3Script.closetSlotImageArray[i+2].GetChild(1).GetComponent<Image>().enabled = true;

                  
                }
            }
            nowitemNameText.text =     list_stone[index].m_title;
            nowitemValueText1.text =   list_stone[index].value.ToString();
            nowitemSlider.value =      list_stone[index].dualbility / 100.0f;
            nowitemDurability.text =   list_stone[index].dualbility.ToString();
            nowitemdescription.text =  list_stone[index].m_description;
        }


    }


    public void UnlockTest()
    {
        sc.UnlockCode(SpawnCode.A002);
        closetSlide2Script.ItemUnLock();
 
    }

    public void SlotItemClick(int index)
    {
        
        Debug.Log("itemChange");
        //*******************************장착 아이템 교체 코드*********************************************
        if (lastClickSlot == 0)
        {
            ps.changer.ChangeArmor(list_weapon[index].m_code, ps.gameObject, ps.weapon);
            closetSlide1Script.closetSlotImageArray[useItemIndex[0]].GetChild(1).GetComponent<Image>().enabled = false;
        }
        else if (lastClickSlot == 1)
        {
            ps.changer.ChangeArmor(list_amulet[index].m_code, ps.gameObject, ps.armor);
            Debug.Log(list_amulet[index].m_title);
            closetSlide1Script.closetSlotImageArray[useItemIndex[1]+2].GetChild(1).GetComponent<Image>().enabled = false;
        }
        else
        {
            ps.changer.ChangeArmor(list_stone[index].m_code, ps.gameObject, ps.armor);
            closetSlide1Script.closetSlotImageArray[useItemIndex[2]+2].GetChild(1).GetComponent<Image>().enabled = false;
        }
        //************************************************************************************************

        ClosetBoardSetting();
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

