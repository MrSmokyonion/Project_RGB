using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public GameObject test;

    private int power;
    private int defence;
    private int hp;
    private float moveSpeed;
    //무기변수
    //방어구변수
    
    public void Attack()
    {
        GameObject tmp = Instantiate(test, gameObject.transform);
        tmp.transform.position += new Vector3(0.5f, 0.0f, 0.0f);
    }
}
