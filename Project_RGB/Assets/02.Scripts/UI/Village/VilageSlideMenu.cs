using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VilageSlideMenu : MonoBehaviour
{
    public Canvas questMenuCanvas;
    public Canvas equipmentMenuCanvas;
    public Canvas skillMenuCanvas;

    Animator SlideMenuAnimator;
    bool isClick;




    // Start is called before the first frame update
    void Start()
    {

        SlideMenuAnimator = gameObject.transform.parent.GetComponent<Animator>();
        //currentBaseState = SlideMenuAnimator.GetCurrentAnimatorStateInfo(0);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void VliageSlideMenuButtonClick()
    {
        isClick = !isClick;
        if (isClick)
        {
            SlideMenuAnimator.SetBool("isSlideMenuButtonClick", true);
        }
        else
        {
            SlideMenuAnimator.SetBool("isSlideMenuButtonClick", false);
        }
    }

    public void QuestMenuButton()
    {
        Debug.Log("questMenuCanvas : " + questMenuCanvas.enabled);
        questMenuCanvas.GetComponent<QuestUI>().QuestBoardSetting();
        questMenuCanvas.enabled = true;
    }

    public void EquipmentMenuButton()
    {
        equipmentMenuCanvas.enabled = true;
    }
    public void SkillMenuButton()
    {
        skillMenuCanvas.enabled = true;
    }
}
