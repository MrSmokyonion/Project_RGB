using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DungeonSelectionImageUI : MonoBehaviour
{
    public GameObject DungeonSlotContent;
    public Scrollbar scrollbar;
    private bool moveindex = false; 
    public int index = 0;

    // Start is called before the first frame update



    public void DungeonSlotUpButton()
    {
       
        if (index < 4)
        {
            moveindex = true;
            ++index;
            //  DungeonSlotContent.transform.localPosition = new Vector2(0.0f, index * 1000);
            DungeonSlotContent.transform.localPosition = Vector2.Lerp(DungeonSlotContent.transform.localPosition, new Vector2(0.0f, index * 1000), 0.5f);

            Debug.Log(index);
            Debug.Log(index * 1000);

        }
       
    }
    public void DungeonSlotDownButton()
    {

        if (index >= 1)
        {
            moveindex = true;
            --index;
            // DungeonSlotContent.transform.localPosition = new Vector2(0.0f, index * 1000);
            DungeonSlotContent.transform.localPosition = Vector2.Lerp(DungeonSlotContent.transform.localPosition, new Vector2(0.0f, index * 1000+400), 1.0f);
                        Debug.Log(index);
            Debug.Log(index * 1000);

        }
     
    }

    public void DungeonSlotScroll()
    {
      
            int value = 0;

            for (int i = 400; i <= 4400; i += 1000)
            {

                if (DungeonSlotContent.transform.localPosition.y <= i)
                {
                    value = i - 400;
                    DungeonSlotContent.transform.localPosition = Vector2.Lerp(DungeonSlotContent.transform.localPosition, new Vector2(0.0f, value), 0.5f); // 스크롤 바의 value 값에 따라 해당 이미지를 키움.
                    index = value / 1000;
                    Debug.Log(value);
                    break;
                }

                //value += 1000;
                //index = value / 1000;
            }
        

    }

}
