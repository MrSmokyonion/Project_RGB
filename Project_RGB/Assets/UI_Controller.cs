using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Controller : MonoBehaviour
{
    public GameObject UI_Melee;
    public GameObject UI_Distance;

    public void UIOnOff(int code/*0-Sword 1-Spear 2-Bow*/)
    {
        UI_Melee.SetActive(false);
        UI_Distance.SetActive(false);

        switch(code)
        {
            case 0: UI_Melee.SetActive(true); break;
            case 1: UI_Melee.SetActive(true); break;
            case 2: UI_Distance.SetActive(true); break;
        }
        return;
    }
}
