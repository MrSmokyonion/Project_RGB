using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class StoreBuyCheckUI : MonoBehaviour
{
    public GameObject StoreBuyCheckSlot;
    public GameObject StoreBuyPanel;
    public StoreUI itemStoreCanvas = null;
    public bool isfood;

    GameObject useItem;


    // Start is called before the first frame update
    void Awake()
    {
        StoreBuyPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StoreBuyCheckSlotBuyClick()//구입
    {

        //**********************구입하는 코드**************************


        //*************************************************************




        //**************************UI 처리****************************
        if (isfood == true)
        {
            if (itemStoreCanvas.useItem != null) //새로 구입 시 구입 패널 없애기
            {
                itemStoreCanvas.useItem.SetActive(false);
            }

            itemStoreCanvas.useItem = StoreBuyPanel;
            StoreBuyPanel.SetActive(true);
        }
        else                                    //장비나 스킬
        {
            //해금
            //아이템 개수따라 리스트 줄이기
            //아이템 개수가 0이면 이미지 띄우기
            Destroy(StoreBuyPanel.transform.parent.gameObject);
        }
      
        StoreBuyCheckSlot.SetActive(false);

        Debug.Log("A");
        //*************************************************************
    }

    public void StoreBuyCheckSlotCancelClick()//구입취소
    {

        StoreBuyCheckSlot.SetActive(false);
        Debug.Log("B");
    }


}

