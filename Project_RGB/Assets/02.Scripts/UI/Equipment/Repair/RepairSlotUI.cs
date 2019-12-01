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
    //=================================================
    //플레이어 쪽에서 쿠폰 가져오기

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void RepairSlotSetting()
    {

        if (slotNumber == 0)
        {
            //무기
            //for (int i = 0; i < ItemList.GetLength(0); i++)
            //{
            //    RepairSlotArray[i] = ItemList[0][i].Weapon?
            //}
        }
        else if (slotNumber == 1)
        {
            //부적
        }
        else
        {
            //돌
        }

        //for (int i = 0; i < RepairSlotArray.Length; i++)
        //{
        //    //if(itemlist[i].Durability <100)
        //    // RepairSlotArray[i].sprite = itemlist[i].sprite;
        //    //RepairSlotArray[i].GetComponent<ButtonChoiceUI>().index = i;
        //}
    }

    public void SlotClick(int index)
    {
        // clickItem = ItemArray[index]
        RepairButtonClick(index);
    }

    public void RepairButtonClick(int index)
    {
        //clickitem
        //수리 비용 계산
        //Ui띄우기
        repairPanelUIScript.RepairPanelUISetting(index);
        repairCheckPanel.SetActive(true);

    }
    public void AllRepairButtonClick()
    {
        //전체 수리 비용 계산
        
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

}
