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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OptionSetting()
    {
        //usercodeText.text = 
        //soundSlider.value = 값 / 100;
        soundSliderText.text = ((int)(soundSlider.value * 100)).ToString();
    }
    #region 다른계정 로그인 창 버튼 UI
    public void AnotherAccountLoginButton()
    {
        anotherAccountLoginPanel.SetActive(true);
    }

    public void AnotherAccountLoginOKButton()
    {
        //changeUserCodeInputText.text
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
            //removeAccountInputText.text
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
