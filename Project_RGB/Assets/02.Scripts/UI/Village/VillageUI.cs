using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VillageUI : MonoBehaviour
{
    public Slider HPSlider;
    public Text GoldText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void VillageUISetting()
    {
        HPSlider.value = GetHPSliderValue();
        GoldText.text = GetGold().ToString();
    }

    public int GetGold()
    {
        return 0;
    }

    public int GetHPSliderValue()
    {
        return 0;
    }
}
