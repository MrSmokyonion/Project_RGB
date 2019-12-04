using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreUI : MonoBehaviour
{
    public int itemType;
    public int itemIndex;
    public GameObject useItem;
    public Capital capital;


    public Button[] itemBuyButton;
    public Text[] itemNameText;
    public Text[] itemPriceText;
    public Text[] itemDescriptionText;
    public Image[] itemImage;

    public PlayerStatus ps;
    public SpawnClass sc;
    public GameObject tmp;
    public List<BaseFood> list_food_S;
    public List<Base_Weapon> list_weapon_S;
    public List<Base_Armor> list_armor_S;
    public List<Base_Skill> list_skill_S;

    public bool isClick = false;

    Animator slideStoreAnimator;
    //public List<Item> itemList;
    // Start is called before the first frame update
    void Start()
    {
        listSetting();
        StoreSetting();
    }

    void listSetting()
    {
        List<BaseFood> list_food = new List<BaseFood>();
        List<Base_Weapon> list_weapon = new List<Base_Weapon>();
        List<Base_Armor> list_armor = new List<Base_Armor>();
        List<Base_Skill> list_skill = new List<Base_Skill>();

        slideStoreAnimator = transform.GetChild(0).GetComponent<Animator>();

        if (itemType == 0)          //Food
        {
            tmp = sc.LoadAll_Food();

            list_food.Add(tmp.GetComponent<Food_Hamburger>());
            list_food.Add(tmp.GetComponent<Food_Pizza>());
            list_food.Add(tmp.GetComponent<Food_Noodle>());
            list_food.Add(tmp.GetComponent<Food_RiceBall>());
            list_food.Add(tmp.GetComponent<Food_Steak>());
        }
        else if (itemType == 1)      //Weapon & Armor
        {
            tmp = sc.LoadAll_Weapon();

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

        list_food_S = list_food;

        for (int i = 0; i < list_weapon.Count; i++)
        {
            if (list_weapon[i].m_isSale == true)
            {
                list_weapon_S.Add(list_weapon[i]);
            }
        }

        for (int i = 0; i < list_armor.Count; i++)
        {
            if (list_armor[i].m_isSale == true)
            {
                list_armor_S.Add(list_armor[i]);
            }
        }

        for (int i = 0; i < list_skill.Count; i++)
        {
            if (list_skill[i].m_isSale == true)
            {
                list_skill_S.Add(list_skill[i]);
            }
        }

    }


    void StoreSetting()
    {
        if (itemType == 0) //음식
        {
            for (int i = 0; i < list_food_S.Count; i++)
            {
                itemNameText[i].text = list_food_S[i].m_title;
                itemPriceText[i].text = list_food_S[i].m_price.ToString();
                itemDescriptionText[i].text = list_food_S[i].m_description;

                if (capital.money < list_food_S[i].m_price)
                    itemBuyButton[i].interactable = false;
                //itemImage[i].sprite = list_food[i].m_spritePath;
            }
        }

        else if (itemType == 1) //Weapon & Armor
        {
            int i = 0;
            Debug.Log(list_weapon_S.Count);
            Debug.Log(list_armor_S.Count);

            for (i = 0; i < list_weapon_S.Count; i++)
            {

                itemNameText[i].text = list_weapon_S[i].m_title;
                itemPriceText[i].text = list_weapon_S[i].m_price.ToString();
                itemDescriptionText[i].text = list_weapon_S[i].m_description;
                itemBuyButton[i].transform.GetChild(0).GetComponent<Text>().text = "구입하기";

                if (capital.money < list_weapon_S[i].m_price)
                    itemBuyButton[i].interactable = false;

            }
            Debug.Log("i: " + i);

            for (i = list_weapon_S.Count; i < list_weapon_S.Count + list_armor_S.Count; i++)
            {
                itemNameText[i].text = list_armor_S[i- list_weapon_S.Count].m_title;
                itemPriceText[i].text = list_armor_S[i- list_weapon_S.Count].m_price.ToString();
                itemDescriptionText[i].text = list_armor_S[i- list_weapon_S.Count].m_description;
                itemBuyButton[i].transform.GetChild(0).GetComponent<Text>().text = "구입하기";


                if (capital.money < list_armor_S[i- list_weapon_S.Count].m_price)
                    itemBuyButton[i].interactable = false;

            }
            //Debug.Log("list_weapon.Count + list_armor : " + list_weapon.Count.ToString() + list_armor.ToString());

        }

        else                    //Skill
        {
            for (int i = 0; i < list_skill_S.Count; i++)
            {
                itemNameText[i].text = list_skill_S[i].m_title;
                itemPriceText[i].text = list_skill_S[i].m_price.ToString();
                itemDescriptionText[i].text = list_skill_S[i].m_description;
                itemBuyButton[i].transform.GetChild(0).GetComponent<Text>().text = "구입하기";


                if (capital.crystal < list_skill_S[i].m_price)
                    itemBuyButton[i].interactable = false;

            }

        }
    }

    public void ItemBuy(int itemname)
    {
        itemIndex = itemname;
        if (itemType == 0)
        {
            //sc.UnlockCode(list_food_S[itemIndex].m_code);
            capital.MinusMoney(list_food_S[itemIndex].m_price);
            ps.changer.ChangeFood(list_food_S[itemIndex].m_code, ps.gameObject, ps.food);

        }
        else if (itemType == 1)
        {
            if (itemIndex < list_weapon_S.Count)
            {
                sc.UnlockCode(list_weapon_S[itemIndex].m_code);
                capital.MinusMoney(list_weapon_S[itemIndex].m_price);
            }
            else
            {
                sc.UnlockCode(list_armor_S[itemIndex].m_code);
                capital.MinusMoney(list_armor_S[itemIndex].m_price);
            }
        }
        else
        {
            sc.UnlockCode(list_skill_S[itemIndex].m_code);
            capital.MinusCrystal(list_skill_S[itemIndex].m_price);
        }

    }


    public void StoreAnimationStart()
    {
        isClick = !isClick;
        if (isClick)
        {
            slideStoreAnimator.SetBool("isOpen", true);
        }
        else
        {
            slideStoreAnimator.SetBool("isOpen", false);
        }

    }
}
