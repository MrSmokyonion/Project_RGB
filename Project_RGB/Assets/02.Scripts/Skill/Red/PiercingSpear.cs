using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SkillEffect
{
    public class PiercingSpear : MonoBehaviour
    {
        public float speed;

        SpriteRenderer sr;
        Rigidbody2D rigid;
        SoundManager sound;

        private void Start()
        {
            sr = GetComponent<SpriteRenderer>();
            rigid = GetComponent<Rigidbody2D>();

            rigid.velocity = new Vector2(speed, 0f);
            sr.flipX = (speed < 0f) ? true : false;

            sound = FindObjectOfType<SoundManager>();
            sound.Play("skill_piercingSpear");
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if(collision.gameObject.tag == "Monster")
            {
                collision.gameObject.GetComponent<MonsterParent>().MonsterHitWeapon(50);
            }
        }
    }
}

