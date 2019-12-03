using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DungeonSelectionImageUI : MonoBehaviour
{
    public GameObject dungeonSlotContent;
    public Scrollbar scrollbar;
    private bool moveindex = false; 
    public int index = 0;
    public Slider slider;

    public SceneManager sceneManagerScript;
    // Start is called before the first frame update



    public void DungeonSlotUpButton()
    {
       
        if (index < 4)
        {
            moveindex = true;
            ++index;
            //  DungeonSlotContent.transform.localPosition = new Vector2(0.0f, index * 1000);
            dungeonSlotContent.transform.localPosition = Vector2.Lerp(dungeonSlotContent.transform.localPosition, new Vector2(0.0f, index * 1000), 0.5f);
            slider.value = index / 4.0f;

        }
       
    }
    public void DungeonSlotDownButton()
    {

        if (index >= 1)
        {
            moveindex = true;
            --index;
            // DungeonSlotContent.transform.localPosition = new Vector2(0.0f, index * 1000);
            dungeonSlotContent.transform.localPosition = Vector2.Lerp(dungeonSlotContent.transform.localPosition, new Vector2(0.0f, index * 1000+400), 1.0f);
            slider.value = index / 4.0f;

        }
     
    }

    public void DungeonSlotScroll()
    {
            int value = 0;

            for (int i = 400; i <= 4400; i += 1000)
            {
                if (dungeonSlotContent.transform.localPosition.y <= i)
                {
                    value = i - 400;
                    dungeonSlotContent.transform.localPosition = Vector2.Lerp(dungeonSlotContent.transform.localPosition, new Vector2(0.0f, value), 0.5f); // 스크롤 바의 value 값에 따라 해당 이미지를 키움.
                    index = (value / 1000);
                slider.value = index / 4.0f;
                break;
                }

         
                //value += 1000;
                //index = value / 1000;
        }
            
    }

    public void DungeonTransform()
    {  
        //index 저장
        PlayerPrefs.SetInt("DUNGEON_NUM", index + 1);
        Debug.Log(index + 1);

        //씬매니저에게 해당 index 씬 바꿔달라 요청
        sceneManagerScript.ChangeScene(SceneType.DUNGEON_LOADING);
    }

}
