using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RepairPanelUI : MonoBehaviour
{
    public Capital capital;

    public Text goldText;

    public Text buyGoldText;
    public Text buttonMyGoldText;
    public Text buttonMyCouponText;

    public Button couponButton;
    public Button goldButton;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void RepairPanelUISetting(int index)
    {
        //수리 비용 계산
        //goldText.text = RepairSlotArray[index].gold;

        //버튼에 내 Gold, Coupon 표기
        buttonMyGoldText.text = capital.money.ToString();
        buttonMyCouponText.text = capital.coupon.ToString();

        //쿠폰이나 골드가 적을 시 버튼 비활성화 함수
       
        ButtonEnableFalse();
    }

    public void ButtonEnableFalse() //쿠폰이나 골드가 적을 시 버튼 비활성화 함수
    {
        if (capital.coupon < int.Parse(buttonMyCouponText.text))
        {
            couponButton.enabled = false;
        }
        else if (capital.money < int.Parse(buttonMyGoldText.text))
        {
            goldButton.enabled = false;
        }
    }

    public void BuyCouponButtonClick()
    {
        //해당 아이템의 내구도 교체 함수
        
        //나의 쿠폰 개수 -1
        capital.coupon -= 1;
        //해당슬롯 삭제 또는 배열 다시 받아와서 넣기
    }

    public void BuyGoldButtonClick()
    {
        //해당 아이템의 내구도 교체 함수
        //나의 골드 - 아이템 수리 비용
        //해당슬롯 삭제 또는 배열 다시 받아와서 넣기
    }


}
