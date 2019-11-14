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

        private void Start()
        {
            sr = GetComponent<SpriteRenderer>();
            rigid = GetComponent<Rigidbody2D>();

            rigid.velocity = new Vector2(speed, 0f);
            sr.flipX = (speed < 0f) ? true : false;
        }
    }
}

