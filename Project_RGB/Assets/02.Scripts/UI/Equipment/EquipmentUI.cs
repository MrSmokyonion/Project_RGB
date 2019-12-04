using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentUI : MonoBehaviour
{
    public Text maxHPText;
    public Text bonusHPText;
    public Text powerText;
    public Text defenceText;


    public PlayerStatus ps;
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

        maxHPText.text = "최대 체력 : " + ps.maxHp.ToString();
        bonusHPText.text = "추가 체력 : " + Food().ToString();
        powerText.text = "공격력 : " + ps.power.ToString();
        defenceText.text = "방어력 : " + ps.defence.ToString();

        //플레이어에서 현재 착용중인 장비 가져와서 세팅
        //useWeaponImage.sprite = pWepon.m_code;
        //useAmuletImage.sprite = pAmulet.m_spritePath;
        //useRockImage.sprite = pStone.m_code;
    }

    public int Food()
    {
       BaseFood food =  ps.food.GetComponent<BaseFood>();
        if (food == null)
            return 0;
        else
           return food.m_foodBonusHp;
       
    }

}
