using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RepairPanelUI : MonoBehaviour
{
    public Capital capital;

    public Text myGoldtext;
    public Text myCoupontext;

    public Text buyGoldText;
    public Text buyAllGoldText;
    public Text buySlotGoldText;
    public Text buttonMyGoldText;
    public Text buttonMyCouponText;

    public Text buttonAMyGoldText;
    public Text buttonAMyCouponText;

    public Text buttonSMyGoldText;
    public Text buttonSMyCouponText;

    public Button couponButton;
    public Button goldButton;


    public List<Base_Weapon> list_weapon;
    public List<Armor_Amulet> list_amulet;
    public List<Armor_Stone> list_stone;

    public RepairSlotUI slot1;
    public RepairSlotUI slot2;
    public RepairSlotUI slot3;

    public List<Base_Weapon> list_weapon_R;
    public List<Armor_Amulet> list_amulet_R;
    public List<Armor_Stone> list_stone_R;

    public int clickItem =0;
    public int clickType = 0;

    public SpawnClass sc;
    public PlayerStatus ps;
    public RepairSlotUI repairSlotUIScript;

    // Start is called before the first frame update
    void Start()
    {
        RepairItemSetting();
        RepairListSetting();
    }
    void RepairItemSetting()
    {
        //여기 수정중
        GameObject tmp = sc.LoadAll_Weapon();

        list_weapon.Add(tmp.GetComponent<Sword_Default>());
        list_weapon.Add(tmp.GetComponent<Sword_HotTuna>());
        list_weapon.Add(tmp.GetComponent<Sword_BBQStick>());
        list_weapon.Add(tmp.GetComponent<Sword_Broad>());
        list_weapon.Add(tmp.GetComponent<Sword_MoonLight>());

        list_weapon.Add(tmp.GetComponent<Spear_Default>());
        list_weapon.Add(tmp.GetComponent<Spear_IceNalchi>());
        list_weapon.Add(tmp.GetComponent<Spear_Nyan>());
        list_weapon.Add(tmp.GetComponent<Spear_DangPa>());
        list_weapon.Add(tmp.GetComponent<Spear_PolarStar>());

        list_weapon.Add(tmp.GetComponent<Bow_Default>());
        list_weapon.Add(tmp.GetComponent<Bow_NoMoney>());
        list_weapon.Add(tmp.GetComponent<Bow_Dryed>());
        list_weapon.Add(tmp.GetComponent<Bow_Long>());
        list_weapon.Add(tmp.GetComponent<Bow_Apollo>());

        tmp = sc.LoadAll_Armor();

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

    }

    public void RepairListSetting()
    {

        for (int i = 0; i < list_weapon.Count; i++)
        {
            if (sc.GetIsUnlocked(list_weapon[i].m_code) && list_weapon[i].dualbility < 100)
            {
                list_weapon_R.Add(list_weapon[i]);
            }
        }

        for (int i = 0; i < list_amulet.Count; i++)
        {
            if (sc.GetIsUnlocked(list_amulet[i].m_code) && list_amulet[i].dualbility < 100)
            {
                list_amulet_R.Add(list_amulet[i]);
            }
        }

        for (int i = 0; i < list_stone.Count; i++)
        {
            if (sc.GetIsUnlocked(list_stone[i].m_code) && list_stone[i].dualbility < 100)
            {
                list_stone_R.Add(list_stone[i]);
            }
        }
    }

    public void RepairPanelUISetting(int index)
    {
        //수리 비용 계산
        //buygold.text = RepairSlotArray[index].gold;
        clickItem = index;
        //버튼에 내 Gold, Coupon 표기
        buttonMyGoldText.text = capital.money.ToString();
        buttonMyCouponText.text = capital.coupon.ToString();

        //쿠폰이나 골드가 적을 시 버튼 비활성화 함수

        ButtonEnableFalse(1);
    }

    public void ButtonEnableFalse(int needcoupon) //쿠폰이나 골드가 적을 시 버튼 비활성화 함수
    {
        if (int.Parse(buttonMyCouponText.text) < needcoupon)
        {
            couponButton.interactable = false;
        }
        if (int.Parse(buttonMyGoldText.text.ToString()) < int.Parse(buyGoldText.text.ToString()))
        {
            goldButton.interactable = false;
        }
    }


    public void SlotButtonEnableFalse(int needcoupon) //쿠폰이나 골드가 적을 시 버튼 비활성화 함수 , 슬롯 수리시 따로
    {
        if (int.Parse(buttonSMyCouponText.text) < needcoupon)
        {
            couponButton.interactable = false;
        }
        if (int.Parse(buttonSMyGoldText.text.ToString()) < int.Parse(buySlotGoldText.text.ToString()))
        {
            goldButton.interactable = false;
        }
    }

    public void AllButtonEnableFalse(int needcoupon) //쿠폰이나 골드가 적을 시 버튼 비활성화 함수 , 슬롯 수리시 따로
    {
        if (int.Parse(buttonAMyCouponText.text) < needcoupon)
        {
            couponButton.interactable = false;
        }
        if (int.Parse(buttonAMyGoldText.text.ToString()) < int.Parse(buyAllGoldText.text.ToString()))
        {
            goldButton.interactable = false;
        }
    }

    public void RepairSetting()
    {
        list_amulet_R.Clear();
        list_weapon_R.Clear();
        list_stone_R.Clear();

        RepairListSetting();

    }




}
