using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroppedGold : MonoBehaviour
{
    public int GoldAmount;                                      //드랍 골드량
    bool isGet = false;                                         //플레이어가 돈을 주웠는가?

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && isGet == false)
        {
            isGet = true;
                                                                //Player에게 닿을 시 Collider를 끈다. (혹시 모를 버그와 중복 방지)
            this.GetComponent<BoxCollider2D>().enabled = false;
                                                                //이펙트를 내뿜는다, 천천히 사라진다, Gold가 적립된다.
            Animator ani = this.GetComponent<Animator>();
            ani.SetBool("isGet", isGet);
            
                                                                //Capital(자본을 관리하는 은행)에 돈을 넣는다.
            collision.gameObject.GetComponent<Capital>().PlusMoney(GoldAmount);
        }

        //UnlockClass 필요함.
    }

    public void Dead()                                          //사라지는 애니메이션 끝나고 실행 시켜야해요!
    {
        Destroy(this.gameObject);
    }
}
