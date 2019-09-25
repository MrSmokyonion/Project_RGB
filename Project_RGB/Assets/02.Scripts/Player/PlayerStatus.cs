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
    public int power;
    public int defence;
    public int hp;
    public float range;

    [Header("etc")]
    public GameObject arrow;

    //스킬 변수
    private RedSkill red;
    private GreenSkill green;
    private BlueSkill blue;

    //장비 변수
    private BaseWeapon weapon;
    //방어구변수
    //방어구변수

    //쿨타임 변수들
    private float d_weapon;
    private float d_red;
    private float d_green;
    private float d_blue;

    #region Init
    private void Start()
    {
        Init();
    }

    private void Init()
    {
        ChangeWeapon(601);
        ChangeSkill(201);

        //무기 종류에 따흔 사거리 지정
        if(weapon is Weapon_Sword)
        {
            range = 0.5f;
            attack_range = new Vector2(1f, 1f);
        }
        if (weapon is Weapon_Spear)
        {
            range = 0.5f;
            attack_range = new Vector2(2f, 0.5f);
        }
        if (weapon is Weapon_Bow)
        {
            range = 0.5f;
            attack_range = new Vector2(1f, 1f);
        }

        hp = 3;
        d_weapon = d_red = d_green = d_blue = 0.0f;
    }
    #endregion

    #region Delay (Weapon, Skills)
    private void Update()
    {
        d_weapon -= Time.deltaTime;
        d_red    -= Time.deltaTime;
        d_green  -= Time.deltaTime;
        d_blue   -= Time.deltaTime;
    }

    //스킬 쿨타임. 사용가능시 true 반환.
    private bool IsSkillDelay(SkillState ss)
    {
        switch(ss)
        {
            case SkillState.Red:   if (d_red <= 0.0f)   return true; break;
            case SkillState.Green: if (d_green <= 0.0f) return true; break;
            case SkillState.Blue:  if (d_blue <= 0.0f)  return true; break;
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
    public void Attack()
    {
        if (IsAttackDelay() == false) return;
        Debug.Log(weapon.weaponName + " 공격!");
        d_weapon = weapon.delay;

        if (weapon is Weapon_Bow)
        {
            Weapon_Bow bow = (Weapon_Bow)weapon;

            bool b = GetComponent<SpriteRenderer>().flipX;
            GameObject obj = Instantiate(arrow, attack_pos.position, Quaternion.Euler(0f, 0f, (b ? 180f : 0f)));
            Arrow a = obj.GetComponent<Arrow>();

            a.speed = bow.speed;
            a.power = bow.power;
        }
        else
        {
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
    }

    public void Interact()
    {
        Debug.Log(Interactive.name + " Interact!");
    }
    public void ChangeWeapon(int weaponCode)
    {
        int what = weaponCode / 100;

        switch (what)
        {
            case 4: weapon = WeaponList.GetWeapon_Sword(weaponCode); break;
            case 5: weapon = WeaponList.GetWeapon_Spear(weaponCode); break;
            case 6: weapon = WeaponList.GetWeapon_Bow(weaponCode); break;
            default: return;
        }
    }

    #endregion

    #region Skill
    public void ActiveSkill(SkillState ss)
    {
        if (IsSkillDelay(ss) == false) return;

        switch (ss)
        {
            case SkillState.Red:   red.ExecuteSkill(gameObject);   d_red = red.delay;     break;
            case SkillState.Green: green.ExecuteSkill(gameObject); d_green = green.delay; break;
            case SkillState.Blue:  blue.ExecuteSkill(gameObject);  d_blue = blue.delay;   break;
        }
    }

    public void ChangeSkill(int skillcode)
    {
        int what = skillcode / 100;

        switch (what)
        {
            case 1: red = SkillList.GetSkill_Red(skillcode); break;
            case 2: green = SkillList.GetSkill_Green(skillcode); break;
            case 3: blue = SkillList.GetSkill_Blue(skillcode); break;
            default: return;
        }
    }

    #endregion

    #region WhenPlayerGetHit
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Monster")
            OnDamaged(collision.gameObject.transform.position);
    }

    private void OnDamaged(Vector2 targetpos)
    {
        hp--;
        if (hp <= 0) Destroy(gameObject);

        gameObject.layer = 12;
        GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 0.4f);
        int dirt = (transform.position.x - targetpos.x > 0) ? 1 : -1;
        GetComponent<Rigidbody2D>().AddForce(new Vector2(dirt, 1) * 7, ForceMode2D.Impulse);
        StartCoroutine(DisableInvisible());
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
