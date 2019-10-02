using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_AttackEffects : MonoBehaviour
{
    public int myDamege;        //Boss가 소환할 때 설정함

    void Start()
    {
        Invoke("ColliderSetEnable", 1.5f);
    }

    public void ColliderSetEnable()
    {
        CircleCollider2D coll = GetComponent<CircleCollider2D>();
        coll.enabled = !coll.enabled;   //보임

        Destroy(this.gameObject, 0.8f);
    }
}
