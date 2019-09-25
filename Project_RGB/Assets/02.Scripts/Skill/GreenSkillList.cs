using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class G_HighJump : GreenSkill //201
{
    public G_HighJump()
    {
        power = 20;
        delay = 2f;
    }

    public override void ExecuteSkill(GameObject obj)
    {
        Debug.Log("Green Skill -> HighJump!");
        Rigidbody2D rigid = obj.GetComponent<Rigidbody2D>();
        rigid.AddForce(Vector2.up * power, ForceMode2D.Impulse);
    }
}
