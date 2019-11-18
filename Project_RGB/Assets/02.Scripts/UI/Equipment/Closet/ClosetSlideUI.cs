using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClosetSlideUI : MonoBehaviour
{
    public RectTransform[] closetSlotImageArray;
    // public List<item> itemList;


    //public Image rockImage;
    public Scrollbar scrollbar;
    public GameObject panel;

    public bool isSlotClick = false;
    public int index;
    public int[] useEquipment = new int[3];
    public int sortNumber;
    public int thisSlotNumber;
    private void Start()
    {
        if (thisSlotNumber == 0)
        {
            //itemList = Weapon
        }
        else if (thisSlotNumber == 1)
        {
            //itemList =  Amulet
        }
        else
        {
            //itemList = Stone
        }

    }

    private void Update()
    {
        index = (int)(scrollbar.value / 0.19f);
        closetSlotImageArray[index + 2].sizeDelta = Vector2.Lerp(closetSlotImageArray[index + 2].sizeDelta, new Vector2(200.0f, 200.0f), 0.2f); // 스크롤 바의 value 값에 따라 해당 이미지를 키움.
        closetSlotImageArray[index + 2].transform.GetChild(0).GetComponent<RectTransform>().sizeDelta = Vector2.Lerp(closetSlotImageArray[index + 2].transform.GetChild(0).GetComponent<RectTransform>().sizeDelta, new Vector2(200.0f, 200.0f), 0.2f); // 스크롤 바의 value 값에 따라 해당 이미지를 키움.
        closetSlotImageArray[index + 2].transform.GetChild(1).GetComponent<RectTransform>().sizeDelta = Vector2.Lerp(closetSlotImageArray[index + 2].transform.GetChild(1).GetComponent<RectTransform>().sizeDelta, new Vector2(200.0f, 200.0f), 0.2f); // 스크롤 바의 value 값에 따라 해당 이미지를 키움.
        closetSlotImageArray[index + 2].transform.GetChild(2).GetComponent<RectTransform>().sizeDelta = Vector2.Lerp(closetSlotImageArray[index + 2].transform.GetChild(2).GetComponent<RectTransform>().sizeDelta, new Vector2(200.0f, 200.0f), 0.2f); // 스크롤 바의 value 값에 따라 해당 이미지를 키움.
    }

    public void ClosetSlotSetting()
    {
        if (sortNumber == 0)    //내구도 순 등등등
        {
            //itemArray[]
        }

        else if (sortNumber == 1)
        {
            //itemList.Sort
        }

        else if (sortNumber == 2)
        {
            //itemList.Sort
        }
    }



    public void ClosetSlotImageSizeReset()//커진 이미지를 원상태로
    {

        for (int i = 0; i < closetSlotImageArray.Length; i++)
        {
            if (closetSlotImageArray[i] != closetSlotImageArray[index + 2])
            {
                closetSlotImageArray[i].sizeDelta = new Vector3(150.0f, 150.0f, 1.0f);
                closetSlotImageArray[i].GetChild(0).GetComponent<RectTransform>().sizeDelta = new Vector3(150.0f, 150.0f, 1.0f);
                closetSlotImageArray[i].GetChild(1).GetComponent<RectTransform>().sizeDelta = new Vector3(150.0f, 150.0f, 1.0f);
                closetSlotImageArray[i].GetChild(2).GetComponent<RectTransform>().sizeDelta = new Vector3(150.0f, 150.0f, 1.0f);
                panel.SetActive(true);
            }

        }

        //for (int i = 0; i < closetSlotImageArray.Length; i++)
        //{
        //    closetSlotImageArray[i].sizeDelta = new Vector3(150.0f, 150.0f, 1.0f);
        //}

    }


    public void ClosetSlotClick()   //리스트 클릭시 커지게, 2번 클릭시 해당 인덱스 장비 착용.
    {
        isSlotClick = true;
        StartCoroutine("ClosetSlotClick_Corutine");
    }



    public void ItemUnLock()    //해금된 아이템 이미지 안보이게 & 새로얻은 아이템 이미지 false로 만들기
    {
        //for(int i = 0; i = closetSlotImageArray.Length;i++)
        //{closetSlotImageArray[i].GetChild(2).GetComponent<Image>().enabled = false;
        //    if(itemList[i].unlock == true)
        //    {
        //        closetSlotImageArray[i].GetChild(0).GetComponent<Image>().enabled = false;
        //    }
        //}
    }

    public void NewItemImage()  //새로 얻은 아이템 표시
    {
        //    for (int i = 0; itemList.Count; i++)
        //    {
        //        if(//새로 얻은 아이템이면)
        //        closetSlotImageArray[i].GetChild(2).GetComponent<Image>().enabled = true;
        //    }
    }

    public void ClosetSlotClickReset()
    {
        isSlotClick = false;
        StartCoroutine("ClosetSlotClickReset_Corutine");

    }



    IEnumerator ClosetSlotClick_Corutine()
    {
        while (gameObject.GetComponent<RectTransform>().localScale.x <= 2.2f)
        {
            gameObject.GetComponent<RectTransform>().localScale = Vector2.Lerp(gameObject.GetComponent<RectTransform>().localScale, new Vector2(2.3f, 2.3f), 0.2f);
            panel.SetActive(false);
            yield return new WaitForSeconds(0.01f);


        }

        Debug.Log("Courutine1");
        yield return null;
    }

    IEnumerator ClosetSlotClickReset_Corutine()
    {
        while (gameObject.GetComponent<RectTransform>().localScale.x >= 1.6f)
        {
            gameObject.GetComponent<RectTransform>().localScale = Vector2.Lerp(gameObject.GetComponent<RectTransform>().localScale, new Vector2(1.5f, 1.5f), 0.2f);
            Debug.Log("Scale : " + gameObject.GetComponent<RectTransform>().localScale);
            yield return new WaitForSeconds(0.01f);

        }
        Debug.Log("Courutine2");
        yield return null;
    }

}









