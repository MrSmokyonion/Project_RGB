using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VilageSlideMenu : MonoBehaviour
{
    public Canvas questMenuCanvas;
    public Canvas equipmentMenuCanvas;
    public Canvas skillMenuCanvas;
    public Sprite VilageSlideCloseImage;
    public Sprite VilageSlideOpenImage;
    Animator SlideMenuAnimator;

    bool isClick;
    Image buttonImage;



    // Start is called before the first frame update
    void Start()
    {
        buttonImage = gameObject.GetComponent<Image>();
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
            buttonImage.sprite = VilageSlideOpenImage;
        }
        else
        {
            SlideMenuAnimator.SetBool("isSlideMenuButtonClick", false);
            buttonImage.sprite = VilageSlideCloseImage;
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
