using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosetDescriptionButton : MonoBehaviour
{
    public GameObject itemDescriptionPanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }


    public void ItemDescriptionPanelClose()
    {
        itemDescriptionPanel.SetActive(false);
    }

    public void ItemDescriptionPanelOpen()
    {
        itemDescriptionPanel.SetActive(true);
    }
}
