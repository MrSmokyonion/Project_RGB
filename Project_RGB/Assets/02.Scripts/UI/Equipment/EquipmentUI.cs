using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentUI : MonoBehaviour
{
    public Image useWeaponImage;
    public Image useAmuletImage;
    public Image useRockImage;

    public Text StatsText1;
    public Text StatsText2;
    public Text StatsText3;

    public Slider StatsSlider1;
    public Slider StatsSlider2;
    public Slider StatsSlider3;

    public PlayerStatus ps;
    public int clickType = 0;       //0 - weapon 1 - amulet 2- stone 
    // Start is called before the first frame update
    void Start()
    {
        EquipmentUISetting();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void EquipmentUISetting()
    {
        Base_Weapon pWepon;
        Armor_Amulet pAmulet;
        Armor_Stone pStone;


        //if (clickType == 0)
        //{
        //    pWepon = ps.weapon.GetComponent<Base_Weapon>();
        //    StatsText1;
        //    StatsText2;
        //    StatsText3;

        //    StatsSlider1;
        //    StatsSlider2;
        //    StatsSlider3;
        //}
        //else if (clickType == 1)
        //{
        //    pAmulet = ps.weapon.GetComponent<Armor_Amulet>();
        //    StatsText1.text;
        //    StatsText2;
        //    StatsText3;

        //    StatsSlider1;
        //    StatsSlider2;
        //    StatsSlider3;
        //}
        //else
        //{
        //    pStone = ps.weapon.GetComponent<Armor_Stone>();
        //    StatsText1.text;
        //    StatsText2;
        //    StatsText3;

        //    StatsSlider1;
        //    StatsSlider2;
        //    StatsSlider3;
        //}


        //플레이어에서 현재 착용중인 장비 가져와서 세팅
        //useWeaponImage.sprite = pWepon.m_code;
        //useAmuletImage.sprite = pAmulet.m_spritePath;
        //useRockImage.sprite = pStone.m_code;
    }

    public void ItemSlotClick(int num)   //0 - weapon 1 - amulet 2- stone 
    {
        clickType = num;
        EquipmentUISetting();
    }
}
