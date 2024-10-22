﻿using System;
using UnityEngine;

namespace SkillEffect
{
    public class PiercingSpear : MonoBehaviour
    {
        public float speed;
        public int cnt = 0;
        public int power = 10;

        SpriteRenderer sr;
        Rigidbody2D rigid;
        SoundManager sound;

        GameObject[] enemyCnt = new GameObject[5]; // 이 문장 어색함 수정 필요.


        private void Start()
        {
            sr = GetComponent<SpriteRenderer>();
            rigid = GetComponent<Rigidbody2D>();

            rigid.velocity = new Vector2(speed * 2.8f, 0f);
            sr.flipX = (speed * 2.8f < 0f) ? true : false;

            sound = FindObjectOfType<SoundManager>();
            sound.Play("skill_piercingSpear");
            FindObjectOfType<ParticleSupplier>().SetParticle(transform.position, "skill_fire");
            Destroy(gameObject,1.3f);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (Array.Find(enemyCnt, obj => obj == collision.gameObject) != null)
                return;

            if (collision.gameObject.tag == "Monster")
            {
                enemyCnt[cnt++] = collision.gameObject;
                FindObjectOfType<ParticleSupplier>().SetParticle(collision.gameObject.transform.position, "skill_hit");
                //collision.gameObject.GetComponent<MonsterParent>().MonsterHitWeapon(50);

                if (cnt >= 5)
                    Destroy(gameObject);
            }
        }
    }
}

