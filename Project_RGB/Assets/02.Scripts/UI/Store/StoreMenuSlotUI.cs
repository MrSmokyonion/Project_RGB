using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class StoreMenuSlotUI : MonoBehaviour
{

    public GameObject StoreBuyCheckSlot;
    public StoreUI storeUIscript;
    // Start is called before the first frame update

    private void Start()
    {
        StoreBuyCheckSlot.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {

    }

    public void StoreBuyButtonClick()//구입 확인버튼 창
    {
       
        StoreBuyCheckSlot.SetActive(true);
    }



}

