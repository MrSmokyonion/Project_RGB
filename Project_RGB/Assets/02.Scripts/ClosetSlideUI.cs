using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClosetSlideUI : MonoBehaviour
{
    public RectTransform[] closetSlotImageArray;
    public Scrollbar scrollbar;
    public bool isSlotClick = false;
    int index;
    private void Start()
    {
       
    }

    private void Update()
    { index = (int)(scrollbar.value / 0.19f);
        closetSlotImageArray[index + 2].sizeDelta = Vector2.Lerp(closetSlotImageArray[index + 2].sizeDelta, new Vector2(200.0f, 200.0f), 0.2f); // 스크롤 바의 value 값에 따라 해당 이미지를 키움.

    }

    public void ClosetSlotImageSizeReset()//커진 이미지를 원상태로
    {

        for (int i = 0; i < closetSlotImageArray.Length; i++)
        {
            if (closetSlotImageArray[i] != closetSlotImageArray[index + 2])
            {
                closetSlotImageArray[i].sizeDelta = new Vector3(150.0f, 150.0f, 1.0f);
            }

        }

        //for (int i = 0; i < closetSlotImageArray.Length; i++)
        //{
        //    closetSlotImageArray[i].sizeDelta = new Vector3(150.0f, 150.0f, 1.0f);
        //}

    }


    public void ClosetSlotClick()
    {
        isSlotClick = true;
        StartCoroutine("ClosetSlotClick_Corutine");
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
            Debug.Log( "Scale : " + gameObject.GetComponent<RectTransform>().localScale);
            yield return new WaitForSeconds(0.01f);

        }
        Debug.Log("Courutine2");
        yield return null;
    }

}









