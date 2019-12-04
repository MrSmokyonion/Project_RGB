using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoticeTextUI : MonoBehaviour
{
    public float delay = 0.1f;
    public Text noticeText;

    public void ItemEat(string itemName)
    {
        //noticeText.text = "itemName" + " " + "을 획득하였습니다.";
        noticeText.text = "드라이어드의 활" + " " + "을 획득하였습니다.";

        StartCoroutine("NoticeTextUIStart");
        StartCoroutine("NoticeTextUIEnd");
    }

    IEnumerator NoticeTextUIEnd()
    {
        yield return new WaitForSeconds(2.5f);

        for (float a = 255; a >= 0; a -= 10)
        {
            transform.GetComponent<Text>().color = new Color(255 / 255f, 255 / 255f, 255 / 255f, a / 255f);
            transform.parent.GetComponent<Image>().color = new Color(255 / 255f, 255 / 255f, 255 / 255f, a / 255f);
            transform.GetChild(0).GetComponent<Image>().color = new Color(255 / 255f, 255 / 255f, 255 / 255f, a / 255f);
            transform.GetChild(0).GetChild(0).GetComponent<Image>().color = new Color(255 / 255f, 255 / 255f, 255 / 255f, a / 255f);
            yield return new WaitForFixedUpdate();
        }

        transform.GetComponent<Text>().enabled = false;
        transform.parent.GetComponent<Image>().enabled = false;
        transform.GetChild(0).GetComponent<Image>().enabled = false;
        transform.GetChild(0).GetChild(0).GetComponent<Image>().enabled = false;
        Destroy(gameObject);
    }

    IEnumerator NoticeTextUIStart()
    {
        yield return new WaitForSeconds(delay);

        for (float a = 0; a >= 0; a += 10)
        {
            transform.GetComponent<Text>().enabled = true;
            transform.parent.GetComponent<Image>().enabled = true;
            transform.GetChild(0).GetComponent<Image>().enabled = true;
            transform.GetChild(0).GetChild(0).GetComponent<Image>().enabled = true;
            transform.GetComponent<Text>().color = new Color(255 / 255f, 255 / 255f, 255 / 255f, a / 255f);
            transform.parent.GetComponent<Image>().color = new Color(255 / 255f, 255 / 255f, 255 / 255f, a / 255f);
            transform.GetChild(0).GetComponent<Image>().color = new Color(255 / 255f, 255 / 255f, 255 / 255f, a / 255f);
            transform.GetChild(0).GetChild(0).GetComponent<Image>().color = new Color(255 / 255f, 255 / 255f, 255 / 255f, a / 255f);
            yield return new WaitForFixedUpdate();
        }
        
        Destroy(gameObject);
    }

}
