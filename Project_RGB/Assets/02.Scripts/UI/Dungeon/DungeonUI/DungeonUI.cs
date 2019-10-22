using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DungeonUI : MonoBehaviour
{
    public Slider playerHPSlider;
    public Text goldText;
    public Image playerImage;
    public Text questText;
    public Slider progressSlider;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public string GoldSetting()
    {
        //캐피탈에서 Gold 받아오기
        return null;
    }
    public string Questsetting()
    {
        //Quest에서 해당 던전 quest 가져오기
        return null;
    }
    public int ProgressSliderSetting()
    {
        return 0;
    }
    public void DungeonUiSetting()
    {
        //playerHPSlider.value = 
        //goldText.text = GoldSetting();
        //playerImage.sprite = 
        //questText.text = Questsetting();
        //progressSlider.value = ProgressSliderSetting();
    }
}
