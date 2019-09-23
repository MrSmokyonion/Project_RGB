using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VilageSlideMenuButton : MonoBehaviour
{
    public VilageSlideMenu slideMenu;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void QuestMenuButton()
    {
        slideMenu.QuestMenuButton();
    }

    public void EquipmentMenuButton()
    {
        slideMenu.EquipmentMenuButton();
    }

    public void SkillMenuButton()
    {
        slideMenu.SkillMenuButton();
    }
}
