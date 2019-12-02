using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroppedItem : MonoBehaviour
{
    public SpawnCode dropItemCode = SpawnCode.NONE;
    public bool isGet = false;                                         //플레이어가 아이템을 주웠는가?(중복 방지용)


    public void GetMoneyOrCrystal()
    {
        isGet = true;
        //Player에게 닿을 시 Collider를 끈다. (혹시 모를 버그와 중복 방지)
        this.GetComponent<BoxCollider2D>().enabled = false;
        //이펙트를 내뿜는다, 천천히 사라진다, Gold가 적립된다.
        Animator ani = this.GetComponent<Animator>();
        ani.SetBool("isGet", isGet);
    }

    public void Dead()                                          //사라지는 애니메이션 끝나고 실행 시켜야해요! (animator)
    {
        Destroy(this.gameObject);
    }
}
