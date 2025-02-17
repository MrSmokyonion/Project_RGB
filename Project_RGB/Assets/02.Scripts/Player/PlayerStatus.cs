﻿using System;
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

    [Header("Load Out")]
    public GameObject skill;
    public GameObject weapon;
    public GameObject armor;
    public GameObject food;

    [Header("etc")]
    public GameObject projectile;
    public ControlManager cm;
    public StatusChanger changer;
    public SkillEffect.SkillCollector skillCollector;


    //쿨타임 변수들
    private float d_weapon;
    private float d_red;
    private float d_green;
    private float d_blue;

    #region Init
    private void Awake()
    {
        //PlayerPrefs.SetString("UserCode", "#9a1d002a");

        changer.ChangeSkill(SpawnCode.R001, gameObject, skill);
        changer.ChangeSkill(SpawnCode.G001, gameObject, skill);
        changer.ChangeSkill(SpawnCode.B001, gameObject, skill);
        changer.ChangeWeapon(SpawnCode.W201, gameObject, weapon);
        changer.ChangeArmor(SpawnCode.A001, gameObject, armor);
        changer.ChangeArmor(SpawnCode.S001, gameObject, armor);
        Debug.Log(skill.GetComponent<Skill_Red>());

    }

    public void Init_Weapon()
    {
        Base_Weapon _Weapon = weapon.GetComponent<Base_Weapon>();

        if (_Weapon is Weapon_Sword)
        {
            range = 0.5f;
            attack_range = new Vector2(3.5f, 1.5f);
            cm.SetAttackUI(0);
        }
        if (_Weapon is Weapon_Spear)
        {
            range = 0.5f;
            attack_range = new Vector2(5f, 0.5f);
            cm.SetAttackUI(1);
            //projectile.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = Resources.Load(weapon.spritePath, typeof(Sprite)) as Sprite;
        }
        if (_Weapon is Weapon_Bow)
        {
            range = 0.1f;
            attack_range = new Vector2(2f, 1f);
            cm.SetAttackUI(2);
        }
        power = _Weapon.power;
    }
    public void Init_Skill()
    {
        d_weapon = d_red = d_green = d_blue = 0.0f;
    }
    public void Init_HpDefence()
    {
        maxHp = 200;
        curHp = maxHp;
        defence = 5;
    }
    public void Init_Food()
    {
        foodBonusHp = food.GetComponent<BaseFood>().m_foodBonusHp;
    }

    public void Init_AllData(string[] data)
    {
        for (int i = 0; i < data.Length; i++)
        {
            string[] str = data[i].Split('&');
            string[] str2 = str[0].Split('!');

            switch (i)
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

                    if (str2[0] == "none") break;
                    else changer.ChangeSkill((SpawnCode)Enum.Parse(typeof(SpawnCode), str2[0].ToUpper()), gameObject, skill);
                    break;
                case 4:
                    for (int j = 1; j < str2.Length; j++)
                    {
                        if (str2[j] == "false") continue;

                        string tmp = "G" + "00" + j.ToString();
                        changer.UnlockCode((SpawnCode)Enum.Parse(typeof(SpawnCode), tmp));
                    }

                    if (str2[0] == "none") break;
                    else changer.ChangeSkill((SpawnCode)Enum.Parse(typeof(SpawnCode), str2[0].ToUpper()), gameObject, skill);
                    break;
                case 5:
                    for (int j = 1; j < str2.Length; j++)
                    {
                        if (str2[j] == "false") continue;

                        string tmp = "B" + "00" + j.ToString();
                        changer.UnlockCode((SpawnCode)Enum.Parse(typeof(SpawnCode), tmp));
                    }

                    if (str2[0] == "none") break;
                    else changer.ChangeSkill((SpawnCode)Enum.Parse(typeof(SpawnCode), str2[0].ToUpper()), gameObject, skill);
                    break;

                case 6:
                    //이부분은 다시 상의할 필요가 있어보임
                    for (int j = 1; j < str.Length; j++)
                    {
                        str2 = str[j].Split('!');
                        for (int k = 0; k < str2.Length; k = k + 2)
                        {
                            if (str2[k] == "false") continue;

                            string tmp = "W" + (j - 1).ToString() + "0" + (k + 1).ToString();
                            changer.UnlockCode((SpawnCode)Enum.Parse(typeof(SpawnCode), tmp));
                        }
                    }
                    changer.ChangeWeapon((SpawnCode)Enum.Parse(typeof(SpawnCode), str[0].ToUpper()), gameObject, skill);
                    break;
                case 7:
                    for (int j = 1; j < str2.Length; j++)
                    {
                        if (str2[j] == "false") continue;

                        string tmp = "A" + "00" + j.ToString();
                        changer.UnlockCode((SpawnCode)Enum.Parse(typeof(SpawnCode), tmp));
                    }

                    if (str2[0] == "none") break;
                    else changer.ChangeArmor((SpawnCode)Enum.Parse(typeof(SpawnCode), str2[0].ToUpper()), gameObject, skill);
                    break;
                case 8:
                    for (int j = 1; j < str2.Length; j++)
                    {
                        if (str2[j] == "false") continue;

                        string tmp = "S" + "00" + j.ToString();
                        changer.UnlockCode((SpawnCode)Enum.Parse(typeof(SpawnCode), tmp));
                    }

                    if (str2[0] == "none") break;
                    else changer.ChangeArmor((SpawnCode)Enum.Parse(typeof(SpawnCode), str2[0].ToUpper()), gameObject, skill);
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
        Base_Weapon _weapon = weapon.GetComponent<Base_Weapon>();

        if (IsAttackDelay() == false) return;
        Debug.Log(_weapon.m_title + " 공격!");
        d_weapon = _weapon.delay;

        SoundManager soundManager = FindObjectOfType<SoundManager>();
        string soundStr = checkWeaponSound(_weapon);
        soundManager.Play(soundStr + "attack");

        Collider2D[] collider2Ds = Physics2D.OverlapBoxAll(attack_pos.position, attack_range, 0);
        for (int i = 0; i < collider2Ds.Length; i++)
        {
            if (collider2Ds[i].tag == "Monster")
            {
                //Debug.Log("Monster Hit!");
                GameObject obj = collider2Ds[i].gameObject;

                //Monster 데미지 처리
                if (obj.GetComponent<MonsterParent>().myMonsterInfo.monsterState != MonsterState.DEAD)
                {
                    obj.GetComponent<MonsterParent>().MonsterHitWeapon(power);

                    soundManager.Play(soundStr + "hit");
                    FindObjectOfType<ParticleSupplier>().SetParticle(obj.gameObject.transform.position, "enemy_hit");
                }
            }
        }
    }
    public void Attack(float angle, Vector2 dir) //원거리 공격 함수
    {
        Base_Weapon _weapon = weapon.GetComponent<Base_Weapon>();

        if (IsAttackDelay() == false) return;
        Debug.Log(_weapon.m_title + " 공격!");
        d_weapon = _weapon.delay;

        SoundManager soundManager = FindObjectOfType<SoundManager>();
        string soundStr = checkWeaponSound(_weapon);
        soundManager.Play(soundStr + "attack");

        GameObject obj = Instantiate(projectile, attack_pos.position, Quaternion.Euler(0f, 0f, angle));

        Arrow ar = obj.GetComponent<Arrow>();
        ar.power = _weapon.power;
        ar.spritePath = _weapon.m_spritePath;

        Rigidbody2D rid = obj.GetComponent<Rigidbody2D>();
        if (_weapon is Weapon_Spear)
        {
            rid.bodyType = RigidbodyType2D.Kinematic;
            rid.velocity = dir * ((Weapon_Spear)_weapon).speed;
            ar.destroyDelay = 1.0f;
        }
        else if (_weapon is Weapon_Bow)
        {
            dir += new Vector2(0f, 0.2f);
            rid.bodyType = RigidbodyType2D.Dynamic;
            rid.velocity = dir * ((Weapon_Bow)_weapon).speed;
        }
    }

    public void Interact()
    {
        Debug.Log(Interactive.name + " Interact!");

        if (Interactive.tag == "TeleportDoor")
        {
            Debug.Log("텔레포트!!!1");
            TeleportDoor terpoDoor = Interactive.GetComponent<TeleportDoor>();
            terpoDoor.PlayerInteractWithDoor();
        }
        else if (Interactive.tag == "NPC")
        {
            NPCClick clickNPC = Interactive.GetComponent<NPCClick>();
            clickNPC.NpcClick();
        }
    }

    private string checkWeaponSound(Base_Weapon weapon)
    {
        if (weapon is Weapon_Sword)
            return "sword_";
        else if (weapon is Weapon_Spear)
            return "spear_";
        else if (weapon is Weapon_Bow)
            return "bow_";
        else
            return "error";
    }
    #endregion

    #region Skill
    public void ActiveSkill(SkillState ss)
    {
        if (IsSkillDelay(ss) == false) return;

        Base_Skill bs;
        switch (ss)
        {
            case SkillState.Red:
                bs = skill.GetComponent<Skill_Red>();
                d_red = bs.m_delay;
                break;

            case SkillState.Green:
                bs = skill.GetComponent<Skill_Green>();
                d_green = bs.m_delay;
                break;

            case SkillState.Blue:
                bs = skill.GetComponent<Skill_Blue>();
                d_blue = bs.m_delay;
                break;

            default: return;
        }
        bs.ExecuteSkill(gameObject);
    }

    #endregion


    #region WhenPlayerGetHit
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Monster")
        {
            FindObjectOfType<SoundManager>().Play("default_hurt");
            FindObjectOfType<ParticleSupplier>().SetParticle(transform.position, "player_hit");

            GameObject obj = collision.gameObject;
            OnDamaged(obj.transform.position, obj.GetComponent<MonsterParent>().myMonsterInfo.monsterDamage);  //해당 몬스터의 파워가 여기 들어가야함.
            OnDamaged(obj.transform.position, 0);  //해당 몬스터의 파워가 여기 들어가야함.
        }
        if (collision.gameObject.tag == "DropGold")  //Gold Or Crystal
        {
            FindObjectOfType<SoundManager>().Play("default_getCapital");

            DroppedGoldOrCrystal dropGOC = collision.gameObject.GetComponent<DroppedGoldOrCrystal>();
            if (!dropGOC.isGet)
            {
                //Capital(자본을 관리하는 은행)에 돈을 넣는다.
                dropGOC.GetMoneyOrCrystal();
                if (!dropGOC.isCrystal)
                {
                    GetComponent<Capital>().PlusMoney(dropGOC.GoldAmount);
                }
                else
                {
                    GetComponent<Capital>().PlusCrystal(dropGOC.GoldAmount / 10);   //100골드 = 10크리스탈..
                }
            }
        }
        if (collision.gameObject.tag == "Item")
        {
            FindObjectOfType<SoundManager>().Play("default_getItem");

            //아이템 획득 후 처리
            DroppedItem dropIS = collision.gameObject.GetComponent<DroppedItem>();
            dropIS.GetItem();
            changer.UnlockCode(dropIS.dropItemCode);
            //NoticeTextUI 에게 알려야함.
            //아이템 먹었다고 자랑해야함
            NoticeTextUI noticeUI = GameObject.Find("NoticeTextBackground").transform.GetChild(0).GetComponent<NoticeTextUI>();
            noticeUI.ItemEat("야매로 만듬.여기에 획득 아이템잉름 들어가야함");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("부모의 콜라이더가 실행됬다구 젠자ㅏㅏㅏㅏㅇ5252믿고있었다고!!1");
        if (collision.gameObject.tag == "Monster")
        {
            FindObjectOfType<SoundManager>().Play("default_hurt");

            GameObject obj = collision.gameObject;
            OnDamaged(obj.transform.position, obj.GetComponent<MonsterParent>().myMonsterInfo.monsterDamage); //해당 몬스터의 파워가 여기 들어가야함.
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
        GetComponent<Rigidbody2D>().AddForce(new Vector2(dirt, 1) * 3, ForceMode2D.Impulse);
        GetComponent<Animator>().SetBool("isHit", true);
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
        GetComponent<Animator>().SetBool("isHit", false);
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
