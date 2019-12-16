using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadLine : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //죽은 처리 해줘야함. (마을로 이동)
            PlayerStatus ps = collision.gameObject.GetComponent<PlayerStatus>();
            ps.Dead();
        }
        else if(collision.gameObject.tag == "Monster")
        {
            //죽은 처리 해줘야함. (문이 열릴 수 있어야함..)
            MonsterParent mp = collision.gameObject.GetComponent<MonsterParent>();
            mp.Dead();
        }
        else
        {
            //그 외는 그냥 삭제.
            Destroy(collision.gameObject);
        }
    }
}
