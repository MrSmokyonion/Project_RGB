using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreUI : MonoBehaviour
{
    public GameObject useItem;
    public Text[] itemNameText;
    public Text[] itemPriceText;
    public Text[] itemDescriptionText;
    public Image[] itemImage;

    //public List<Item> itemList;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void StoreSetting()
    {
        //for (int i = 0; i < itemList.Count; i++)
        //{
        //    itemNameText[i].text = itemList[i].itemname;
        //    itemPriceText[i].text = itemList[i].itemPrice;
        //    itemDescriptionText[i].text = itemList[i].itemDescription;
        //    itemImage[i].sprite = itemList[i].itemImage;
        //}
    }

}
