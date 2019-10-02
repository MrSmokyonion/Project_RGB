using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreMenuSlotUI : MonoBehaviour
{
    public GameObject StoreBuyCheckSlot;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StoreBuyButtonClick()//구입 확인버튼 창
    {
        Debug.Log("Button Click");
        GameObject slot = Instantiate(StoreBuyCheckSlot) as GameObject;
        slot.transform.SetParent(gameObject.transform.parent.transform);
        slot.transform.localPosition = new Vector2(0, 0);
        Debug.Log("Button Click Finish");
    }


    public void StoreBuyCheckSlotBuyClick()//구입
    {
        //구입하는 코드필요
        Destroy(gameObject.transform.parent.parent);
    }

    public void StoreBuyCheckSlotCancelClick()//구입취소
    {
        Destroy(gameObject.transform.parent);
    }


}

