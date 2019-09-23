using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroppedGold : MonoBehaviour
{
    public int GoldAmount;  //드랍 골드량
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Player에게 닿을 시 이펙트를 내뿜는다, 천천히 사라진다, Gold가 적립된다.
    }
}
