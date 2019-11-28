using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionCanvas : MonoBehaviour
{
    //*************************UI 변수*******************
    public Text usercodeText;
    public Slider soundSlider;
    public Text soundSliderText;

    public InputField changeUserCodeInputText;
    public InputField removeAccountInputText;

    public GameObject anotherAccountLoginPanel;
    public GameObject accountRemovePanel;

    public Canvas optionCanvas;
    //***************************************************
    public NetworkRouter networkRouter = null;
    // Start is called before the first frame update
    void Start()
    {
        OptionSetting();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OptionSetting()
    {
        string optionUsercode = PlayerPrefs.GetString("USERCODE");
        int volume = PlayerPrefs.GetInt("VOLUME");

        usercodeText.text = optionUsercode;
        soundSlider.value = volume / 100;
        soundSliderText.text = ((int)(soundSlider.value * 100)).ToString();
    }

    public void OptionSoundSlider()
    {
        int volume = (int)(soundSlider.value * 100);
        soundSliderText.text = ((int)(soundSlider.value * 100)).ToString();
        Debug.Log("volume : " + volume);
        PlayerPrefs.SetInt("VOLUME", volume);
    }

    #region 다른계정 로그인 창 버튼 UI
    public void AnotherAccountLoginButton()
    {
        anotherAccountLoginPanel.SetActive(true);
    }

    public void AnotherAccountLoginOKButton()
    {
        string otherAccountUserCode = changeUserCodeInputText.text;
        networkRouter.PostRouter(PostType.PLAYER_CHARACTER_GET_CHARDATA, otherAccountUserCode);
    }

    public void AnotherAccountLoginCancleButton()
    {
        changeUserCodeInputText.text = "";
        anotherAccountLoginPanel.SetActive(false);
    }
    #endregion

    #region 계정 삭제 창 버튼 UI
    public void AccountRemoveButton()
    {
        accountRemovePanel.SetActive(true);
    }

    public void AccountRemoveOKButton()
    {
        if (removeAccountInputText.text == "삭제합니다")
        {
            networkRouter.PostRouter(PostType.PLAYER_CHARACTER_REMOVE, usercodeText.text);
        }

    }

    public void AccountRemoveCancleButton()
    {
        removeAccountInputText.text = "";
        accountRemovePanel.SetActive(false);
    }

    public void OpenOptionCanvas()
    {
        optionCanvas.enabled = true;
    }
    #endregion
}
