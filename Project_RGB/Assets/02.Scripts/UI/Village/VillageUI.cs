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
    public bool isFoodEat;
    // Start is called before the first frame update
    void Start()
    {
        HPSliderSetting();
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
        HPSliderSetting();
        int value = playerStatusScript.curHp / playerStatusScript.maxHp;

        return value;
    }

    public int GetCoupon()
    {
        int value = capitalScript.coupon;

        return value;
    }

    public void HPSliderSetting()
    {
        if (isFoodEat == true)
        {
            hpSlider.fillRect.parent.GetComponent<RectTransform>().offsetMax = new Vector2(200, 0); // 음식 증가값에 따른 조정 필요!
            hpSlider.transform.GetChild(0).gameObject.SetActive(true);

        }
        else
        {
            hpSlider.fillRect.parent.GetComponent<RectTransform>().offsetMax = new Vector2(0, 0);
            hpSlider.transform.GetChild(0).gameObject.SetActive(false);

            //hpSlider.value = playerStatusScript.curHp / playerStatusScript.maxHp;
            //
        }


    }
}
