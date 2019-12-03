using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VillageUI : MonoBehaviour
{
    public PlayerStatus ps;
    public Capital capitalScript;
    public Slider hpSlider;
    public Text goldText;
    public Text couponText;

    public Image slideBackground;
    public Image slideBackgroundF;
    public bool isFoodEat;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        VillageUISetting();
    }


    void VillageUISetting()
    {
        hpSlider.value = GetHPSliderValue();
        goldText.text = GetGold().ToString();
        couponText.text = GetCoupon().ToString();
    }

    public int GetGold()
    {
        return capitalScript.money;
    }

    public int GetHPSliderValue()
    {
        HPSliderSetting();
        //int value = ps.curHp / ps.maxHp;

        return ps.maxHp - ps.curHp;
    }

    public int GetCoupon()
    {
        int value = capitalScript.coupon;

        return value;
    }

    public void HPSliderSetting()
    {
        int bonusHP = FoodCheck();
        if (bonusHP != 0)
        {
            isFoodEat = true;
            hpSlider.fillRect.parent.GetComponent<RectTransform>().offsetMax = new Vector2(200+(200/bonusHP), 0); // 음식 증가값에 따른 조정 필요!
            hpSlider.maxValue = ps.maxHp + bonusHP;
            slideBackground.enabled = true;
            slideBackgroundF.enabled = false;


        }
        else
        {
            isFoodEat = false;
            hpSlider.fillRect.parent.GetComponent<RectTransform>().offsetMax = new Vector2(0, 0);
            hpSlider.maxValue = ps.maxHp;
            slideBackgroundF.enabled = true;
            slideBackground.enabled = false;

            //hpSlider.value = playerStatusScript.curHp / playerStatusScript.maxHp;
            //
        }


    }

    public void TestButton()
    {
        ps.curHp -=20;
    }

    public int FoodCheck()
    {
        BaseFood food = ps.food.GetComponent<BaseFood>();
        if (food == null)
            return 0;
        else
            return food.m_foodBonusHp;

    }
}
