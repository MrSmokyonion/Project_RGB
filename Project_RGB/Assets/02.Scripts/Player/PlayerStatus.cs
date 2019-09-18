using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public GameObject test;

    private RedSkill red;
    private GreenSkill green;
    private BlueSkill blue;

    private int power;
    private int defence;
    private int hp;
    //무기변수
    //방어구변수

    private void Start()
    {
        hp = 3;
        ChangeSkill(201);
    }

    public void Attack()
    {
        GameObject tmp = Instantiate(test, gameObject.transform);
        tmp.transform.position += new Vector3(0.5f, 0.0f, 0.0f);
    }

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
        
        switch(what)
        {
            case 1: red = SkillList.GetSkill_Red(skillcode); break;
            case 2: green = SkillList.GetSkill_Green(skillcode); break;
            case 3: blue = SkillList.GetSkill_Blue(skillcode); break;
            default: return;
        }
    }

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
}
