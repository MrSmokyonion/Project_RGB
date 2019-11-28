using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreUI : MonoBehaviour
{
    public GameObject useItem;
    public int itemType;
    public Text[] itemNameText;
    public Text[] itemPriceText;
    public Text[] itemDescriptionText;
    public Image[] itemImage;


    public SpawnClass sc;
    public GameObject tmp;
    public List<BaseFood> list_food;
    public List<Base_Weapon> list_weapon;
    public List<Base_Armor> list_armor;
    public List<Base_Skill> list_skill;
    //public List<Item> itemList;
    // Start is called before the first frame update
    void Start()
    {//햄버거피자국수주먹밥스테이크

        if (itemType == 0)
        {
            tmp = sc.LoadAll_Food();

            list_food.Add(tmp.GetComponent<Food_Hamburger>());
            list_food.Add(tmp.GetComponent<Food_Pizza>());
            list_food.Add(tmp.GetComponent<Food_Noodle>());
            list_food.Add(tmp.GetComponent<Food_RiceBall>());
            list_food.Add(tmp.GetComponent<Food_Steak>());
        }
        else if(itemType == 1)
        {
            tmp = sc.LoadAll_Armor();

            list_weapon.Add(tmp.GetComponent<Sword_Default>());
            list_weapon.Add(tmp.GetComponent<Sword_HotTuna>());
            list_weapon.Add(tmp.GetComponent<Sword_BBQStick>());
            list_weapon.Add(tmp.GetComponent<Sword_Broad>());
            list_weapon.Add(tmp.GetComponent<Sword_MoonLight>());

            //====================================================

            list_weapon.Add(tmp.GetComponent<Spear_Default>());
            list_weapon.Add(tmp.GetComponent<Spear_IceNalchi>());
            list_weapon.Add(tmp.GetComponent<Spear_Nyan>());
            list_weapon.Add(tmp.GetComponent<Spear_DangPa>());
            list_weapon.Add(tmp.GetComponent<Spear_PolarStar>());

            //====================================================  
            
            list_weapon.Add(tmp.GetComponent<Bow_Default>());
            list_weapon.Add(tmp.GetComponent<Bow_NoMoney>());
            list_weapon.Add(tmp.GetComponent<Bow_Dryed>());
            list_weapon.Add(tmp.GetComponent<Bow_Long>());
            list_weapon.Add(tmp.GetComponent<Bow_Apollo>());

            

        }

        else
        {
            tmp = sc.LoadAll_Skill();

            list_armor.Add(tmp.GetComponent<Amulet_Default>());
            list_armor.Add(tmp.GetComponent<Amulet_Richness>());
            list_armor.Add(tmp.GetComponent<Amulet_Drain>());
            list_armor.Add(tmp.GetComponent<Amulet_ImproveSkill>());
            list_armor.Add(tmp.GetComponent<Amulet_PainPatch>());

            list_armor.Add(tmp.GetComponent<Stone_Default>());
            list_armor.Add(tmp.GetComponent<Stone_Magnetic>());
            list_armor.Add(tmp.GetComponent<Stone_Guardian>());
            list_armor.Add(tmp.GetComponent<Stone_Minor>());
            list_armor.Add(tmp.GetComponent<Stone_Major>());
        }

        StoreSetting();
    }

    void StoreSetting()
    {
        if (itemType == 0) //음식
        {
            for (int i = 0; i < list_food.Count; i++)
            {
                if (list_food[i].m_price == -123456789)
                    continue;

                itemNameText[i].text = list_food[i].m_title;
                itemPriceText[i].text = list_food[i].m_price.ToString();
                itemDescriptionText[i].text = list_food[i].m_description;
                //itemImage[i].sprite = list_food[i].m_spritePath;
            }
        }
    }

}
