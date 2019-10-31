using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Green_HighJump : Skill_Green //201
{
    public Skill_Green_HighJump()
    {
        title = "하이 점프";
        code = SpawnCode.G001;
        spritePath = "";


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
