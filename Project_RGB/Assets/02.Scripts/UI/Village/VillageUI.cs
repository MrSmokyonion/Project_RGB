using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VillageUI : MonoBehaviour
{
    public PlayerStatus playerStatusScript;
    public Capital capitalScript;
    public Slider hpSlider;
    public Text goldText;
    public Text couponText;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

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
        int value = playerStatusScript.curHp / playerStatusScript.maxHp;

        return value;
    }

    public int GetCoupon()
    {
        int value = capitalScript.coupon;

        return value;
    }
}
