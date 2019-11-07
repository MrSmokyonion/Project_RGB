using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    [Header("Nearby NPC")] //가까이 있는 상호작용 NPC
    public GameObject Interactive;

    [Header("Attack Variable")] //공격 관련 변수들
    public Transform attack_pos;
    public Vector2 attack_range;

    [Header("Status")] //플레이어의 스탯
    public int maxHp;
    public int curHp;
    public int foodBonusHp;

    [Space(10)]
    public int power;
    public int defence;
    public float range;

    [Header("etc")]
    public GameObject projectile;
    public ControlManager cm;
    public StatusChanger changer;

    //스킬 변수
    public Skill_Red red;
    public Skill_Green green;
    public Skill_Blue blue;

    //장비 변수
    public Base_Weapon weapon;
    public Armor_Amulet amulet;
    public Armor_Stone stone;

    public BaseFood food;

    //쿨타임 변수들
    private float d_weapon;
    private float d_red;
    private float d_green;
    private float d_blue;


    #region Init
    private void Start()
    {
        PlayerPrefs.SetString("UserCode", "#9a1d002a");

        changer.ChangeSkill(SpawnCode.R001, this);
        changer.ChangeSkill(SpawnCode.G001, this);
        changer.ChangeSkill(SpawnCode.B001, this);
        changer.ChangeWeapon(SpawnCode.W201, this);
        changer.ChangeArmor(SpawnCode.A001, this);
        changer.ChangeArmor(SpawnCode.S001, this);
    }

    public void Init_Weapon()
    {
        if (weapon is Weapon_Sword)
        {
            range = 0.5f;
            attack_range = new Vector2(1f, 1f);
            cm.SetAttackUI(0);
        }
        if (weapon is Weapon_Spear)
        {
            range = 0.3f;
            attack_range = new Vector2(2f, 0.5f);
            cm.SetAttackUI(1);
            projectile.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = Resources.Load(weapon.spritePath, typeof(Sprite)) as Sprite;
        }
        if (weapon is Weapon_Bow)
        {
            range = 0.1f;
            attack_range = new Vector2(1f, 1f);
            cm.SetAttackUI(2);
        }
        power = weapon.power;
    }
    public void Init_Skill()
    {
        d_weapon = d_red = d_green = d_blue = 0.0f;
    }
    public void Init_HpDefence()
    {
        maxHp = 100;
        curHp = maxHp;
        defence = 1;
    }
    public void Init_Food()
    {
        foodBonusHp = food.foodBonusHp;
    }

    public void Init_AllData(string[] data)
    {
        for(int i = 0; i<data.Length; i++)
        {
            string[] str = data[i].Split('&');
            string[] str2 = str[0].Split('!');

            switch(i)
            {
                case 0: maxHp = int.Parse(str[0]); break;
                case 1: power = int.Parse(str[0]); break;
                case 2: defence = int.Parse(str[0]); break;
                        
                case 3:
                    for (int j = 1; j < str2.Length; j++)
                    {
                        if (str2[j] == "false") continue;

                        string tmp = "R" + "00" + j.ToString();
                        changer.UnlockCode((SpawnCode)Enum.Parse(typeof(SpawnCode), tmp));
                    }

                    if (str2[0] == "none") red = null;
                    else changer.ChangeSkill((SpawnCode)Enum.Parse(typeof(SpawnCode), str2[0].ToUpper()), this);
                        break;
                case 4:
                    for (int j = 1; j < str2.Length; j++)
                    {
                        if (str2[j] == "false") continue;

                        string tmp = "G" + "00" + j.ToString();
                        changer.UnlockCode((SpawnCode)Enum.Parse(typeof(SpawnCode), tmp));
                    }

                    if (str2[0] == "none") green = null;
                    else changer.ChangeSkill((SpawnCode)Enum.Parse(typeof(SpawnCode), str2[0].ToUpper()), this);
                    break;
                case 5:
                    for (int j = 1; j < str2.Length; j++)
                    {
                        if (str2[j] == "false") continue;

                        string tmp = "B" + "00" + j.ToString();
                        changer.UnlockCode((SpawnCode)Enum.Parse(typeof(SpawnCode), tmp));
                    }

                    if (str2[0] == "none") blue = null;
                    else changer.ChangeSkill((SpawnCode)Enum.Parse(typeof(SpawnCode), str2[0].ToUpper()), this);
                    break;

                case 6:
                    //이부분은 다시 상의할 필요가 있어보임
                    for (int j = 1; j < str.Length; j++)
                    {
                        str2 = str[j].Split('!');
                        for(int k = 0; k < str2.Length; k = k + 2)
                        {
                            if (str2[k] == "false") continue;

                            string tmp = "W" + (j - 1).ToString() + "0" + (k + 1).ToString();
                            changer.UnlockCode((SpawnCode)Enum.Parse(typeof(SpawnCode), tmp));
                        }
                    }
                    changer.ChangeWeapon((SpawnCode)Enum.Parse(typeof(SpawnCode), str[0].ToUpper()), this);
                    break;
                case 7:
                    for (int j = 1; j < str2.Length; j++)
                    {
                        if (str2[j] == "false") continue;

                        string tmp = "A" + "00" + j.ToString();
                        changer.UnlockCode((SpawnCode)Enum.Parse(typeof(SpawnCode), tmp));
                    }

                    if (str2[0] == "none") amulet = null;
                    else changer.ChangeArmor((SpawnCode)Enum.Parse(typeof(SpawnCode), str2[0].ToUpper()), this);
                    break;
                case 8:
                    for (int j = 1; j < str2.Length; j++)
                    {
                        if (str2[j] == "false") continue;

                        string tmp = "S" + "00" + j.ToString();
                        changer.UnlockCode((SpawnCode)Enum.Parse(typeof(SpawnCode), tmp));
                    }

                    if (str2[0] == "none") stone = null;
                    else changer.ChangeArmor((SpawnCode)Enum.Parse(typeof(SpawnCode), str2[0].ToUpper()), this);
                    break;
            }
        }
    }
    #endregion

    #region Delay (Weapon, Skills)
    private void Update()
    {
        d_weapon -= Time.deltaTime;
        d_red -= Time.deltaTime;
        d_green -= Time.deltaTime;
        d_blue -= Time.deltaTime;
    }

    //스킬 쿨타임. 사용가능시 true 반환.
    private bool IsSkillDelay(SkillState ss)
    {
        switch (ss)
        {
            case SkillState.Red: if (d_red <= 0.0f) return true; break;
            case SkillState.Green: if (d_green <= 0.0f) return true; break;
            case SkillState.Blue: if (d_blue <= 0.0f) return true; break;
        }
        return false;
    }
    private bool IsAttackDelay()
    {
        if (d_weapon <= 0.0f) return true;
        return false;
    }
    #endregion

    #region Attack <==> Interact
    public void Attack() //근접 공격 함수
    {
        if (IsAttackDelay() == false) return;
        Debug.Log(weapon.title + " 공격!");
        d_weapon = weapon.delay;

        Collider2D[] collider2Ds = Physics2D.OverlapBoxAll(attack_pos.position, attack_range, 0);
        for (int i = 0; i < collider2Ds.Length; i++)
        {
            if (collider2Ds[i].tag == "Monster")
            {
                Debug.Log("Monster Hit!");
                GameObject obj = collider2Ds[i].gameObject;

                //Monster 넉백
                int dirt = (obj.transform.position.x - transform.position.x > 0) ? 1 : -1;
                obj.GetComponent<Rigidbody2D>().AddForce(new Vector2(dirt, 1) * 7, ForceMode2D.Impulse);
            }
        }
    }
    public void Attack(float angle, Vector2 dir) //원거리 공격 함수
    {
        if (IsAttackDelay() == false) return;
        Debug.Log(weapon.title + " 공격!");
        d_weapon = weapon.delay;

        GameObject obj = Instantiate(projectile, attack_pos.position, Quaternion.Euler(0f, 0f, angle));

        Arrow ar = obj.GetComponent<Arrow>();
        ar.power = weapon.power;
        ar.spritePath = weapon.spritePath;

        Rigidbody2D rid = obj.GetComponent<Rigidbody2D>();
        if (weapon is Weapon_Spear)
        {
            rid.bodyType = RigidbodyType2D.Kinematic;
            rid.velocity = dir * ((Weapon_Spear)weapon).speed;
            ar.destroyDelay = 1.0f;
        }
        else if (weapon is Weapon_Bow)
        {
            dir += new Vector2(0f, 0.2f);
            rid.bodyType = RigidbodyType2D.Dynamic;
            rid.velocity = dir * ((Weapon_Bow)weapon).speed;
        }
    }

    public void Interact()
    {
        Debug.Log(Interactive.name + " Interact!");

        if (Interactive.tag == "TeleportDoor")
        {
            TeleportDoor terpoDoor = Interactive.GetComponent<TeleportDoor>();
            terpoDoor.PlayerGoToNextDoor(this.gameObject);
        }
    }
    #endregion

    #region Skill
    public void ActiveSkill(SkillState ss)
    {
        if (IsSkillDelay(ss) == false) return;

        switch (ss)
        {
            case SkillState.Red: red.ExecuteSkill(gameObject); d_red = red.delay; break;
            case SkillState.Green: green.ExecuteSkill(gameObject); d_green = green.delay; break;
            case SkillState.Blue: blue.ExecuteSkill(gameObject); d_blue = blue.delay; break;
        }
    }

    #endregion


    #region WhenPlayerGetHit
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Monster")
        {
            GameObject obj = collision.gameObject;
            OnDamaged(obj.transform.position, 10); //해당 몬스터의 파워가 여기 들어가야함.
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Monster")
        {
            GameObject obj = collision.gameObject;
            OnDamaged(obj.transform.position, 10); //해당 몬스터의 파워가 여기 들어가야함.
        }
    }

    private void OnDamaged(Vector2 targetpos, int damage)
    {
        //HP
        damage -= defence;
        if (damage <= 0) damage = 1;
        if (foodBonusHp > 0)
        {
            foodBonusHp -= damage;
            if (foodBonusHp >= 0) damage = 0;
            else if (foodBonusHp < 0) damage = -1 * foodBonusHp;
        }
        curHp -= damage;
        if (curHp <= 0) Dead();

        //Invisible
        gameObject.layer = 12;
        StartCoroutine(DisableInvisible());

        //Knock-Back
        GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 0.4f);
        int dirt = (transform.position.x - targetpos.x > 0) ? 1 : -1;
        GetComponent<Rigidbody2D>().AddForce(new Vector2(dirt, 1) * 7, ForceMode2D.Impulse);
    }

    public void Dead()
    {
        //다시 시작할 수 있도록 처리 해줘야함.
        //DeadAnimation Play
        Destroy(gameObject);
    }
    IEnumerator DisableInvisible()
    {
        yield return new WaitForSeconds(1.0f);
        gameObject.layer = 11;
        GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
    }
    #endregion

    #region Gizmo
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(attack_pos.position, attack_range);
    }
    #endregion
}
