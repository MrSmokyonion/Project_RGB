using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairButtonUI : MonoBehaviour
{
    public RepairSlotUI repairScript;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RepairButtonClick()
    {
        repairScript.RepairButtonClick();
    }

    public void AllRepairButtonClick()
    {
        repairScript.AllRepairButtonClick();
    }
}
