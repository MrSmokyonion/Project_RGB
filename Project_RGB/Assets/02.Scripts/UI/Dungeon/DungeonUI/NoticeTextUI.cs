using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoticeTextUI : MonoBehaviour
{
    public float delay = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("NoticeTextUIStart");
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator NoticeTextUIEnd()
    {
        yield return new WaitForSeconds(delay);

        for (float a = 255; a >= 0; a -= 10)
        {
            transform.GetComponent<Text>().color = new Color(255 / 255f, 255 / 255f, 255 / 255f, a / 255f);
            transform.parent.GetComponent<Text>().color = new Color(255 / 255f, 255 / 255f, 255 / 255f, a / 255f);
            transform.GetChild(0).GetComponent<Image>().color = new Color(255 / 255f, 255 / 255f, 255 / 255f, a / 255f);
            transform.GetChild(0).GetChild(0).GetComponent<Image>().color = new Color(255 / 255f, 255 / 255f, 255 / 255f, a / 255f);
            yield return new WaitForFixedUpdate();
        }

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
            transform.parent.GetComponent<Text>().color = new Color(255 / 255f, 255 / 255f, 255 / 255f, a / 255f);
            transform.GetChild(0).GetComponent<Image>().color = new Color(255 / 255f, 255 / 255f, 255 / 255f, a / 255f);
            transform.GetChild(0).GetChild(0).GetComponent<Image>().color = new Color(255 / 255f, 255 / 255f, 255 / 255f, a / 255f);
            yield return new WaitForFixedUpdate();
        }

        Destroy(gameObject);
    }

}
