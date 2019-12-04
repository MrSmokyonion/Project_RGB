using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackButton : MonoBehaviour
{
    public Canvas BackButtonCanvas;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void BackButtonScript()
    {
        BackButtonCanvas.enabled = false;
    }
    public void NPCCanvas_BackButtonScript()
    {
        BackButtonCanvas.gameObject.transform.GetChild(0).GetComponent<Animator>().SetBool("isOpen", false);
        BackButtonCanvas.enabled = false;
    }

    public void NPCQuestCanvas_BackButtonScript()
    {
        transform.parent.GetChild(0).GetComponent<Animator>().SetBool("isOpen", false);
        BackButtonCanvas.enabled = false;
    }

    public void StoreCanvas_BackButtonScript()
    {
        transform.parent.GetChild(0).GetComponent<Animator>().SetBool("isOpen", false);
        BackButtonCanvas.enabled = false;


    }
}
