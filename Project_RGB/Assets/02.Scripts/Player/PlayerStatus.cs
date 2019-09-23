using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    [Header("Nearby NPC")]
    public GameObject Interactive;

    [Header("Attack Variable")]
    public Transform attack_pos;
    public Vector2 attack_range;

    private RedSkill red;
    private GreenSkill green;
    private BlueSkill blue;

    private BaseWeapon weapon;
    //방어구변수

    [Header("Status")]
    public int power;
    public int defence;
    public int hp;
    public float range;


    private void Start()
    {
        hp = 3;
        range = 0.5f;
        ChangeWeapon(401);
        ChangeSkill(201);
    }

    #region Attack <==> Interact
    public void Attack()
    {
        Debug.Log(weapon.weaponName + " 공격!");
        Collider2D[] collider2Ds = Physics2D.OverlapBoxAll(attack_pos.position, attack_range, 0);
        for(int i = 0; i<collider2Ds.Length; i++)
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
        switch (ss)
        {
            case SkillState.Red: red.ExecuteSkill(gameObject); break;
            case SkillState.Green: green.ExecuteSkill(gameObject); break;
            case SkillState.Blue: blue.ExecuteSkill(gameObject); break;
        }
        return;
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
