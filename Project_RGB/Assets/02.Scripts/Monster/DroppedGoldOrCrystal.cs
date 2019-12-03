using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroppedGoldOrCrystal : MonoBehaviour
{
    public int GoldAmount = -2;                                 //드랍 골드량 / -2 Error
    public bool isCrystal = false;                                     //골드인지 스킬파편(Crystal)인지 확인
    public bool isGet = false;                                         //플레이어가 돈을 주웠는가?(중복 방지용)
    public Sprite CrystalSprite;                                //(inspector) 오브젝트 DefaultSprite : GoldSprite

    /*
     * Capital에 돈 넣는 법.
     * Player가 돈 Tag를 체크.
     * Player가 미리 연결되어있던 public Capital에 PlusMoney를 요청.
     * (Capital은 빈 GameObject에 이미 만들어져 있음.)
     * 입금 완료!
     */

    public void ChangeToCrystal()
    {
        isCrystal = true;
        SpriteRenderer mySR = GetComponent<SpriteRenderer>();
        mySR.sprite = CrystalSprite;
    }

    public void GetMoneyOrCrystal()
    {
        isGet = true;

        //Player에게 닿을 시 Collider를 끄고 멈춘다. (혹시 모를 버그와 중복 방지)
        this.GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<Rigidbody2D>().gravityScale = 0;
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        GetComponent<Rigidbody2D>().angularVelocity = 0;
        //이펙트를 내뿜는다, 천천히 사라진다, Gold가 적립된다.
        Animator ani = this.GetComponent<Animator>();
        ani.SetBool("isGet", isGet);
    }

    public void Dead()                                          //사라지는 애니메이션 끝나고 실행 시켜야해요! (animator)
    {
        Destroy(this.gameObject);
    }
}
