using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreUI : MonoBehaviour
{
    public int itemType;
    public GameObject useItem;
    
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
    {

        if (itemType == 0)          //Food
        {
            tmp = sc.LoadAll_Food();

            list_food.Add(tmp.GetComponent<Food_Hamburger>());
            list_food.Add(tmp.GetComponent<Food_Pizza>());
            list_food.Add(tmp.GetComponent<Food_Noodle>());
            list_food.Add(tmp.GetComponent<Food_RiceBall>());
            list_food.Add(tmp.GetComponent<Food_Steak>());
        }
        else if(itemType == 1)      //Weapon & Armor
        {
            //tmp = sc.LoadAll_Weapon();

            list_weapon.Add(tmp.GetComponent<Sword_Default>());
            list_weapon.Add(tmp.GetComponent<Sword_HotTuna>());
            list_weapon.Add(tmp.GetComponent<Sword_BBQStick>());
            list_weapon.Add(tmp.GetComponent<Sword_Broad>());
            list_weapon.Add(tmp.GetComponent<Sword_MoonLight>());

            list_weapon.Add(tmp.GetComponent<Spear_Default>());
            list_weapon.Add(tmp.GetComponent<Spear_IceNalchi>());
            list_weapon.Add(tmp.GetComponent<Spear_Nyan>());
            list_weapon.Add(tmp.GetComponent<Spear_DangPa>());
            list_weapon.Add(tmp.GetComponent<Spear_PolarStar>()); 
            
            list_weapon.Add(tmp.GetComponent<Bow_Default>());
            list_weapon.Add(tmp.GetComponent<Bow_NoMoney>());
            list_weapon.Add(tmp.GetComponent<Bow_Dryed>());
            list_weapon.Add(tmp.GetComponent<Bow_Long>());
            list_weapon.Add(tmp.GetComponent<Bow_Apollo>());

            tmp = sc.LoadAll_Armor();

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

        else                //Skill
        {
            tmp = sc.LoadAll_Skill();

            list_skill.Add(tmp.GetComponent<Skill_Red_PiercingSpear>());
            list_skill.Add(tmp.GetComponent<Skill_Red_ArrowRain>());
            list_skill.Add(tmp.GetComponent<Skill_Red_SwordTrap>());
            list_skill.Add(tmp.GetComponent<Skill_Red_Turret>());
            list_skill.Add(tmp.GetComponent<Skill_Red_PowerBuff>());
                 
            list_skill.Add(tmp.GetComponent<Skill_Green_HighJump>());
            list_skill.Add(tmp.GetComponent<Skill_Green_Dash>());
            list_skill.Add(tmp.GetComponent<Skill_Green_BackStep>());
            list_skill.Add(tmp.GetComponent<Skill_Green_Charger>());
            list_skill.Add(tmp.GetComponent<Skill_Green_MoveBuff>());
             
            list_skill.Add(tmp.GetComponent<Skill_Blue_Barrier>());
            list_skill.Add(tmp.GetComponent<Skill_Blue_Wall>());
            list_skill.Add(tmp.GetComponent<Skill_Blue_Invisible>());
            list_skill.Add(tmp.GetComponent<Skill_Blue_Shield>());
            list_skill.Add(tmp.GetComponent<Skill_Blue_DefenceBuff>());

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

        else if (itemType == 1) //Weapon & Armor
        {
            for (int i = 0; i < list_weapon.Count; i++)
            {
                //if (list_food[i].m_price == -123456789)
                //    continue;

                itemNameText[i].text = list_food[i].m_title;
                itemPriceText[i].text = list_food[i].m_price.ToString();
                itemDescriptionText[i].text = list_food[i].m_description;
                //itemImage[i].sprite = list_food[i].m_spritePath;
            }

            for(int i = list_weapon.Count-1; i<list_armor.Count;i++)
            {
                //if (list_food[i].m_price == -123456789)
                //    continue;

                itemNameText[i].text = list_weapon[i].m_title;
                itemPriceText[i].text = list_weapon[i].m_price.ToString();
                itemDescriptionText[i].text = list_weapon[i].m_description;
                //itemImage[i].sprite = list_food[i].m_spritePath;
            }
        }

        else                    //Skill
        {
            //for (int i = 0; i < list_skill.Count; i++)
            //{
            //    //if (list_skill[i].m_price == -123456789)
            //    //    continue;

            //    itemNameText[i].text = list_skill[i].m_title;
            //    itemPriceText[i].text = list_skill[i].m_price.ToString();
            //    itemDescriptionText[i].text = list_skill[i].m_description;
            //    //itemImage[i].sprite = list_food[i].m_spritePath;
            //}
        }
    }

    
}
