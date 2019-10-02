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
    public GameObject arrow;

    //스킬 변수
    private Skill_Red red;
    private Skill_Green green;
    private Skill_Blue blue;

    //장비 변수
    private Base_Weapon weapon;
    private Armor_Amulet amulet;
    private Armor_Stone stone;

    private BaseFood food;

    //쿨타임 변수들
    private float d_weapon;
    private float d_red;
    private float d_green;
    private float d_blue;

    #region Init
    private void Start()
    {
        ChangeSkill(SpawnCode.G001);
        ChangeWeapon(SpawnCode.W201);
        ChangeArmor(SpawnCode.A001);
        ChangeArmor(SpawnCode.S001);
        ChangeFood(SpawnCode.F001);

        Init();
    }

    private void Init()
    {
        //초기화 앞서 장착한 장비, 스킬들 확인 작업
        //1. 무기 종류에 따른 사거리 지정
        Init_Weapon();

        //2. 장비 종류의 효과를 플레이어 스탯에 적용
        Init_HpDefence();

        //3. 음식 시너지 적용
        Init_Food();

        //초기화 부분
        d_weapon = d_red = d_green = d_blue = 0.0f;
    }

    private void Init_Weapon()
    {
        power = 1;
        if (weapon is Weapon_Sword)
        {
            range = 0.5f;
            attack_range = new Vector2(1f, 1f);
            Weapon_Sword w = (Weapon_Sword)weapon;
            power = w.power;
        }
        if (weapon is Weapon_Spear)
        {
            range = 0.3f;
            attack_range = new Vector2(2f, 0.5f);
            Weapon_Spear w = (Weapon_Spear)weapon;
            power = w.power;
        }
        if (weapon is Weapon_Bow)
        {
            range = 0.1f;
            attack_range = new Vector2(1f, 1f);
            Weapon_Bow w = (Weapon_Bow)weapon;
            power = w.power;
        }
    }
    private void Init_HpDefence()
    {
        maxHp = 100;
        maxHp += amulet.hp;
        curHp = maxHp;
        foodBonusHp = 0;
        defence = 1;
        defence = stone.defence;
    }
    private void Init_Food()
    {
        if (food == null) return;
        foodBonusHp = food.foodBonusHp;
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
        Debug.Log(weapon.weaponName + " 공격!");
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
        Debug.Log(weapon.weaponName + " 공격!");
        d_weapon = weapon.delay;

        Weapon_Bow bow = (Weapon_Bow)weapon;

        dir += new Vector2(0f, 0.25f);
        GameObject obj = Instantiate(arrow, attack_pos.position, Quaternion.Euler(0f, 0f, angle));
        obj.GetComponent<Rigidbody2D>().velocity = dir * bow.speed;

        Arrow ar = obj.GetComponent<Arrow>();
        ar.power = bow.power;
    }

    public void Interact()
    {
        Debug.Log(Interactive.name + " Interact!");
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

    #region Change Method
    public void ChangeSkill(SpawnCode code)
    {
        string what = (code.ToString().Substring(0, 1));

        switch (what)
        {
            case "R": red = SpawnClass.GetSkill_Red(code); break;
            case "G": green = SpawnClass.GetSkill_Green(code); break;
            case "B": blue = SpawnClass.GetSkill_Blue(code); break;
            default: return;
        }
    }

    public void ChangeWeapon(SpawnCode code)
    {
        string what = (code.ToString().Substring(0, 2));

        switch (what)
        {
            case "W0": weapon = SpawnClass.GetWeapon_Sword(code); break;
            case "W1": weapon = SpawnClass.GetWeapon_Spear(code); break;
            case "W2": weapon = SpawnClass.GetWeapon_Bow(code); break;
            default: return;
        }
    }

    public void ChangeArmor(SpawnCode code)
    {
        string what = (code.ToString().Substring(0, 1));

        switch (what)
        {
            case "A": amulet = SpawnClass.GetArmor_Amulet(code); break;
            case "S": stone = SpawnClass.GetArmor_Stone(code); break;
            default: return;
        }
    }

    public void ChangeFood(SpawnCode code)
    {
        string what = (code.ToString().Substring(0, 1));

        switch (what)
        {
            case "F": food = SpawnClass.GetFood(code); break;
            default: return;
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
        if (curHp <= 0) Destroy(gameObject);

        //Invisible
        gameObject.layer = 12;
        StartCoroutine(DisableInvisible());

        //Knock-Back
        GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 0.4f);
        int dirt = (transform.position.x - targetpos.x > 0) ? 1 : -1;
        GetComponent<Rigidbody2D>().AddForce(new Vector2(dirt, 1) * 7, ForceMode2D.Impulse);
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
